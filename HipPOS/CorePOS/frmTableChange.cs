using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmTableChange : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public Layout layout;

		public _003C_003Ec__DisplayClass26_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadAllTables_003Eb__1(OccupiedTable a)
		{
			return a.TableName == layout.TableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public string tableName;

		public _003C_003Ec__DisplayClass30_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CclearReservationOnTable_003Eb__0(TableModel l)
		{
			return l.TableName == tableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public TableModel occupiedTable;

		public _003C_003Ec__DisplayClass32_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CTimer1_Tick_003Eb__1(OccupiedTable t)
		{
			return t.TableName == occupiedTable.TableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_1
	{
		public OccupiedTable occupiedTablesResult;

		public _003C_003Ec__DisplayClass32_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public Layout layout;

		public _003C_003Ec__DisplayClass33_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CsubTableClick_003Eb__2(OccupiedTable a)
		{
			return a.TableName == layout.TableName;
		}
	}

	private string string_0;

	private string string_1;

	private int int_0;

	private int int_1;

	private string string_2;

	private string string_3;

	private int int_2;

	private int int_3;

	private string[] string_4;

	private short short_0;

	private OrderMethods orderMethods_0;

	private GClass6 gclass6_0;

	private DataManager dataManager_0;

	private int int_4;

	private TableModel tableModel_0;

	private int int_5;

	private List<Layout> list_2;

	private List<TableModel> list_3;

	private List<string> list_4;

	private bool bool_0;

	private List<Layout> list_5;

	private frmMessageBox frmMessageBox_0;

	private IContainer icontainer_1;

	internal Button BtnClose;

	internal Timer timer_0;

	private Label lblTraining;

	private TransparentLabel transparentLabel_0;

	private Panel panelNav;

	private Label label2;

	internal Panel PanelLayOut;

	private Label lblSectionName;

	internal Button btnRight;

	internal Button btnLeft;

	private Label lblOrderType;

	private Label lblCustomer;

	private Label lblTitle;

	internal Button btnTakeOut;

	private PictureBox pictureBoxGuest;

	private PictureBox chairImage;

	private PictureBox benchImage;

	private PictureBox plantImage;

	private PictureBox pbZoomOut;

	private PictureBox pbZoomIn;

	public string OrderType
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public int GuestsMoved
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public string OrderTable
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public int Guest
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public string CustomerInfoName
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string OriginalTable
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public frmTableChange(string title, int originalGuest, string tablename, string orderType, string customerInfoName = "", bool showBtnToGo = true)
	{
		Class26.Ggkj0JxzN9YmC();
		string_4 = new string[200];
		int_4 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		int_5 = 5;
		list_2 = new List<Layout>();
		list_3 = new List<TableModel>();
		list_4 = new List<string>();
		frmMessageBox_0 = new frmMessageBox("");
		// base._002Ector();
		frmLoadingBar.ShowSplashScreen();
		frmLoadingBar.SetPercentage(1);
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		frmLoadingBar.SetPercentage(10);
		lblTitle.Text = title;
		list_4 = new List<string>();
		btnTakeOut.Visible = showBtnToGo;
		if (!string.IsNullOrEmpty(tablename))
		{
			if ((orderType == OrderTypes.PickUp || orderType == OrderTypes.Delivery) && !string.IsNullOrEmpty(customerInfoName))
			{
				lblCustomer.Text = customerInfoName + " - " + tablename;
			}
			else
			{
				lblCustomer.Text = tablename;
			}
		}
		else
		{
			lblCustomer.Text = "";
		}
		string_0 = orderType;
		if (string_0 == OrderTypes.DineIn)
		{
			string_1 = tablename.Replace("Table ", "");
			lblOrderType.Text = Resources.CHANGED_TO_DINE_IN;
		}
		else
		{
			string_1 = tablename;
			lblOrderType.Text = Resources.CHANGED_TO_TAKE_OUT;
		}
		int_0 = 0;
		int_1 = originalGuest;
		string_2 = customerInfoName;
		gclass6_0 = new GClass6();
		Setting setting = gclass6_0.Settings.Where((Setting s) => s.Key.ToUpper() == "restaurant_capacity").FirstOrDefault();
		if (setting != null && setting.Value == "ON")
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
		frmLoadingBar.SetPercentage(20);
		Terminal terminal = gclass6_0.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			int_5 = (terminal.LayoutZoomValue.HasValue ? terminal.LayoutZoomValue.Value : 5);
		}
		method_3();
		frmLoadingBar.SetPercentage(99);
		frmLoadingBar.CloseForm();
	}

	private void method_3()
	{
		orderMethods_0 = new OrderMethods();
		dataManager_0 = new DataManager(gclass6_0);
		PanelLayOut.SendToBack();
		frmLoadingBar.SetPercentage(30);
		method_5();
		frmLoadingBar.SetPercentage(45);
		method_9();
	}

	private void PanelLayOut_MouseClick(object sender, MouseEventArgs e)
	{
		Panel obj = (Panel)sender;
		Point p = new Point(Cursor.Position.X + PanelLayOut.HorizontalScroll.Value, Cursor.Position.Y + PanelLayOut.VerticalScroll.Value);
		Point point = obj.PointToClient(p);
		double num = (double)int_5 / 5.0 - 0.1 * ((double)int_5 - 5.0);
		foreach (TableModel item in list_3.Where((TableModel tableModel_1) => tableModel_1.Section == lblSectionName.Text).ToList())
		{
			if (!item.isRound)
			{
				int num2 = item.TotalCapacity;
				if (num2 <= 2)
				{
					num2++;
				}
				int val = (int)(40.0 * num);
				int val2 = (int)((double)(15 * num2) * num);
				int angleOfRotation = item.angleOfRotation;
				int num3 = Math.Max(val, val2);
				Size size = new Size(num3 * 2 + num3 / 2, num3 * 2 + num3 / 2);
				int num4 = (int)((double)(size.Width / 2) + (double)item.Location.X * num);
				int num5 = (int)((double)(size.Height / 2) + (double)item.Location.Y * num);
				Point center = new Point(num4, num5);
				Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angleOfRotation, center, val2, val);
				Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angleOfRotation, center, val2, val);
				Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angleOfRotation, center, val2, val);
				Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angleOfRotation, center, val2, val);
				if (ControlHelpers.IsPointInPolygon4(new PointF[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 }, point))
				{
					method_8(item);
					break;
				}
			}
			else
			{
				int totalCapacity = item.TotalCapacity;
				int num6 = (int)((double)(60 + totalCapacity * 4) * num);
				new Size(num6, num6);
				Point point2 = new Point((int)((double)item.Location.X * num), (int)((double)item.Location.Y * num));
				Point point3 = new Point(point2.X, point2.Y);
				Point point4 = new Point(point2.X + num6, point2.Y);
				Point point5 = new Point(point2.X + num6, point2.Y + num6);
				Point point6 = new Point(point2.X, point2.Y + num6);
				if (ControlHelpers.IsPointInPolygon4(new PointF[4] { point3, point4, point5, point6 }, point))
				{
					method_8(item);
					break;
				}
			}
		}
	}

	private void PanelLayOut_Paint(object sender, PaintEventArgs e)
	{
		GraphicHelpers.DrawLayout(sender, e, list_2, list_3, lblSectionName.Text, pictureBoxGuest.Image, plantImage.Image, benchImage.Image, chairImage.Image, int_5, bool_0);
	}

	private void method_4()
	{
		PanelLayOut.Controls.Clear();
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		List<Layout> list = list_5.Where((Layout layout_0) => layout_0.Active && layout_0.Section == lblSectionName.Text).ToList();
		int num = 0;
		list_2.Clear();
		list_3.Clear();
		List<OccupiedTable> source = orderMethods_0.OccupiedTables().ToList();
		using List<Layout>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
			CS_0024_003C_003E8__locals0.layout = enumerator.Current;
			if (CS_0024_003C_003E8__locals0.layout.Rotation != 'V' && CS_0024_003C_003E8__locals0.layout.Rotation != 'H')
			{
				list_2.Add(CS_0024_003C_003E8__locals0.layout);
				continue;
			}
			OccupiedTable occupiedTable = source.Where((OccupiedTable a) => a.TableName == CS_0024_003C_003E8__locals0.layout.TableName).FirstOrDefault();
			int num2 = occupiedTable?.GuestCount ?? 0;
			string status = TableStatus.Open;
			if (occupiedTable != null)
			{
				status = ((occupiedTable.Customer == null) ? TableStatus.Open : ((occupiedTable.Customer == null) ? TableStatus.Ordered : ((occupiedTable.Cleared || !occupiedTable.Paid) ? TableStatus.Ordered : TableStatus.Paid)));
			}
			else if (CS_0024_003C_003E8__locals0.layout.AppointmentID.HasValue)
			{
				status = TableStatus.Reserved;
			}
			else if (num2 > 0)
			{
				status = TableStatus.Seated;
			}
			TableModel tableModel = new TableModel
			{
				TableName = CS_0024_003C_003E8__locals0.layout.TableName,
				isRound = CS_0024_003C_003E8__locals0.layout.Round,
				currentGuests = num2,
				angleOfRotation = CS_0024_003C_003E8__locals0.layout.AngleOfRotation,
				Location = new Point(CS_0024_003C_003E8__locals0.layout.X.Value, CS_0024_003C_003E8__locals0.layout.Y.Value),
				Section = CS_0024_003C_003E8__locals0.layout.Section,
				TotalCapacity = CS_0024_003C_003E8__locals0.layout.NumOfSeats.Value,
				Status = status
			};
			list_3.Add(tableModel);
			num++;
			method_6(tableModel);
		}
	}

	private void method_5()
	{
		GClass6 gClass = new GClass6();
		list_4 = gClass.Layouts.Select((Layout l) => l.Section).Distinct().ToList();
		if (list_4.Count > 1)
		{
			btnRight.Enabled = true;
		}
	}

	private void method_6(TableModel tableModel_1)
	{
		int num = tableModel_1.TotalCapacity;
		if (num <= 2)
		{
			num++;
		}
		double num2 = (double)int_5 / 5.0 - 0.1 * ((double)int_5 - 5.0);
		double num3 = 40.0 * num2;
		double num4 = (double)(15 * num) * num2;
		int val = (int)num3;
		int val2 = (int)num4;
		int num5 = Math.Max(val, val2);
		Size size = new Size(num5 * 2 + num5 / 2, num5 * 2 + num5 / 2);
		int num6 = size.Width / 2 + tableModel_1.Location.X;
		int num7 = size.Height / 2 + tableModel_1.Location.Y;
		Point point = new Point((int)((double)num6 * num2), (int)((double)num7 * num2));
		TransparentLabel transparentLabel = new TransparentLabel();
		transparentLabel.Font = new Font("Arial", 8f, FontStyle.Regular);
		transparentLabel.BackColor = ColorPalette.WhiteSmoke;
		transparentLabel.FlatStyle = FlatStyle.Flat;
		transparentLabel.Opacity = 100;
		transparentLabel.transparentBackColor = Color.FromArgb(235, 107, 86);
		transparentLabel.Size = new Size(120, 80);
		transparentLabel.Text = "";
		transparentLabel.Padding = new Padding(0, 0, 0, 0);
		transparentLabel.BringToFront();
		transparentLabel.Name = "Reserved " + tableModel_1.TableName;
		transparentLabel.TextAlign = ContentAlignment.TopCenter;
		transparentLabel.Click += ReservedLabel_click;
		transparentLabel.Visible = false;
		transparentLabel.Location = new Point(point.X - transparentLabel.Width / 2, point.Y - transparentLabel.Height / 2);
		PanelLayOut.Controls.Add(transparentLabel);
	}

	public void ReservedLabel_click(object sender, EventArgs e)
	{
		TransparentLabel transparentLabel_ = (TransparentLabel)sender;
		method_7(transparentLabel_);
	}

	private bool method_7(TransparentLabel transparentLabel_1, bool bool_1 = false)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_remov2, Resources.Remove_Reservation, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
			CS_0024_003C_003E8__locals0.tableName = transparentLabel_1.Name.Replace("Reserved ", "");
			TableModel tableModel = list_3.Where((TableModel l) => l.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault();
			if (tableModel != null)
			{
				gclass6_0 = new GClass6();
				tableModel.Status = TableStatus.Open;
				gclass6_0.Layouts.Where((Layout a) => a.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault().AppointmentID = null;
				Helper.SubmitChangesWithCatch(gclass6_0);
				transparentLabel_1.Visible = false;
				PanelLayOut.Invalidate();
				return true;
			}
		}
		PanelLayOut.Invalidate();
		return false;
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		PanelLayOut.SendToBack();
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		Station station = MemoryLoadedObjects.all_stations.Where((Station a) => a.StationID == 1).FirstOrDefault();
		List<OccupiedTable> source = orderMethods_0.OccupiedTables().ToList();
		using (List<TableModel>.Enumerator enumerator = list_3.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_0();
				CS_0024_003C_003E8__locals0.occupiedTable = enumerator.Current;
				_003C_003Ec__DisplayClass32_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass32_1();
				CS_0024_003C_003E8__locals1.occupiedTablesResult = source.Where((OccupiedTable t) => t.TableName == CS_0024_003C_003E8__locals0.occupiedTable.TableName).FirstOrDefault();
				Layout layout = gclass6_0.Layouts.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.occupiedTable.TableName).FirstOrDefault();
				CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = layout.CurrentGuests;
				if (CS_0024_003C_003E8__locals1.occupiedTablesResult != null)
				{
					if (CS_0024_003C_003E8__locals1.occupiedTablesResult.Customer == null)
					{
						CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Open;
					}
					else if (CS_0024_003C_003E8__locals1.occupiedTablesResult.Customer != null)
					{
						if (!CS_0024_003C_003E8__locals1.occupiedTablesResult.Cleared && CS_0024_003C_003E8__locals1.occupiedTablesResult.Paid)
						{
							CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Paid;
						}
						else
						{
							CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Ordered;
						}
					}
					else
					{
						CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Ordered;
					}
					if (station.EnablePrint)
					{
						continue;
					}
					var list = (from o in gclass6_0.Orders
						where o.Customer == "Table " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName && o.ItemMadeNotified == false && o.DateFilled.HasValue && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)
						select o into x
						group x by x.Customer into x
						select new
						{
							TableName = x.FirstOrDefault().Customer,
							StationId = x.FirstOrDefault().StationID
						}).ToList();
					if (list.Count > 0)
					{
						TransparentLabel transparentLabel = (TransparentLabel)PanelLayOut.Controls.Find("Label Food " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
						TransparentLabel transparentLabel2 = (TransparentLabel)PanelLayOut.Controls.Find("Label Drink " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
						var anon = list.FirstOrDefault();
						if (anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("1") && transparentLabel != null)
						{
							transparentLabel.Visible = true;
							transparentLabel.BringToFront();
						}
						else if (anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("2") && transparentLabel2 != null)
						{
							transparentLabel2.Visible = true;
							transparentLabel2.BringToFront();
						}
					}
					continue;
				}
				TransparentLabel transparentLabel3 = (TransparentLabel)PanelLayOut.Controls.Find("Reserved " + CS_0024_003C_003E8__locals0.occupiedTable.TableName, searchAllChildren: false).FirstOrDefault();
				if (layout.AppointmentID.HasValue)
				{
					CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = 0;
					CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Reserved;
					transparentLabel3.Visible = true;
					transparentLabel3.Text = "[" + layout.TableName + "] RESERVED\n" + layout.Appointment.CustomerName.ToUpper() + " @ " + layout.Appointment.StartDateTime.ToShortTimeString();
				}
				else
				{
					transparentLabel3.Visible = false;
					if (CS_0024_003C_003E8__locals0.occupiedTable.currentGuests > 0)
					{
						CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Seated;
						continue;
					}
					CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = 0;
					CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Open;
				}
			}
		}
		PanelLayOut.Invalidate();
		if (!frmMessageBox_0.Visible)
		{
			string empty = string.Empty;
			Appointment appointment = (from r in dataManager_0.getUpcomingReservations(DateTime.Now)
				where r.NextNotifyDateTime <= DateTime.Now && !r.ReminderDismissed
				select r).FirstOrDefault();
			if (appointment != null)
			{
				timer_0.Enabled = false;
				empty = string.Concat(Resources.Reservation, appointment.StartDateTime.DayOfWeek, " ", appointment.StartDateTime.ToString("MMMM"), " ", appointment.StartDateTime.Day, " @ ", appointment.StartDateTime.ToShortTimeString(), Resources._for0, appointment.NumOfPeople.ToString(), Resources._people, appointment.CustomerName, ".\n");
				frmMessageBox_0 = new frmMessageBox(empty, Resources.Reservation_Reminder, CustomMessageBoxButtons.DismissSnooze);
			}
			timer_0.Enabled = false;
		}
	}

	private void method_8(TableModel tableModel_1)
	{
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		List<OccupiedTable> list = orderMethods_0.OccupiedTables().ToList();
		if (tableModel_0 != null)
		{
			_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
			CS_0024_003C_003E8__locals0.layout = gclass6_0.Layouts.FirstOrDefault((Layout x) => ((int?)x.Rotation == (int?)86 || (int?)x.Rotation == (int?)72) && x.TableName == tableModel_0.TableName);
			TableModel tableModel = list_3.FirstOrDefault((TableModel tableModel_1) => tableModel_1.TableName == tableModel_0.TableName);
			OccupiedTable occupiedTable = (from a in orderMethods_0.OccupiedTables()
				where a.TableName == CS_0024_003C_003E8__locals0.layout.TableName
				select a).FirstOrDefault();
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(CS_0024_003C_003E8__locals0.layout.TableName);
			string status = TableStatus.Open;
			if (occupiedTable != null)
			{
				status = ((occupiedTable.Customer == null) ? TableStatus.Open : ((occupiedTable.Customer == null) ? TableStatus.Ordered : ((occupiedTable.Cleared || !occupiedTable.Paid) ? TableStatus.Ordered : TableStatus.Paid)));
			}
			else if (CS_0024_003C_003E8__locals0.layout.AppointmentID.HasValue)
			{
				status = TableStatus.Reserved;
			}
			else if (currentTableGuestCapacity > 0)
			{
				status = TableStatus.Seated;
			}
			if (tableModel != null)
			{
				tableModel.Status = status;
			}
			PanelLayOut.Invalidate();
		}
		if (tableModel_1.Status == TableStatus.Reserved)
		{
			TransparentLabel transparentLabel_ = (TransparentLabel)PanelLayOut.Controls.Find("Reserved " + tableModel_1.TableName, searchAllChildren: false).FirstOrDefault();
			if (!method_7(transparentLabel_))
			{
				return;
			}
		}
		bool flag = false;
		foreach (OccupiedTable item in list)
		{
			if (item.TableName == tableModel_1.TableName)
			{
				flag = true;
				break;
			}
		}
		if (flag && string_1 != tableModel_1.TableName)
		{
			if (tableModel_1.Status == TableStatus.Paid)
			{
				new frmMessageBox(Resources.Table0 + tableModel_1.TableName + Resources._must_be_cleared_before_allowing, Resources.OCCUPIED_TABLE).ShowDialog(this);
			}
			else
			{
				frmMessageBox obj = new frmMessageBox(Resources.Table0 + tableModel_1.TableName + Resources._is_already_occupuied_Would_yo, Resources.OCCUPIED_TABLE, CustomMessageBoxButtons.YesNo);
				obj.ShowDialog(this);
				if (obj.DialogResult == DialogResult.Yes)
				{
					int_2 += GuestMethods.GetCurrentTableGuestCapacity(tableModel_1.TableName);
					tableModel_1.Status = TableStatus.Ordered;
					flag = false;
					tableModel_0 = tableModel_1;
				}
			}
		}
		if (!flag || string_1 == tableModel_1.TableName)
		{
			int_3 = int_1;
			if (string_0 == OrderTypes.DineIn)
			{
				if (string_1 == tableModel_1.TableName)
				{
					new frmMessageBox(Resources.Table0 + tableModel_1.TableName + Resources._is_the_current_table_Please_c, Resources.TABLE_NAME).ShowDialog(this);
					return;
				}
				int totalTableGuestCapacity = GuestMethods.GetTotalTableGuestCapacity(tableModel_1.TableName);
				int num = (int)((double)totalTableGuestCapacity + 0.5 * (double)totalTableGuestCapacity);
				if (int_1 + int_2 > num)
				{
					frmMessageBox obj2 = new frmMessageBox(Resources.The_number_of_guests_is_over_t0, Resources.Warning1, CustomMessageBoxButtons.YesNo);
					obj2.ShowDialog(this);
					if (obj2.DialogResult == DialogResult.No)
					{
						return;
					}
				}
				int_0 = int_1 + int_2;
				lblOrderType.Text = Resources.CHANGED_TO_DINE_IN;
				lblCustomer.Text = "Table " + tableModel_1.TableName;
				string_0 = OrderTypes.DineIn;
				string_1 = tableModel_1.TableName;
				tableModel_1.Status = TableStatus.Ordered;
				tableModel_0 = tableModel_1;
			}
			else
			{
				short totalTableGuestCapacity2 = GuestMethods.GetTotalTableGuestCapacity(tableModel_1.TableName);
				frmPatronNum frmPatronNum2 = new frmPatronNum(totalTableGuestCapacity2);
				if (frmPatronNum2.ShowDialog() == DialogResult.OK)
				{
					int seat = frmPatronNum2.seat;
					if (seat > 0)
					{
						int num2 = (int)((double)totalTableGuestCapacity2 + 0.5 * (double)totalTableGuestCapacity2);
						if (seat > num2)
						{
							frmMessageBox obj3 = new frmMessageBox(Resources.The_number_of_guests_is_over_t0, Resources.Warning1, CustomMessageBoxButtons.YesNo);
							obj3.ShowDialog(this);
							if (obj3.DialogResult == DialogResult.No)
							{
								return;
							}
						}
						int_0 = seat;
						lblOrderType.Text = Resources.CHANGED_TO_DINE_IN;
						lblCustomer.Text = "Table " + tableModel_1.TableName;
						string_0 = OrderTypes.DineIn;
						string_1 = tableModel_1.TableName;
						tableModel_1.Status = TableStatus.Ordered;
						tableModel_0 = tableModel_1;
						int_3 = seat;
					}
					else
					{
						new frmMessageBox(Resources.The_number_of_guests_must_be_g, Resources.Invalid_Number0).ShowDialog(this);
					}
				}
			}
		}
		PanelLayOut.Invalidate();
	}

	private void btnLeft_Click(object sender, EventArgs e)
	{
		if (short_0 > 0)
		{
			short_0--;
			method_9();
			if (short_0 == 0)
			{
				btnLeft.Enabled = false;
			}
			else
			{
				btnLeft.Enabled = true;
			}
			if (short_0 == list_4.Count - 1)
			{
				btnRight.Enabled = false;
			}
			else
			{
				btnRight.Enabled = true;
			}
		}
	}

	private void btnRight_Click(object sender, EventArgs e)
	{
		if (short_0 < list_4.Count - 1)
		{
			short_0++;
			method_9();
			if (short_0 == 0)
			{
				btnLeft.Enabled = false;
			}
			else
			{
				btnLeft.Enabled = true;
			}
			if (short_0 == list_4.Count - 1)
			{
				btnRight.Enabled = false;
			}
			else
			{
				btnRight.Enabled = true;
			}
		}
	}

	private void method_9()
	{
		lblSectionName.Text = list_4[short_0];
		list_5 = gclass6_0.Layouts.Where((Layout x) => x.Section == lblSectionName.Text).ToList();
		method_4();
		timer_0_Tick(null, null);
	}

	private void btnLeft_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.BackColor = Color.Gray;
		}
		else
		{
			button.BackColor = Color.FromArgb(61, 142, 185);
		}
	}

	private void btnTakeOut_Click(object sender, EventArgs e)
	{
		string_0 = OrderTypes.ToGo;
		string_3 = string_1;
		lblOrderType.Text = "Order changed to TO-GO";
		lblCustomer.Text = OrderTypes.ToGo + " - " + Resources.Walk_In;
		new NotificationLabel(this, "ORDER CHANGE TO TO-GO", NotificationTypes.Success).Show();
	}

	private void pbZoomOut_Click(object sender, EventArgs e)
	{
		if (int_5 > 1)
		{
			int_5--;
			method_9();
		}
	}

	private void pbZoomIn_Click(object sender, EventArgs e)
	{
		if (int_5 < 9)
		{
			int_5++;
			method_9();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTableChange));
		timer_0 = new Timer(icontainer_1);
		lblTraining = new Label();
		panelNav = new Panel();
		pictureBoxGuest = new PictureBox();
		btnTakeOut = new Button();
		lblCustomer = new Label();
		lblOrderType = new Label();
		btnRight = new Button();
		btnLeft = new Button();
		lblSectionName = new Label();
		label2 = new Label();
		BtnClose = new Button();
		PanelLayOut = new Panel();
		pbZoomOut = new PictureBox();
		chairImage = new PictureBox();
		pbZoomIn = new PictureBox();
		benchImage = new PictureBox();
		plantImage = new PictureBox();
		lblTitle = new Label();
		panelNav.SuspendLayout();
		((ISupportInitialize)pictureBoxGuest).BeginInit();
		PanelLayOut.SuspendLayout();
		((ISupportInitialize)pbZoomOut).BeginInit();
		((ISupportInitialize)chairImage).BeginInit();
		((ISupportInitialize)pbZoomIn).BeginInit();
		((ISupportInitialize)benchImage).BeginInit();
		((ISupportInitialize)plantImage).BeginInit();
		SuspendLayout();
		timer_0.Interval = 15000;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		panelNav.BackColor = Color.FromArgb(35, 39, 56);
		panelNav.Controls.Add(pictureBoxGuest);
		panelNav.Controls.Add(btnTakeOut);
		panelNav.Controls.Add(lblCustomer);
		panelNav.Controls.Add(lblOrderType);
		panelNav.Controls.Add(btnRight);
		panelNav.Controls.Add(btnLeft);
		panelNav.Controls.Add(lblSectionName);
		panelNav.Controls.Add(label2);
		panelNav.Controls.Add(BtnClose);
		componentResourceManager.ApplyResources(panelNav, "panelNav");
		panelNav.Name = "panelNav";
		pictureBoxGuest.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(pictureBoxGuest, "pictureBoxGuest");
		pictureBoxGuest.Name = "pictureBoxGuest";
		pictureBoxGuest.TabStop = false;
		btnTakeOut.BackColor = Color.FromArgb(61, 142, 185);
		btnTakeOut.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnTakeOut.FlatAppearance.BorderSize = 0;
		btnTakeOut.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnTakeOut, "btnTakeOut");
		btnTakeOut.ForeColor = Color.White;
		btnTakeOut.Name = "btnTakeOut";
		btnTakeOut.UseVisualStyleBackColor = false;
		btnTakeOut.Click += btnTakeOut_Click;
		lblCustomer.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(lblCustomer, "lblCustomer");
		lblCustomer.ForeColor = Color.Black;
		lblCustomer.Name = "lblCustomer";
		lblOrderType.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(lblOrderType, "lblOrderType");
		lblOrderType.ForeColor = SystemColors.ButtonHighlight;
		lblOrderType.Name = "lblOrderType";
		btnRight.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(btnRight, "btnRight");
		btnRight.FlatAppearance.BorderColor = Color.Black;
		btnRight.FlatAppearance.BorderSize = 0;
		btnRight.FlatAppearance.MouseDownBackColor = Color.White;
		btnRight.ForeColor = Color.White;
		btnRight.Name = "btnRight";
		btnRight.UseVisualStyleBackColor = false;
		btnRight.EnabledChanged += btnLeft_EnabledChanged;
		btnRight.Click += btnRight_Click;
		btnLeft.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(btnLeft, "btnLeft");
		btnLeft.FlatAppearance.BorderColor = Color.Black;
		btnLeft.FlatAppearance.BorderSize = 0;
		btnLeft.FlatAppearance.MouseDownBackColor = Color.White;
		btnLeft.ForeColor = Color.White;
		btnLeft.Name = "btnLeft";
		btnLeft.UseVisualStyleBackColor = false;
		btnLeft.EnabledChanged += btnLeft_EnabledChanged;
		btnLeft.Click += btnLeft_Click;
		lblSectionName.BackColor = Color.Gray;
		lblSectionName.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblSectionName, "lblSectionName");
		lblSectionName.ForeColor = Color.Black;
		lblSectionName.Name = "lblSectionName";
		label2.BackColor = Color.DarkGray;
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = SystemColors.ButtonHighlight;
		label2.Name = "label2";
		BtnClose.BackColor = Color.FromArgb(65, 168, 95);
		BtnClose.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		componentResourceManager.ApplyResources(PanelLayOut, "PanelLayOut");
		PanelLayOut.BackColor = Color.Transparent;
		PanelLayOut.Controls.Add(chairImage);
		PanelLayOut.Controls.Add(benchImage);
		PanelLayOut.Controls.Add(plantImage);
		PanelLayOut.Name = "PanelLayOut";
		PanelLayOut.Paint += PanelLayOut_Paint;
		PanelLayOut.MouseClick += PanelLayOut_MouseClick;
		componentResourceManager.ApplyResources(pbZoomOut, "pbZoomOut");
		pbZoomOut.BackColor = Color.Transparent;
		pbZoomOut.Name = "pbZoomOut";
		pbZoomOut.TabStop = false;
		pbZoomOut.Click += pbZoomOut_Click;
		componentResourceManager.ApplyResources(chairImage, "chairImage");
		chairImage.BackColor = Color.Transparent;
		chairImage.Name = "chairImage";
		chairImage.TabStop = false;
		componentResourceManager.ApplyResources(pbZoomIn, "pbZoomIn");
		pbZoomIn.BackColor = Color.Transparent;
		pbZoomIn.Name = "pbZoomIn";
		pbZoomIn.TabStop = false;
		pbZoomIn.Click += pbZoomIn_Click;
		componentResourceManager.ApplyResources(benchImage, "benchImage");
		benchImage.BackColor = Color.Transparent;
		benchImage.Name = "benchImage";
		benchImage.TabStop = false;
		componentResourceManager.ApplyResources(plantImage, "plantImage");
		plantImage.BackColor = Color.Transparent;
		plantImage.Name = "plantImage";
		plantImage.TabStop = false;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(pbZoomOut);
		base.Controls.Add(lblTraining);
		base.Controls.Add(panelNav);
		base.Controls.Add(pbZoomIn);
		base.Controls.Add(lblTitle);
		base.Controls.Add(PanelLayOut);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmTableChange";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		panelNav.ResumeLayout(performLayout: false);
		((ISupportInitialize)pictureBoxGuest).EndInit();
		PanelLayOut.ResumeLayout(performLayout: false);
		((ISupportInitialize)pbZoomOut).EndInit();
		((ISupportInitialize)chairImage).EndInit();
		((ISupportInitialize)pbZoomIn).EndInit();
		((ISupportInitialize)benchImage).EndInit();
		((ISupportInitialize)plantImage).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_10(TableModel tableModel_1)
	{
		return tableModel_1.Section == lblSectionName.Text;
	}

	[CompilerGenerated]
	private bool method_11(Layout layout_0)
	{
		if (layout_0.Active)
		{
			return layout_0.Section == lblSectionName.Text;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_12(TableModel tableModel_1)
	{
		return tableModel_1.TableName == tableModel_0.TableName;
	}
}
