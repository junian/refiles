using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls.UI;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace CorePOS;

public class frmOrderEntryShowItems : frmMasterForm
{
	private bool bool_0;

	private decimal decimal_0;

	private int int_0;

	private string string_0;

	private List<ImageScreen> list_2;

	private string[] string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	private int int_1;

	private int int_2;

	private int int_3;

	private IContainer icontainer_1;

	private Label lblQty;

	private Label lblExt;

	private Label lblPrice;

	private Label lblItemDesc;

	private Panel panelLogo;

	private Panel panelItems;

	internal Label lblTotal;

	public TextBox txtTotal;

	internal Label lblTotalTax;

	public TextBox txtTotalTax;

	internal Label lblSubTotal;

	public TextBox txtSubTotal;

	private Label label2;

	private Label label1;

	private System.Windows.Forms.Timer timer_0;

	private PictureBox pictureBox2;

	private PictureBox picLogo;

	internal Label label3;

	public TextBox txtDiscount;

	internal Label label4;

	public TextBox txtTotalAndGratuity;

	internal Label label5;

	public TextBox txtGratuity;

	private VlcControl myVlcControl;

	private Label label6;

	internal CustomListViewTelerik radListItemsSecond;

	private System.Windows.Forms.Timer timer_1;

	private Panel pnlDisplayChange;

	internal Label label7;

	internal TextBox txtChange;

	internal Label lblPhone;

	private Panel pnlVerifyNumber;

	internal Label label8;

	public string customer
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string orderType
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public frmOrderEntryShowItems()
	{
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		string_0 = AppDomain.CurrentDomain.BaseDirectory + "videos\\";
		string_1 = new string[1] { "input-repeat=0" };
		int_2 = 10;
		base._002Ector();
		InitializeComponent_1();
		pnlDisplayChange.Location = new Point(base.Width / 2 + pnlDisplayChange.Width / 2, base.Height / 2 + pnlDisplayChange.Height / 2);
		pnlVerifyNumber.Location = new Point(base.Width / 2 - pnlVerifyNumber.Width / 2, base.Height / 2 - pnlVerifyNumber.Height / 2);
		if (SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON")
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
		if (!bool_0)
		{
			Label label = label5;
			Label label2 = label4;
			TextBox textBox = txtGratuity;
			txtTotalAndGratuity.Visible = false;
			textBox.Visible = false;
			label2.Visible = false;
			label.Visible = false;
			((Control)(object)radListItemsSecond).Height += txtSubTotal.Height * 3;
			lblSubTotal.Location = new Point(lblSubTotal.Location.X, ((Control)(object)radListItemsSecond).Bottom + 5);
			txtSubTotal.Location = new Point(txtSubTotal.Location.X, ((Control)(object)radListItemsSecond).Bottom + 5);
			label3.Location = new Point(label3.Location.X, txtSubTotal.Bottom + 2);
			txtDiscount.Location = new Point(txtDiscount.Location.X, txtSubTotal.Bottom + 2);
			lblTotalTax.Location = new Point(lblTotalTax.Location.X, txtDiscount.Bottom + 2);
			txtTotalTax.Location = new Point(txtTotalTax.Location.X, txtDiscount.Bottom + 2);
			lblTotal.Location = new Point(lblTotal.Location.X, txtTotalTax.Bottom + 2);
			txtTotal.Location = new Point(txtTotal.Location.X, txtTotalTax.Bottom + 2);
		}
		txtTotal.TextChanged += txtTotal_TextChanged;
		base.FormClosing += frmOrderEntryShowItems_FormClosing;
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("font_size_second_screen");
		((Control)(object)radListItemsSecond).Font = new Font(((Control)(object)radListItemsSecond).Font.FontFamily, (float)Convert.ToDouble(settingValueByKey), ((Control)(object)radListItemsSecond).Font.Style);
		((RadListView)radListItemsSecond).add_CellFormatting(new ListViewCellFormattingEventHandler(radListItemsSecond_CellFormatting));
	}

	private void frmOrderEntryShowItems_FormClosing(object sender, FormClosingEventArgs e)
	{
		timer_0.Enabled = false;
		if (myVlcControl.get_IsPlaying())
		{
			myVlcControl.Stop();
		}
		((Component)(object)myVlcControl).Dispose();
	}

	private void radListItemsSecond_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
	{
		if ((e.get_CellElement().get_Data().get_HeaderText() == "Price" || e.get_CellElement().get_Data().get_HeaderText() == "Ext. Price") && e.get_CellElement() is DetailListViewDataCellElement)
		{
			((LightVisualElement)e.get_CellElement()).set_TextAlignment(ContentAlignment.MiddleRight);
		}
	}

	public void ShowCustomerTenderChange(string change)
	{
		txtChange.Text = change;
		pnlDisplayChange.Visible = true;
		timer_1.Enabled = true;
	}

	public void ResetValues()
	{
		((RadListView)radListItemsSecond).get_Items().Clear();
		txtSubTotal.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		txtDiscount.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		txtTotalTax.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		txtTotal.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		txtGratuity.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		txtTotalAndGratuity.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
	}

	private void txtTotal_TextChanged(object sender, EventArgs e)
	{
		CalculateAutoGratuity();
	}

	public void CalculateAutoGratuity()
	{
		if (!string.IsNullOrEmpty(customer) && !string.IsNullOrEmpty(orderType) && orderType == OrderTypes.DineIn)
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(customer.Replace("Table ", ""));
			if (bool_0 && currentTableGuestCapacity >= Convert.ToInt32(settingValueByKey))
			{
				string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("auto_gratuity_percentage");
				decimal_0 = Math.Round(Convert.ToDecimal(txtTotal.Text, Thread.CurrentThread.CurrentCulture) * (Convert.ToDecimal(settingValueByKey2, Thread.CurrentThread.CurrentCulture) / 100m), 2);
			}
			else
			{
				decimal_0 = default(decimal);
			}
		}
		txtGratuity.Text = decimal_0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		decimal num = decimal_0 + Convert.ToDecimal(txtTotal.Text, Thread.CurrentThread.CurrentCulture);
		txtTotalAndGratuity.Text = num.ToString("0.00", Thread.CurrentThread.CurrentCulture);
	}

