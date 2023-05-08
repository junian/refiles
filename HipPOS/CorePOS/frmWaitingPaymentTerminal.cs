using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
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
							if (MemoryLoadedObjects.Clover.listener.saleResponse != null && MemoryLoadedObjects.Clover.listener.saleResponse.Result.ToString() == "ERROR")
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
							if (MemoryLoadedObjects.Clover.listener.saleResponse != null)
							{
								paymentTransactionObject.rawdata = JsonConvert.SerializeObject(MemoryLoadedObjects.Clover.listener.saleResponse, Formatting.Indented, new JsonSerializerSettings
								{
									ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
									MaxDepth = 2000
								});
								PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, string_2, int_0, paymentTransactionObject.rawdata, "response", request_0.OrderNumber, string_4);
								int_1 = 0;
								if (MemoryLoadedObjects.Clover.listener.success)
								{
									if (MemoryLoadedObjects.Clover.listener.saleResponse.Payment != null)
									{
										paymentTransactionObject.approvalcode = MemoryLoadedObjects.Clover.listener.saleResponse.Payment.cardTransaction.authCode;
										paymentTransactionObject.cardaccount = MemoryLoadedObjects.Clover.listener.saleResponse.Payment.cardTransaction.last4;
										paymentTransactionObject.totalamount = (MemoryLoadedObjects.Clover.listener.saleResponse.Payment.amount + MemoryLoadedObjects.Clover.listener.saleResponse.Payment.tipAmount).ToString();
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
									paymentTransactionObject.responsecode = ((MemoryLoadedObjects.Clover.listener.saleResponse.Result.ToString() == "CANCEL") ? "555" : "51");
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
								MemoryLoadedObjects.Clover.listener.refundResponse.Message = request_0.OrderNumber;
								paymentTransactionObject.rawdata = JsonConvert.SerializeObject(MemoryLoadedObjects.Clover.listener.refundResponse, Formatting.Indented, new JsonSerializerSettings
								{
									ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
									MaxDepth = 2000
								});
								PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, string_2, int_0, paymentTransactionObject.rawdata, "response", request_0.OrderNumber, string_4);
								paymentTransactionObject.invoicenumber = request_0.OrderNumber;
								paymentTransactionObject.responsecode = (MemoryLoadedObjects.Clover.listener.success ? "00" : "51");
								paymentTransactionObject.totalamount = MemoryLoadedObjects.Clover.listener.refundResponse.Refund.amount.ToString();
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
								paymentTransactionObject.rawdata = JsonConvert.SerializeObject(MemoryLoadedObjects.Clover.listener.closeoutResponse, Formatting.Indented, new JsonSerializerSettings
								{
									ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
									MaxDepth = 2000
								});
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
		radWaitingBar1.Name = "radWaitingBar1";
		radWaitingBar1.WaitingIndicators.Add(lineRingWaitingBarIndicatorElement1);
		radWaitingBar1.WaitingSpeed = 50;
		radWaitingBar1.WaitingStyle = WaitingBarStyles.LineRing;
		((RadWaitingBarElement)radWaitingBar1.GetChildAt(0)).WaitingSpeed = 50;
		((WaitingBarContentElement)radWaitingBar1.GetChildAt(0).GetChildAt(0)).WaitingStyle = WaitingBarStyles.LineRing;
		((WaitingBarSeparatorElement)radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0)).Dash = false;
		componentResourceManager.ApplyResources(lineRingWaitingBarIndicatorElement1, "lineRingWaitingBarIndicatorElement1");
		lineRingWaitingBarIndicatorElement1.AutoSize = false;
		lineRingWaitingBarIndicatorElement1.AutoSizeMode = RadAutoSizeMode.WrapAroundChildren;
		lineRingWaitingBarIndicatorElement1.Bounds = new Rectangle(0, 0, 350, 120);
		lineRingWaitingBarIndicatorElement1.DefaultSize = new Size(0, 0);
		lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = TextRenderingHint.SystemDefault;
		lineRingWaitingBarIndicatorElement1.DrawImage = true;
		lineRingWaitingBarIndicatorElement1.ElementColor = Color.FromArgb(252, 193, 0);
		lineRingWaitingBarIndicatorElement1.ElementColor2 = Color.FromArgb(251, 211, 64);
		lineRingWaitingBarIndicatorElement1.ElementColor3 = Color.FromArgb(252, 239, 175);
		lineRingWaitingBarIndicatorElement1.ElementCount = 12;
		lineRingWaitingBarIndicatorElement1.Font = new Font("Segoe UI", 12f);
		lineRingWaitingBarIndicatorElement1.ForeColor = Color.White;
		lineRingWaitingBarIndicatorElement1.InnerRadius = 15;
		lineRingWaitingBarIndicatorElement1.LineThickness = 3.0;
		lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
		lineRingWaitingBarIndicatorElement1.NumberOfColors = 10;
		lineRingWaitingBarIndicatorElement1.Opacity = 1.0;
		lineRingWaitingBarIndicatorElement1.Radius = 30;
		lineRingWaitingBarIndicatorElement1.RotationDirection = RotationDirection.Clockwise;
		lineRingWaitingBarIndicatorElement1.ScaleTransform = new SizeF(1f, 1f);
		lineRingWaitingBarIndicatorElement1.Shape = null;
		lineRingWaitingBarIndicatorElement1.ShouldPaint = true;
		lineRingWaitingBarIndicatorElement1.SmoothingMode = SmoothingMode.HighSpeed;
		lineRingWaitingBarIndicatorElement1.TextAlignment = ContentAlignment.BottomCenter;
		lineRingWaitingBarIndicatorElement1.TextImageRelation = TextImageRelation.ImageBeforeText;
		lineRingWaitingBarIndicatorElement1.TextRenderingHint = TextRenderingHint.SystemDefault;
		lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(radWaitingBar1);
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
