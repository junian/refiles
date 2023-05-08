using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmSelectDateSingle : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public string dateofweek;

		public _003C_003Ec__DisplayClass31_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private int int_2;

	private string string_2;

	private string string_3;

	private IContainer icontainer_1;

	private DateTimePicker DatePick;

	private Label lblTitle;

	private Button btnCancel;

	private Button btnOkay;

	private Button btnView;

	private DateTimePicker startTimePicker;

	private Label label1;

	private Label label2;

	private DateTimePicker endTimePicker;

	private Label label3;

	private Class19 ddlEmployees;

	private Label label4;

	private Class19 ddlTerminals;

	private Class19 ddlLastDayType;

	private Label lblShowTimeRange;

	private DateTimePicker DatePickEnd;

	private Label label5;

	private Label label6;

	public DateTime DatePicked
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public int EmployeeId
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int TerminalId
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public string BatchId
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

	public string title
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

	public int LastDayType
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public frmSelectDateSingle(string _title, string _latestOpening = "", string _latestCloseing = "")
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		title = _title;
		lblTitle.Text = _title;
		Text = _title;
		if (title == Resources.Day_End_Closing_Report)
		{
			if (SettingsHelper.GetSettingValueByKey("delivery_management") == "OFF")
			{
				ddlLastDayType.Items.RemoveAt(2);
			}
			btnView.Visible = true;
			btnOkay.Text = Resources.Print;
			string_3 = _latestCloseing;
			string_2 = _latestOpening;
			GClass6 gClass = new GClass6();
			method_3();
			Dictionary<int, string> dictionary = new Dictionary<int, string> { { -1, "All Hippos Terminals" } };
			foreach (KeyValuePair<int, string> item in (from a in gClass.Terminals
				where a.Status == TerminalStatus.active
				orderby a.SystemName
				select a).ToDictionary((Terminal a) => a.TerminalID, (Terminal a) => a.SystemName))
			{
				dictionary.Add(item.Key, item.Value);
			}
			ddlTerminals.DisplayMember = "Value";
			ddlTerminals.ValueMember = "Key";
			ddlTerminals.DataSource = new BindingSource(dictionary, null);
			ddlLastDayType.SelectedIndex = 0;
		}
		else
		{
			label3.Visible = false;
			ddlEmployees.Visible = false;
			ddlTerminals.Visible = false;
			btnView.Visible = false;
			btnView.Location = new Point(btnView.Location.X, label2.Bottom + 1);
			btnOkay.Location = new Point(btnOkay.Location.X, label2.Bottom + 1);
			btnCancel.Location = new Point(btnCancel.Location.X, label2.Bottom + 1);
			base.Size = new Size(base.Size.Width, base.Size.Height - label3.Height);
			btnOkay.Text = Resources.Okay;
		}
		method_4();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		string employeeRole = UserMethods.GetEmployeeRole(num);
		if (!(employeeRole == Roles.admin) && !(employeeRole == Roles.manager))
		{
			Employee employeeByID = UserMethods.GetEmployeeByID(num);
			dictionary.Add(employeeByID.EmployeeID, employeeByID.FirstName + " " + employeeByID.LastName);
			EmployeeId = num;
		}
		else
		{
			dictionary.Add(0, Resources.All_Employees);
			foreach (KeyValuePair<int, string> item in (from a in gClass.Employees
				where a.isActive && a.FirstName != null && a.FirstName != string.Empty
				select a into x
				orderby x.FirstName
				select x).ThenBy((Employee y) => y.LastName).ToDictionary((Employee a) => a.EmployeeID, (Employee a) => (!string.IsNullOrEmpty(a.FirstName) && !string.IsNullOrEmpty(a.LastName)) ? (a.FirstName + " " + a.LastName) : a.FirstName))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		ddlEmployees.DisplayMember = "Value";
		ddlEmployees.ValueMember = "Key";
		ddlEmployees.DataSource = new BindingSource(dictionary, null);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		if (DatePick.Value.Date > DatePickEnd.Value.Date)
		{
			new frmMessageBox("Start Date cannot be greater than End Date.", "Date Invalid").ShowDialog();
			return;
		}
		if (title == Resources.Day_End_Closing_Report)
		{
			if (ddlLastDayType.SelectedIndex == 2 && new frmMessageBox("Are you sure you want to Print Last Date Settlement Report? Last Settlement Date will be updated on print.", "Print Last Date Settlement", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
			{
				base.DialogResult = DialogResult.None;
				return;
			}
			DatePicked = DatePick.Value;
			EmployeeId = (int)ddlEmployees.SelectedValue;
			TerminalId = (int)ddlTerminals.SelectedValue;
			LastDayType = ddlLastDayType.SelectedIndex;
		}
		else
		{
			DatePicked = DatePick.Value;
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void DatePickEnd_ValueChanged(object sender, EventArgs e)
	{
		if (DatePick.Value.Date > DateTime.Now.Date && title == Resources.Day_End_Closing_Report)
		{
			DatePick.Value = DateTime.Now;
		}
		method_4();
	}

	private void method_4()
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.dateofweek = Enum.GetName(typeof(DayOfWeek), DatePick.Value.Date.DayOfWeek);
		List<BusinessHour> list = gClass.BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek == CS_0024_003C_003E8__locals0.dateofweek.ToLower()).ToList();
		string text = string.Empty;
		string text2 = string.Empty;
		if (list != null)
		{
			foreach (BusinessHour item in list)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = item.LatestOpeningTime;
				}
				else if (Convert.ToDateTime(item.LatestOpeningTime) < Convert.ToDateTime(text))
				{
					text = item.LatestOpeningTime;
				}
				if (string.IsNullOrEmpty(text2))
				{
					text2 = item.LatestClosingTime;
				}
				else if (Convert.ToDateTime(item.LatestClosingTime) > Convert.ToDateTime(text2))
				{
					text2 = item.LatestClosingTime;
				}
			}
		}
		DateTime value;
		DateTime dateTime;
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
		{
			value = Convert.ToDateTime(DatePick.Value.Date.ToShortDateString() + " " + text);
			dateTime = Convert.ToDateTime(DatePick.Value.Date.ToShortDateString() + " " + text2);
		}
		else
		{
			value = Convert.ToDateTime(DatePick.Value.Date.ToShortDateString() + " " + string_2);
			dateTime = Convert.ToDateTime(DatePick.Value.Date.ToShortDateString() + " " + string_3);
		}
		startTimePicker.Value = value;
		if (dateTime > DateTime.Now)
		{
			dateTime = DateTime.Today.AddHours(DateTime.Now.Hour);
		}
		endTimePicker.Value = dateTime.AddHours(1.0);
		startTimePicker.CustomFormat = "hh:mm tt";
		endTimePicker.CustomFormat = "hh:mm tt";
	}

	private void btnView_Click(object sender, EventArgs e)
	{
		if (DatePick.Value.Date > DatePickEnd.Value.Date)
		{
			new frmMessageBox("Start Date cannot be greater than End Date.", "Date Invalid").ShowDialog();
			return;
		}
		DateTime dateTime = startTimePicker.Value;
		DateTime dateTime2 = endTimePicker.Value;
		DateTime start = DatePick.Value;
		DateTime end = DatePickEnd.Value;
		if (dateTime > dateTime2)
		{
			dateTime2 = dateTime2.AddDays(1.0);
		}
		else if ((dateTime2 - dateTime).TotalHours > 24.0)
		{
			dateTime2 = dateTime2.AddDays(-1.0);
		}
		if (ddlLastDayType.SelectedIndex == 2)
		{
			CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
			if (!companySetup.LastDateSettlement.HasValue)
			{
				frmSelectDateAndTime frmSelectDateAndTime2 = new frmSelectDateAndTime("Select Last Date Settlement");
				if (frmSelectDateAndTime2.ShowDialog(this) == DialogResult.Cancel)
				{
					return;
				}
				dateTime = new DateTime(frmSelectDateAndTime2.returnDate.Year, frmSelectDateAndTime2.returnDate.Month, frmSelectDateAndTime2.returnDate.Day, frmSelectDateAndTime2.returnTime.Hour, frmSelectDateAndTime2.returnTime.Minute, frmSelectDateAndTime2.returnTime.Second);
			}
			else
			{
				dateTime = companySetup.LastDateSettlement.Value;
			}
			dateTime2 = DateTime.Now;
		}
		else if (ddlLastDayType.SelectedIndex == 1)
		{
			start = start.Date + dateTime.TimeOfDay;
			end = end.Date + dateTime2.TimeOfDay;
		}
		string param = dateTime.ToString() + "|" + dateTime2.ToString();
		string param2 = start.ToString() + "|" + end.ToString();
		int employeeId = (int)ddlEmployees.SelectedValue;
		int terminalId = (int)ddlTerminals.SelectedValue;
		if (ddlLastDayType.SelectedIndex == 3)
		{
			new frmReport(param, ReportTypes.DeliveryCommission, null, employeeId, terminalId).Show();
		}
		else if (ddlLastDayType.SelectedIndex == 4)
		{
			new frmReport(param, ReportTypes.DeliveryDrivers, null, employeeId, terminalId).Show();
		}
		else if (ddlLastDayType.SelectedIndex == 1)
		{
			ReceiptMethods.ParseDayEndTotals(start, end, employeeId, terminalId);
			new frmReport(param2, ReportTypes.DayEndClosing, null, employeeId, terminalId).Show();
		}
		else
		{
			ReceiptMethods.ParseDayEndTotals(dateTime, dateTime2, employeeId, terminalId);
			new frmReport(param, ReportTypes.DayEndClosing, null, employeeId, terminalId).Show();
		}
	}

	public DateTime getOpenDateTime()
	{
		return DatePick.Value.Date + startTimePicker.Value.TimeOfDay;
	}

	public DateTime getEndTime()
	{
		return endTimePicker.Value;
	}

	public DateTime getEndDateWithTime()
	{
		return DatePickEnd.Value.Date + endTimePicker.Value.TimeOfDay;
	}

	private DateTime method_5(DateTime dateTime_1)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_1);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_1;
	}

	private void DatePickEnd_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_5(dateTimePicker.Value);
	}

	private void endTimePicker_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_6(dateTimePicker.Value);
		dateTimePicker.CustomFormat = "hh:mm tt";
	}

	private DateTime method_6(DateTime dateTime_1)
	{
		frmTimePicker frmTimePicker2 = new frmTimePicker(dateTime_1, 30);
		if (frmTimePicker2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmTimePicker2.Time;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_1;
	}

	private void ddlLastDayType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlLastDayType.SelectedIndex == 2)
		{
			method_3();
			lblShowTimeRange.Location = new Point(ddlLastDayType.Location.X, ddlLastDayType.Location.Y + ddlLastDayType.Height + 1);
			lblShowTimeRange.Visible = true;
			ddlEmployees.SelectedValue = EmployeeId;
			return;
		}
		if (ddlLastDayType.SelectedIndex == 0)
		{
			DateTimePicker dateTimePicker = startTimePicker;
			endTimePicker.Enabled = true;
			dateTimePicker.Enabled = true;
			DatePickEnd.Enabled = false;
			lblShowTimeRange.Visible = false;
			method_3();
			ddlEmployees.SelectedValue = EmployeeId;
			return;
		}
		if (ddlLastDayType.SelectedIndex == 1)
		{
			DateTimePicker dateTimePicker2 = startTimePicker;
			endTimePicker.Enabled = true;
			dateTimePicker2.Enabled = true;
			DatePickEnd.Enabled = true;
			lblShowTimeRange.Visible = false;
			method_3();
			ddlEmployees.SelectedValue = EmployeeId;
			return;
		}
		lblShowTimeRange.Visible = false;
		GClass6 gClass = new GClass6();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		string employeeRole = UserMethods.GetEmployeeRole(num);
		if (!(employeeRole == Roles.admin) && !(employeeRole == Roles.manager))
		{
			Employee employeeByID = UserMethods.GetEmployeeByID(num);
			dictionary.Add(employeeByID.EmployeeID, employeeByID.FirstName + " " + employeeByID.LastName);
			EmployeeId = num;
		}
		else
		{
			dictionary.Add(0, Resources.All_Employees);
			foreach (KeyValuePair<int, string> item in (from a in gClass.Employees
				where a.Users.First().Role.RoleName == "Driver" && a.isActive && a.FirstName != null && a.FirstName != string.Empty
				select a into x
				orderby x.FirstName
				select x).ThenBy((Employee y) => y.LastName).ToDictionary((Employee a) => a.EmployeeID, (Employee a) => (!string.IsNullOrEmpty(a.FirstName) && !string.IsNullOrEmpty(a.LastName)) ? (a.FirstName + " " + a.LastName) : a.FirstName))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		ddlEmployees.DisplayMember = "Value";
		ddlEmployees.ValueMember = "Key";
		ddlEmployees.DataSource = new BindingSource(dictionary, null);
		ddlEmployees.SelectedIndex = 0;
	}

	private void startTimePicker_ValueChanged(object sender, EventArgs e)
	{
	}

	private void frmSelectDateSingle_Load(object sender, EventArgs e)
	{
		if (EmployeeId == 0)
		{
			return;
		}
		User user = MemoryLoadedObjects.ListOfUsers.Where((User user_0) => user_0.EmployeeID == EmployeeId).FirstOrDefault();
		if (user != null && user.Role.RoleName == Roles.employee)
		{
			if (ddlLastDayType.Items.Count == 3)
			{
				ddlLastDayType.Items.RemoveAt(2);
			}
			else if (ddlLastDayType.Items.Count == 4)
			{
				ddlLastDayType.Items.RemoveAt(3);
			}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectDateSingle));
		btnView = new Button();
		btnCancel = new Button();
		btnOkay = new Button();
		lblTitle = new Label();
		DatePick = new DateTimePicker();
		startTimePicker = new DateTimePicker();
		label1 = new Label();
		label2 = new Label();
		endTimePicker = new DateTimePicker();
		label3 = new Label();
		ddlEmployees = new Class19();
		label4 = new Label();
		ddlTerminals = new Class19();
		ddlLastDayType = new Class19();
		lblShowTimeRange = new Label();
		DatePickEnd = new DateTimePicker();
		label5 = new Label();
		label6 = new Label();
		SuspendLayout();
		btnView.BackColor = Color.FromArgb(50, 119, 155);
		btnView.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnView, "btnView");
		btnView.ForeColor = SystemColors.ButtonFace;
		btnView.Name = "btnView";
		btnView.UseVisualStyleBackColor = false;
		btnView.Click += btnView_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOkay, "btnOkay");
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.Name = "btnOkay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(DatePick, "DatePick");
		DatePick.Format = DateTimePickerFormat.Short;
		DatePick.Name = "DatePick";
		DatePick.ValueChanged += DatePickEnd_ValueChanged;
		DatePick.MouseDown += DatePickEnd_MouseDown;
		componentResourceManager.ApplyResources(startTimePicker, "startTimePicker");
		startTimePicker.Format = DateTimePickerFormat.Custom;
		startTimePicker.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		startTimePicker.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		startTimePicker.Name = "startTimePicker";
		startTimePicker.ValueChanged += startTimePicker_ValueChanged;
		startTimePicker.MouseDown += endTimePicker_MouseDown;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(endTimePicker, "endTimePicker");
		endTimePicker.Format = DateTimePickerFormat.Custom;
		endTimePicker.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		endTimePicker.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		endTimePicker.Name = "endTimePicker";
		endTimePicker.MouseDown += endTimePicker_MouseDown;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		ddlEmployees.DrawMode = DrawMode.OwnerDrawVariable;
		ddlEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlEmployees, "ddlEmployees");
		ddlEmployees.Name = "ddlEmployees";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		ddlTerminals.DrawMode = DrawMode.OwnerDrawVariable;
		ddlTerminals.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlTerminals, "ddlTerminals");
		ddlTerminals.Name = "ddlTerminals";
		ddlLastDayType.DrawMode = DrawMode.OwnerDrawVariable;
		ddlLastDayType.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlLastDayType, "ddlLastDayType");
		ddlLastDayType.Items.AddRange(new object[5]
		{
			componentResourceManager.GetString("ddlLastDayType.Items"),
			componentResourceManager.GetString("ddlLastDayType.Items1"),
			componentResourceManager.GetString("ddlLastDayType.Items2"),
			componentResourceManager.GetString("ddlLastDayType.Items3"),
			componentResourceManager.GetString("ddlLastDayType.Items4")
		});
		ddlLastDayType.Name = "ddlLastDayType";
		ddlLastDayType.SelectedIndexChanged += ddlLastDayType_SelectedIndexChanged;
		lblShowTimeRange.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblShowTimeRange, "lblShowTimeRange");
		lblShowTimeRange.ForeColor = Color.White;
		lblShowTimeRange.Name = "lblShowTimeRange";
		componentResourceManager.ApplyResources(DatePickEnd, "DatePickEnd");
		DatePickEnd.Format = DateTimePickerFormat.Short;
		DatePickEnd.Name = "DatePickEnd";
		DatePickEnd.ValueChanged += DatePickEnd_ValueChanged;
		DatePickEnd.MouseDown += DatePickEnd_MouseDown;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lblShowTimeRange);
		base.Controls.Add(DatePickEnd);
		base.Controls.Add(ddlLastDayType);
		base.Controls.Add(ddlTerminals);
		base.Controls.Add(label4);
		base.Controls.Add(ddlEmployees);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(endTimePicker);
		base.Controls.Add(label1);
		base.Controls.Add(startTimePicker);
		base.Controls.Add(btnView);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(lblTitle);
		base.Controls.Add(DatePick);
		base.Controls.Add(label6);
		base.Controls.Add(label5);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSelectDateSingle";
		base.Opacity = 1.0;
		base.Load += frmSelectDateSingle_Load;
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_7(User user_0)
	{
		return user_0.EmployeeID == EmployeeId;
	}
}
