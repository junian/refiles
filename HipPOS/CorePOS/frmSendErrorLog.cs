using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmSendErrorLog : frmMasterForm
{
	private Exception exception_0;

	private IContainer icontainer_1;

	private Label crsFgyswxWt;

	internal Button btnCancel;

	internal Button btnSave;

	private PictureBox pictureBox2;

	public frmSendErrorLog(ThreadExceptionEventArgs e)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		Text = BrandingTerms.SoftwareName.ToUpper();
		exception_0 = e.Exception;
		if (exception_0.StackTrace.Contains("SqlInternalConnection") || exception_0.Message.Contains("The timeout period elapsed prior to completion of the operation or the server is not responding"))
		{
			crsFgyswxWt.Text = "Database disconnected! Please check your database connection and restart the app.";
			crsFgyswxWt.Font = new Font(crsFgyswxWt.Font.FontFamily, 16f);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		LogHelper.WriteLog(exception_0.Message + "\n" + exception_0.StackTrace, LogTypes.error_log);
		NotificationMethods.sendCrash(AppSettings.AppVersion + " Build " + AppSettings.Build, Environment.OSVersion.VersionString, exception_0, isSilent: false);
		new frmMessageBox(Resources.Error_report_has_been_sent_Tha).ShowDialog(this);
		FormHelper.CleanupObjects();
		Application.Restart();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		FormHelper.CleanupObjects();
		Application.Restart();
	}

	private CompanySetup method_3()
	{
		CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
		if (companySetup != null)
		{
			return companySetup;
		}
		return null;
	}

	private Employee method_4()
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.EmpID = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		if (CS_0024_003C_003E8__locals0.EmpID != 0)
		{
			Employee employee = gClass.Employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.EmpID).FirstOrDefault();
			if (employee != null)
			{
				return employee;
			}
			return null;
		}
		return null;
	}

	private void frmSendErrorLog_Load(object sender, EventArgs e)
	{
		DebugMethods.ShowExceptionTextFile(exception_0);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSendErrorLog));
		crsFgyswxWt = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		pictureBox2 = new PictureBox();
		((ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(crsFgyswxWt, "lblMessage");
		crsFgyswxWt.Name = "lblMessage";
		btnCancel.BackColor = Color.FromArgb(193, 57, 43);
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(47, 204, 113);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(pictureBox2, "pictureBox2");
		pictureBox2.Name = "pictureBox2";
		pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(pictureBox2);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(crsFgyswxWt);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSendErrorLog";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.Load += frmSendErrorLog_Load;
		((ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(performLayout: false);
	}
}
