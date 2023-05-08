using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;

namespace CorePOS;

public class frmStationServingScreen : frmMasterForm
{
	private bool bool_0;

	private int int_0;

	private int int_1;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Label lbl1;

	private Label lbl2;

	private Label lblDivider;

	private FlowLayoutPanel pnlWaitOrders;

	private Timer timer_0;

	private FlowLayoutPanel pnlOrderMade;

	private PictureBox pictureBox1;

	private Panel panelLogo;

	private PictureBox picLogo;

	private Timer timer_1;

	private Panel panel1;

	public frmStationServingScreen()
	{
		Class26.Ggkj0JxzN9YmC();
		int_0 = 2;
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmStationServingScreen_Load(object sender, EventArgs e)
	{
		timer_0.Enabled = true;
		LoadOrders();
		if (method_3())
		{
			picLogo.Size = panelLogo.Size;
			picLogo.Location = new Point(0, 0);
			picLogo.Image = method_5();
			picLogo.SizeMode = PictureBoxSizeMode.Zoom;
			timer_1.Enabled = true;
		}
		else
		{
			timer_1.Enabled = false;
		}
	}

	public void LoadOrders()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		pnlWaitOrders.Controls.Clear();
		pnlOrderMade.Controls.Clear();
		OrderMethods orderMethods = new OrderMethods();
		_ = SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON";
		List<Order> list = (from a in orderMethods.UnfilledOrders(-1)
			where !a.Void && a.StationID != null && !a.OrderType.ToUpper().Contains("DELIVERY")
			group a by a.OrderNumber into a
			select a.FirstOrDefault()).ToList();
		List<Order> list2 = (from a in orderMethods.FilledCompleteOrders(int_0)
			where !a.Void && a.StationID != null && !a.OrderType.ToUpper().Contains("DELIVERY")
			group a by a.OrderNumber into a
			select a.FirstOrDefault()).ToList();
		foreach (Order item in list)
		{
			Label label = new Label
			{
				BackColor = Color.Transparent,
				ForeColor = Color.Black
			};
			string text = (label.Text = TextFilters.GetOrderNumberDisplay(item));
			label.Font = new Font("Microsoft Sans Serif", 30 - text.Length, FontStyle.Bold);
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.Size = new Size(pnlWaitOrders.Width / 2 - 10, 50);
			pnlWaitOrders.Controls.Add(label);
		}
		GClass6 gClass = new GClass6();
		using (List<Order>.Enumerator enumerator = list2.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
				CS_0024_003C_003E8__locals0.moOrder = enumerator.Current;
				if (gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.moOrder.OrderNumber && !o.DateFilled.HasValue && o.ItemID > 0).Count() == 0)
				{
					Label label2 = new Label();
					label2.BackColor = Color.Transparent;
					label2.ForeColor = Color.DarkRed;
					string text2 = (label2.Text = TextFilters.GetOrderNumberDisplay(CS_0024_003C_003E8__locals0.moOrder));
					label2.Font = new Font("Microsoft Sans Serif", 30 - text2.Length, FontStyle.Bold);
					label2.TextAlign = ContentAlignment.MiddleCenter;
					label2.Size = new Size(pnlOrderMade.Width / 2 - 10, 50);
					pnlOrderMade.Controls.Add(label2);
				}
			}
		}
		bool_0 = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		LoadOrders();
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		ControlHelpers.CloseNowServingScreen();
	}

	private bool method_3()
	{
		new GClass6();
		if (method_4() > 0)
		{
			return true;
		}
		return false;
	}

	private int method_4()
	{
		return new GClass6().ImageScreens.Where((ImageScreen a) => a.ImageType == "second_screen_photos").Count();
	}

	private Image method_5()
	{
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(new GClass6().ImageScreens.Where((ImageScreen x) => x.ImageType == "second_screen_photos").Skip(int_1).FirstOrDefault()
			.ImageAsText));
			return Image.FromStream(stream);
		}

		private void timer_1_Tick(object sender, EventArgs e)
		{
			if (method_4() > int_1)
			{
				picLogo.Image = method_5();
				picLogo.SizeMode = PictureBoxSizeMode.Zoom;
				int_1++;
				GC.Collect();
			}
			else
			{
				int_1 = 0;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmStationServingScreen));
			timer_0 = new Timer(icontainer_1);
			timer_1 = new Timer(icontainer_1);
			panelLogo = new Panel();
			picLogo = new PictureBox();
			pictureBox1 = new PictureBox();
			pnlOrderMade = new FlowLayoutPanel();
			pnlWaitOrders = new FlowLayoutPanel();
			lblDivider = new Label();
			lbl2 = new Label();
			lbl1 = new Label();
			lblTitle = new Label();
			panel1 = new Panel();
			panelLogo.SuspendLayout();
			((ISupportInitialize)picLogo).BeginInit();
			((ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			timer_0.Enabled = true;
			timer_0.Interval = 10000;
			timer_0.Tick += timer_0_Tick;
			timer_1.Interval = 10000;
			timer_1.Tick += timer_1_Tick;
			componentResourceManager.ApplyResources(panelLogo, "panelLogo");
			panelLogo.BackColor = Color.FromArgb(35, 39, 56);
			panelLogo.Controls.Add(picLogo);
			panelLogo.Name = "panelLogo";
			componentResourceManager.ApplyResources(picLogo, "picLogo");
			picLogo.Name = "picLogo";
			picLogo.TabStop = false;
			pictureBox1.BackColor = Color.FromArgb(147, 101, 184);
			componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			componentResourceManager.ApplyResources(pnlOrderMade, "pnlOrderMade");
			pnlOrderMade.BackColor = Color.White;
			pnlOrderMade.Name = "pnlOrderMade";
			componentResourceManager.ApplyResources(pnlWaitOrders, "pnlWaitOrders");
			pnlWaitOrders.BackColor = Color.White;
			pnlWaitOrders.Name = "pnlWaitOrders";
			componentResourceManager.ApplyResources(lblDivider, "lblDivider");
			lblDivider.BackColor = Color.FromArgb(61, 142, 185);
			lblDivider.ForeColor = Color.White;
			lblDivider.Name = "lblDivider";
			componentResourceManager.ApplyResources(lbl2, "lbl2");
			lbl2.BackColor = Color.FromArgb(61, 142, 185);
			lbl2.ForeColor = Color.White;
			lbl2.Name = "lbl2";
			lbl1.BackColor = Color.FromArgb(61, 142, 185);
			componentResourceManager.ApplyResources(lbl1, "lbl1");
			lbl1.ForeColor = Color.White;
			lbl1.Name = "lbl1";
			componentResourceManager.ApplyResources(lblTitle, "lblTitle");
			lblTitle.BackColor = Color.FromArgb(147, 101, 184);
			lblTitle.FlatStyle = FlatStyle.Flat;
			lblTitle.ForeColor = Color.White;
			lblTitle.Name = "lblTitle";
			componentResourceManager.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(lbl1);
			panel1.Controls.Add(lbl2);
			panel1.Controls.Add(lblDivider);
			panel1.Controls.Add(pnlOrderMade);
			panel1.Controls.Add(pnlWaitOrders);
			panel1.Name = "panel1";
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(panel1);
			base.Controls.Add(panelLogo);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(lblTitle);
			base.Name = "frmStationServingScreen";
			base.Opacity = 1.0;
			base.WindowState = FormWindowState.Maximized;
			base.Load += frmStationServingScreen_Load;
			base.Controls.SetChildIndex(lblTitle, 0);
			base.Controls.SetChildIndex(pictureBox1, 0);
			base.Controls.SetChildIndex(panelLogo, 0);
			base.Controls.SetChildIndex(panel1, 0);
			base.Controls.SetChildIndex(PersistentNotification, 0);
			panelLogo.ResumeLayout(performLayout: false);
			((ISupportInitialize)picLogo).EndInit();
			((ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(performLayout: false);
			ResumeLayout(performLayout: false);
		}
	}