	private void frmOrderEntryShowItems_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		list_2 = (from a in gClass.ImageScreens
			where a.ImageType == MediaType.second_screen_photos || a.ImageType == MediaType.second_screen_videos
			orderby a.SortOrder
			select a).ToList();
		if (list_2.Count > 0)
		{
			timer_0.Enabled = true;
			method_3();
		}
		else
		{
			timer_0.Enabled = false;
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (int_1 >= int_2)
		{
			int_1 = 0;
			method_3();
		}
		else
		{
			int_1++;
		}
	}

	private void method_3()
	{
		try
		{
			if (int_1 != 0)
			{
				return;
			}
			if (myVlcControl.get_IsPlaying())
			{
				myVlcControl.Stop();
			}
			ImageScreen imageScreen = list_2.Skip(int_0).FirstOrDefault();
			if (imageScreen != null)
			{
				if (imageScreen.ImageType == MediaType.second_screen_photos)
				{
					int_1 = 0;
					int_2 = ((imageScreen.Interval > 0) ? imageScreen.Interval : 10);
					picLogo.Visible = true;
					picLogo.Size = panelLogo.Size;
					picLogo.Location = new Point(0, 0);
					picLogo.SizeMode = PictureBoxSizeMode.Zoom;
					if (picLogo.Image != null)
					{
						picLogo.Image.Dispose();
					}
					using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(imageScreen.ImageAsText));
					try
					{
						Image image = Image.FromStream(memoryStream);
						picLogo.Image = image;
					}
					catch (OutOfMemoryException error)
					{
						memoryStream.Dispose();
						GC.Collect();
						NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
					}
				}
				else if (File.Exists(string_0 + imageScreen.ImageName))
				{
					int_1 = 0;
					picLogo.Visible = false;
					myVlcControl.SetMedia(new FileInfo(string_0 + imageScreen.ImageName), string_1);
					myVlcControl.Play();
					int_2 = 100;
				}
			}
			int_0++;
			if (list_2.Count <= int_0)
			{
				int_0 = 0;
			}
		}
		catch
		{
			int_1 = int_2;
			if (myVlcControl != null)
			{
				myVlcControl.Stop();
			}
			GC.Collect();
		}
	}

	private void method_4(object sender, VlcMediaPlayerEndReachedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)myVlcControl.get_State() != 6)
		{
			return;
		}
		Task.Factory.StartNew(delegate
		{
			Thread.Sleep(2000);
			if (base.InvokeRequired)
			{
				Invoke((Action)delegate
				{
					int_1 = int_2;
				});
			}
		});
	}

	private void method_5(object sender, ScrollEventArgs e)
	{
	}

	private void method_6(object sender, VlcLibDirectoryNeededEventArgs e)
	{
		e.set_VlcLibDirectory(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\vlclib\\"));
		_ = e.get_VlcLibDirectory().Exists;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (int_3 >= 15)
		{
			int_3 = 0;
			timer_1.Enabled = false;
			txtChange.Text = "$0.00";
			pnlDisplayChange.Visible = false;
		}
		else
		{
			int_3++;
		}
	}

	public void ChangePhoneNumber(string phone)
	{
		if (phone.Length == 10)
		{
			string text = phone.Substring(0, 3) + "-" + phone.Substring(3, 3) + "-" + phone.Substring(6, 4);
			lblPhone.Text = text;
		}
		else
		{
			lblPhone.Text = phone;
		}
	}

	public void ShowPanelNumber(bool show)
	{
		pnlVerifyNumber.Location = new Point(base.Width / 2 - pnlVerifyNumber.Width / 2, base.Height / 2 - pnlVerifyNumber.Height / 2);
		pnlVerifyNumber.Visible = show;
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
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmOrderEntryShowItems));
		ListViewDetailColumn val = new ListViewDetailColumn("Column 0", "Qty");
		ListViewDetailColumn val2 = new ListViewDetailColumn("Column 1", "Item Name");
		ListViewDetailColumn val3 = new ListViewDetailColumn("Column 2", "Price");
		ListViewDetailColumn val4 = new ListViewDetailColumn("Column 3", "Ext. Price");
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		panelItems = new Panel();
		label6 = new Label();
		label4 = new Label();
		txtTotalAndGratuity = new TextBox();
		label5 = new Label();
		txtGratuity = new TextBox();
		label3 = new Label();
		txtDiscount = new TextBox();
		label2 = new Label();
		pictureBox2 = new PictureBox();
		lblTotal = new Label();
		txtTotal = new TextBox();
		label1 = new Label();
		lblTotalTax = new Label();
		txtTotalTax = new TextBox();
		lblSubTotal = new Label();
		txtSubTotal = new TextBox();
		lblItemDesc = new Label();
		lblQty = new Label();
		lblPrice = new Label();
		lblExt = new Label();
		radListItemsSecond = new CustomListViewTelerik();
		lblPhone = new Label();
		panelLogo = new Panel();
		picLogo = new PictureBox();
		myVlcControl = new VlcControl();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		pnlDisplayChange = new Panel();
		label7 = new Label();
		txtChange = new TextBox();
		pnlVerifyNumber = new Panel();
		label8 = new Label();
		panelItems.SuspendLayout();
		((ISupportInitialize)pictureBox2).BeginInit();
		((ISupportInitialize)radListItemsSecond).BeginInit();
		panelLogo.SuspendLayout();
		((ISupportInitialize)picLogo).BeginInit();
		((ISupportInitialize)myVlcControl).BeginInit();
		pnlDisplayChange.SuspendLayout();
		pnlVerifyNumber.SuspendLayout();
		SuspendLayout();
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		panelItems.BackColor = Color.FromArgb(35, 39, 56);
		panelItems.Controls.Add(label6);
		panelItems.Controls.Add(label4);
		panelItems.Controls.Add(txtTotalAndGratuity);
		panelItems.Controls.Add(label5);
		panelItems.Controls.Add(txtGratuity);
		panelItems.Controls.Add(label3);
		panelItems.Controls.Add(txtDiscount);
		panelItems.Controls.Add(label2);
		panelItems.Controls.Add(pictureBox2);
		panelItems.Controls.Add(lblTotal);
		panelItems.Controls.Add(txtTotal);
		panelItems.Controls.Add(label1);
		panelItems.Controls.Add(lblTotalTax);
		panelItems.Controls.Add(txtTotalTax);
		panelItems.Controls.Add(lblSubTotal);
		panelItems.Controls.Add(txtSubTotal);
		panelItems.Controls.Add(lblItemDesc);
		panelItems.Controls.Add(lblQty);
		panelItems.Controls.Add(lblPrice);
		panelItems.Controls.Add(lblExt);
		panelItems.Controls.Add((Control)(object)radListItemsSecond);
		componentResourceManager.ApplyResources(panelItems, "panelItems");
		panelItems.Name = "panelItems";
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtTotalAndGratuity, "txtTotalAndGratuity");
		txtTotalAndGratuity.BackColor = Color.White;
		txtTotalAndGratuity.BorderStyle = BorderStyle.None;
		txtTotalAndGratuity.Name = "txtTotalAndGratuity";
		txtTotalAndGratuity.ReadOnly = true;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(txtGratuity, "txtGratuity");
		txtGratuity.BackColor = Color.White;
		txtGratuity.BorderStyle = BorderStyle.None;
		txtGratuity.Name = "txtGratuity";
		txtGratuity.ReadOnly = true;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtDiscount, "txtDiscount");
		txtDiscount.BackColor = Color.White;
		txtDiscount.BorderStyle = BorderStyle.None;
		txtDiscount.Name = "txtDiscount";
		txtDiscount.ReadOnly = true;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(pictureBox2, "pictureBox2");
		pictureBox2.Name = "pictureBox2";
		pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(lblTotal, "lblTotal");
		lblTotal.ForeColor = Color.White;
		lblTotal.Name = "lblTotal";
		componentResourceManager.ApplyResources(txtTotal, "txtTotal");
		txtTotal.BackColor = Color.White;
		txtTotal.BorderStyle = BorderStyle.None;
		txtTotal.Name = "txtTotal";
		txtTotal.ReadOnly = true;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(lblTotalTax, "lblTotalTax");
		lblTotalTax.ForeColor = Color.White;
		lblTotalTax.Name = "lblTotalTax";
		componentResourceManager.ApplyResources(txtTotalTax, "txtTotalTax");
		txtTotalTax.BackColor = Color.White;
		txtTotalTax.BorderStyle = BorderStyle.None;
		txtTotalTax.Name = "txtTotalTax";
		txtTotalTax.ReadOnly = true;
		componentResourceManager.ApplyResources(lblSubTotal, "lblSubTotal");
		lblSubTotal.ForeColor = Color.White;
		lblSubTotal.Name = "lblSubTotal";
		componentResourceManager.ApplyResources(txtSubTotal, "txtSubTotal");
		txtSubTotal.BackColor = Color.White;
		txtSubTotal.BorderStyle = BorderStyle.None;
		txtSubTotal.Name = "txtSubTotal";
		txtSubTotal.ReadOnly = true;
		lblItemDesc.BackColor = Color.FromArgb(1, 110, 211);
		componentResourceManager.ApplyResources(lblItemDesc, "lblItemDesc");
		lblItemDesc.ForeColor = Color.White;
		lblItemDesc.Name = "lblItemDesc";
		lblQty.BackColor = Color.FromArgb(1, 110, 211);
		componentResourceManager.ApplyResources(lblQty, "lblQty");
		lblQty.ForeColor = Color.White;
		lblQty.Name = "lblQty";
		lblPrice.BackColor = Color.FromArgb(1, 110, 211);
		componentResourceManager.ApplyResources(lblPrice, "lblPrice");
		lblPrice.ForeColor = Color.White;
		lblPrice.Name = "lblPrice";
		lblExt.BackColor = Color.FromArgb(1, 110, 211);
		componentResourceManager.ApplyResources(lblExt, "lblExt");
		lblExt.ForeColor = Color.White;
		lblExt.Name = "lblExt";
		((RadListView)radListItemsSecond).set_AllowArbitraryItemHeight(true);
		((RadListView)radListItemsSecond).set_AllowEdit(false);
		((RadListView)radListItemsSecond).set_AllowRemove(false);
		componentResourceManager.ApplyResources(radListItemsSecond, "radListItemsSecond");
		val.set_HeaderText("Qty");
		val.set_Width(40f);
		val2.set_HeaderText("Item Name");
		val2.set_Width(289f);
		val3.set_HeaderText("Price");
		val3.set_Width(78f);
		val4.set_HeaderText("Ext. Price");
		val4.set_Width(123f);
		((RadListView)radListItemsSecond).get_Columns().AddRange((ListViewDetailColumn[])(object)new ListViewDetailColumn[4] { val, val2, val3, val4 });
		((RadListView)radListItemsSecond).set_EnableCustomGrouping(true);
		((RadListView)radListItemsSecond).set_EnableKineticScrolling(true);
		((RadListView)radListItemsSecond).set_GroupIndent(0);
		((RadListView)radListItemsSecond).set_GroupItemSize(new Size(300, 60));
		((RadListView)radListItemsSecond).set_ItemSize(new Size(200, 40));
		((RadListView)radListItemsSecond).set_ItemSpacing(-1);
		((Control)(object)radListItemsSecond).Name = "radListItemsSecond";
		((RadListView)radListItemsSecond).set_ShowColumnHeaders(false);
		((RadListView)radListItemsSecond).set_ShowGridLines(true);
		((RadListView)radListItemsSecond).set_ShowGroups(true);
		((RadListView)radListItemsSecond).set_ViewType((ListViewType)2);
		componentResourceManager.ApplyResources(lblPhone, "lblPhone");
		lblPhone.ForeColor = Color.FromArgb(244, 156, 20);
		lblPhone.Name = "lblPhone";
		componentResourceManager.ApplyResources(panelLogo, "panelLogo");
		panelLogo.BackColor = Color.FromArgb(35, 39, 56);
		panelLogo.Controls.Add(picLogo);
		panelLogo.Controls.Add((Control)(object)myVlcControl);
		panelLogo.Name = "panelLogo";
		componentResourceManager.ApplyResources(picLogo, "picLogo");
		picLogo.Name = "picLogo";
		picLogo.TabStop = false;
		((Control)(object)myVlcControl).BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(myVlcControl, "myVlcControl");
		((Control)(object)myVlcControl).Name = "myVlcControl";
		myVlcControl.set_Spu(-1);
		myVlcControl.set_VlcLibDirectory((DirectoryInfo)null);
		myVlcControl.set_VlcMediaplayerOptions((string[])null);
		myVlcControl.add_VlcLibDirectoryNeeded((EventHandler<VlcLibDirectoryNeededEventArgs>)method_6);
		myVlcControl.add_EndReached((EventHandler<VlcMediaPlayerEndReachedEventArgs>)method_4);
		timer_1.Interval = 1000;
		timer_1.Tick += timer_1_Tick;
		pnlDisplayChange.BackColor = Color.FromArgb(30, 30, 30);
		pnlDisplayChange.Controls.Add(label7);
		pnlDisplayChange.Controls.Add(txtChange);
		componentResourceManager.ApplyResources(pnlDisplayChange, "pnlDisplayChange");
		pnlDisplayChange.Name = "pnlDisplayChange";
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		txtChange.BackColor = Color.FromArgb(30, 30, 30);
		txtChange.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtChange, "txtChange");
		txtChange.ForeColor = Color.FromArgb(244, 156, 20);
		txtChange.Name = "txtChange";
		txtChange.ReadOnly = true;
		pnlVerifyNumber.BackColor = Color.FromArgb(64, 0, 0);
		pnlVerifyNumber.Controls.Add(label8);
		pnlVerifyNumber.Controls.Add(lblPhone);
		componentResourceManager.ApplyResources(pnlVerifyNumber, "pnlVerifyNumber");
		pnlVerifyNumber.Name = "pnlVerifyNumber";
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ControlBox = false;
		base.Controls.Add(pnlVerifyNumber);
		base.Controls.Add(pnlDisplayChange);
		base.Controls.Add(panelLogo);
		base.Controls.Add(panelItems);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmOrderEntryShowItems";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmOrderEntryShowItems_Load;
		panelItems.ResumeLayout(performLayout: false);
		panelItems.PerformLayout();
		((ISupportInitialize)pictureBox2).EndInit();
		((ISupportInitialize)radListItemsSecond).EndInit();
		panelLogo.ResumeLayout(performLayout: false);
		((ISupportInitialize)picLogo).EndInit();
		((ISupportInitialize)myVlcControl).EndInit();
		pnlDisplayChange.ResumeLayout(performLayout: false);
		pnlDisplayChange.PerformLayout();
		pnlVerifyNumber.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void method_7()
	{
		Thread.Sleep(2000);
		if (base.InvokeRequired)
		{
			Invoke((Action)delegate
			{
				int_1 = int_2;
			});
		}
	}

	[CompilerGenerated]
	private void method_8()
	{
		int_1 = int_2;
	}
}
