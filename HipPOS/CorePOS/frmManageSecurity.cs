using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmManageSecurity : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public ModulesAndFeature module;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetSecurityMatrix_003Eb__3(SecurityMatrix a)
		{
			return a.ModuleID == module.Id;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public Role role;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass6_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetSecurityMatrix_003Eb__4(SecurityMatrix a)
		{
			if (a.ModuleID == CS_0024_003C_003E8__locals1.module.Id)
			{
				return a.RoleID == role.RoleID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int moduleId;

		public short roleId;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private List<Role> list_2;

	private bool bool_0;

	private int int_0;

	private int int_1;

	private IContainer icontainer_1;

	private Label lblHeaderTitle;

	private FlowLayoutPanel pnlRoles;

	private FlowLayoutPanel pnlSecurityMatrix;

	private PictureBox pictureBox1;

	private VerticalScrollControl verticalScrollControl1;

	public frmManageSecurity()
	{
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<Role>();
		int_0 = 350;
		int_1 = 90;
		// base._002Ector();
		GClass6 gClass = new GClass6();
		list_2 = (from x in gClass.Roles
			where x.RoleID != 4 && x.RoleID != 5
			select x into a
			orderby a.RoleLevel
			select a).ToList();
		int num = list_2.Count();
		InitializeComponent_1();
		int num2 = base.Width;
		base.Width = num * int_1 + int_0 + 90 + 10;
		int num3 = base.Location.X - (base.Width - num2);
		base.Location = new Point((num3 >= 0) ? num3 : 0, base.Location.Y);
		pnlSecurityMatrix.Refresh();
		pnlRoles.Refresh();
		lblHeaderTitle.Refresh();
		pictureBox1.Refresh();
		AddRolesToPanel();
		GetSecurityMatrix();
		verticalScrollControl1.ConnectedPanel = pnlSecurityMatrix;
	}

	public void AddRolesToPanel()
	{
		Label label = new Label();
		label.Size = new Size(int_0, pnlRoles.Height);
		label.BackColor = Color.FromArgb(150, 166, 166);
		label.Padding = new Padding(10, 0, 0, 0);
		label.Margin = new Padding(0, 1, 1, 0);
		pnlRoles.Controls.Add(label);
		foreach (Role item in list_2)
		{
			Label label2 = new Label();
			label2.Name = "lbl" + item.RoleName;
			int num = ((item.RoleID == 6) ? 10 : 0);
			Size size = new Size(int_1 + num, pnlRoles.Height);
			label2.Size = size;
			label2.Margin = new Padding(0, 1, 1, 0);
			label2.Padding = new Padding(0, 0, 0, 0);
			label2.Text = Resources.ResourceManager.GetString(item.RoleName.Replace(" ", "_"));
			label2.BackColor = Color.FromArgb(50, 119, 155);
			label2.ForeColor = Color.White;
			label2.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular);
			label2.TextAlign = ContentAlignment.MiddleCenter;
			pnlRoles.Controls.Add(label2);
		}
	}

	public void GetSecurityMatrix()
	{
		GClass6 gClass = new GClass6();
		string empty = string.Empty;
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("restaurant_mode");
		List<SecurityMatrix> source = gClass.SecurityMatrixes.ToList();
		using List<ModulesAndFeature>.Enumerator enumerator = (from x in gClass.ModulesAndFeatures
			where x.AllowAdminEdit == true
			select x into a
			orderby a.Description == "Admin Panel" descending, a.Description
			select a).ToList().GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals0.module = enumerator.Current;
			if (settingValueByKey == "Dine In" && CS_0024_003C_003E8__locals0.module.ModuleName == "frmQuickService")
			{
				continue;
			}
			Label label = new Label();
			label.Name = "lbl" + CS_0024_003C_003E8__locals0.module.ModuleName + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.module.ControlName) ? string.Empty : ("_" + CS_0024_003C_003E8__locals0.module.ControlName));
			label.Text = (string.IsNullOrEmpty(empty) ? CS_0024_003C_003E8__locals0.module.Description : empty);
			label.BackColor = Color.FromArgb(150, 166, 166);
			label.ForeColor = Color.White;
			label.Size = new Size(int_0, pnlRoles.Height);
			label.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular);
			if (CS_0024_003C_003E8__locals0.module.Id == 6 && Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
			{
				label.Font = new Font(label.Font.FontFamily, label.Font.Size - 1.25f);
			}
			label.TextAlign = ContentAlignment.MiddleLeft;
			label.Padding = new Padding(10, 0, 0, 0);
			label.Margin = new Padding(0, 1, 1, 0);
			pnlSecurityMatrix.Controls.Add(label);
			List<SecurityMatrix> source2 = source.Where((SecurityMatrix a) => a.ModuleID == CS_0024_003C_003E8__locals0.module.Id).ToList();
			using List<Role>.Enumerator enumerator2 = list_2.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_1();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals1.role = enumerator2.Current;
				Panel panel = new Panel();
				int num = ((CS_0024_003C_003E8__locals1.role.RoleID == 6) ? 10 : 0);
				panel.Size = new Size(int_1 + num, label.Height);
				panel.BackColor = Color.White;
				panel.Margin = new Padding(0, 1, 1, 0);
				panel.Padding = new Padding(0, 0, 0, 0);
				pnlSecurityMatrix.Controls.Add(panel);
				SecurityMatrix securityMatrix = source2.Where((SecurityMatrix a) => a.ModuleID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.module.Id && a.RoleID == CS_0024_003C_003E8__locals1.role.RoleID).FirstOrDefault();
				Class17 @class = new Class17(100, 42, 40);
				@class.Location = new Point(panel.Width / 2 - 21, 0);
				@class.Margin = new Padding(0, 0, 0, 0);
				@class.Padding = new Padding(0, 0, 0, 0);
				if (securityMatrix != null)
				{
					@class.Name = "chkMatrix_" + securityMatrix.ModulesAndFeature.Id + "_" + securityMatrix.Role.RoleID;
					@class.Checked = securityMatrix.IsAllow;
				}
				else
				{
					@class.Name = "chkMatrix_" + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.module.Id + "_" + CS_0024_003C_003E8__locals1.role.RoleID;
					@class.Checked = true;
					SecurityHelper.AddSecurityMatrix(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.module.Id, CS_0024_003C_003E8__locals1.role.RoleID);
				}
				if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.module.ModuleName == "frmAdmin" && (CS_0024_003C_003E8__locals1.role.RoleName == "Admin" || CS_0024_003C_003E8__locals1.role.RoleID == 1))
				{
					@class.Enabled = false;
					panel.BackColor = Color.Gray;
				}
				@class.Click += method_3;
				panel.Controls.Add(@class);
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		GClass6 gClass = new GClass6();
		Class17 @class = (Class17)sender;
		CS_0024_003C_003E8__locals0.moduleId = Convert.ToInt32(@class.Name.Split('_')[1]);
		CS_0024_003C_003E8__locals0.roleId = Convert.ToInt16(@class.Name.Split('_')[2]);
		SecurityMatrix securityMatrix = gClass.SecurityMatrixes.Where((SecurityMatrix a) => a.ModuleID == CS_0024_003C_003E8__locals0.moduleId && a.RoleID == CS_0024_003C_003E8__locals0.roleId).FirstOrDefault();
		if (securityMatrix != null)
		{
			securityMatrix.IsAllow = @class.Checked;
			gClass.SubmitChanges();
			bool_0 = true;
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			new NotificationLabel(this, "Reloading security matrix to memory, please wait...", NotificationTypes.Notification).Show();
			SecurityHelper.LoadSecuritySettings();
		}
		Close();
	}

	private void pnlSecurityMatrix_Paint(object sender, PaintEventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageSecurity));
		pnlRoles = new FlowLayoutPanel();
		lblHeaderTitle = new Label();
		pnlSecurityMatrix = new FlowLayoutPanel();
		pictureBox1 = new PictureBox();
		verticalScrollControl1 = new VerticalScrollControl();
		((ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlRoles, "pnlRoles");
		pnlRoles.Name = "pnlRoles";
		componentResourceManager.ApplyResources(lblHeaderTitle, "lblHeaderTitle");
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.Name = "lblHeaderTitle";
		componentResourceManager.ApplyResources(pnlSecurityMatrix, "pnlSecurityMatrix");
		pnlSecurityMatrix.Name = "pnlSecurityMatrix";
		pnlSecurityMatrix.Paint += pnlSecurityMatrix_Paint;
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Name = "verticalScrollControl1";
		base.AutoScaleMode = AutoScaleMode.None;
		componentResourceManager.ApplyResources(this, "$this");
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(pnlSecurityMatrix);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(pnlRoles);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmManageSecurity";
		base.Opacity = 1.0;
		((ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
