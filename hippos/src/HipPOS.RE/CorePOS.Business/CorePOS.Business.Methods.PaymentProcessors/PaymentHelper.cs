using System;
using CorePOS.Data;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class PaymentHelper
{
	public static void RecordPaymentTransactionLog(string provider, string model, string ip, int port, string req_res_data, string transaction_type, string orderNumber, string paymentMethod)
	{
		GClass6 gClass = new GClass6();
		gClass.PaymentTerminalTransactionLogs.InsertOnSubmit(new PaymentTerminalTransactionLog
		{
			ProcessorName = provider,
			DeviceModel = model,
			IP = ip,
			Type = transaction_type,
			Data = req_res_data,
			DateCreated = DateTime.Now,
			OrderNumber = orderNumber,
			PaymentMethod = paymentMethod
		});
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static byte[] HexStringToByteArray(string hex)
	{
		if (hex.Length % 2 == 1)
		{
			throw new Exception("The binary key cannot have an odd number of digits");
		}
		byte[] array = new byte[hex.Length >> 1];
		for (int i = 0; i < hex.Length >> 1; i++)
		{
			array[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + GetHexVal(hex[(i << 1) + 1]));
		}
		return array;
	}

	public static int GetHexVal(char hex)
	{
		return hex - ((hex < ':') ? 48 : ((hex < 'a') ? 55 : 87));
	}
}
