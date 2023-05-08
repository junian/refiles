using System;
using System.Runtime.CompilerServices;
using com.clover.remotepay.sdk;
using com.clover.sdk.v3.payments;

namespace CorePOS.Business.Methods.PaymentProcessors;

public class CloverConnectionListener : DefaultCloverConnectorListener
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private SaleResponse saleResponse_0;

	[CompilerGenerated]
	private RefundPaymentResponse refundPaymentResponse_0;

	[CompilerGenerated]
	private RetrieveDeviceStatusResponse retrieveDeviceStatusResponse_0;

	[CompilerGenerated]
	private CloseoutResponse closeoutResponse_0;

	public bool deviceReady
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool deviceConnected
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool saleDone
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool refundDone
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool closeoutDone
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool statusCheckDone
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public string paymentId
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string orderId
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public bool success
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public SaleResponse saleResponse
	{
		[CompilerGenerated]
		get
		{
			return saleResponse_0;
		}
		[CompilerGenerated]
		set
		{
			saleResponse_0 = value;
		}
	}

	public RefundPaymentResponse refundResponse
	{
		[CompilerGenerated]
		get
		{
			return refundPaymentResponse_0;
		}
		[CompilerGenerated]
		set
		{
			refundPaymentResponse_0 = value;
		}
	}

	public RetrieveDeviceStatusResponse statusResponse
	{
		[CompilerGenerated]
		get
		{
			return retrieveDeviceStatusResponse_0;
		}
		[CompilerGenerated]
		set
		{
			retrieveDeviceStatusResponse_0 = value;
		}
	}

	public CloseoutResponse closeoutResponse
	{
		[CompilerGenerated]
		get
		{
			return closeoutResponse_0;
		}
		[CompilerGenerated]
		set
		{
			closeoutResponse_0 = value;
		}
	}

	public CloverConnectionListener(ICloverConnector cloverConnector)
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector(cloverConnector);
	}

	public override void OnDeviceReady(MerchantInfo merchantInfo)
	{
		base.OnDeviceReady(merchantInfo);
		deviceReady = true;
	}

	public override void OnDeviceConnected()
	{
		base.OnDeviceConnected();
		deviceConnected = true;
	}

	public override void OnDeviceDisconnected()
	{
		base.OnDeviceDisconnected();
		Console.WriteLine("Disconnected");
	}

	public override void OnSaleResponse(SaleResponse response)
	{
		base.OnSaleResponse(response);
		saleDone = true;
		success = response.Success;
		if (success)
		{
			paymentId = response.Payment.id;
			orderId = response.Payment.order.id;
		}
		saleResponse = response;
	}

	public override void OnConfirmPaymentRequest(ConfirmPaymentRequest request)
	{
	}

	public override void OnRefundPaymentResponse(RefundPaymentResponse response)
	{
		base.OnRefundPaymentResponse(response);
		try
		{
			if (response.Success)
			{
				Refund refund = response.Refund;
				success = true;
				refundResponse = response;
				Console.WriteLine("Refund request successful");
				Console.WriteLine(" ID: " + refund.id);
				Console.WriteLine(" Amount: " + refund.amount);
				Console.WriteLine(" Order ID: " + response.OrderId);
				Console.WriteLine(" Payment ID: " + response.PaymentId);
			}
			else
			{
				success = false;
				Console.Error.WriteLine("Refund request failed - " + response.Reason);
			}
		}
		catch
		{
			Console.Error.WriteLine("Error handling sale notification");
		}
		refundDone = true;
	}

	public override void OnRetrieveDeviceStatusResponse(RetrieveDeviceStatusResponse response)
	{
		base.OnRetrieveDeviceStatusResponse(response);
		statusResponse = response;
	}

	public override void OnCloseoutResponse(CloseoutResponse response)
	{
		base.OnCloseoutResponse(response);
		closeoutResponse = response;
		closeoutDone = true;
		success = response.Success;
	}
}
