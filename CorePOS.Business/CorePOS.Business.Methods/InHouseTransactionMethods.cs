using System;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class InHouseTransactionMethods
{
	public static void AddTransaction(decimal amount, string reson)
	{
		GClass6 gClass = new GClass6();
		Payout entity = new Payout
		{
			Amount = amount,
			Reason = reson,
			DateCreated = DateTime.Now
		};
		gClass.Payouts.InsertOnSubmit(entity);
		gClass.SubmitChanges();
	}
}
