using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmLayout : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public Func<Control, bool> isMatch;

		public List<Control> matches;

		public Action<Control> filter;

		public _003C_003Ec__DisplayClass33_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CFilterControls_003Eb__0(Control c)
		{
			if (isMatch(c))
			{
				matches.Add(c);
			}
			foreach (Control control in c.Controls)
			{
				filter(control);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public Terminal terminal;

		public _003C_003Ec__DisplayClass36_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CSetButtonLeftRight_003Eb__0(string a)
		{
			return a == terminal.DefaultLayoutSectionName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public Layout layout;

		public _003C_003Ec__DisplayClass41_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CLoadAllTables_003Eb__1(OccupiedTable a)
		{
			return a.TableName.Trim() == layout.TableName.Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public TableModel occupiedTable;

		public _003C_003Ec__DisplayClass49_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CTimer1_Tick_003Eb__5(OccupiedTable t)
		{
			return t.TableName == occupiedTable.TableName;
		}

		internal bool _003CTimer1_Tick_003Eb__6(Layout l)
		{
			return l.TableName == occupiedTable.TableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_1
	{
		public OccupiedTable occupiedTablesResult;

		public Layout layout;

		public _003C_003Ec__DisplayClass49_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CTimer1_Tick_003Eb__7(Order o)
		{
			if (o.Customer == "Table " + occupiedTablesResult.TableName)
			{
				return !o.ItemMadeNotified;
			}
			return false;
		}

		internal bool _003CTimer1_Tick_003Eb__10(Appointment x)
		{
			return x.AppointmentID == layout.AppointmentID.Value;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_2
	{
		public string tableName;

		public _003C_003Ec__DisplayClass49_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CTimer1_Tick_003Eb__11(TableModel l)
		{
			return l.TableName == tableName;
		}

		internal bool _003CTimer1_Tick_003Eb__12(Layout a)
		{
			return a.TableName == tableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public string customer;

		public string _OrderNumber;

		public _003C_003Ec__DisplayClass50_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public string customer;

		public _003C_003Ec__DisplayClass51_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CClearOccupiedTable_003Eb__0(TableModel l)
		{
			return l.TableName == customer.Replace("Table", string.Empty).Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public TableModel table;

		public _003C_003Ec__DisplayClass52_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public string tableName;

		public _003C_003Ec__DisplayClass63_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_1
	{
		public string tableName;

		public _003C_003Ec__DisplayClass63_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public string tableName;

		public _003C_003Ec__DisplayClass65_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CclearReservationOnTable_003Eb__0(TableModel l)
		{
			return l.TableName == tableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass70_0
	{
		public string tblName;

		public _003C_003Ec__DisplayClass70_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CReCalControlLocation_003Eb__2(KeyValuePair<string, Point> x)
		{
			return x.Key == tblName;
		}
	}

	private static int int_0;

	private string[] string_0;

	private short short_0;

	private OrderMethods orderMethods_0;

	private DataManager dataManager_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private int int_5;

	private bool bool_4;

	private bool bool_5;

	private frmReservations frmReservations_0;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private List<Layout> list_2;

	private List<TableModel> list_3;

	private List<string> list_4;

	private Dictionary<string, Point> dictionary_0;

	private GClass6 gclass6_0;

	private bool bool_9;

	private List<Layout> list_5;

	private frmMessageBox frmMessageBox_0;

	private Employee employee_0;

	private bool bool_10;

	private bool bool_11;

	private IContainer icontainer_1;

	internal Button btnLock;

	internal Button BtnClose;

	internal System.Windows.Forms.Timer timer_0;

	internal Button btnTakeOut;

	private Label lblTraining;

	internal Button btnReservations;

	private Panel panelNav;

	private Label lblEmployee;

	internal Panel PanelLayOut;

	private Label lblSectionName;

	internal Button btnRight;

	internal Button btnLeft;

	private Label lblStationLocked;

	private Label lblCapacity;

	internal System.Windows.Forms.Timer timer_1;

	private PictureBox pictureBoxGuest;

	internal Button btnEditLayout;

	private PictureBox picDrink;

	private PictureBox picFood;

	internal Button btnUnLock;

	private PictureBox pbZoomOut;

	private PictureBox pbZoomIn;

	private PictureBox benchImage;

	private PictureBox plantImage;

	private PictureBox chairImage;

	private PictureBox pbRefresh;

	internal Button btnOpenRegister;

	private System.Windows.Forms.Timer timer_2;

	internal Button btnWaitList;

	internal System.Windows.Forms.Timer timer_3;

	internal Button btnAssignEmployee;

	private Label lblAssignEmployee;

	internal System.Windows.Forms.Timer timer_4;

	internal Button btnChangeLanguage;

	internal System.Windows.Forms.Timer timer_5;

	internal System.Windows.Forms.Timer timer_6;

	private PictureBox picReservationPopup;

	private PictureBox picTempReserve;

	internal System.Windows.Forms.Timer timer_7;

	private PictureBox picTempOnlineOrder;

	public frmLayout()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = new string[200];
		int_1 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		int_5 = 5;
		list_2 = new List<Layout>();
		list_3 = new List<TableModel>();
		list_4 = new List<string>();
		dictionary_0 = new Dictionary<string, Point>();
		gclass6_0 = new GClass6();
		frmMessageBox_0 = new frmMessageBox("");
		base._002Ector();
		frmLoadingBar.ShowSplashScreen();
		frmLoadingBar.SetPercentage(1);
		InitializeComponent_1();
		frmLoadingBar.SetPercentage(10);
		frmLoadingBar.SetPercentage(92);
		frmLoadingBar.SetPercentage(100);
		frmLoadingBar.CloseForm();
		if (SettingsHelper.CurrentTerminalMode != "Patron")
		{
			timer_5.Enabled = false;
		}
	}

	public void LoadFormData()
	{
		base.WindowState = FormWindowState.Maximized;
		list_5 = gclass6_0.Layouts.Where((Layout x) => x.Section == lblSectionName.Text).ToList();
		Terminal this_terminal = MemoryLoadedObjects.this_terminal;
		if (this_terminal != null)
		{
			int_5 = (this_terminal.LayoutZoomValue.HasValue ? this_terminal.LayoutZoomValue.Value : 5);
		}
		new FormHelper().ResizeButtonFonts(this);
		employee_0 = null;
		employee_0 = AuthMethods.EmployeeLoginBeforeFormControl(this, base.Name);
		if (employee_0 == null)
		{
			return;
		}
		short roleID = employee_0.Users.FirstOrDefault().RoleID;
		if (roleID == RoleIDs.patron || roleID == RoleIDs.kiosk)
		{
			btnOpenRegister.Visible = false;
			btnWaitList.Visible = false;
			btnReservations.Visible = false;
			btnLock.Visible = false;
			btnUnLock.Visible = false;
			btnEditLayout.Visible = false;
			btnTakeOut.Visible = true;
			btnTakeOut.Location = new Point(btnAssignEmployee.Location.X + btnAssignEmployee.Width + 1, btnTakeOut.Location.Y);
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("primary_language");
			string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("secondary_language");
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = currentCulture;
			Thread.CurrentThread.CurrentUICulture = currentCulture;
			if (settingValueByKey != settingValueByKey2)
			{
				btnChangeLanguage.Visible = true;
				btnChangeLanguage.Location = new Point(btnTakeOut.Location.X + btnTakeOut.Width + 1, btnChangeLanguage.Location.Y);
				BtnClose.Location = new Point(btnChangeLanguage.Location.X + btnChangeLanguage.Width + 1, BtnClose.Location.Y);
			}
			else
			{
				BtnClose.Location = new Point(btnTakeOut.Location.X + btnTakeOut.Width + 1, BtnClose.Location.Y);
			}
		}
		list_4 = new List<string>();
		method_6();
		method_17();
		string settingValueByKey3 = SettingsHelper.GetSettingValueByKey("restaurant_capacity");
		if (!string.IsNullOrEmpty(settingValueByKey3) && settingValueByKey3 == "ON")
		{
			bool_9 = true;
		}
		else
		{
			bool_9 = false;
		}
		bool_7 = ((SettingsHelper.GetSettingValueByKey("lock_table_staff").ToUpper() == "ON") ? true : false);
		timer_2.Enabled = ((SettingsHelper.GetSettingValueByKey("auto_lock_layout").ToUpper() == "ON") ? true : false);
		ShowEmptyOrderEntry();
		if (SettingsHelper.GetSettingValueByKey("auto_clear_table") == "ON")
		{
			bool_8 = true;
		}
		else
		{
			bool_8 = false;
		}
		if (SettingsHelper.GetSettingValueByKey("tip_tracking") == "ON")
		{
			bool_2 = true;
		}
		else
		{
			bool_2 = false;
		}
		if (bool_8)
		{
			foreach (TableModel item in list_3)
			{
				if (item.Status == TableStatus.Paid)
				{
					ClearOccupiedTable(item.TableName);
				}
			}
		}
		method_3();
	}

	public void LoadDefaultValues()
	{
		lblTraining.Show();
		if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Hide();
		}
		int_1 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		bool_3 = false;
		lblAssignEmployee.Visible = false;
		method_17();
		method_3();
	}

	private void method_3()
	{
		MemoryLoadedData.ListOfItemsInGroupMemory = new GClass6().ItemsInGroups.Where((ItemsInGroup a) => a.Item.isDeleted == false && a.Item.Active == true).ToList();
	}

	private Control[] method_4(Control control_0, Func<Control, bool> func_0)
	{
		_003C_003Ec__DisplayClass33_0 _003C_003Ec__DisplayClass33_ = new _003C_003Ec__DisplayClass33_0();
		_003C_003Ec__DisplayClass33_.isMatch = func_0;
		_003C_003Ec__DisplayClass33_.matches = new List<Control>();
		_003C_003Ec__DisplayClass33_.filter = null;
		(_003C_003Ec__DisplayClass33_.filter = delegate(Control c)
		{
			if (_003C_003Ec__DisplayClass33_.isMatch(c))
			{
				_003C_003Ec__DisplayClass33_.matches.Add(c);
			}
			foreach (Control control in c.Controls)
			{
				_003C_003Ec__DisplayClass33_.filter(control);
			}
		})(control_0);
		return _003C_003Ec__DisplayClass33_.matches.ToArray();
	}

	public void ShowEmptyOrderEntry()
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("second_screen");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (AppSettings.ScreenCount >= 2 && settingValueByKey == "ON")
			{
				if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
				{
					MemoryLoadedObjects.OrderEntrySecondScreen.ResetValues();
					return;
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntrySecondScreen();
				Rectangle bounds = AppSettings.SecondaryScreen.Bounds;
				MemoryLoadedObjects.OrderEntrySecondScreen.WindowState = FormWindowState.Normal;
				MemoryLoadedObjects.OrderEntrySecondScreen.TopMost = true;
				MemoryLoadedObjects.OrderEntrySecondScreen.Size = new Size(bounds.Width, bounds.Height);
				MemoryLoadedObjects.OrderEntrySecondScreen.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
				MemoryLoadedObjects.OrderEntrySecondScreen.StartPosition = FormStartPosition.Manual;
				MemoryLoadedObjects.OrderEntrySecondScreen.Show();
			}
			else
			{
				MemoryLoadedObjects.OrderEntrySecondScreen = null;
			}
		}
		else
		{
			MemoryLoadedObjects.OrderEntrySecondScreen = null;
		}
	}

	private void frmLayout_Load(object sender, EventArgs e)
	{
		int_1 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
	}

	private void method_5()
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		btnLeft.Enabled = false;
		btnRight.Enabled = true;
		CS_0024_003C_003E8__locals0.terminal = MemoryLoadedObjects.this_terminal;
		if (CS_0024_003C_003E8__locals0.terminal != null)
		{
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.terminal.DefaultLayoutSectionName))
			{
				int num = list_4.FindIndex((string a) => a == CS_0024_003C_003E8__locals0.terminal.DefaultLayoutSectionName);
				if (num != -1)
				{
					short_0 = (short)num;
					if (short_0 == 0)
					{
						btnLeft.Enabled = false;
						btnRight.Enabled = true;
					}
					else if (short_0 > 0)
					{
						btnLeft.Enabled = true;
						btnRight.Enabled = true;
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
				else if (list_4.Count > 1)
				{
					btnRight.Enabled = true;
				}
				else
				{
					btnRight.Enabled = false;
				}
			}
			else if (list_4.Count > 1)
			{
				btnRight.Enabled = true;
			}
			else
			{
				btnRight.Enabled = false;
			}
		}
		else if (list_4.Count > 1)
		{
			btnRight.Enabled = true;
		}
		else
		{
			btnRight.Enabled = false;
		}
	}

	private void method_6()
	{
		gclass6_0 = new GClass6();
		orderMethods_0 = new OrderMethods();
		dataManager_0 = new DataManager(gclass6_0);
		btnRight.Visible = false;
		btnLeft.Visible = false;
		PanelLayOut.SendToBack();
		method_5();
		method_17();
		lblEmployee.BringToFront();
		pbZoomIn.BringToFront();
		pbZoomOut.BringToFront();
		pbRefresh.BringToFront();
		pbZoomIn.Visible = true;
		pbZoomOut.Visible = true;
		pbRefresh.Visible = true;
		btnRight.Visible = true;
		btnLeft.Visible = true;
		bool_6 = true;
		RefreshLayout();
	}

	private void frmLayout_Activated(object sender, EventArgs e)
	{
		timer_0.Enabled = true;
		timer_1.Enabled = true;
		method_14();
		if (orderMethods_0 != null && bool_6)
		{
			timer_0_Tick(null, null);
		}
		if (Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]) == 0 && !bool_10)
		{
			bool_10 = true;
			try
			{
				employee_0 = AuthMethods.EmployeeLoginFormControl(this, "");
				if (employee_0 != null)
				{
					int_1 = employee_0.EmployeeID;
				}
				method_17();
			}
			catch
			{
			}
			bool_10 = false;
		}
		if (MemoryLoadedObjects.OrderEntry != null && MemoryLoadedObjects.OrderEntry.Visible)
		{
			MemoryLoadedObjects.OrderEntry.HideOrderEntry();
		}
	}

	private void frmLayout_VisibleChanged(object sender, EventArgs e)
	{
		timer_0.Enabled = base.Visible;
		timer_1.Enabled = base.Visible;
	}

	private void method_7()
	{
		PanelLayOut.Controls.Clear();
		PanelLayOut.Invalidate();
		PanelLayOut.Update();
		PanelLayOut.Controls.Add(lblStationLocked);
		PanelLayOut.Controls.Add(lblAssignEmployee);
		PanelLayOut.Controls.Add(lblTraining);
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		List<Layout> list = list_5.Where((Layout layout_0) => layout_0.Active && layout_0.Section == lblSectionName.Text).ToList();
		int num = 0;
		list_2.Clear();
		list_3.Clear();
		int num2 = 30;
		List<OccupiedTable> source = orderMethods_0.OccupiedTables().ToList();
		using (List<Layout>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
				CS_0024_003C_003E8__locals0.layout = enumerator.Current;
				if (CS_0024_003C_003E8__locals0.layout.Rotation != 'V' && CS_0024_003C_003E8__locals0.layout.Rotation != 'H')
				{
					list_2.Add(CS_0024_003C_003E8__locals0.layout);
				}
				else
				{
					OccupiedTable occupiedTable = source.Where((OccupiedTable a) => a.TableName.Trim() == CS_0024_003C_003E8__locals0.layout.TableName.Trim()).FirstOrDefault();
					int num3 = occupiedTable?.GuestCount ?? 0;
					string text = TableStatus.Open;
					if (occupiedTable != null)
					{
						text = ((occupiedTable.Customer == null) ? TableStatus.Open : ((occupiedTable.Customer == null) ? TableStatus.Ordered : ((occupiedTable.Cleared || !occupiedTable.Paid) ? TableStatus.Ordered : TableStatus.Paid)));
					}
					else if (CS_0024_003C_003E8__locals0.layout.AppointmentID.HasValue)
					{
						text = TableStatus.Reserved;
					}
					else if (num3 > 0)
					{
						text = TableStatus.Seated;
					}
					string employeeBytable = GuestMethods.GetEmployeeBytable(text, CS_0024_003C_003E8__locals0.layout.EmployeeID);
					TableModel tableModel = new TableModel
					{
						TableName = CS_0024_003C_003E8__locals0.layout.TableName.Trim(),
						isRound = CS_0024_003C_003E8__locals0.layout.Round,
						currentGuests = num3,
						angleOfRotation = CS_0024_003C_003E8__locals0.layout.AngleOfRotation,
						Location = new Point(CS_0024_003C_003E8__locals0.layout.X.Value, CS_0024_003C_003E8__locals0.layout.Y.Value),
						Section = CS_0024_003C_003E8__locals0.layout.Section,
						TotalCapacity = CS_0024_003C_003E8__locals0.layout.NumOfSeats.Value,
						Status = text,
						layout = CS_0024_003C_003E8__locals0.layout,
						EmployeeAssigned = employeeBytable
					};
					list_3.Add(tableModel);
					num++;
					method_8(tableModel);
				}
				if (num2 <= 90)
				{
					num2 += 2;
					frmLoadingBar.SetPercentage(num2);
				}
			}
		}
		method_19();
		if (int_5 != 5)
		{
			method_20();
		}
	}

	private void method_8(TableModel tableModel_0)
	{
		int num = tableModel_0.TotalCapacity;
		if (num <= 2)
		{
			num++;
		}
		double num2 = 1.0;
		int val = (int)((double)(15 * num) * num2);
		int num3 = Math.Max(40, val);
		Size size = new Size(num3 * 2 + num3 / 2, num3 * 2 + num3 / 2);
		int num4 = (int)((double)(size.Width / 2) + (double)tableModel_0.Location.X * num2);
		int num5 = (int)((double)(size.Height / 2) + (double)tableModel_0.Location.Y * num2);
		Point point = new Point(num4, num5);
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
		transparentLabel.Name = "Reserved " + tableModel_0.TableName;
		transparentLabel.TextAlign = ContentAlignment.TopCenter;
		transparentLabel.Visible = false;
		transparentLabel.Location = new Point(point.X - transparentLabel.Width / 2, point.Y - transparentLabel.Height / 2);
		if (tableModel_0.isRound)
		{
			transparentLabel.Location = new Point((int)((double)tableModel_0.Location.X * num2), (int)((double)tableModel_0.Location.Y * num2));
		}
		PanelLayOut.Controls.Add(transparentLabel);
		transparentLabel.Click += ReservedLabel_click;
		int num6 = (int)(double)(60 + num * 4);
		int capacityLabelWidth = GraphicHelpers.GetCapacityLabelWidth(((tableModel_0.currentGuests < 0) ? "0" : tableModel_0.currentGuests.ToString()) + "/" + tableModel_0.TotalCapacity);
		Size capacity = new Size(capacityLabelWidth, 20);
		Point capacityLocationRectTable;
		if (!tableModel_0.isRound)
		{
			tableModel_0.layout.X = (int)((double)tableModel_0.layout.X.Value * num2);
			tableModel_0.layout.Y = (int)((double)tableModel_0.layout.Y.Value * num2);
			capacityLocationRectTable = GraphicHelpers.GetCapacityLocationRectTable(GraphicHelpers.GetFourPolygonPoints(tableModel_0.layout, out var _, num2), capacity);
		}
		else
		{
			Point point2 = new Point(tableModel_0.layout.X.Value, tableModel_0.layout.Y.Value);
			Point point3 = new Point(tableModel_0.layout.X.Value + num6, tableModel_0.layout.Y.Value);
			Point point4 = new Point(tableModel_0.layout.X.Value, tableModel_0.layout.Y.Value + num6);
			Point point5 = new Point(tableModel_0.layout.X.Value + num6, tableModel_0.layout.Y.Value + num6);
			capacityLocationRectTable = GraphicHelpers.GetCapacityLocationRectTable(new Point[4] { point2, point3, point4, point5 }, capacity);
		}
		if (SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON")
		{
			PictureBox pictureBox = new PictureBox();
			pictureBox.Name = "Pic Food " + tableModel_0.TableName;
			pictureBox.Image = picFood.Image;
			pictureBox.Size = picFood.Size;
			pictureBox.SizeMode = picFood.SizeMode;
			pictureBox.BackColor = Color.Transparent;
			pictureBox.Click += method_15;
			pictureBox.Visible = false;
			pictureBox.Location = new Point(capacityLocationRectTable.X - pictureBox.Size.Width + 3, capacityLocationRectTable.Y - 10);
			pictureBox.BringToFront();
			PanelLayOut.Controls.Add(pictureBox);
		}
		if (SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON")
		{
			PictureBox pictureBox2 = new PictureBox();
			pictureBox2.Name = "Pic Drink " + tableModel_0.TableName;
			pictureBox2.Image = picDrink.Image;
			pictureBox2.Size = picDrink.Size;
			pictureBox2.SizeMode = picDrink.SizeMode;
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Click += method_15;
			pictureBox2.Location = new Point(capacityLocationRectTable.X - pictureBox2.Size.Width + 3, capacityLocationRectTable.Y - 10);
			pictureBox2.Visible = false;
			PanelLayOut.Controls.Add(pictureBox2);
		}
	}

	private void PanelLayOut_MouseClick(object sender, MouseEventArgs e)
	{
		Panel obj = (Panel)sender;
		Point p = new Point(Cursor.Position.X + PanelLayOut.HorizontalScroll.Value, Cursor.Position.Y + PanelLayOut.VerticalScroll.Value);
		Point point = obj.PointToClient(p);
		double num = (double)int_5 / 5.0 - 0.1 * ((double)int_5 - 5.0);
		foreach (TableModel item in list_3.Where((TableModel tableModel_0) => tableModel_0.Section == lblSectionName.Text))
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
					method_10(item);
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
					method_10(item);
					break;
				}
			}
		}
	}

	private void PanelLayOut_Paint(object sender, PaintEventArgs e)
	{
		dictionary_0 = GraphicHelpers.DrawLayout(sender, e, list_2, list_3, lblSectionName.Text, pictureBoxGuest.Image, plantImage.Image, benchImage.Image, chairImage.Image, int_5, bool_9);
	}

	private void method_9()
	{
		GClass6 gClass = new GClass6();
		list_4 = gClass.Layouts.Select((Layout l) => l.Section).Distinct().ToList();
	}

	private void btnTakeOut_Click(object sender, EventArgs e)
	{
		ShowOnlineOrderNotification(show: false);
		method_22();
		if (SettingsHelper.CurrentTerminalMode == "Patron")
		{
			frmPatron obj = new frmPatron();
			obj.LoadFormData(null, Resources.Walk_In, OrderTypes.ToGo);
			obj.ShowDialog();
			obj.Dispose();
		}
		else
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.MultiBills();
			MemoryLoadedObjects.MultiBills.LoadFormData(this, OrderTypes.PickUp, OrderTypes.PickUp);
			MemoryLoadedObjects.MultiBills.ShowDialog();
		}
		GC.Collect();
	}

	private void btnLock_Click(object sender, EventArgs e)
	{
		timer_2.Stop();
		method_23();
		Button button = (Button)sender;
		if (!(button.Text.ToUpper() == Resources.LOCK_SCREEN))
		{
			return;
		}
		foreach (Control control3 in PanelLayOut.Controls)
		{
			if (control3.GetType() != button.GetType() || (control3.Text != Resources.UNLOCK_SCREEN && control3.Text != Resources.LOCK_SCREEN))
			{
				control3.Enabled = false;
			}
		}
		foreach (Control control4 in panelNav.Controls)
		{
			if (control4.GetType() == button.GetType() && control4.Text != Resources.UNLOCK_SCREEN && control4.Text != Resources.LOCK_SCREEN)
			{
				control4.Enabled = false;
			}
		}
		pbRefresh.Enabled = false;
		pbZoomIn.Enabled = false;
		pbZoomOut.Enabled = false;
		PanelLayOut.Enabled = false;
		lblStationLocked.Visible = true;
		lblStationLocked.BringToFront();
		btnLock.Visible = false;
		btnUnLock.Visible = true;
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode == "Patron")
		{
			ModulesAndFeature modulesAndFeature = gclass6_0.ModulesAndFeatures.Where((ModulesAndFeature x) => x.ModuleName == "frmSplash" && x.ControlName == "btnClose").FirstOrDefault();
			if (modulesAndFeature != null)
			{
				List<SecurityMatrix> list = modulesAndFeature.SecurityMatrixes.Where((SecurityMatrix x) => x.IsAllow).ToList();
				List<string> list2 = new List<string>();
				using (List<SecurityMatrix>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						switch (enumerator.Current.RoleID)
						{
						case 1:
							list2.Add(Roles.admin);
							break;
						case 2:
							list2.Add(Roles.manager);
							break;
						case 3:
							list2.Add(Roles.employee);
							break;
						case 6:
							list2.Add(Roles.supervisor);
							break;
						}
					}
				}
				if (list2.Count() != 0 && AuthMethods.ValidatePin(this, list2))
				{
					FormHelper.CleanupObjects();
					Application.Exit();
				}
			}
			else
			{
				FormHelper.CleanupObjects();
				Application.Exit();
			}
		}
		else
		{
			AuthMethods.LogOutUser();
			if (MemoryLoadedObjects.OrderEntry != null && MemoryLoadedObjects.OrderEntry.Visible)
			{
				MemoryLoadedObjects.OrderEntry.HideOrderEntry();
			}
			Hide();
			GC.Collect();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (MemoryLoadedObjects.OrderEntry.Visible || Application.OpenForms["frmPay"] != null || Application.OpenForms["frmPayFinish"] != null || !bool_6)
		{
			return;
		}
		dataManager_0 = new DataManager();
		int_3 = GuestMethods.GetTotalGuestCapacity();
		int_4 = GuestMethods.GetCurrentGuestCapacity();
		lblCapacity.Text = int_4 + "/" + int_3;
		List<Appointment> upcomingReservations = dataManager_0.getUpcomingReservations(DateTime.Now);
		List<Appointment> upcomingWaitingList = dataManager_0.getUpcomingWaitingList();
		List<Appointment> source = upcomingReservations.AsQueryable().Union(upcomingWaitingList.AsQueryable()).ToList();
		PanelLayOut.SendToBack();
		if (lblStationLocked.Visible)
		{
			btnTakeOut.Enabled = false;
		}
		gclass6_0 = new GClass6();
		list_5 = gclass6_0.Layouts.Where((Layout x) => x.Section == lblSectionName.Text).ToList();
		List<OccupiedTable> source2 = orderMethods_0.OccupiedTables().ToList();
		List<Order> source3 = new List<Order>();
		if (SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON" || SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON")
		{
			source3 = gclass6_0.Orders.Where((Order o) => o.DateFilled.HasValue && o.OrderType == "Dine In" && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && o.ShareItemID == null).ToList();
		}
		bool flag = false;
		using (List<TableModel>.Enumerator enumerator = list_3.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
				CS_0024_003C_003E8__locals0.occupiedTable = enumerator.Current;
				_003C_003Ec__DisplayClass49_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass49_1();
				CS_0024_003C_003E8__locals1.occupiedTablesResult = source2.Where((OccupiedTable t) => t.TableName == CS_0024_003C_003E8__locals0.occupiedTable.TableName).FirstOrDefault();
				CS_0024_003C_003E8__locals1.layout = list_5.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.occupiedTable.TableName).FirstOrDefault();
				if (CS_0024_003C_003E8__locals1.layout == null)
				{
					continue;
				}
				CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = CS_0024_003C_003E8__locals1.layout.CurrentGuests;
				TransparentLabel transparentLabel = (TransparentLabel)PanelLayOut.Controls.Find("Reserved " + CS_0024_003C_003E8__locals0.occupiedTable.TableName, searchAllChildren: false).FirstOrDefault();
				if (CS_0024_003C_003E8__locals1.occupiedTablesResult != null)
				{
					transparentLabel.Visible = false;
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
					if (CS_0024_003C_003E8__locals0.occupiedTable.Status != TableStatus.Paid && (SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON" || SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON"))
					{
						var list = (from o in source3
							where o.Customer == "Table " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName && !o.ItemMadeNotified
							select o into x
							group x by x.Customer into x
							select new
							{
								TableName = x.FirstOrDefault().Customer,
								StationId = x.FirstOrDefault().StationID
							}).ToList();
						if (list.Count > 0)
						{
							PictureBox pictureBox = (PictureBox)PanelLayOut.Controls.Find("Pic Food " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
							PictureBox pictureBox2 = (PictureBox)PanelLayOut.Controls.Find("Pic Drink " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
							var anon = list.FirstOrDefault();
							if (SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON" && anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("1") && pictureBox != null)
							{
								pictureBox.Visible = true;
								pictureBox.BringToFront();
							}
							else if (SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON" && anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("2") && pictureBox2 != null)
							{
								pictureBox2.Visible = true;
								pictureBox2.BringToFront();
							}
						}
					}
					else
					{
						PictureBox pictureBox3 = (PictureBox)PanelLayOut.Controls.Find("Pic Food " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
						PictureBox pictureBox4 = (PictureBox)PanelLayOut.Controls.Find("Pic Drink " + CS_0024_003C_003E8__locals1.occupiedTablesResult.TableName, searchAllChildren: false).FirstOrDefault();
						if (pictureBox3 != null && pictureBox3.Visible)
						{
							pictureBox3.Visible = false;
						}
						if (pictureBox4 != null && pictureBox4.Visible)
						{
							pictureBox4.Visible = false;
						}
					}
				}
				else
				{
					if (CS_0024_003C_003E8__locals1.layout.AppointmentID.HasValue)
					{
						CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = 0;
						CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Reserved;
						transparentLabel.Visible = true;
						string text = ((CS_0024_003C_003E8__locals1.layout.Appointment.CustomerName.Length > 10) ? "\n" : "");
						if (source.Where((Appointment x) => x.AppointmentID == CS_0024_003C_003E8__locals1.layout.AppointmentID.Value).Count() > 0)
						{
							transparentLabel.Text = "[" + CS_0024_003C_003E8__locals1.layout.TableName + "] RESERVED\n" + CS_0024_003C_003E8__locals1.layout.Appointment.CustomerName.ToUpper() + text + " @ " + CS_0024_003C_003E8__locals1.layout.Appointment.StartDateTime.ToShortTimeString();
						}
						else
						{
							_003C_003Ec__DisplayClass49_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass49_2();
							CS_0024_003C_003E8__locals2.tableName = transparentLabel.Name.Replace("Reserved ", "");
							TableModel tableModel = list_3.Where((TableModel l) => l.TableName == CS_0024_003C_003E8__locals2.tableName).FirstOrDefault();
							if (tableModel != null)
							{
								tableModel.Status = TableStatus.Open;
								list_5.Where((Layout a) => a.TableName == CS_0024_003C_003E8__locals2.tableName).FirstOrDefault().Appointment = null;
								Helper.SubmitChangesWithCatch(gclass6_0);
								transparentLabel.Visible = false;
							}
						}
					}
					else
					{
						transparentLabel.Visible = false;
						if (CS_0024_003C_003E8__locals0.occupiedTable.currentGuests > 0)
						{
							CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Seated;
						}
						else
						{
							CS_0024_003C_003E8__locals0.occupiedTable.currentGuests = 0;
							CS_0024_003C_003E8__locals0.occupiedTable.Status = TableStatus.Open;
						}
					}
					PictureBox pictureBox5 = (PictureBox)PanelLayOut.Controls.Find("Pic Food " + CS_0024_003C_003E8__locals0.occupiedTable.TableName, searchAllChildren: false).FirstOrDefault();
					PictureBox pictureBox6 = (PictureBox)PanelLayOut.Controls.Find("Pic Drink " + CS_0024_003C_003E8__locals0.occupiedTable.TableName, searchAllChildren: false).FirstOrDefault();
					if (pictureBox5 != null && pictureBox5.Visible)
					{
						pictureBox5.Visible = false;
					}
					if (pictureBox6 != null && pictureBox6.Visible)
					{
						pictureBox6.Visible = false;
					}
				}
				CS_0024_003C_003E8__locals0.occupiedTable.EmployeeAssigned = GuestMethods.GetEmployeeBytable(CS_0024_003C_003E8__locals0.occupiedTable.Status, CS_0024_003C_003E8__locals1.layout.EmployeeID);
				if (!flag && (CS_0024_003C_003E8__locals0.occupiedTable.isRound != CS_0024_003C_003E8__locals1.layout.Round || CS_0024_003C_003E8__locals0.occupiedTable.Location.X != CS_0024_003C_003E8__locals1.layout.X.Value || CS_0024_003C_003E8__locals0.occupiedTable.Location.Y != CS_0024_003C_003E8__locals1.layout.Y || CS_0024_003C_003E8__locals0.occupiedTable.Section != CS_0024_003C_003E8__locals1.layout.Section || CS_0024_003C_003E8__locals0.occupiedTable.TotalCapacity != CS_0024_003C_003E8__locals1.layout.NumOfSeats || CS_0024_003C_003E8__locals0.occupiedTable.angleOfRotation != CS_0024_003C_003E8__locals1.layout.AngleOfRotation || CS_0024_003C_003E8__locals0.occupiedTable.TableName != CS_0024_003C_003E8__locals1.layout.TableName))
				{
					flag = true;
				}
			}
		}
		Setting setting = gclass6_0.Settings.Where((Setting s) => "auto_clear_table".Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_clear_table");
			if (setting.Value != settingValueByKey)
			{
				SettingsHelper.SetSettingValueByKey("auto_clear_table", setting.Key);
			}
			if (setting.Value == "ON")
			{
				bool_8 = true;
				foreach (TableModel item in list_3)
				{
					if (item.Status == TableStatus.Paid)
					{
						ClearOccupiedTable(item.TableName);
					}
				}
			}
			else
			{
				bool_8 = false;
			}
		}
		int num = gclass6_0.Layouts.Where((Layout l) => l.Active == true && l.Section == lblSectionName.Text && ((int?)l.Rotation == (int?)86 || (int?)l.Rotation == (int?)72)).Count();
		if (flag || num != list_3.Count)
		{
			if (list_3.Count > 0 && !bool_4)
			{
				new NotificationLabel(this, "Restaurant Layout has been updated by admin.", NotificationTypes.Notification).Show();
			}
			list_5 = gclass6_0.Layouts.Where((Layout x) => x.Section == lblSectionName.Text).ToList();
			method_7();
		}
		bool_4 = false;
		PanelLayOut.Invalidate();
		if (SettingsHelper.CurrentTerminalMode != "Patron")
		{
			if (upcomingReservations.Where((Appointment r) => r.NextNotifyDateTime <= DateTime.Now && !r.ReminderDismissed && r.AppointmentType == AppointmentTypes.reservation).FirstOrDefault() != null)
			{
				timer_6.Enabled = true;
				picReservationPopup.Visible = true;
			}
			else
			{
				timer_6.Enabled = false;
				picReservationPopup.Visible = false;
			}
			if (upcomingWaitingList.Count() > 0 && list_3.Select((TableModel a) => a.Status).Contains(TableStatus.Open))
			{
				timer_3.Enabled = true;
				return;
			}
			btnWaitList.BackColor = Color.FromArgb(176, 124, 219);
			timer_3.Enabled = false;
		}
	}

	public bool RecordTip(string customer, string _OrderNumber = null, string orderType = "Dine In")
	{
		_003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_0();
		CS_0024_003C_003E8__locals0.customer = customer;
		CS_0024_003C_003E8__locals0._OrderNumber = _OrderNumber;
		GClass6 gClass = new GClass6();
		List<Order> list = null;
		if (CS_0024_003C_003E8__locals0.customer != null && CS_0024_003C_003E8__locals0._OrderNumber == null)
		{
			if (!bool_2)
			{
				return true;
			}
			list = gClass.Orders.Where((Order o) => o.Customer == "Table " + CS_0024_003C_003E8__locals0.customer && o.OrderType == OrderTypes.DineIn && o.Paid == true && o.Void == false && o.DateCleared == null).ToList();
		}
		else if (CS_0024_003C_003E8__locals0._OrderNumber != null)
		{
			list = gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0._OrderNumber).ToList();
			if (list.Count > 0 && (orderType != OrderTypes.DineIn || (orderType == OrderTypes.DineIn && list.FirstOrDefault().Customer.Contains("KIOSK"))) && !bool_2)
			{
				string text = CS_0024_003C_003E8__locals0._OrderNumber.ToUpper();
				if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON" && list.Count > 0 && !string.IsNullOrEmpty(list.FirstOrDefault().OrderTicketNumber))
				{
					text = list.FirstOrDefault().OrderTicketNumber;
				}
				if (new frmMessageBox("Do you want to clear this order (" + text + ")? ", "Clear Order", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
				{
					return false;
				}
				string source = string.Empty;
				string text2 = "";
				foreach (Order item in list)
				{
					item.Synced = false;
					item.DateCleared = DateTime.Now;
					source = item.Source;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = item.ThirdPartyOrderId;
					}
				}
				if (orderType == OrderTypes.DeliveryOnline || orderType == OrderTypes.TakeOutOnline || orderType == OrderTypes.PickUpOnline || orderType == OrderTypes.PickUpCurbsideOnline || orderType == OrderTypes.DineInOnline)
				{
					_ = SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals0._OrderNumber, "Completed", string.Empty, string.Empty, source, -1, text2).code;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			if (!bool_2)
			{
				return true;
			}
		}
		decimal tipAmount = list.FirstOrDefault().TipAmount;
		if (tipAmount > 0m && !list.FirstOrDefault().TipRecorded && new frmMessageBox(Resources.A_tip_amount_of + tipAmount.ToString("0.00") + Resources._has_been_recorded_Do_you_want, "Keep " + Resources.Tip_Amount + "?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			foreach (Order item2 in list)
			{
				item2.TipRecorded = true;
				item2.Synced = false;
				if (item2.OrderType == OrderTypes.Delivery || item2.OrderType == OrderTypes.PickUp || item2.OrderType == OrderTypes.DeliveryOnline || item2.OrderType == OrderTypes.PickUpOnline || item2.OrderType == OrderTypes.PickUpCurbsideOnline || item2.OrderType == OrderTypes.DineInOnline || item2.OrderType == OrderTypes.TakeOutOnline)
				{
					item2.DateCleared = DateTime.Now;
				}
			}
			try
			{
				gClass.SubmitChanges(ConflictMode.ContinueOnConflict);
				Order order = list.FirstOrDefault();
				if (order != null && (order.OrderType == OrderTypes.DeliveryOnline || order.OrderType == OrderTypes.PickUpOnline || order.OrderType == OrderTypes.TakeOutOnline || order.OrderType == OrderTypes.PickUpCurbsideOnline || order.OrderType == OrderTypes.DineInOnline))
				{
					_ = SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals0._OrderNumber, "Completed", string.Empty, string.Empty, order.Source, -1, order.ThirdPartyOrderId).code;
				}
			}
			catch (ChangeConflictException)
			{
				foreach (ObjectChangeConflict changeConflict in gClass.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
				}
			}
			return true;
		}
		string title = Resources.Enter_Tip_Amount_To_Clear + ((orderType == OrderTypes.DineIn) ? Resources.Table : Resources.The_Bill);
		bool flag = true;
		do
		{
			flag = true;
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(title, 2, 8);
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				continue;
			}
			if (list != null && MemoryLoadedObjects.Numpad.numberEntered >= Convert.ToDecimal(0.5) * list.Sum((Order s) => s.Total))
			{
				frmMessageBox frmMessageBox2 = ((!Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA")) ? new frmMessageBox(Resources.Are_you_sure_you_want_to_enter + $"{MemoryLoadedObjects.Numpad.numberEntered:C}" + "?", Resources.Tip_Amount, CustomMessageBoxButtons.YesNo) : new frmMessageBox(Resources.Are_you_sure_you_want_to_enter + $"{MemoryLoadedObjects.Numpad.numberEntered:C}" + "?", Resources.Tip_Amount, CustomMessageBoxButtons.YesNo));
				if (frmMessageBox2.ShowDialog(this) == DialogResult.No)
				{
					flag = false;
					continue;
				}
			}
			foreach (Order item3 in list)
			{
				item3.TipAmount = MemoryLoadedObjects.Numpad.numberEntered;
				if (item3.TipAmount > 0m)
				{
					item3.TipDesc = OrderHelper.UpdateDiscountFromDiscountDescription("", TipTypes.Cash, item3.TipAmount);
				}
				item3.TipRecorded = true;
				item3.Synced = false;
				if (item3.OrderType == OrderTypes.Delivery || item3.OrderType == OrderTypes.ToGo || item3.OrderType == OrderTypes.PickUp || item3.OrderType == OrderTypes.DeliveryOnline || item3.OrderType == OrderTypes.PickUpOnline || item3.OrderType == OrderTypes.TakeOutOnline || item3.OrderType == OrderTypes.PickUpCurbsideOnline || item3.OrderType == OrderTypes.DineInOnline || item3.OrderType == OrderTypes.Catering || (item3.OrderType == OrderTypes.DineIn && item3.Customer == "KIOSK"))
				{
					item3.DateCleared = DateTime.Now;
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
		while (!flag);
		return true;
	}

	public void ClearOccupiedTable(string customer)
	{
		_003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_0();
		CS_0024_003C_003E8__locals0.customer = customer;
		if (bool_8 || new frmMessageBox(Resources.Are_you_sure_you_want_to_clear0 + CS_0024_003C_003E8__locals0.customer.Replace("Table", string.Empty).Trim() + "?", "Table Status", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			TableModel tableModel = list_3.Where((TableModel l) => l.TableName == CS_0024_003C_003E8__locals0.customer.Replace("Table", string.Empty).Trim()).FirstOrDefault();
			short table_guest_count = (short)tableModel.currentGuests;
			tableModel.currentGuests = 0;
			tableModel.Status = TableStatus.Open;
			GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.customer.Replace("Table", string.Empty).Trim(), 0, 0);
			GuestMethods.AssignEmployeeTable(CS_0024_003C_003E8__locals0.customer.Replace("Table", string.Empty).Trim(), 0);
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
			List<Order> list = gclass6_0.Orders.Where((Order o) => o.Customer == "Table " + CS_0024_003C_003E8__locals0.customer.Replace("Table", string.Empty).Trim() && o.OrderType == OrderTypes.DineIn && o.Paid == true && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-14.0) && o.DateCleared == null).ToList();
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, list);
			GuestMethods.setGuestPerBill(list, table_guest_count, gclass6_0);
		}
	}

	private void method_10(TableModel tableModel_0)
	{
		_003C_003Ec__DisplayClass52_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass52_0();
		CS_0024_003C_003E8__locals0.table = tableModel_0;
		if (bool_3)
		{
			if (CS_0024_003C_003E8__locals0.table.Status == TableStatus.Open)
			{
				new NotificationLabel(this, "Please select an occupied table.", NotificationTypes.Warning, 3, 2);
				return;
			}
			frmSelectEmployee frmSelectEmployee2 = new frmSelectEmployee(showBtnClose: true);
			if (frmSelectEmployee2.ShowDialog(this) == DialogResult.OK)
			{
				GuestMethods.AssignEmployeeTable(CS_0024_003C_003E8__locals0.table.TableName.Replace("Table", string.Empty).Trim(), frmSelectEmployee2.employeeID);
				new NotificationLabel(this, "Employee Sussessfully assigned to " + CS_0024_003C_003E8__locals0.table.TableName, NotificationTypes.Success, 3, 2);
			}
			else
			{
				new NotificationLabel(this, "Assign Employee a Table Cancelled.", NotificationTypes.Success, 3, 2);
			}
			bool_3 = false;
			lblAssignEmployee.Visible = false;
			method_24(bool_12: true);
			return;
		}
		method_22();
		try
		{
			if (bool_7 && CS_0024_003C_003E8__locals0.table.Status != TableStatus.Open && employee_0 != null)
			{
				int? employeeTable = GuestMethods.GetEmployeeTable(CS_0024_003C_003E8__locals0.table.TableName.Replace("Table", string.Empty).Trim());
				if (employee_0.Users.FirstOrDefault().Role.RoleName == "Staff" && employeeTable.HasValue && employeeTable.Value != 0 && int_1 != employeeTable.Value)
				{
					new frmMessageBox(Resources.This_table_was_opened_by_anoth, Resources.Unable_To_View_Table).ShowDialog();
					return;
				}
			}
			if (bool_7 && CS_0024_003C_003E8__locals0.table.Status == TableStatus.Open)
			{
				GuestMethods.AssignEmployeeTable(CS_0024_003C_003E8__locals0.table.TableName.Replace("Table", string.Empty).Trim(), 0);
			}
			if (CS_0024_003C_003E8__locals0.table.Status == TableStatus.Reserved)
			{
				TransparentLabel transparentLabel_ = (TransparentLabel)PanelLayOut.Controls.Find("Reserved " + CS_0024_003C_003E8__locals0.table.TableName, searchAllChildren: false).FirstOrDefault();
				method_16(transparentLabel_);
				GC.Collect();
				return;
			}
			gclass6_0 = new GClass6();
			List<Order> source = gclass6_0.Orders.Where((Order o) => (o.Customer == "Table " + CS_0024_003C_003E8__locals0.table.TableName || o.Customer == "TABLE " + CS_0024_003C_003E8__locals0.table.TableName.ToUpper()) && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
			string string_ = string.Empty;
			if (source.Count() > 0)
			{
				string_ = source.FirstOrDefault().CustomerInfoName;
			}
			List<string> list = source.Select((Order x) => x.OrderNumber).Distinct().ToList();
			if (list.Count > 1)
			{
				if (CS_0024_003C_003E8__locals0.table.Status == TableStatus.Paid)
				{
					if (source.Where((Order x) => !x.TipRecorded).Count() > 0)
					{
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.MultiBills();
						MemoryLoadedObjects.MultiBills.LoadFormData(this, "Table " + CS_0024_003C_003E8__locals0.table.TableName, OrderTypes.DineIn);
						MemoryLoadedObjects.MultiBills.ShowDialog();
					}
					else
					{
						ClearOccupiedTable(CS_0024_003C_003E8__locals0.table.TableName);
						timer_0_Tick(null, null);
						timer_1_Tick(null, null);
					}
				}
				else
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.MultiBills();
					MemoryLoadedObjects.MultiBills.LoadFormData(this, "Table " + CS_0024_003C_003E8__locals0.table.TableName, OrderTypes.DineIn);
					MemoryLoadedObjects.MultiBills.ShowDialog();
				}
			}
			else if (list.Count == 1)
			{
				if (CS_0024_003C_003E8__locals0.table.Status == TableStatus.Paid)
				{
					if (source.Where((Order x) => !x.TipRecorded).Count() > 0 && bool_2)
					{
						if (new frmMessageBox(Resources.Do_you_want_to_enter_a_tip_amo, Resources.Tips0, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
						{
							RecordTip(CS_0024_003C_003E8__locals0.table.TableName);
							ClearOccupiedTable(CS_0024_003C_003E8__locals0.table.TableName);
						}
						else
						{
							ClearOccupiedTable(CS_0024_003C_003E8__locals0.table.TableName);
						}
						timer_0_Tick(null, null);
						timer_1_Tick(null, null);
					}
					else
					{
						ClearOccupiedTable(CS_0024_003C_003E8__locals0.table.TableName);
						timer_0_Tick(null, null);
						timer_1_Tick(null, null);
					}
				}
				else
				{
					string string_2 = list[0].ToString();
					method_11(string_2, CS_0024_003C_003E8__locals0.table.TableName, (short)CS_0024_003C_003E8__locals0.table.currentGuests, string_, UserMethods.GetUserByID((short)int_1));
				}
			}
			else
			{
				short currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName);
				switch (currentTableGuestCapacity)
				{
				case -1:
					new frmMessageBox(Resources.It_looks_like_there_was_an_upd, Resources.Update_Layout, CustomMessageBoxButtons.Ok).ShowDialog();
					method_7();
					timer_0_Tick(null, null);
					return;
				case 0:
				{
					short totalTableGuestCapacity = GuestMethods.GetTotalTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName);
					if (bool_9)
					{
						if (Convert.ToInt16((double)totalTableGuestCapacity * 1.5) <= int_0)
						{
							frmPatronNum frmPatronNum2 = new frmPatronNum(totalTableGuestCapacity);
							if (frmPatronNum2.ShowDialog() == DialogResult.OK)
							{
								short seat = frmPatronNum2.seat;
								method_11(null, CS_0024_003C_003E8__locals0.table.TableName, seat, string_, employee_0);
								GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName, seat, int_1, updateDateSeated: true);
								CS_0024_003C_003E8__locals0.table.currentGuests = seat;
								timer_1_Tick(null, null);
								timer_0_Tick(null, null);
								frmPatronNum2.Dispose();
							}
							else
							{
								frmPatronNum2.Dispose();
							}
							break;
						}
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
						MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Number_of_Guest, 0, 3);
						if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
						{
							break;
						}
						short num = Convert.ToInt16(MemoryLoadedObjects.Numpad);
						if (num > 0)
						{
							int num2 = (int)((double)totalTableGuestCapacity + 0.5 * (double)totalTableGuestCapacity);
							if (num > num2)
							{
								frmMessageBox frmMessageBox2 = new frmMessageBox(Resources.The_number_of_guests_is_over_t, Resources.Warning1, CustomMessageBoxButtons.YesNo);
								frmMessageBox2.ShowDialog(this);
								if (frmMessageBox2.DialogResult == DialogResult.Yes)
								{
									GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName, num, int_1, updateDateSeated: true);
									CS_0024_003C_003E8__locals0.table.currentGuests = num;
									timer_1_Tick(null, null);
									timer_0_Tick(null, null);
									method_11(null, CS_0024_003C_003E8__locals0.table.TableName, num, string_, employee_0);
									frmMessageBox2.Dispose();
								}
							}
							else
							{
								GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName, num, int_1, updateDateSeated: true);
								CS_0024_003C_003E8__locals0.table.currentGuests = num;
								timer_1_Tick(null, null);
								timer_0_Tick(null, null);
								method_11(null, CS_0024_003C_003E8__locals0.table.TableName, num, string_, employee_0);
							}
						}
						else
						{
							new frmMessageBox(Resources.The_number_of_guests_must_be_g, Resources.Invalid_Number0).ShowDialog(this);
						}
					}
					else
					{
						GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.table.TableName, 0, int_1, updateDateSeated: true);
						CS_0024_003C_003E8__locals0.table.currentGuests = 0;
						timer_1_Tick(null, null);
						timer_0_Tick(null, null);
						method_11(null, CS_0024_003C_003E8__locals0.table.TableName, 0, string_, employee_0);
					}
					break;
				}
				default:
					method_11(null, CS_0024_003C_003E8__locals0.table.TableName, currentTableGuestCapacity, string_, employee_0);
					timer_0_Tick(null, null);
					break;
				}
			}
			GC.Collect();
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
		}
	}

	private void method_11(string string_1, string string_2, short short_1, string string_3, Employee employee_1)
	{
		if (SettingsHelper.CurrentTerminalMode == "Patron")
		{
			frmPatron obj = new frmPatron();
			obj.LoadFormData(string_1, "Table " + string_2, OrderTypes.DineIn, short_1, string_3, employee_1.FirstName + " " + employee_1.LastName);
			obj.ShowDialog();
			obj.Dispose();
		}
		else
		{
			ShowEmptyOrderEntry();
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
			MemoryLoadedObjects.OrderEntry.LoadFormData(string_1, "Table " + string_2, OrderTypes.DineIn, short_1, 0, string_3, "", resetComboId: true, 1);
			MemoryLoadedObjects.OrderEntry.Show();
		}
	}

	private void btnReservations_Click(object sender, EventArgs e)
	{
		method_22();
		method_23();
		frmReservations_0 = new frmReservations(int_1);
		frmReservations_0.ShowDialog(this);
		frmReservations_0 = null;
	}

	private void btnLeft_Click(object sender, EventArgs e)
	{
		method_22();
		if (short_0 > 0)
		{
			short_0--;
			method_13();
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
		method_22();
		if (short_0 < list_4.Count - 1)
		{
			short_0++;
			method_13();
		}
	}

	private void method_12()
	{
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

	private void method_13()
	{
		if (list_4.Count() != 0)
		{
			if (list_4.Count - 1 < short_0)
			{
				short_0 = 0;
			}
			lblSectionName.Text = list_4[short_0];
		}
		method_7();
		timer_0_Tick(null, null);
		method_12();
	}

	private void btnRight_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (bool_9 && SettingsHelper.CurrentTerminalMode != "Patron")
		{
			if (int_4 >= int_3 && int_2 == 0 && !bool_1)
			{
				int_2 = 1;
				bool_0 = true;
				bool_1 = true;
				new frmMessageBox(Resources.The_restaurant_has_reached_it_, Resources.Warning_Restaurant_Capacity_Re).ShowDialog();
				int_2 = 0;
			}
			else if ((double)((float)int_4 / (float)int_3) >= 0.9 && int_2 == 0 && !bool_0 && !bool_1)
			{
				int_2 = 1;
				bool_0 = true;
				new frmMessageBox(Resources.The_restaurant_is_near_capacit, Resources.Warning_Restaurant_Near_Capaci).ShowDialog();
				int_2 = 0;
			}
		}
	}

	private void method_14()
	{
		if ((double)((float)int_4 / (float)int_3) < 0.9)
		{
			bool_0 = false;
		}
		if (int_4 < int_3)
		{
			bool_1 = false;
		}
	}

	public void btnEditLayout_Click(object sender, EventArgs e)
	{
		method_22();
		method_23();
		if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmEditLayout") != null)
		{
			bool_4 = true;
			new frmEditLayout().ShowDialog();
			RefreshLayout();
			method_5();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		PictureBox pictureBox = (PictureBox)sender;
		if (pictureBox.Name.Contains("Pic Food"))
		{
			_003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass63_0();
			CS_0024_003C_003E8__locals0.tableName = pictureBox.Name.Replace("Pic Food ", "");
			gclass6_0 = new GClass6();
			(from o in gclass6_0.Orders.Where((Order o) => o.Customer == "Table " + CS_0024_003C_003E8__locals0.tableName && o.ItemMadeNotified == false && o.StationID != null && o.StationID != string.Empty && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
				where o.StationID.Split(',').Contains("1")
				select o).ToList().ForEach(delegate(Order x)
			{
				x.ItemMadeNotified = true;
			});
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		else if (pictureBox.Name.Contains("Pic Drink"))
		{
			_003C_003Ec__DisplayClass63_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass63_1();
			CS_0024_003C_003E8__locals1.tableName = pictureBox.Name.Replace("Pic Drink ", "");
			gclass6_0 = new GClass6();
			(from o in gclass6_0.Orders.Where((Order o) => o.Customer == "Table " + CS_0024_003C_003E8__locals1.tableName && o.ItemMadeNotified == false && o.StationID != null && o.StationID != string.Empty && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
				where o.StationID.Split(',').Contains("2")
				select o).ToList().ForEach(delegate(Order x)
			{
				x.ItemMadeNotified = true;
			});
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		pictureBox.Visible = false;
		timer_0_Tick(null, null);
	}

	public void ReservedLabel_click(object sender, EventArgs e)
	{
		TransparentLabel transparentLabel_ = (TransparentLabel)sender;
		method_16(transparentLabel_);
	}

	private void method_16(TransparentLabel transparentLabel_0, bool bool_12 = false)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_remov2, Resources.Remove_Reservation, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			_003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass65_0();
			CS_0024_003C_003E8__locals0.tableName = transparentLabel_0.Name.Replace("Reserved ", "");
			TableModel tableModel = list_3.Where((TableModel l) => l.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault();
			if (tableModel != null)
			{
				gclass6_0 = new GClass6();
				tableModel.Status = TableStatus.Open;
				gclass6_0.Layouts.Where((Layout a) => a.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault().AppointmentID = null;
				Helper.SubmitChangesWithCatch(gclass6_0);
				transparentLabel_0.Visible = false;
			}
		}
		PanelLayOut.Invalidate();
	}

	private void btnUnLock_Click(object sender, EventArgs e)
	{
		int childIndex = PanelLayOut.Controls.GetChildIndex(lblStationLocked);
		PanelLayOut.Controls.SetChildIndex(lblStationLocked, 100000);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Employee_PIN, 0, 8);
		bool flag = false;
		method_23();
		do
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				flag = true;
				PanelLayOut.Controls.SetChildIndex(lblStationLocked, childIndex);
			}
			else if (MemoryLoadedObjects.Numpad.numberEntered.ToString().Length <= 8)
			{
				employee_0 = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee_0 != null)
				{
					RefreshLockedControls();
					if (frmMasterForm.allowedRoles.Contains(employee_0.Users.FirstOrDefault().Role.RoleName))
					{
						CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = (int_1 = employee_0.EmployeeID);
						PanelLayOut.Controls.SetChildIndex(lblStationLocked, childIndex);
						flag = true;
						foreach (Control control2 in PanelLayOut.Controls)
						{
							control2.Enabled = true;
						}
						foreach (Control control3 in panelNav.Controls)
						{
							if (control3.GetType() == btnUnLock.GetType() && control3.Text != Resources.UNLOCK_SCREEN && control3.Text != Resources.LOCK_SCREEN)
							{
								control3.ForeColor = Color.White;
								control3.Enabled = true;
							}
						}
						if (short_0 == 0)
						{
							btnLeft.Enabled = false;
							btnRight.Enabled = true;
						}
						else if (short_0 > 0)
						{
							btnLeft.Enabled = true;
							btnRight.Enabled = true;
						}
						if (short_0 == list_4.Count - 1)
						{
							btnRight.Enabled = false;
						}
						PanelLayOut.Enabled = true;
						pbZoomIn.Enabled = true;
						pbZoomOut.Enabled = true;
						pbRefresh.Enabled = true;
						lblStationLocked.Visible = false;
						btnLock.Visible = true;
						btnUnLock.Visible = false;
						method_17();
					}
					else
					{
						new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
						MemoryLoadedObjects.Numpad.TextInput = string.Empty;
					}
				}
				else
				{
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			else
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
			}
		}
		while (!flag);
	}

	private void method_17()
	{
		if (int_1 == 0)
		{
			lblEmployee.Text = Resources.NOT_LOGGED_IN;
		}
		else if (employee_0 != null)
		{
			lblEmployee.Text = Resources.EMPLOYEE + employee_0.FirstName + " " + employee_0.LastName;
		}
		lblEmployee.BringToFront();
	}

	private IEnumerable<Control> method_18(Control control_0)
	{
		foreach (Control child in control_0.Controls)
		{
			yield return child;
			foreach (Control item in method_18(child))
			{
				yield return item;
			}
		}
	}

	private void method_19()
	{
		foreach (Control item in method_18(PanelLayOut))
		{
			if (item.Name != "lblStationLocked")
			{
				string text = string.Empty;
				int i = 1;
				double num = 1.0;
				for (; i <= 9; i++)
				{
					num = (double)i / 5.0 - 0.1 * ((double)i - 5.0);
					int num2 = Convert.ToInt32((double)item.Location.X * num);
					int num3 = Convert.ToInt32((double)item.Location.Y * num);
					int num4 = Convert.ToInt32((double)item.Size.Width * num);
					int num5 = Convert.ToInt32((double)item.Size.Height * num);
					text = text + num2 + "," + num3 + "," + num4 + "," + num5 + ";";
				}
				text = text.Substring(0, text.Length - 1);
				item.Tag = text;
			}
		}
	}

	private void method_20()
	{
		IEnumerable<Control> source = method_18(PanelLayOut);
		foreach (Control item in source.Where((Control x) => !x.Name.Contains("Pic")))
		{
			if (!(item.Name != "lblStationLocked") || !(item.Name != "lblAssignEmployee") || !(item.Name != "lblTraining") || !(item.Name != "picReservationPopup") || !(item.Name != "picOnlineOrder"))
			{
				continue;
			}
			string[] array = ((string)item.Tag).Split(';');
			if (array.Length == 9)
			{
				string[] array2 = ((string)array.GetValue(int_5 - 1)).Split(',');
				if (array2.Length == 4)
				{
					item.Location = new Point(Convert.ToInt32(array2[0]) - PanelLayOut.HorizontalScroll.Value, Convert.ToInt32(array2[1]) - PanelLayOut.VerticalScroll.Value);
					item.Size = new Size(Convert.ToInt32(array2[2]), Convert.ToInt32(array2[3]));
				}
			}
		}
		PanelLayOut.Refresh();
		foreach (Control item2 in source.Where((Control x) => x.Name.Contains("Pic")))
		{
			string[] array3 = ((string)item2.Tag).Split(';');
			if (array3.Length != 9)
			{
				continue;
			}
			string[] array4 = ((string)array3.GetValue(int_5 - 1)).Split(',');
			if (array4.Length == 4 && (item2.Name.Contains("Food") || item2.Name.Contains("Drink")))
			{
				_003C_003Ec__DisplayClass70_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass70_0();
				CS_0024_003C_003E8__locals0.tblName = item2.Name.Replace("Pic Food", string.Empty).Replace("Pic Drink", string.Empty).Trim();
				Point value = dictionary_0.Where((KeyValuePair<string, Point> x) => x.Key == CS_0024_003C_003E8__locals0.tblName).FirstOrDefault().Value;
				item2.Location = new Point(value.X - PanelLayOut.HorizontalScroll.Value - Convert.ToInt32(array4[2]) + int_5 / 2, value.Y - PanelLayOut.VerticalScroll.Value - Convert.ToInt32(array4[3]) / 6);
				item2.Size = new Size(Convert.ToInt32(array4[2]), Convert.ToInt32(array4[3]));
			}
		}
		PanelLayOut.Invalidate();
	}

	private void pbZoomOut_Click(object sender, EventArgs e)
	{
		method_22();
		if (int_5 > 1)
		{
			int_5--;
			method_20();
			method_21();
		}
	}

	private void pbZoomIn_Click(object sender, EventArgs e)
	{
		method_22();
		if (int_5 < 9)
		{
			int_5++;
			method_20();
			method_21();
		}
	}

	private void method_21()
	{
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			terminal.LayoutZoomValue = int_5;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	private void pbRefresh_Click(object sender, EventArgs e)
	{
		RefreshLayout();
	}

	public void RefreshLayout()
	{
		pbRefresh.Enabled = false;
		timer_4.Enabled = false;
		method_22();
		frmLoadingBar.ShowSplashScreen();
		frmLoadingBar.SetPercentage(1);
		frmLoadingBar.SetPercentage(10);
		list_4 = new List<string>();
		method_9();
		method_5();
		method_13();
		frmLoadingBar.SetPercentage(99);
		frmLoadingBar.CloseForm();
		timer_4.Enabled = true;
	}

	private void timer_4_Tick(object sender, EventArgs e)
	{
		timer_4.Enabled = false;
		pbRefresh.Enabled = true;
	}

	private void btnTakeOut_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.BackColor = Color.Gray;
		}
		else
		{
			button.BackColor = Color.FromArgb(84, 172, 210);
		}
	}

	private void method_22()
	{
		timer_2.Stop();
		timer_2.Start();
	}

	private void btnOpenRegister_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, "btnOpenRegister") != null)
		{
			method_22();
			GClass8.OpenCashDrawer();
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		if (!(SettingsHelper.CurrentTerminalMode != "Patron"))
		{
			return;
		}
		timer_2.Enabled = ((SettingsHelper.GetSettingValueByKey("auto_lock_layout").ToUpper() == "ON") ? true : false);
		if (timer_2.Enabled)
		{
			if (Form.ActiveForm != this)
			{
				method_22();
			}
			else
			{
				btnLock_Click(btnLock, null);
			}
		}
		else
		{
			timer_2.Stop();
		}
	}

	private void btnWaitList_Click(object sender, EventArgs e)
	{
		method_22();
		method_23();
		frmWaitingList obj = new frmWaitingList(int_1);
		obj.ShowDialog(this);
		obj.Dispose();
	}

	private void timer_3_Tick(object sender, EventArgs e)
	{
		if (btnWaitList.BackColor == Color.FromArgb(235, 107, 86))
		{
			btnWaitList.BackColor = Color.FromArgb(176, 124, 219);
		}
		else
		{
			btnWaitList.BackColor = Color.FromArgb(235, 107, 86);
		}
	}

	private void btnAssignEmployee_Click(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			bool_3 = true;
			lblAssignEmployee.Visible = true;
			new NotificationLabel(this, "Select a Table", NotificationTypes.Success, 3, 2).Show();
			method_24(bool_12: false);
		}
		else
		{
			bool_3 = false;
			lblAssignEmployee.Visible = false;
			new NotificationLabel(this, "Assign Employee a Table Cancelled.", NotificationTypes.Success, 5, 2);
			method_24(bool_12: true);
		}
	}

	private void method_23()
	{
		if (bool_3)
		{
			bool_3 = false;
			lblAssignEmployee.Visible = false;
			new NotificationLabel(this, "Assign Employee a Table Cancelled.", NotificationTypes.Success, 1);
			method_24(bool_12: true);
		}
	}

	private void method_24(bool bool_12)
	{
		Button button = btnTakeOut;
		Button button2 = btnReservations;
		Button button3 = btnWaitList;
		Button button4 = btnOpenRegister;
		bool flag2 = (btnEditLayout.Enabled = bool_12);
		bool flag4 = (button4.Enabled = flag2);
		bool flag6 = (button3.Enabled = flag4);
		bool enabled = (button2.Enabled = flag6);
		button.Enabled = enabled;
	}

	private void btnChangeLanguage_Click(object sender, EventArgs e)
	{
		new frmSelectLanguage().ShowDialog(this);
	}

	private void timer_5_Tick(object sender, EventArgs e)
	{
		if (bool_11 || !(SettingsHelper.CurrentTerminalMode == "Patron"))
		{
			return;
		}
		bool_11 = true;
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null && terminal.ItemsInGroupsRefreshRequired)
		{
			method_3();
			MemoryLoadedObjects.RefreshItemOptions = true;
			terminal.ItemsInGroupsRefreshRequired = false;
			Helper.SubmitChangesWithCatch(gClass);
			frmOrderEntry frmOrderEntry2 = (frmOrderEntry)Application.OpenForms["frmOrderEntry"];
			if (frmOrderEntry2 != null)
			{
				frmOrderEntry2.RefreshGroupsAndItems();
			}
			else
			{
				((frmPatron)Application.OpenForms["frmPatron"])?.RefreshGroupsAndItems();
			}
		}
		bool_11 = false;
	}

	private void timer_6_Tick(object sender, EventArgs e)
	{
		Image image = picReservationPopup.Image;
		picReservationPopup.Image = picTempReserve.Image;
		picTempReserve.Image = image;
	}

	private void picReservationPopup_Click(object sender, EventArgs e)
	{
		method_23();
		DataManager dataManager = new DataManager();
		Appointment appointment = (from r in dataManager.getUpcomingReservations(DateTime.Now).ToList()
			where r.NextNotifyDateTime <= DateTime.Now && !r.ReminderDismissed && r.AppointmentType == AppointmentTypes.reservation
			select r).FirstOrDefault();
		if (appointment == null)
		{
			return;
		}
		timer_0.Enabled = false;
		timer_1.Enabled = false;
		string message = string.Concat(Resources.Reservation, appointment.StartDateTime.DayOfWeek, " ", appointment.StartDateTime.ToString("MMMM"), " ", appointment.StartDateTime.Day, " @ ", appointment.StartDateTime.ToShortTimeString(), Resources._for0, appointment.NumOfPeople.ToString(), Resources._people, appointment.CustomerName, ".\n");
		frmMessageBox_0 = new frmMessageBox(message, Resources.Reservation_Reminder, CustomMessageBoxButtons.DismissSnooze);
		DialogResult dialogResult = frmMessageBox_0.ShowDialog(this);
		try
		{
			if (dialogResult == DialogResult.No)
			{
				appointment.NextNotifyDateTime = DateTime.Now.AddMinutes(10.0);
			}
			else
			{
				appointment.ReminderDismissed = true;
			}
			Helper.SubmitChangesWithCatch(dataManager.DataContext);
			timer_0_Tick(null, null);
			timer_0.Enabled = true;
			timer_1.Enabled = true;
		}
		catch
		{
			if (frmReservations_0 != null)
			{
				frmReservations_0.UpdateList();
			}
		}
	}

	public void ShowOnlineOrderNotification(bool show)
	{
		Color backColor = Color.FromArgb(84, 172, 210);
		timer_7.Enabled = show;
		bool_5 = show;
		if (!bool_5)
		{
			btnTakeOut.BackColor = backColor;
		}
	}

	private void timer_7_Tick(object sender, EventArgs e)
	{
		Color color = Color.FromArgb(84, 172, 210);
		if (bool_5)
		{
			if (btnTakeOut.BackColor == color)
			{
				btnTakeOut.BackColor = Color.Red;
			}
			else
			{
				btnTakeOut.BackColor = color;
			}
		}
		else
		{
			btnTakeOut.BackColor = color;
		}
	}

	private void lblEmployee_Click(object sender, EventArgs e)
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLayout));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		timer_2 = new System.Windows.Forms.Timer(icontainer_1);
		timer_3 = new System.Windows.Forms.Timer(icontainer_1);
		timer_4 = new System.Windows.Forms.Timer(icontainer_1);
		timer_5 = new System.Windows.Forms.Timer(icontainer_1);
		timer_6 = new System.Windows.Forms.Timer(icontainer_1);
		timer_7 = new System.Windows.Forms.Timer(icontainer_1);
		picReservationPopup = new PictureBox();
		picTempOnlineOrder = new PictureBox();
		pbRefresh = new PictureBox();
		pbZoomOut = new PictureBox();
		pbZoomIn = new PictureBox();
		lblTraining = new Label();
		picTempReserve = new PictureBox();
		lblEmployee = new Label();
		panelNav = new Panel();
		btnChangeLanguage = new Button();
		btnAssignEmployee = new Button();
		btnWaitList = new Button();
		btnOpenRegister = new Button();
		btnEditLayout = new Button();
		pictureBoxGuest = new PictureBox();
		lblCapacity = new Label();
		btnLeft = new Button();
		lblSectionName = new Label();
		btnTakeOut = new Button();
		btnReservations = new Button();
		BtnClose = new Button();
		btnLock = new Button();
		btnUnLock = new Button();
		btnRight = new Button();
		PanelLayOut = new Panel();
		lblAssignEmployee = new Label();
		chairImage = new PictureBox();
		picDrink = new PictureBox();
		benchImage = new PictureBox();
		plantImage = new PictureBox();
		picFood = new PictureBox();
		lblStationLocked = new Label();
		((ISupportInitialize)picReservationPopup).BeginInit();
		((ISupportInitialize)picTempOnlineOrder).BeginInit();
		((ISupportInitialize)pbRefresh).BeginInit();
		((ISupportInitialize)pbZoomOut).BeginInit();
		((ISupportInitialize)pbZoomIn).BeginInit();
		((ISupportInitialize)picTempReserve).BeginInit();
		panelNav.SuspendLayout();
		((ISupportInitialize)pictureBoxGuest).BeginInit();
		PanelLayOut.SuspendLayout();
		((ISupportInitialize)chairImage).BeginInit();
		((ISupportInitialize)picDrink).BeginInit();
		((ISupportInitialize)benchImage).BeginInit();
		((ISupportInitialize)plantImage).BeginInit();
		((ISupportInitialize)picFood).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 30000;
		timer_0.Tick += timer_0_Tick;
		timer_1.Interval = 60000;
		timer_1.Tick += timer_1_Tick;
		timer_2.Enabled = true;
		timer_2.Interval = 120000;
		timer_2.Tick += timer_2_Tick;
		timer_3.Interval = 500;
		timer_3.Tick += timer_3_Tick;
		timer_4.Interval = 2000;
		timer_4.Tick += timer_4_Tick;
		timer_5.Enabled = true;
		timer_5.Interval = 30000;
		timer_5.Tick += timer_5_Tick;
		timer_6.Interval = 500;
		timer_6.Tick += timer_6_Tick;
		timer_7.Interval = 500;
		timer_7.Tick += timer_7_Tick;
		componentResourceManager.ApplyResources(picReservationPopup, "picReservationPopup");
		picReservationPopup.BackColor = Color.Transparent;
		picReservationPopup.Name = "picReservationPopup";
		picReservationPopup.TabStop = false;
		picReservationPopup.Click += picReservationPopup_Click;
		componentResourceManager.ApplyResources(picTempOnlineOrder, "picTempOnlineOrder");
		picTempOnlineOrder.BackColor = Color.Transparent;
		picTempOnlineOrder.Name = "picTempOnlineOrder";
		picTempOnlineOrder.TabStop = false;
		componentResourceManager.ApplyResources(pbRefresh, "pbRefresh");
		pbRefresh.BackColor = Color.Transparent;
		pbRefresh.Name = "pbRefresh";
		pbRefresh.TabStop = false;
		pbRefresh.Click += pbRefresh_Click;
		componentResourceManager.ApplyResources(pbZoomOut, "pbZoomOut");
		pbZoomOut.BackColor = Color.Transparent;
		pbZoomOut.Name = "pbZoomOut";
		pbZoomOut.TabStop = false;
		pbZoomOut.Click += pbZoomOut_Click;
		componentResourceManager.ApplyResources(pbZoomIn, "pbZoomIn");
		pbZoomIn.BackColor = Color.Transparent;
		pbZoomIn.Name = "pbZoomIn";
		pbZoomIn.TabStop = false;
		pbZoomIn.Click += pbZoomIn_Click;
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(picTempReserve, "picTempReserve");
		picTempReserve.BackColor = Color.Transparent;
		picTempReserve.Name = "picTempReserve";
		picTempReserve.TabStop = false;
		componentResourceManager.ApplyResources(lblEmployee, "lblEmployee");
		lblEmployee.BackColor = Color.FromArgb(47, 204, 113);
		lblEmployee.ForeColor = Color.White;
		lblEmployee.Name = "lblEmployee";
		lblEmployee.Click += lblEmployee_Click;
		panelNav.BackColor = Color.FromArgb(35, 39, 56);
		panelNav.Controls.Add(btnChangeLanguage);
		panelNav.Controls.Add(btnAssignEmployee);
		panelNav.Controls.Add(btnWaitList);
		panelNav.Controls.Add(btnOpenRegister);
		panelNav.Controls.Add(btnEditLayout);
		panelNav.Controls.Add(pictureBoxGuest);
		panelNav.Controls.Add(lblCapacity);
		panelNav.Controls.Add(btnLeft);
		panelNav.Controls.Add(lblSectionName);
		panelNav.Controls.Add(btnTakeOut);
		panelNav.Controls.Add(btnReservations);
		panelNav.Controls.Add(BtnClose);
		panelNav.Controls.Add(btnLock);
		panelNav.Controls.Add(btnUnLock);
		panelNav.Controls.Add(btnRight);
		componentResourceManager.ApplyResources(panelNav, "panelNav");
		panelNav.Name = "panelNav";
		btnChangeLanguage.BackColor = Color.FromArgb(80, 203, 116);
		btnChangeLanguage.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnChangeLanguage.FlatAppearance.BorderSize = 0;
		btnChangeLanguage.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnChangeLanguage, "btnChangeLanguage");
		btnChangeLanguage.ForeColor = Color.White;
		btnChangeLanguage.Name = "btnChangeLanguage";
		btnChangeLanguage.UseVisualStyleBackColor = false;
		btnChangeLanguage.Click += btnChangeLanguage_Click;
		btnAssignEmployee.BackColor = Color.FromArgb(122, 79, 148);
		btnAssignEmployee.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnAssignEmployee.FlatAppearance.BorderSize = 0;
		btnAssignEmployee.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAssignEmployee, "btnAssignEmployee");
		btnAssignEmployee.ForeColor = Color.White;
		btnAssignEmployee.Name = "btnAssignEmployee";
		btnAssignEmployee.UseVisualStyleBackColor = false;
		btnAssignEmployee.EnabledChanged += btnRight_EnabledChanged;
		btnAssignEmployee.Click += btnAssignEmployee_Click;
		btnWaitList.BackColor = Color.FromArgb(176, 124, 219);
		btnWaitList.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnWaitList.FlatAppearance.BorderSize = 0;
		btnWaitList.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnWaitList, "btnWaitList");
		btnWaitList.ForeColor = Color.White;
		btnWaitList.Name = "btnWaitList";
		btnWaitList.UseVisualStyleBackColor = false;
		btnWaitList.EnabledChanged += btnRight_EnabledChanged;
		btnWaitList.Click += btnWaitList_Click;
		btnOpenRegister.BackColor = Color.FromArgb(50, 119, 155);
		btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnOpenRegister.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenRegister, "btnOpenRegister");
		btnOpenRegister.ForeColor = Color.White;
		btnOpenRegister.Name = "btnOpenRegister";
		btnOpenRegister.UseVisualStyleBackColor = false;
		btnOpenRegister.EnabledChanged += btnRight_EnabledChanged;
		btnOpenRegister.Click += btnOpenRegister_Click;
		btnEditLayout.BackColor = Color.FromArgb(122, 79, 148);
		btnEditLayout.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnEditLayout.FlatAppearance.BorderSize = 0;
		btnEditLayout.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnEditLayout, "btnEditLayout");
		btnEditLayout.ForeColor = Color.White;
		btnEditLayout.Name = "btnEditLayout";
		btnEditLayout.Tag = "EDIT LAYOUT BUTTON";
		btnEditLayout.UseVisualStyleBackColor = false;
		btnEditLayout.EnabledChanged += btnRight_EnabledChanged;
		btnEditLayout.Click += btnEditLayout_Click;
		pictureBoxGuest.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(pictureBoxGuest, "pictureBoxGuest");
		pictureBoxGuest.Name = "pictureBoxGuest";
		pictureBoxGuest.TabStop = false;
		lblCapacity.BackColor = Color.DarkGray;
		lblCapacity.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblCapacity, "lblCapacity");
		lblCapacity.ForeColor = Color.WhiteSmoke;
		lblCapacity.Name = "lblCapacity";
		btnLeft.BackColor = Color.FromArgb(50, 119, 155);
		btnLeft.FlatAppearance.BorderColor = Color.Black;
		btnLeft.FlatAppearance.BorderSize = 0;
		btnLeft.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnLeft, "btnLeft");
		btnLeft.ForeColor = Color.White;
		btnLeft.Name = "btnLeft";
		btnLeft.UseVisualStyleBackColor = false;
		btnLeft.EnabledChanged += btnRight_EnabledChanged;
		btnLeft.Click += btnLeft_Click;
		lblSectionName.BackColor = Color.Gray;
		lblSectionName.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblSectionName, "lblSectionName");
		lblSectionName.ForeColor = Color.Black;
		lblSectionName.Name = "lblSectionName";
		btnTakeOut.BackColor = Color.FromArgb(84, 172, 210);
		btnTakeOut.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnTakeOut.FlatAppearance.BorderSize = 0;
		btnTakeOut.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnTakeOut, "btnTakeOut");
		btnTakeOut.ForeColor = Color.White;
		btnTakeOut.Name = "btnTakeOut";
		btnTakeOut.UseVisualStyleBackColor = false;
		btnTakeOut.EnabledChanged += btnTakeOut_EnabledChanged;
		btnTakeOut.Click += btnTakeOut_Click;
		btnReservations.BackColor = Color.FromArgb(80, 203, 116);
		btnReservations.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnReservations.FlatAppearance.BorderSize = 0;
		btnReservations.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnReservations, "btnReservations");
		btnReservations.ForeColor = Color.White;
		btnReservations.Name = "btnReservations";
		btnReservations.UseVisualStyleBackColor = false;
		btnReservations.EnabledChanged += btnRight_EnabledChanged;
		btnReservations.Click += btnReservations_Click;
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.EnabledChanged += btnRight_EnabledChanged;
		BtnClose.Click += BtnClose_Click;
		btnLock.BackColor = Color.SandyBrown;
		btnLock.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnLock.FlatAppearance.BorderSize = 0;
		btnLock.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnLock, "btnLock");
		btnLock.ForeColor = Color.White;
		btnLock.Name = "btnLock";
		btnLock.Tag = "LOCK BUTTON";
		btnLock.UseVisualStyleBackColor = false;
		btnLock.Click += btnLock_Click;
		btnUnLock.BackColor = Color.SandyBrown;
		btnUnLock.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnUnLock.FlatAppearance.BorderSize = 0;
		btnUnLock.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnUnLock, "btnUnLock");
		btnUnLock.ForeColor = Color.White;
		btnUnLock.Name = "btnUnLock";
		btnUnLock.Tag = "UN";
		btnUnLock.UseVisualStyleBackColor = false;
		btnUnLock.Click += btnUnLock_Click;
		btnRight.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(btnRight, "btnRight");
		btnRight.FlatAppearance.BorderColor = Color.Black;
		btnRight.FlatAppearance.BorderSize = 0;
		btnRight.FlatAppearance.MouseDownBackColor = Color.White;
		btnRight.ForeColor = Color.White;
		btnRight.Name = "btnRight";
		btnRight.UseVisualStyleBackColor = false;
		btnRight.EnabledChanged += btnRight_EnabledChanged;
		btnRight.Click += btnRight_Click;
		componentResourceManager.ApplyResources(PanelLayOut, "PanelLayOut");
		PanelLayOut.BackColor = Color.Transparent;
		PanelLayOut.Controls.Add(lblAssignEmployee);
		PanelLayOut.Controls.Add(chairImage);
		PanelLayOut.Controls.Add(picDrink);
		PanelLayOut.Controls.Add(benchImage);
		PanelLayOut.Controls.Add(plantImage);
		PanelLayOut.Controls.Add(picFood);
		PanelLayOut.Controls.Add(lblStationLocked);
		PanelLayOut.Name = "PanelLayOut";
		PanelLayOut.Paint += PanelLayOut_Paint;
		PanelLayOut.MouseClick += PanelLayOut_MouseClick;
		componentResourceManager.ApplyResources(lblAssignEmployee, "lblAssignEmployee");
		lblAssignEmployee.BackColor = Color.FromArgb(122, 79, 148);
		lblAssignEmployee.BorderStyle = BorderStyle.FixedSingle;
		lblAssignEmployee.ForeColor = Color.White;
		lblAssignEmployee.Name = "lblAssignEmployee";
		componentResourceManager.ApplyResources(chairImage, "chairImage");
		chairImage.BackColor = Color.Transparent;
		chairImage.Name = "chairImage";
		chairImage.TabStop = false;
		picDrink.BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(picDrink, "picDrink");
		picDrink.Name = "picDrink";
		picDrink.TabStop = false;
		componentResourceManager.ApplyResources(benchImage, "benchImage");
		benchImage.BackColor = Color.Transparent;
		benchImage.Name = "benchImage";
		benchImage.TabStop = false;
		componentResourceManager.ApplyResources(plantImage, "plantImage");
		plantImage.BackColor = Color.Transparent;
		plantImage.Name = "plantImage";
		plantImage.TabStop = false;
		picFood.BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(picFood, "picFood");
		picFood.Name = "picFood";
		picFood.TabStop = false;
		componentResourceManager.ApplyResources(lblStationLocked, "lblStationLocked");
		lblStationLocked.BackColor = Color.FromArgb(193, 57, 43);
		lblStationLocked.BorderStyle = BorderStyle.FixedSingle;
		lblStationLocked.ForeColor = Color.White;
		lblStationLocked.Name = "lblStationLocked";
		lblStationLocked.Tag = "LOCKED";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(picReservationPopup);
		base.Controls.Add(picTempOnlineOrder);
		base.Controls.Add(pbRefresh);
		base.Controls.Add(pbZoomOut);
		base.Controls.Add(pbZoomIn);
		base.Controls.Add(lblTraining);
		base.Controls.Add(picTempReserve);
		base.Controls.Add(lblEmployee);
		base.Controls.Add(panelNav);
		base.Controls.Add(PanelLayOut);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLayout";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Activated += frmLayout_Activated;
		base.Load += frmLayout_Load;
		base.VisibleChanged += frmLayout_VisibleChanged;
		base.Controls.SetChildIndex(PanelLayOut, 0);
		base.Controls.SetChildIndex(panelNav, 0);
		base.Controls.SetChildIndex(lblEmployee, 0);
		base.Controls.SetChildIndex(picTempReserve, 0);
		base.Controls.SetChildIndex(lblTraining, 0);
		base.Controls.SetChildIndex(pbZoomIn, 0);
		base.Controls.SetChildIndex(pbZoomOut, 0);
		base.Controls.SetChildIndex(pbRefresh, 0);
		base.Controls.SetChildIndex(picTempOnlineOrder, 0);
		base.Controls.SetChildIndex(picReservationPopup, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		((ISupportInitialize)picReservationPopup).EndInit();
		((ISupportInitialize)picTempOnlineOrder).EndInit();
		((ISupportInitialize)pbRefresh).EndInit();
		((ISupportInitialize)pbZoomOut).EndInit();
		((ISupportInitialize)pbZoomIn).EndInit();
		((ISupportInitialize)picTempReserve).EndInit();
		panelNav.ResumeLayout(performLayout: false);
		((ISupportInitialize)pictureBoxGuest).EndInit();
		PanelLayOut.ResumeLayout(performLayout: false);
		((ISupportInitialize)chairImage).EndInit();
		((ISupportInitialize)picDrink).EndInit();
		((ISupportInitialize)benchImage).EndInit();
		((ISupportInitialize)plantImage).EndInit();
		((ISupportInitialize)picFood).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	static frmLayout()
	{
		Class26.Ggkj0JxzN9YmC();
		int_0 = 49;
	}

	[CompilerGenerated]
	private bool method_25(Layout layout_0)
	{
		if (layout_0.Active)
		{
			return layout_0.Section == lblSectionName.Text;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_26(TableModel tableModel_0)
	{
		return tableModel_0.Section == lblSectionName.Text;
	}
}
