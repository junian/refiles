using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using com.clover.remotepay.sdk;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Newtonsoft.Json;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Tests;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmWaitingPaymentTerminal : frmMasterForm
{
	[CompilerGenerated]
	private List<PaymentTransactionObject> list_2;

	private string string_0;

	private string string_1;

	private string string_2;

	private string AfgdAwAynP;

	private string string_3;

	private int int_0;

	private int int_1;

	private int ikrdNpekkf;

	private bool bool_0;

	private string string_4;

	private CloverTransactionObject.Request request_0;

	private Thread thread_0;

	private IContainer icontainer_1;

	private RadWaitingBar radWaitingBar1;

	private LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;

	private Panel panel1;

	private System.Windows.Forms.Timer timer_0;

	private MediaShape mediaShape_0;

	private ChamferedRectShape chamferedRectShape_0;

	private EllipseShape ellipseShape_0;

	internal Button btnCancel;

	public List<PaymentTransactionObject> transaction_objects
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public frmWaitingPaymentTerminal(string provider, string model, string ip, int port, string request, bool parseObject, string orderNumber, string paymentMethod)
	{
		Class26.Ggkj0JxzN9YmC();
		ikrdNpekkf = 120;
		base._002Ector();
		InitializeComponent_1();
		radWaitingBar1.StartWaiting();
		string_0 = provider;
		string_1 = model;
		string_2 = ip;
		AfgdAwAynP = request;
		int_0 = port;
		bool_0 = parseObject;
		string_3 = orderNumber;
		string_4 = paymentMethod;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Abort;
		if (transaction_objects == null)
		{
			transaction_objects = new List<PaymentTransactionObject>();
		}
		PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
		paymentTransactionObject.rawdata = HipposTransactionErrorMessages.staff_cancelled;
		transaction_objects.Add(paymentTransactionObject);
	}

	public frmWaitingPaymentTerminal(string provider, string model, string ip, int port, CloverTransactionObject.Request request, string paymentMethod)
	{
		Class26.Ggkj0JxzN9YmC();
		ikrdNpekkf = 120;
		base._002Ector();
		InitializeComponent_1();
		radWaitingBar1.StartWaiting();
		request_0 = request;
		string_0 = provider;
		string_1 = model;
		string_2 = ip;
		int_0 = port;
		string_4 = paymentMethod;
	}

	private void frmWaitingPaymentTerminal_Load(object sender, EventArgs e)
	{
		btnCancel.Visible = false;
		thread_0 = new Thread((ThreadStart)delegate
		{
			Thread.CurrentThread.IsBackground = true;
			LoadForm();
		});
		thread_0.Start();
	}

	public void LoadForm()
	{
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		try
		{
			if (string_0 == PaymentProviderNames.FirstData)
			{
				if (transaction_objects == null)
				{
					transaction_objects = new List<PaymentTransactionObject>();
				}
				PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
				if (string_1 == PaymentTerminalModels.Clover.Flex)
				{
					MemoryLoadedObjects.Clover.resetListener();
					if (request_0.RequestType == "ping")
					{
						if (MemoryLoadedObjects.Clover.connector != null)
						{
							MemoryLoadedObjects.Clover.connector = null;
						}
						MemoryLoadedObjects.Clover.pairingAuthCode = null;
						while (string.IsNullOrEmpty(MemoryLoadedObjects.Clover.pairingAuthCode))
						{
							Thread.Sleep(500);
						}
						int_1 = 0;
						paymentTransactionObject.rawdata = MemoryLoadedObjects.Clover.pairingAuthCode;
						transaction_objects.Add(paymentTransactionObject);
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						_ = MemoryLoadedObjects.Clover.connector;
						while (!MemoryLoadedObjects.Clover.listener.deviceReady)
						{
							Thread.Sleep(500);
						}
						int_1 = 0;
						while (!MemoryLoadedObjects.Clover.listener.deviceConnected)
						{
							Thread.Sleep(500);
						}
						int_1 = 0;
						FirstData.SendToClover(MemoryLoadedObjects.Clover.connector, string_2, int_0, request_0, string_4);
						paymentTransactionObject = new PaymentTransactionObject();
						if (request_0.RequestType == "sale")
						{
							while (!MemoryLoadedObjects.Clover.listener.saleDone)
							{
								Thread.Sleep(500);
							}
							ResponseCode result;
							if (MemoryLoadedObjects.Clover.listener.saleResponse != null)
							{
								result = ((BaseResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Result();
								if (((object)(ResponseCode)(ref result)).ToString() == "ERROR")
								{
									int_1 = 0;
									MemoryLoadedObjects.Clover.resetListener();
									MemoryLoadedObjects.Clover.connector = null;
									_ = MemoryLoadedObjects.Clover.connector;
									while (!MemoryLoadedObjects.Clover.listener.deviceReady)
									{
										Thread.Sleep(500);
									}
									int_1 = 0;
									while (!MemoryLoadedObjects.Clover.listener.deviceConnected)
									{
										Thread.Sleep(500);
									}
									int_1 = 0;
									FirstData.SendToClover(MemoryLoadedObjects.Clover.connector, string_2, int_0, request_0, string_4);
									while (!MemoryLoadedObjects.Clover.listener.saleDone)
									{
										Thread.Sleep(500);
									}
								}
							}
							if (MemoryLoadedObjects.Clover.listener.saleResponse != null)
							{
								PaymentTransactionObject paymentTransactionObject2 = paymentTransactionObject;
								SaleResponse saleResponse = MemoryLoadedObjects.Clover.listener.saleResponse;
								JsonSerializerSettings val = new JsonSerializerSettings();
								val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
								val.set_MaxDepth((int?)2000);
								paymentTransactionObject2.rawdata = JsonConvert.SerializeObject((object)saleResponse, (Formatting)1, val);
								PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, string_2, int_0, paymentTransactionObject.rawdata, "response", request_0.OrderNumber, string_4);
								int_1 = 0;
								if (MemoryLoadedObjects.Clover.listener.success)
								{
									if (((PaymentResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Payment() != null)
									{
										paymentTransactionObject.approvalcode = ((PaymentResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Payment().get_cardTransaction().get_authCode();
										paymentTransactionObject.cardaccount = ((PaymentResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Payment().get_cardTransaction().get_last4();
										paymentTransactionObject.totalamount = (((PaymentResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Payment().get_amount() + ((PaymentResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Payment().get_tipAmount()).ToString();
										paymentTransactionObject.responsecode = (MemoryLoadedObjects.Clover.listener.success ? "00" : "51");
										string text = FirstData.FormatCloverReceipt(request_0.RequestType, paymentTransactionObject.rawdata, request_0.OrderNumber);
										paymentTransactionObject.customerreceipt = text.Replace("###RECEIPT_RECIPIENT###", "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>CUSTOMER COPY</span>");
										paymentTransactionObject.merchantreceipt = text.Replace("###RECEIPT_RECIPIENT###", "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>MERCHANT COPY</span>");
									}
									else
									{
										paymentTransactionObject.totalamount = "0";
										paymentTransactionObject.responsecode = "56";
									}
									paymentTransactionObject.invoicenumber = request_0.OrderNumber;
									paymentTransactionObject.transaction_type = request_0.RequestType;
									MemoryLoadedObjects.Clover.listener.saleDone = false;
								}
								else if (!MemoryLoadedObjects.Clover.listener.success)
								{
									paymentTransactionObject.approvalcode = null;
									paymentTransactionObject.cardaccount = null;
									paymentTransactionObject.invoicenumber = request_0.OrderNumber;
									PaymentTransactionObject paymentTransactionObject3 = paymentTransactionObject;
									result = ((BaseResponse)MemoryLoadedObjects.Clover.listener.saleResponse).get_Result();
									paymentTransactionObject3.responsecode = ((((object)(ResponseCode)(ref result)).ToString() == "CANCEL") ? "555" : "51");
									paymentTransactionObject.totalamount = "0";
									paymentTransactionObject.transaction_type = request_0.RequestType;
									MemoryLoadedObjects.Clover.listener.saleDone = false;
								}
							}
						}
						else if (request_0.RequestType == "refund")
						{
							while (!MemoryLoadedObjects.Clover.listener.refundDone)
							{
								Thread.Sleep(500);
							}
							int_1 = 0;
							if (MemoryLoadedObjects.Clover.listener.success && MemoryLoadedObjects.Clover.listener.refundResponse != null)
							{
								((BaseResponse)MemoryLoadedObjects.Clover.listener.refundResponse).set_Message(request_0.OrderNumber);
								PaymentTransactionObject paymentTransactionObject4 = paymentTransactionObject;
								RefundPaymentResponse refundResponse = MemoryLoadedObjects.Clover.listener.refundResponse;
								JsonSerializerSettings val2 = new JsonSerializerSettings();
								val2.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
								val2.set_MaxDepth((int?)2000);
								paymentTransactionObject4.rawdata = JsonConvert.SerializeObject((object)refundResponse, (Formatting)1, val2);
								PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, string_2, int_0, paymentTransactionObject.rawdata, "response", request_0.OrderNumber, string_4);
								paymentTransactionObject.invoicenumber = request_0.OrderNumber;
								paymentTransactionObject.responsecode = (MemoryLoadedObjects.Clover.listener.success ? "00" : "51");
								paymentTransactionObject.totalamount = MemoryLoadedObjects.Clover.listener.refundResponse.get_Refund().get_amount().ToString();
								paymentTransactionObject.transaction_type = request_0.RequestType;
								string text2 = FirstData.FormatCloverReceipt(request_0.RequestType, paymentTransactionObject.rawdata, request_0.OrderNumber);
								paymentTransactionObject.customerreceipt = text2.Replace("###RECEIPT_RECIPIENT###", "<span style='text-align:center; font-size: 12pt; font-weight:bold;'>CUSTOMER COPY</span>");
								paymentTransactionObject.merchantreceipt = text2.Replace("###RECEIPT_RECIPIENT###", "<span style='text-align:center; font-size: 12pt; font-weight:bold;'>MERCHANT COPY</span>");
								MemoryLoadedObjects.Clover.listener.refundDone = false;
							}
						}
						else if (request_0.RequestType == "settlement")
						{
							while (!MemoryLoadedObjects.Clover.listener.closeoutDone)
							{
								Thread.Sleep(500);
							}
							int_1 = 0;
							if (MemoryLoadedObjects.Clover.listener.success && MemoryLoadedObjects.Clover.listener.closeoutResponse != null)
							{
								PaymentTransactionObject paymentTransactionObject5 = paymentTransactionObject;
								CloseoutResponse closeoutResponse = MemoryLoadedObjects.Clover.listener.closeoutResponse;
								JsonSerializerSettings val3 = new JsonSerializerSettings();
								val3.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
								val3.set_MaxDepth((int?)2000);
								paymentTransactionObject5.rawdata = JsonConvert.SerializeObject((object)closeoutResponse, (Formatting)1, val3);
								PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, string_2, int_0, paymentTransactionObject.rawdata, "response", request_0.OrderNumber, string_4);
								paymentTransactionObject.invoicenumber = request_0.OrderNumber;
								paymentTransactionObject.responsecode = (MemoryLoadedObjects.Clover.listener.success ? "00" : "51");
								paymentTransactionObject.transaction_type = request_0.RequestType;
							}
						}
						ikrdNpekkf = 0;
						int_1 = 0;
						base.DialogResult = DialogResult.OK;
					}
				}
				else
				{
					int_1 = 0;
					paymentTransactionObject = FirstData.SendToTerminal(string_1, string_2, int_0, AfgdAwAynP, bool_0, string_3, string_4);
					base.DialogResult = DialogResult.OK;
				}
				transaction_objects.Add(paymentTransactionObject);
			}
			else
			{
				int_1 = 0;
				transaction_objects = Ingenico.SendToTerminal(string_0, string_1, string_2, int_0, AfgdAwAynP, bool_0, string_3, string_4);
				base.DialogResult = DialogResult.OK;
			}
		}
		catch (Exception ex)
		{
			GClass6 gClass = new GClass6();
			if (transaction_objects != null)
			{
				foreach (PaymentTransactionObject transaction_object in transaction_objects)
				{
					gClass.PaymentTerminalTransactionLogs.InsertOnSubmit(new PaymentTerminalTransactionLog
					{
						ProcessorName = string_0,
						DeviceModel = string_1,
						IP = string_2,
						Type = "response-failed",
						Data = transaction_object?.rawdata,
						DateCreated = DateTime.Now,
						OrderNumber = string_3
					});
				}
			}
			else
			{
				gClass.PaymentTerminalTransactionLogs.InsertOnSubmit(new PaymentTerminalTransactionLog
				{
					ProcessorName = string_0,
					DeviceModel = string_1,
					IP = string_2,
					Type = "response-failed",
					Data = null,
					DateCreated = DateTime.Now,
					OrderNumber = string_3
				});
			}
			Helper.SubmitChangesWithCatch(gClass);
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
			base.DialogResult = DialogResult.Abort;
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		thread_0.Abort();
		base.OnClosed(e);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int_1++;
		if (transaction_objects != null && transaction_objects.Count != 0)
		{
			btnCancel.Visible = false;
		}
		else if (int_1 >= ikrdNpekkf && !Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"]))
		{
			base.DialogResult = DialogResult.Abort;
			if (transaction_objects == null)
			{
				transaction_objects = new List<PaymentTransactionObject>();
			}
			transaction_objects.Add(new PaymentTransactionObject
			{
				rawdata = "Timed Out"
			});
		}
		else if (int_1 > 10 && !Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"]))
		{
			btnCancel.Visible = true;
		}
		else
		{
			btnCancel.Visible = false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmWaitingPaymentTerminal));
		radWaitingBar1 = new RadWaitingBar();
		lineRingWaitingBarIndicatorElement1 = new LineRingWaitingBarIndicatorElement();
		panel1 = new Panel();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		mediaShape_0 = new MediaShape();
		chamferedRectShape_0 = new ChamferedRectShape();
		ellipseShape_0 = new EllipseShape();
		btnCancel = new Button();
		((ISupportInitialize)radWaitingBar1).BeginInit();
		panel1.SuspendLayout();
		SuspendLayout();
		componentResourceManager.ApplyResources(radWaitingBar1, "radWaitingBar1");
		((Control)(object)radWaitingBar1).Name = "radWaitingBar1";
		((Collection<BaseWaitingBarIndicatorElement>)(object)radWaitingBar1.get_WaitingIndicators()).Add((BaseWaitingBarIndicatorElement)(object)lineRingWaitingBarIndicatorElement1);
		radWaitingBar1.set_WaitingSpeed(50);
		radWaitingBar1.set_WaitingStyle((WaitingBarStyles)5);
		((RadWaitingBarElement)((RadControl)radWaitingBar1).GetChildAt(0)).set_WaitingSpeed(50);
		((WaitingBarContentElement)((RadControl)radWaitingBar1).GetChildAt(0).GetChildAt(0)).set_WaitingStyle((WaitingBarStyles)5);
		((WaitingBarSeparatorElement)((RadControl)radWaitingBar1).GetChildAt(0).GetChildAt(0).GetChildAt(0)).set_Dash(false);
		componentResourceManager.ApplyResources(lineRingWaitingBarIndicatorElement1, "lineRingWaitingBarIndicatorElement1");
		((RadElement)lineRingWaitingBarIndicatorElement1).set_AutoSize(false);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_AutoSizeMode((RadAutoSizeMode)1);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_Bounds(new Rectangle(0, 0, 350, 120));
		((VisualElement)lineRingWaitingBarIndicatorElement1).set_DefaultSize(new Size(0, 0));
		((LightVisualElement)lineRingWaitingBarIndicatorElement1).set_DisabledTextRenderingHint(TextRenderingHint.SystemDefault);
		((LightVisualElement)lineRingWaitingBarIndicatorElement1).set_DrawImage(true);
		((BaseWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_ElementColor(Color.FromArgb(252, 193, 0));
		((BaseWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_ElementColor2(Color.FromArgb(251, 211, 64));
		((BaseRingWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_ElementColor3(Color.FromArgb(252, 239, 175));
		((BaseWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_ElementCount(12);
		((VisualElement)lineRingWaitingBarIndicatorElement1).set_Font(new Font("Segoe UI", 12f));
		((VisualElement)lineRingWaitingBarIndicatorElement1).set_ForeColor(Color.White);
		((BaseRingWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_InnerRadius(15);
		lineRingWaitingBarIndicatorElement1.set_LineThickness(3.0);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_Name("lineRingWaitingBarIndicatorElement1");
		((UIItemBase)lineRingWaitingBarIndicatorElement1).set_NumberOfColors(10);
		((VisualElement)lineRingWaitingBarIndicatorElement1).set_Opacity(1.0);
		((BaseRingWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_Radius(30);
		((BaseRingWaitingBarIndicatorElement)lineRingWaitingBarIndicatorElement1).set_RotationDirection((RotationDirection)0);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_ScaleTransform(new SizeF(1f, 1f));
		((RadElement)lineRingWaitingBarIndicatorElement1).set_Shape((ElementShape)null);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_ShouldPaint(true);
		((VisualElement)lineRingWaitingBarIndicatorElement1).set_SmoothingMode(SmoothingMode.HighSpeed);
		((LightVisualElement)lineRingWaitingBarIndicatorElement1).set_TextAlignment(ContentAlignment.BottomCenter);
		((LightVisualElement)lineRingWaitingBarIndicatorElement1).set_TextImageRelation(TextImageRelation.ImageBeforeText);
		((LightVisualElement)lineRingWaitingBarIndicatorElement1).set_TextRenderingHint(TextRenderingHint.SystemDefault);
		((RadElement)lineRingWaitingBarIndicatorElement1).set_UseCompatibleTextRendering(false);
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add((Control)(object)radWaitingBar1);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnCancel);
		base.Controls.Add(panel1);
		base.Name = "frmWaitingPaymentTerminal";
		base.Opacity = 1.0;
		base.Load += frmWaitingPaymentTerminal_Load;
		((ISupportInitialize)radWaitingBar1).EndInit();
		panel1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void method_3()
	{
		Thread.CurrentThread.IsBackground = true;
		LoadForm();
	}
}
