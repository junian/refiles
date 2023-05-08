using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CommonForms;
using CorePOS.CustomControls;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS;

public class frmEmployeePunchInOut : frmMasterForm
{
	private string string_0;

	private Employee employee_0;

	private EmployeeClockInOutQueue jQmugvadnv;

	private string string_1;

	private int int_0;

	private LoadingLabel loadingLabel_0;

	private int int_1;

	private int int_2;

	private string string_2;

	private bool bool_0;

	private string string_3;

	private IContainer tbEudxUjfv;

	private Label lblWIndowTitle;

	private CustomListViewTelerik radListPunch;

	internal Button btnTimeIn;

	internal Button btnTimeOut;

	private PictureBox pictureBox1;

	private VerticalScrollControl verticalScrollControl1;

	private Label label1;

	private Class20 ddlEmployee;

	private Label lblEmployeeName;

	private Class19 ddlMonth;

	internal Button btnClose;

	internal Button btnExport;

	private System.Windows.Forms.Timer timer_0;

	public frmEmployeePunchInOut(Employee employee)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = SyncMethods.GetToken();
		int_1 = 1;
		int_2 = 1;
		string_2 = "";
		string_3 = "Exporting...";
		base._002Ector();
		InitializeComponent_1();
		employee_0 = employee;
		int_0 = employee.Users.First().RoleID;
		if (int_0 != RoleIDs.manager && int_0 != RoleIDs.admin)
		{
			label1.Text = "Name";
			lblEmployeeName.Visible = true;
		}
		else
		{
			List<Employee> list = (from a in new GClass6().Employees
				where a.isActive == true
				select a into s
				orderby s.FirstName
				select s).ToList();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (Employee item in list)
			{
				dictionary.Add(item.EmployeeID.ToString(), item.FirstName + " " + item.LastName);
			}
			ddlEmployee.DisplayMember = "Value";
			ddlEmployee.ValueMember = "Key";
			ddlEmployee.DataSource = new BindingSource(dictionary, null);
			ddlEmployee.SelectedValue = employee.EmployeeID.ToString();
			label1.Text = "Employee";
			lblEmployeeName.Visible = false;
		}
		if (employee_0 != null)
		{
			lblEmployeeName.Text = employee_0.FirstName + " " + employee_0.LastName;
		}
		ddlMonth.SelectedIndex = 0;
		method_3();
		verticalScrollControl1.ConnectedRadListView = radListPunch;
	}

	private void method_3()
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.monthSelected = ((ddlMonth.SelectedIndex == 0) ? DateTime.Now.Date.Month : DateTime.Now.Date.AddMonths(-1).Month);
		CS_0024_003C_003E8__locals0.yearSelected = ((ddlMonth.SelectedIndex == 0) ? DateTime.Now.Date.Year : DateTime.Now.Date.AddMonths(-1).Year);
		GClass6 gClass = new GClass6();
		List<EmployeeClockInOutQueue> list = (from a in gClass.EmployeeClockInOutQueues
			where a.EmployeeId == (int?)employee_0.EmployeeID && Convert.ToDateTime(a.Timestamp).Month == CS_0024_003C_003E8__locals0.monthSelected && Convert.ToDateTime(a.Timestamp).Year == CS_0024_003C_003E8__locals0.yearSelected
			orderby Convert.ToDateTime(a.Timestamp)
			select a).Take(100).ToList();
		jQmugvadnv = list.LastOrDefault();
		if (jQmugvadnv == null)
		{
			jQmugvadnv = (from a in gClass.EmployeeClockInOutQueues
				where a.EmployeeId == (int?)employee_0.EmployeeID && Convert.ToDateTime(a.Timestamp).Date == DateTime.Now.Date.AddDays(-1.0)
				orderby Convert.ToDateTime(a.Timestamp)
				select a).Take(20).ToList().LastOrDefault();
		}
		radListPunch.Items.Clear();
		string_1 = "hippos-clockin";
		if (jQmugvadnv != null)
		{
			if (jQmugvadnv.Action == "hippos-clockin")
			{
				string_1 = "hippos-clockout";
			}
			else if (jQmugvadnv.Action == "hippos-clockout")
			{
				string_1 = "hippos-clockin";
			}
			else if (jQmugvadnv.Action == "start-break")
			{
				string_1 = "end-break";
			}
			else if (jQmugvadnv.Action == "end-break")
			{
				string_1 = "hippos-clockout";
			}
		}
		if (string_1 == "hippos-clockin")
		{
			btnTimeIn.Enabled = true;
			btnTimeOut.Enabled = false;
		}
		else
		{
			btnTimeIn.Enabled = false;
			btnTimeOut.Enabled = true;
		}
		if (ddlMonth.SelectedIndex != 0)
		{
			Button button = btnTimeOut;
			btnTimeIn.Enabled = false;
			button.Enabled = false;
		}
		if (jQmugvadnv == null)
		{
			return;
		}
		foreach (EmployeeClockInOutQueue item in list)
		{
			string text = "TIME IN";
			if (item.Action == "hippos-clockin")
			{
				text = "TIME IN";
			}
			else if (item.Action == "hippos-clockout")
			{
				text = "TIME OUT";
			}
			else if (item.Action == "start-break")
			{
				text = "START BREAK";
			}
			else if (item.Action == "end-break")
			{
				text = "END BREAK";
			}
			string[] values = new string[2] { item.Timestamp, text };
			ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
			listViewDataItem.BackColor = Color.White;
			radListPunch.Items.Add(listViewDataItem);
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnTimeIn_Click(object sender, EventArgs e)
	{
		if (!method_4())
		{
			return;
		}
		new NotificationLabel(this, "Successfully clocked in at " + DateTime.Now.ToString("hh:mm tt"), NotificationTypes.Success).Show();
		new Thread((ThreadStart)delegate
		{
			try
			{
				Thread.Sleep(5000);
				Invoke((MethodInvoker)delegate
				{
					Close();
				});
			}
			catch
			{
			}
		}).Start();
	}

	private void btnTimeOut_Click(object sender, EventArgs e)
	{
		if (!method_4())
		{
			return;
		}
		new NotificationLabel(this, "Successfully clocked out at " + DateTime.Now.ToString("hh:mm tt"), NotificationTypes.Success).Show();
		new Thread((ThreadStart)delegate
		{
			try
			{
				Thread.Sleep(5000);
				Invoke((MethodInvoker)delegate
				{
					Close();
				});
			}
			catch
			{
			}
		}).Start();
	}

	private bool method_4(string string_4 = "")
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.ckInData = new HipposClockInOutRequestObject();
		CS_0024_003C_003E8__locals0.ckInData.cs_apikey = string_0;
		CS_0024_003C_003E8__locals0.ckInData.employee_pin = employee_0.Users.First().PIN.ToString();
		CS_0024_003C_003E8__locals0.ckInData.timestamp = (string.IsNullOrEmpty(string_4) ? HelperMethods.getServerTime(toUTC: false).ToString("MMM dd yyyy hh:mm:ss tt") : string_4);
		CS_0024_003C_003E8__locals0.ckInData.action = string_1;
		CS_0024_003C_003E8__locals0.ckInData.employee_id = employee_0.EmployeeID;
		string text = ((string_1 == "hippos-clockin" || string_1 == "hippos-clockout") ? ETimeCardMethods.CheckPunchInOut(CS_0024_003C_003E8__locals0.ckInData) : "true");
		if (text == "true")
		{
			if (string_1 == "hippos-clockout")
			{
				GClass6 gClass = new GClass6();
				EmployeeClockInOutQueue employeeClockInOutQueue = null;
				if (SettingsHelper.GetSettingValueByKey("print_clock_out") == "ON")
				{
					employeeClockInOutQueue = (from a in gClass.EmployeeClockInOutQueues
						where a.EmployeePin == CS_0024_003C_003E8__locals0.ckInData.employee_pin && (a.Action == "hippos-clockin" || a.Action == "hippos-clockout")
						orderby a.Id descending
						select a).FirstOrDefault();
					if (employeeClockInOutQueue != null)
					{
						new PrintHelper((!string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.DefaultPrinter)) ? MemoryLoadedObjects.this_terminal.DefaultPrinter : SettingsHelper.GetSettingValueByKey("printer_default")).PrintString("NAME: " + employee_0.FirstName + " " + employee_0.LastName + " <br/> IN: " + employeeClockInOutQueue.Timestamp + "<br/>OUT: " + CS_0024_003C_003E8__locals0.ckInData.timestamp);
					}
				}
				if (SettingsHelper.GetSettingValueByKey("print_eod_clock_out") == "ON" && gClass.Orders.Where((Order x) => (int?)x.UserServed == (int?)employee_0.EmployeeID || (int?)x.UserCashout == (int?)employee_0.EmployeeID).Count() > 0)
				{
					if (employee_0 == null)
					{
						employee_0 = gClass.Employees.Where((Employee a) => a.Users.First().PIN == CS_0024_003C_003E8__locals0.ckInData.employee_pin).FirstOrDefault();
					}
					if (employee_0 != null)
					{
						DateTime dateTime = Convert.ToDateTime(employeeClockInOutQueue.Timestamp);
						DateTime dateTime2 = Convert.ToDateTime(CS_0024_003C_003E8__locals0.ckInData.timestamp);
						ReceiptMethods.ParseDayEndTotals(dateTime, dateTime2, employee_0.EmployeeID, -1);
						new PrintHelper().GenerateDayEndTotals(dateTime, dateTime2, employee_0.EmployeeID, -1);
						if (SettingsHelper.GetSettingValueByKey("delivery_management") == "ON" && employee_0.Users.First().RoleID == RoleIDs.driver)
						{
							new PrintHelper().PrintDeliveryCommission(dateTime, dateTime2, employee_0.EmployeeID, ReportTypes.DeliveryCommission);
							new PrintHelper().PrintDeliveryCommission(dateTime, dateTime2, employee_0.EmployeeID, ReportTypes.DeliveryDrivers);
						}
					}
				}
			}
			ETimeCardMethods.AddEmployeePunchInOutQueue(CS_0024_003C_003E8__locals0.ckInData);
			method_3();
			return true;
		}
		new NotificationLabel(this, text, NotificationTypes.Warning).Show();
		return false;
	}

	private void btnTimeOut_EnabledChanged(object sender, EventArgs e)
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

	private void method_5(object sender, EventArgs e)
	{
		if (string_1 == "hippos-clockout")
		{
			string_1 = "start-break";
		}
		if (method_4())
		{
			if (string_1 == "start-break")
			{
				new NotificationLabel(this, "Successfully take break at " + DateTime.Now.ToString("hh:mm tt"), NotificationTypes.Success).Show();
			}
			else
			{
				new NotificationLabel(this, "Successfully END break at " + DateTime.Now.ToString("hh:mm tt"), NotificationTypes.Success).Show();
			}
		}
	}

	private void method_6(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_7(dateTimePicker.Value);
	}

	private DateTime method_7(DateTime dateTime_0)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_0);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void method_8(object sender, EventArgs e)
	{
		method_3();
	}

	private void ddlEmployee_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if ((int_0 == RoleIDs.manager || int_0 == RoleIDs.admin) && ddlEmployee.Items.Count > 0)
		{
			GClass6 gClass = new GClass6();
			employee_0 = gClass.Employees.Where((Employee a) => a.EmployeeID.ToString() == ddlEmployee.SelectedValue.ToString()).FirstOrDefault();
			method_3();
		}
	}

	private void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnExport_Click(object sender, EventArgs e)
	{
		frmSelectDateRange frmSelectDateRange = new frmSelectDateRange();
		if (frmSelectDateRange.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.startDate = frmSelectDateRange.selectedStartDate;
		CS_0024_003C_003E8__locals0.endDate = frmSelectDateRange.selectedEndDate;
		CS_0024_003C_003E8__locals0.fbd = new FolderBrowserDialog();
		if (CS_0024_003C_003E8__locals0.fbd.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		new Thread((ThreadStart)delegate
		{
			string separator = ",";
			string text = "EmployeePunchInOuts-" + CS_0024_003C_003E8__locals0.startDate.ToString("MM-dd-yyyy") + "_to_" + CS_0024_003C_003E8__locals0.endDate.ToString("MM-dd-yyyy") + ".csv";
			string path = CS_0024_003C_003E8__locals0.fbd.SelectedPath + "\\" + text;
			List<EmployeeClockInOutQueue> list = new GClass6().EmployeeClockInOutQueues.Where((EmployeeClockInOutQueue a) => a.Timestamp != null && Convert.ToDateTime(a.Timestamp) >= CS_0024_003C_003E8__locals0.startDate.Date && Convert.ToDateTime(a.Timestamp) <= CS_0024_003C_003E8__locals0.endDate.Date.AddDays(1.0)).ToList();
			CS_0024_003C_003E8__locals0._003C_003E4__this.int_2 = list.Count;
			if (list.Count == 0)
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.int_2 = 1;
				CS_0024_003C_003E8__locals0._003C_003E4__this.bool_0 = true;
				CS_0024_003C_003E8__locals0._003C_003E4__this.string_2 = "No Data to Export.";
				return;
			}
			try
			{
				using TextWriter textWriter = File.CreateText(path);
				string[] value = new string[3] { "Employee", "Time", "Action" };
				textWriter.WriteLine(string.Join(separator, value));
				CS_0024_003C_003E8__locals0._003C_003E4__this.int_1 = 1;
				foreach (EmployeeClockInOutQueue item in (from a in list
					orderby a.EmployeeId, a.Id
					select a).ToList())
				{
					string text2 = ((item.Action == "hippos-clockin") ? "TIME IN" : "TIME OUT");
					if (item.Employee != null)
					{
						string[] value2 = new string[3]
						{
							item.Employee.FirstName + " " + item.Employee.LastName,
							item.Timestamp,
							text2
						};
						textWriter.WriteLine(string.Join(separator, value2));
						CS_0024_003C_003E8__locals0._003C_003E4__this.int_1 = CS_0024_003C_003E8__locals0._003C_003E4__this.int_1 + 1;
					}
				}
				CS_0024_003C_003E8__locals0._003C_003E4__this.string_2 = "Successfully Exported.";
				textWriter.Close();
				textWriter.Dispose();
			}
			catch (Exception ex)
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.string_2 = ex.Message;
				CS_0024_003C_003E8__locals0._003C_003E4__this.bool_0 = true;
			}
		}).Start();
		loadingLabel_0 = new LoadingLabel(this);
		loadingLabel_0.StartLoading();
		timer_0.Enabled = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int value = Convert.ToInt32((float)int_1 / (float)int_2 * 100f);
		loadingLabel_0.SetPercentage(value, string_3 + " (" + int_1 + "/" + int_2 + ")");
		if ((int_1 != 1 && int_1 >= int_2) || bool_0)
		{
			if (!bool_0)
			{
				loadingLabel_0.SetPercentage(100);
			}
			loadingLabel_0.EndLoading();
			timer_0.Enabled = false;
			int_1 = 1;
			int_2 = 1;
			new NotificationLabel(this, string_2, NotificationTypes.Success).Show();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && tbEudxUjfv != null)
		{
			tbEudxUjfv.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		tbEudxUjfv = new Container();
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "Column 0");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Column 1");
		ListViewDataItem listViewDataItem = new ListViewDataItem("ListViewItem 1");
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEmployeePunchInOut));
		lblWIndowTitle = new Label();
		radListPunch = new CustomListViewTelerik();
		btnTimeIn = new Button();
		btnTimeOut = new Button();
		pictureBox1 = new PictureBox();
		verticalScrollControl1 = new VerticalScrollControl();
		label1 = new Label();
		ddlEmployee = new Class20();
		lblEmployeeName = new Label();
		ddlMonth = new Class19();
		btnClose = new Button();
		btnExport = new Button();
		timer_0 = new System.Windows.Forms.Timer(tbEudxUjfv);
		((ISupportInitialize)radListPunch).BeginInit();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)ddlEmployee).BeginInit();
		SuspendLayout();
		lblWIndowTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblWIndowTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblWIndowTitle.ForeColor = Color.White;
		lblWIndowTitle.ImeMode = ImeMode.NoControl;
		lblWIndowTitle.Location = new Point(6, 6);
		lblWIndowTitle.Name = "lblWIndowTitle";
		lblWIndowTitle.Size = new Size(509, 35);
		lblWIndowTitle.TabIndex = 160;
		lblWIndowTitle.Text = "Employee Punch In/Out";
		lblWIndowTitle.TextAlign = ContentAlignment.MiddleCenter;
		radListPunch.AllowArbitraryItemHeight = true;
		radListPunch.AllowEdit = false;
		radListPunch.AllowRemove = false;
		radListPunch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listViewDetailColumn.HeaderText = "Column 0";
		listViewDetailColumn2.HeaderText = "Column 1";
		listViewDetailColumn2.Width = 150f;
		radListPunch.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2);
		radListPunch.EnableKineticScrolling = true;
		radListPunch.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
		listViewDataItem.Text = "ListViewItem 1";
		radListPunch.Items.AddRange(listViewDataItem);
		radListPunch.ItemSize = new Size(200, 12);
		radListPunch.ItemSpacing = -1;
		radListPunch.Location = new Point(5, 72);
		radListPunch.Name = "radListPunch";
		radListPunch.ShowColumnHeaders = false;
		radListPunch.ShowGridLines = true;
		radListPunch.Size = new Size(485, 373);
		radListPunch.TabIndex = 161;
		radListPunch.Text = "radListView1";
		radListPunch.ViewType = ListViewType.DetailsView;
		btnTimeIn.BackColor = Color.FromArgb(53, 152, 220);
		btnTimeIn.FlatAppearance.BorderColor = Color.White;
		btnTimeIn.FlatAppearance.BorderSize = 0;
		btnTimeIn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnTimeIn.FlatStyle = FlatStyle.Flat;
		btnTimeIn.Font = new Font("Microsoft Sans Serif", 15f);
		btnTimeIn.ForeColor = Color.White;
		btnTimeIn.ImeMode = ImeMode.NoControl;
		btnTimeIn.Location = new Point(5, 446);
		btnTimeIn.Name = "btnTimeIn";
		btnTimeIn.Padding = new Padding(5);
		btnTimeIn.Size = new Size(172, 75);
		btnTimeIn.TabIndex = 162;
		btnTimeIn.Text = "CLOCK IN";
		btnTimeIn.UseVisualStyleBackColor = false;
		btnTimeIn.EnabledChanged += btnTimeOut_EnabledChanged;
		btnTimeIn.Click += btnTimeIn_Click;
		btnTimeOut.BackColor = Color.SandyBrown;
		btnTimeOut.FlatAppearance.BorderColor = Color.White;
		btnTimeOut.FlatAppearance.BorderSize = 0;
		btnTimeOut.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnTimeOut.FlatStyle = FlatStyle.Flat;
		btnTimeOut.Font = new Font("Microsoft Sans Serif", 15f);
		btnTimeOut.ForeColor = Color.White;
		btnTimeOut.ImeMode = ImeMode.NoControl;
		btnTimeOut.Location = new Point(178, 447);
		btnTimeOut.Name = "btnTimeOut";
		btnTimeOut.Padding = new Padding(5);
		btnTimeOut.Size = new Size(170, 75);
		btnTimeOut.TabIndex = 163;
		btnTimeOut.Text = "CLOCK OUT";
		btnTimeOut.UseVisualStyleBackColor = false;
		btnTimeOut.EnabledChanged += btnTimeOut_EnabledChanged;
		btnTimeOut.Click += btnTimeOut_Click;
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(480, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(40, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 236;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(469, 72);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 0);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 373);
		verticalScrollControl1.TabIndex = 238;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImageAlign = ContentAlignment.MiddleLeft;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(199, 41);
		label1.Name = "label1";
		label1.Size = new Size(80, 31);
		label1.TabIndex = 241;
		label1.Text = "Employee";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		ddlEmployee.AutoSize = false;
		ddlEmployee.BackColor = Color.White;
		ddlEmployee.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlEmployee.EnableKineticScrolling = true;
		ddlEmployee.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlEmployee.Location = new Point(280, 42);
		ddlEmployee.Margin = new Padding(4, 5, 4, 5);
		ddlEmployee.MinimumSize = new Size(200, 0);
		ddlEmployee.Name = "ddlEmployee";
		ddlEmployee.RootElement.MinSize = new Size(200, 0);
		ddlEmployee.Size = new Size(239, 30);
		ddlEmployee.TabIndex = 242;
		ddlEmployee.ThemeName = "Windows8";
		ddlEmployee.SelectedIndexChanged += ddlEmployee_SelectedIndexChanged;
		lblEmployeeName.BackColor = SystemColors.AppWorkspace;
		lblEmployeeName.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		lblEmployeeName.ForeColor = Color.Black;
		lblEmployeeName.ImeMode = ImeMode.NoControl;
		lblEmployeeName.Location = new Point(280, 41);
		lblEmployeeName.Margin = new Padding(4, 0, 4, 0);
		lblEmployeeName.Name = "lblEmployeeName";
		lblEmployeeName.Padding = new Padding(0, 0, 5, 0);
		lblEmployeeName.Size = new Size(239, 31);
		lblEmployeeName.TabIndex = 244;
		lblEmployeeName.TextAlign = ContentAlignment.MiddleLeft;
		ddlMonth.DrawMode = DrawMode.OwnerDrawVariable;
		ddlMonth.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlMonth.FlatStyle = FlatStyle.Flat;
		ddlMonth.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
		ddlMonth.ItemHeight = 24;
		ddlMonth.Items.AddRange(new object[2] { "Current Month", "Previous Month" });
		ddlMonth.Location = new Point(6, 42);
		ddlMonth.Margin = new Padding(4, 5, 4, 5);
		ddlMonth.Name = "ddlMonth";
		ddlMonth.Size = new Size(192, 30);
		ddlMonth.TabIndex = 246;
		ddlMonth.SelectedIndexChanged += ddlMonth_SelectedIndexChanged;
		btnClose.Anchor = AnchorStyles.Top;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 14f);
		btnClose.ForeColor = Color.White;
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(349, 447);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(170, 75);
		btnClose.TabIndex = 247;
		btnClose.Text = "CLOSE";
		btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnExport.BackColor = Color.FromArgb(65, 168, 95);
		btnExport.FlatAppearance.BorderColor = Color.White;
		btnExport.FlatAppearance.BorderSize = 0;
		btnExport.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnExport.FlatStyle = FlatStyle.Flat;
		btnExport.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnExport.ForeColor = Color.White;
		btnExport.ImeMode = ImeMode.NoControl;
		btnExport.Location = new Point(6, 5);
		btnExport.Name = "btnExport";
		btnExport.Padding = new Padding(5);
		btnExport.Size = new Size(130, 37);
		btnExport.TabIndex = 248;
		btnExport.Text = "EXPORT";
		btnExport.UseVisualStyleBackColor = false;
		btnExport.Click += btnExport_Click;
		timer_0.Interval = 200;
		timer_0.Tick += timer_0_Tick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(523, 528);
		base.Controls.Add(btnExport);
		base.Controls.Add(btnClose);
		base.Controls.Add(ddlMonth);
		base.Controls.Add(lblEmployeeName);
		base.Controls.Add(ddlEmployee);
		base.Controls.Add(label1);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(btnTimeIn);
		base.Controls.Add(btnTimeOut);
		base.Controls.Add(radListPunch);
		base.Controls.Add(lblWIndowTitle);
		base.Name = "frmEmployeePunchInOut";
		base.Opacity = 1.0;
		Text = "frmEmployeePunchInOut";
		((ISupportInitialize)radListPunch).EndInit();
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)ddlEmployee).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void method_9()
	{
		try
		{
			Thread.Sleep(5000);
			Invoke((MethodInvoker)delegate
			{
				Close();
			});
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private void method_10()
	{
		Close();
	}

	[CompilerGenerated]
	private void method_11()
	{
		try
		{
			Thread.Sleep(5000);
			Invoke((MethodInvoker)delegate
			{
				Close();
			});
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private void method_12()
	{
		Close();
	}
}
