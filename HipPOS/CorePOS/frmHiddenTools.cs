using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;

namespace CorePOS;

public class frmHiddenTools : frmMasterForm
{
	private IContainer icontainer_1;

	private Button btnAddOrders;

	private Button btnShowSplash;

	private TextBox txtStartDate;

	private Label label1;

	private Label label2;

	private TextBox txtMinPerDate;

	private Label label3;

	private TextBox txtMaxPerDate;

	private Label label4;

	private TextBox txtNumOfOrders;

	private Button button1;

	private Button button2;

	private ListBox listBox1;

	private Button button3;

	public frmHiddenTools()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void btnAddOrders_Click(object sender, EventArgs e)
	{
		DateTime value;
		int num;
		int num2;
		int num3;
		try
		{
			value = DateTime.ParseExact(txtStartDate.Text + " 11:01:00 AM", "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
			num = Convert.ToInt32(txtNumOfOrders.Text);
			num2 = Convert.ToInt32(txtMinPerDate.Text);
			num3 = Convert.ToInt32(txtMaxPerDate.Text);
		}
		catch
		{
			MessageBox.Show("All textboxes need to be filled out and in proper format.");
			return;
		}
		int num4 = num;
		GClass6 gClass = new GClass6();
		do
		{
			Random random = new Random();
			int num5 = 0;
			if (num4 >= num3 || num4 <= num2)
			{
				num5 = ((num4 > num2) ? random.Next(num2, num3) : num4);
			}
			else
			{
				num3 = num4;
				num5 = random.Next(num2, num3);
			}
			for (int j = 0; j <= num5; j++)
			{
				_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1_0();
				int num6 = new Random().Next(-2, 5);
				if (num6 < 0)
				{
					num6 = 1;
				}
				else if (num6 == 1)
				{
					num6 = 2;
				}
				List<Item> list = new List<Item>();
				int itemID = gClass.Items.OrderByDescending((Item i) => i.ItemID).FirstOrDefault().ItemID;
				for (int k = 1; k <= num6; k++)
				{
					_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_1();
					CS_0024_003C_003E8__locals0.item = null;
					Random random2 = new Random();
					do
					{
						_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass1_2();
						CS_0024_003C_003E8__locals1.rID = random2.Next(1, itemID);
						CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals1.rID).FirstOrDefault();
						if (CS_0024_003C_003E8__locals0.item == null)
						{
							continue;
						}
						CS_0024_003C_003E8__locals0.item.InventoryCount = 1m;
						if (list.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).Count() > 0)
						{
							list.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).FirstOrDefault().InventoryCount++;
						}
						else
						{
							list.Add(CS_0024_003C_003E8__locals0.item);
						}
					}
					while (CS_0024_003C_003E8__locals0.item == null);
				}
				CS_0024_003C_003E8__locals2.orderNumber = OrderMethods.GetNewOrderNumber();
				Random random3 = new Random();
				Layout layout = gClass.Layouts.Where((Layout x) => !x.TableName.Contains(TransparentLabelType.Wall)).Skip(random3.Next(1, gClass.Layouts.Where((Layout x) => !x.TableName.Contains(TransparentLabelType.Wall)).Count())).FirstOrDefault();
				int num7 = random3.Next(0, 3);
				string orderType = OrderTypes.DineIn;
				if (num7 == 3)
				{
					orderType = OrderTypes.PickUp;
				}
				new OrderMethods(gClass).SaveOrder(list, CS_0024_003C_003E8__locals2.orderNumber, "Table " + layout.TableName, orderType, 0, string.Empty, 0m, 0m, isPaid: false, string.Empty, string.Empty, string.Empty, string.Empty, layout.NumOfSeats.Value, isDiscount: false, "", 0, null, null, 0, null, "", GratuityRemoved: false, 0);
				Thread.Sleep(200);
				GClass6 gClass2 = new GClass6();
				IQueryable<Order> queryable = gClass2.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals2.orderNumber);
				if (queryable.Count() > 0)
				{
					string empty = string.Empty;
					empty = new Random().Next(0, 3) switch
					{
						0 => "Cash=", 
						1 => "Debit=", 
						2 => "Credit Card=", 
						_ => "Cash=", 
					};
					decimal num8 = queryable.Sum((Order o) => o.Total);
					if (num8 < 3m)
					{
						empty = "Cash=";
					}
					decimal num9 = default(decimal);
					for (int l = 1; l < 99; l++)
					{
						num9 = 5m * (decimal)l;
						if (num9 > num8)
						{
							break;
						}
					}
					empty = empty + queryable.Sum((Order o) => o.Total).ToString("0.00") + "|";
					int num10 = new Random().Next(120, 1200);
					value = value.AddSeconds(num10);
					foreach (Order item in queryable)
					{
						item.DateCreated = value;
						item.DatePaid = value;
						item.DateFilled = value;
						item.TenderAmount = num9;
						item.TenderChange = num9 - num8;
						item.PaymentMethods = empty;
						item.TipAmount = num8 * 0.1m;
						item.Paid = true;
						item.TipRecorded = true;
						item.ItemMadeNotified = true;
					}
					gClass2.SubmitChanges();
					if (value.TimeOfDay.Hours == 14)
					{
						value = value.AddMinutes(160.0);
					}
					else if (value.TimeOfDay.Hours == 21)
					{
						j = num5;
					}
				}
				method_3(107);
			}
			value = Convert.ToDateTime(value.AddDays(1.0).Date.ToShortDateString() + " 11:00:00 AM");
			num4 -= num5;
		}
		while (num4 > 0);
	}

	private void method_3(int int_0 = 187)
	{
		Thread.Sleep(new Random().Next(5, int_0));
	}

	private void btnShowSplash_Click(object sender, EventArgs e)
	{
		new frmSplash().Show();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		using GClass6 gClass = new GClass6();
		Group entity = new Group
		{
			GroupID = 45,
			Active = false,
			AllowHalfOrder = false,
			GroupClassification = "product",
			GroupColor = "150,166,166",
			GroupName = "*DELETED GROUP*",
			HighTraffic = false,
			ParentGroupID = 0,
			Synced = false,
			Archived = true
		};
		gClass.Groups.InsertOnSubmit(entity);
		gClass.SubmitChanges();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		new NotificationLabel(this, "Testing Label.", NotificationTypes.Success).Show();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		for (int i = 0; i <= 5; i++)
		{
			listBox1.Items.Add(DateTime.Now.AddDays(i));
		}
	}

	private void listBox1_MouseDown(object sender, MouseEventArgs e)
	{
		if (listBox1.SelectedItem != null)
		{
			listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
		}
	}

	private void listBox1_DragOver(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
	}

	private void listBox1_DragDrop(object sender, DragEventArgs e)
	{
		Point p = listBox1.PointToClient(new Point(e.X, e.Y));
		int num = listBox1.IndexFromPoint(p);
		if (num < 0)
		{
			num = listBox1.Items.Count - 1;
		}
		object data = e.Data.GetData(typeof(DateTime));
		listBox1.Items.Remove(data);
		listBox1.Items.Insert(num, data);
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmHiddenTools));
		button2 = new Button();
		button1 = new Button();
		label4 = new Label();
		txtNumOfOrders = new TextBox();
		label3 = new Label();
		txtMaxPerDate = new TextBox();
		label2 = new Label();
		txtMinPerDate = new TextBox();
		label1 = new Label();
		txtStartDate = new TextBox();
		btnShowSplash = new Button();
		btnAddOrders = new Button();
		listBox1 = new ListBox();
		button3 = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(button2, "button2");
		button2.Name = "button2";
		button2.UseVisualStyleBackColor = true;
		button2.Click += button2_Click;
		componentResourceManager.ApplyResources(button1, "button1");
		button1.Name = "button1";
		button1.UseVisualStyleBackColor = true;
		button1.Click += button1_Click;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtNumOfOrders, "txtNumOfOrders");
		txtNumOfOrders.Name = "txtNumOfOrders";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtMaxPerDate, "txtMaxPerDate");
		txtMaxPerDate.Name = "txtMaxPerDate";
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(txtMinPerDate, "txtMinPerDate");
		txtMinPerDate.Name = "txtMinPerDate";
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(txtStartDate, "txtStartDate");
		txtStartDate.Name = "txtStartDate";
		componentResourceManager.ApplyResources(btnShowSplash, "btnShowSplash");
		btnShowSplash.Name = "btnShowSplash";
		btnShowSplash.UseVisualStyleBackColor = true;
		btnShowSplash.Click += btnShowSplash_Click;
		componentResourceManager.ApplyResources(btnAddOrders, "btnAddOrders");
		btnAddOrders.Name = "btnAddOrders";
		btnAddOrders.UseVisualStyleBackColor = true;
		btnAddOrders.Click += btnAddOrders_Click;
		listBox1.AllowDrop = true;
		listBox1.DrawMode = DrawMode.OwnerDrawVariable;
		componentResourceManager.ApplyResources(listBox1, "listBox1");
		listBox1.FormattingEnabled = true;
		listBox1.Name = "listBox1";
		listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
		listBox1.DragDrop += listBox1_DragDrop;
		listBox1.DragOver += listBox1_DragOver;
		listBox1.MouseDown += listBox1_MouseDown;
		componentResourceManager.ApplyResources(button3, "button3");
		button3.Name = "button3";
		button3.UseVisualStyleBackColor = true;
		button3.Click += button3_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(button3);
		base.Controls.Add(listBox1);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.Controls.Add(label4);
		base.Controls.Add(txtNumOfOrders);
		base.Controls.Add(label3);
		base.Controls.Add(txtMaxPerDate);
		base.Controls.Add(label2);
		base.Controls.Add(txtMinPerDate);
		base.Controls.Add(label1);
		base.Controls.Add(txtStartDate);
		base.Controls.Add(btnShowSplash);
		base.Controls.Add(btnAddOrders);
		base.Name = "frmHiddenTools";
		base.Opacity = 1.0;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
