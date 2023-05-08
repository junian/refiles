using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class PaymentTypeMethods
{
	public static List<ProcessorPaymentType> GetPaymentTypes(string paymentMethods)
	{
		if (string.IsNullOrEmpty(paymentMethods))
		{
			return new List<ProcessorPaymentType>();
		}
		List<ProcessorPaymentType> list = new List<ProcessorPaymentType>();
		if (!paymentMethods.Contains("SAVED ORDER") && !paymentMethods.Contains("SAVEDORDER"))
		{
			string[] array = paymentMethods.Split('|');
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					string[] array2 = text.Replace("|", string.Empty).Split('=');
					if (array2[0].Contains("CashBack"))
					{
						array2[0] = "Cash Back";
					}
					decimal amount = ((!(Thread.CurrentThread.CurrentCulture.Name == "fr-CA")) ? Convert.ToDecimal(array2[1]) : Convert.ToDecimal(array2[1].Replace(".", ",")));
					list.Add(new ProcessorPaymentType
					{
						PaymentTypeName = array2[0],
						Amount = amount
					});
				}
			}
			return list;
		}
		return list;
	}

	public static List<ProcessorPaymentType> GetTaxTypes(string paymentMethods, bool withPercentage = false)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		List<TaxPercentage> source = new List<TaxPercentage>();
		if (withPercentage)
		{
			source = (from a in new GClass6().Taxes.ToList()
				select new TaxPercentage
				{
					TaxName = a.TaxCode,
					Percentage = (a.Percentage * 100m).ToString("0.##")
				}).ToList();
		}
		List<ProcessorPaymentType> list = new List<ProcessorPaymentType>();
		string[] array = paymentMethods.Split('|');
		foreach (string text in array)
		{
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass1_1();
			CS_0024_003C_003E8__locals0.temp = text.Replace("|", string.Empty).Split(':');
			decimal num = ((!(Thread.CurrentThread.CurrentCulture.Name == "fr-CA")) ? Convert.ToDecimal(CS_0024_003C_003E8__locals0.temp[1]) : Convert.ToDecimal(CS_0024_003C_003E8__locals0.temp[1].Replace(".", ",")));
			ProcessorPaymentType processorPaymentType = list.Where((ProcessorPaymentType a) => a.PaymentTypeName == CS_0024_003C_003E8__locals0.temp[0]).FirstOrDefault();
			CS_0024_003C_003E8__locals1.paymentTypeName = CS_0024_003C_003E8__locals0.temp[0];
			if (withPercentage)
			{
				TaxPercentage taxPercentage = source.Where((TaxPercentage a) => a.TaxName.ToUpper().Trim() == CS_0024_003C_003E8__locals1.paymentTypeName.ToUpper().Trim()).FirstOrDefault();
				if (taxPercentage != null)
				{
					CS_0024_003C_003E8__locals1.paymentTypeName = CS_0024_003C_003E8__locals0.temp[0] + " " + taxPercentage.Percentage + "%";
				}
			}
			if (processorPaymentType == null)
			{
				list.Add(new ProcessorPaymentType
				{
					PaymentTypeName = CS_0024_003C_003E8__locals1.paymentTypeName,
					Amount = num
				});
			}
			else
			{
				processorPaymentType.Amount += num;
			}
		}
		return (from a in list
			group a by a.PaymentTypeName into a
			select new ProcessorPaymentType
			{
				PaymentTypeName = a.Key,
				Amount = a.Sum((ProcessorPaymentType b) => b.Amount)
			}).ToList();
	}
}
