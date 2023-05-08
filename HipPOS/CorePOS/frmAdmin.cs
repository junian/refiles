using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.AdminPanel;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmAdmin : frmMasterForm
{
	private TransparentLabel transparentLabel_0;

	private Control control_0;

	private IContainer icontainer_1;

	private Panel panel1;

	private Panel panel2;

	internal Button btnClose;

	internal Button btnSettings;

	internal Button btnAddItemInGroup;

	internal Button btnEmployees;

	private Label lblTrainingMode;

	internal Button btnTaxSettings;

	internal Button btnViewGroupItems;

	internal Button btnOptions;

	internal Button btnInstructions;

	internal Button btnSetMode;

	private System.Windows.Forms.Timer timer_0;

	internal Button btnEditLayout;

	internal Button btnAddEditIngredients;

	internal Button btnAddEditGroup;

	internal Button btnAddEditItem;

	internal Button btnPromotions;

	public frmAdmin(Control _lblTrainingModeSplashScreen = null)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this, 2.5f);
		control_0 = _lblTrainingModeSplashScreen;
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			btnSetMode.Text = Resources.PRODUCTION_MODE;
			btnSetMode.Font = new Font("Microsoft Sans Serif", 9f);
			btnSetMode.Padding = new Padding(0, 5, 0, 5);
			lblTrainingMode.Visible = true;
		}
		else
		{
			btnSetMode.Text = Resources.TRAINING_MODE;
			btnSetMode.Font = new Font("Microsoft Sans Serif", 10f);
			btnSetMode.Padding = new Padding(0, 5, 0, 3);
			lblTrainingMode.Visible = false;
		}
		if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
		{
			btnEditLayout.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			btnSetMode.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
		}
	}

	private void frmAdmin_Load(object sender, EventArgs e)
	{
		if (new GClass6().Settings.Where((Setting o) => o.Key == "restaurant_mode").FirstOrDefault().Value == "Quick Service")
		{
			btnEditLayout.Enabled = false;
			btnEditLayout.BackColor = Color.Gray;
		}
	}

	private void btnAddItemInGroup_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddItemInGroup frmAddItemInGroup2 = new frmAddItemInGroup();
		frmAddItemInGroup2.TopLevel = false;
		panel1.Controls.Add(frmAddItemInGroup2);
		frmAddItemInGroup2.FormBorderStyle = FormBorderStyle.None;
		frmAddItemInGroup2.Dock = DockStyle.Fill;
		frmAddItemInGroup2.Show();
	}

	private void method_3(object sender, EventArgs e)
	{
		method_4();
		frmAdminCompanySetup frmAdminCompanySetup2 = new frmAdminCompanySetup();
		frmAdminCompanySetup2.TopLevel = false;
		panel1.Controls.Add(frmAdminCompanySetup2);
		frmAdminCompanySetup2.FormBorderStyle = FormBorderStyle.None;
		frmAdminCompanySetup2.Dock = DockStyle.Fill;
		frmAdminCompanySetup2.Show();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		CloseAdmin();
	}

	public void CloseAdmin()
	{
		method_4();
		CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
		MemoryLoadedObjects.isUserRemember = false;
		((frmSplash)Application.OpenForms["frmSplash"])?.SetBtnLogOutText("");
		Close();
		GC.Collect();
	}

	private void btnSettings_Click(object sender, EventArgs e)
	{
		method_4();
		frmAdminSettings frmAdminSettings2 = new frmAdminSettings();
		frmAdminSettings2.TopLevel = false;
		panel1.Controls.Add(frmAdminSettings2);
		frmAdminSettings2.FormBorderStyle = FormBorderStyle.None;
		frmAdminSettings2.Dock = DockStyle.Fill;
		frmAdminSettings2.Show();
	}

	private void btnEmployees_Click(object sender, EventArgs e)
	{
		method_4();
		frmAdminEmployees frmAdminEmployees2 = new frmAdminEmployees();
		frmAdminEmployees2.TopLevel = false;
		panel1.Controls.Add(frmAdminEmployees2);
		frmAdminEmployees2.FormBorderStyle = FormBorderStyle.None;
		frmAdminEmployees2.Dock = DockStyle.Fill;
		frmAdminEmployees2.Show();
	}

	private void btnTaxSettings_Click(object sender, EventArgs e)
	{
		method_4();
		frmAdminTaxSettings frmAdminTaxSettings2 = new frmAdminTaxSettings();
		frmAdminTaxSettings2.TopLevel = false;
		panel1.Controls.Add(frmAdminTaxSettings2);
		frmAdminTaxSettings2.FormBorderStyle = FormBorderStyle.None;
		frmAdminTaxSettings2.Dock = DockStyle.Fill;
		frmAdminTaxSettings2.Show();
	}

	private void btnViewGroupItems_Click(object sender, EventArgs e)
	{
		method_4();
		frmAdminViewItemsAndGroups frmAdminViewItemsAndGroups2 = new frmAdminViewItemsAndGroups();
		frmAdminViewItemsAndGroups2.TopLevel = false;
		panel1.Controls.Add(frmAdminViewItemsAndGroups2);
		frmAdminViewItemsAndGroups2.FormBorderStyle = FormBorderStyle.None;
		frmAdminViewItemsAndGroups2.Dock = DockStyle.Fill;
		frmAdminViewItemsAndGroups2.Show();
	}

	private void btnOptions_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddEditOptions frmAddEditOptions2 = new frmAddEditOptions();
		frmAddEditOptions2.TopLevel = false;
		panel1.Controls.Add(frmAddEditOptions2);
		frmAddEditOptions2.FormBorderStyle = FormBorderStyle.None;
		frmAddEditOptions2.Dock = DockStyle.Fill;
		frmAddEditOptions2.Show();
	}

	private void btnInstructions_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddEditInstructions frmAddEditInstructions2 = new frmAddEditInstructions();
		frmAddEditInstructions2.TopLevel = false;
		panel1.Controls.Add(frmAddEditInstructions2);
		frmAddEditInstructions2.FormBorderStyle = FormBorderStyle.None;
		frmAddEditInstructions2.Dock = DockStyle.Fill;
		frmAddEditInstructions2.Show();
	}

	private void btnSetMode_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		bool flag = false;
		Setting setting = new GClass6().Settings.Where((Setting o) => o.Key.ToLower() == "restaurant_mode").FirstOrDefault();
		do
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				flag = true;
			}
			else if (UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered), new List<string>
			{
				Roles.admin,
				Roles.manager,
				Roles.supervisor
			}))
			{
				flag = true;
				if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
				{
					CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"] = true;
					Helper.SetConnectionString(StringCipher.Decrypt(Helper.GetEncryptedConnectionString(), "DigitalCraftHipPOS"));
					try
					{
						GClass6 gClass = new GClass6();
						gClass.Taxes.FirstOrDefault();
						btnSetMode.Text = Resources.PRODUCTION_MODE;
						btnSetMode.Font = new Font(Resources.Microsoft_Sans_Serif, 9f);
						btnSetMode.Padding = new Padding(0, 5, 0, 5);
						lblTrainingMode.Visible = true;
						if (control_0 != null)
						{
							control_0.Visible = true;
						}
						gClass.Settings.Where((Setting o) => o.Key.ToLower() == "restaurant_mode").FirstOrDefault().Value = setting.Value;
						Helper.SubmitChangesWithCatch(gClass);
						new frmMessageBox(Resources.Training_Mode_has_been_activat).ShowDialog(this);
					}
					catch
					{
						new frmMessageBox(Resources.Training_Database_does_not_exi).ShowDialog(this);
						CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"] = false;
						lblTrainingMode.Visible = false;
						btnSetMode.Text = Resources.TRAINING_MODE;
						btnSetMode.Font = new Font("Microsoft Sans Serif", 10f);
						btnSetMode.Padding = new Padding(0, 5, 0, 3);
						Helper.SetConnectionString(StringCipher.Decrypt(Helper.GetEncryptedConnectionString(), "DigitalCraftHipPOS"));
					}
				}
				else
				{
					CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"] = false;
					Helper.SetConnectionString(StringCipher.Decrypt(Helper.GetEncryptedConnectionString(), "DigitalCraftHipPOS"));
					lblTrainingMode.Visible = false;
					btnSetMode.Text = Resources.TRAINING_MODE;
					btnSetMode.Font = new Font("Microsoft Sans Serif", 10f);
					if (control_0 != null)
					{
						control_0.Visible = false;
					}
					new frmMessageBox(Resources.Production_Mode_has_been_resto).ShowDialog(this);
				}
				CorePOS.Properties.Settings.Default.Save();
				method_4();
				SettingsHelper.SetAllSettings();
				MemoryLoadedObjects.RefreshUsers();
				MemoryLoadedObjects.RefreshPromotions();
				MemoryLoadedObjects.RefreshGeneralOEData();
				MemoryLoadedObjects.RefreshItemImages();
				btnClose_Click(null, null);
			}
			else
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
			}
		}
		while (!flag);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (transparentLabel_0 != null)
		{
			if (transparentLabel_0.Opacity > 15)
			{
				transparentLabel_0.Opacity -= 15;
				return;
			}
			transparentLabel_0.Opacity = 0;
			transparentLabel_0.SendToBack();
			transparentLabel_0.Dispose();
			timer_0.Enabled = false;
			transparentLabel_0 = null;
			GC.Collect();
		}
	}

	private void method_4()
	{
		Control.ControlCollection controls = panel1.Controls;
		if (controls.Count > 0)
		{
			Form form = controls[0].FindForm();
			ControlHelpers.ClearControlsInPanel(panel1);
			form.Dispose();
		}
		controls = null;
		GC.Collect();
	}

	private void btnEditLayout_Click(object sender, EventArgs e)
	{
		frmEditLayout obj = new frmEditLayout(0, 1);
		obj.ShowDialog();
		obj.Dispose();
		GC.Collect();
	}

	private void btnAddEditIngredients_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddEditMaterials frmAddEditMaterials2 = new frmAddEditMaterials();
		frmAddEditMaterials2.TopLevel = false;
		panel1.Controls.Add(frmAddEditMaterials2);
		frmAddEditMaterials2.FormBorderStyle = FormBorderStyle.None;
		frmAddEditMaterials2.Dock = DockStyle.Fill;
		frmAddEditMaterials2.Show();
	}

	private void btnAddEditGroup_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddEditGroups frmAddEditGroups2 = new frmAddEditGroups();
		frmAddEditGroups2.TopLevel = false;
		panel1.Controls.Add(frmAddEditGroups2);
		frmAddEditGroups2.FormBorderStyle = FormBorderStyle.None;
		frmAddEditGroups2.Dock = DockStyle.Fill;
		frmAddEditGroups2.Show();
	}

	private void btnAddEditItem_Click(object sender, EventArgs e)
	{
		method_4();
		frmAddEditItems frmAddEditItems2 = new frmAddEditItems();
		frmAddEditItems2.TopLevel = false;
		panel1.Controls.Add(frmAddEditItems2);
		frmAddEditItems2.FormBorderStyle = FormBorderStyle.None;
		frmAddEditItems2.Dock = DockStyle.Fill;
		frmAddEditItems2.Show();
	}

	private void btnEmployees_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!string.IsNullOrEmpty(button.Text))
		{
			if (!button.Enabled)
			{
				button.Tag = button.BackColor;
				button.BackColor = Color.Gray;
			}
			else if (!string.IsNullOrEmpty(button.Tag.ToString()))
			{
				button.BackColor = (Color)button.Tag;
			}
		}
	}

	private void btnPromotions_Click(object sender, EventArgs e)
	{
		method_4();
		frmPromotionList frmPromotionList = new frmPromotionList();
		frmPromotionList.TopLevel = false;
		panel1.Controls.Add(frmPromotionList);
		frmPromotionList.FormBorderStyle = FormBorderStyle.None;
		frmPromotionList.Dock = DockStyle.Fill;
		frmPromotionList.Show();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdmin));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		lblTrainingMode = new Label();
		panel2 = new Panel();
		btnAddEditItem = new Button();
		btnAddEditGroup = new Button();
		btnEditLayout = new Button();
		btnAddEditIngredients = new Button();
		btnSetMode = new Button();
		btnInstructions = new Button();
		btnOptions = new Button();
		btnViewGroupItems = new Button();
		btnTaxSettings = new Button();
		btnClose = new Button();
		btnSettings = new Button();
		btnAddItemInGroup = new Button();
		btnEmployees = new Button();
		panel1 = new Panel();
		btnPromotions = new Button();
		panel2.SuspendLayout();
		SuspendLayout();
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		panel2.BorderStyle = BorderStyle.FixedSingle;
		panel2.Controls.Add(btnPromotions);
		panel2.Controls.Add(btnAddEditItem);
		panel2.Controls.Add(btnAddEditGroup);
		panel2.Controls.Add(btnEditLayout);
		panel2.Controls.Add(btnAddEditIngredients);
		panel2.Controls.Add(btnSetMode);
		panel2.Controls.Add(btnInstructions);
		panel2.Controls.Add(btnOptions);
		panel2.Controls.Add(btnViewGroupItems);
		panel2.Controls.Add(btnTaxSettings);
		panel2.Controls.Add(btnClose);
		panel2.Controls.Add(btnSettings);
		panel2.Controls.Add(btnAddItemInGroup);
		panel2.Controls.Add(btnEmployees);
		componentResourceManager.ApplyResources(panel2, "panel2");
		panel2.Name = "panel2";
		btnAddEditItem.BackColor = Color.FromArgb(176, 124, 219);
		btnAddEditItem.DialogResult = DialogResult.OK;
		btnAddEditItem.FlatAppearance.BorderColor = Color.White;
		btnAddEditItem.FlatAppearance.BorderSize = 0;
		btnAddEditItem.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddEditItem, "btnAddEditItem");
		btnAddEditItem.ForeColor = Color.White;
		btnAddEditItem.Name = "btnAddEditItem";
		btnAddEditItem.UseVisualStyleBackColor = false;
		btnAddEditItem.EnabledChanged += btnEmployees_EnabledChanged;
		btnAddEditItem.Click += btnAddEditItem_Click;
		btnAddEditGroup.BackColor = Color.FromArgb(147, 101, 184);
		btnAddEditGroup.DialogResult = DialogResult.OK;
		btnAddEditGroup.FlatAppearance.BorderColor = Color.White;
		btnAddEditGroup.FlatAppearance.BorderSize = 0;
		btnAddEditGroup.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddEditGroup, "btnAddEditGroup");
		btnAddEditGroup.ForeColor = Color.White;
		btnAddEditGroup.Name = "btnAddEditGroup";
		btnAddEditGroup.UseVisualStyleBackColor = false;
		btnAddEditGroup.EnabledChanged += btnEmployees_EnabledChanged;
		btnAddEditGroup.Click += btnAddEditGroup_Click;
		btnEditLayout.BackColor = Color.FromArgb(69, 175, 171);
		btnEditLayout.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnEditLayout.FlatAppearance.BorderSize = 0;
		btnEditLayout.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnEditLayout, "btnEditLayout");
		btnEditLayout.ForeColor = Color.White;
		btnEditLayout.Name = "btnEditLayout";
		btnEditLayout.Tag = "EDIT LAYOUT BUTTON";
		btnEditLayout.UseVisualStyleBackColor = false;
		btnEditLayout.Click += btnEditLayout_Click;
		btnAddEditIngredients.BackColor = Color.FromArgb(73, 195, 191);
		btnAddEditIngredients.DialogResult = DialogResult.OK;
		btnAddEditIngredients.FlatAppearance.BorderColor = Color.White;
		btnAddEditIngredients.FlatAppearance.BorderSize = 0;
		btnAddEditIngredients.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddEditIngredients, "btnAddEditIngredients");
		btnAddEditIngredients.ForeColor = Color.White;
		btnAddEditIngredients.Name = "btnAddEditIngredients";
		btnAddEditIngredients.UseVisualStyleBackColor = false;
		btnAddEditIngredients.EnabledChanged += btnEmployees_EnabledChanged;
		btnAddEditIngredients.Click += btnAddEditIngredients_Click;
		componentResourceManager.ApplyResources(btnSetMode, "btnSetMode");
		btnSetMode.BackColor = Color.FromArgb(214, 142, 81);
		btnSetMode.FlatAppearance.BorderColor = Color.White;
		btnSetMode.FlatAppearance.BorderSize = 0;
		btnSetMode.FlatAppearance.MouseDownBackColor = Color.White;
		btnSetMode.ForeColor = Color.White;
		btnSetMode.Name = "btnSetMode";
		btnSetMode.UseVisualStyleBackColor = false;
		btnSetMode.EnabledChanged += btnEmployees_EnabledChanged;
		btnSetMode.Click += btnSetMode_Click;
		btnInstructions.BackColor = Color.FromArgb(53, 153, 77);
		btnInstructions.DialogResult = DialogResult.OK;
		btnInstructions.FlatAppearance.BorderColor = Color.White;
		btnInstructions.FlatAppearance.BorderSize = 0;
		btnInstructions.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnInstructions, "btnInstructions");
		btnInstructions.ForeColor = Color.White;
		btnInstructions.Name = "btnInstructions";
		btnInstructions.UseVisualStyleBackColor = false;
		btnInstructions.EnabledChanged += btnEmployees_EnabledChanged;
		btnInstructions.Click += btnInstructions_Click;
		btnOptions.BackColor = Color.FromArgb(65, 168, 95);
		btnOptions.DialogResult = DialogResult.OK;
		btnOptions.FlatAppearance.BorderColor = Color.White;
		btnOptions.FlatAppearance.BorderSize = 0;
		btnOptions.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnOptions, "btnOptions");
		btnOptions.ForeColor = Color.White;
		btnOptions.Name = "btnOptions";
		btnOptions.UseVisualStyleBackColor = false;
		btnOptions.EnabledChanged += btnEmployees_EnabledChanged;
		btnOptions.Click += btnOptions_Click;
		btnViewGroupItems.BackColor = Color.FromArgb(80, 203, 116);
		btnViewGroupItems.DialogResult = DialogResult.OK;
		btnViewGroupItems.FlatAppearance.BorderColor = Color.White;
		btnViewGroupItems.FlatAppearance.BorderSize = 0;
		btnViewGroupItems.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnViewGroupItems, "btnViewGroupItems");
		btnViewGroupItems.ForeColor = Color.White;
		btnViewGroupItems.Name = "btnViewGroupItems";
		btnViewGroupItems.UseVisualStyleBackColor = false;
		btnViewGroupItems.EnabledChanged += btnEmployees_EnabledChanged;
		btnViewGroupItems.Click += btnViewGroupItems_Click;
		btnTaxSettings.BackColor = Color.SandyBrown;
		btnTaxSettings.DialogResult = DialogResult.OK;
		btnTaxSettings.FlatAppearance.BorderColor = Color.White;
		btnTaxSettings.FlatAppearance.BorderSize = 0;
		btnTaxSettings.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnTaxSettings, "btnTaxSettings");
		btnTaxSettings.ForeColor = Color.White;
		btnTaxSettings.Name = "btnTaxSettings";
		btnTaxSettings.UseVisualStyleBackColor = false;
		btnTaxSettings.EnabledChanged += btnEmployees_EnabledChanged;
		btnTaxSettings.Click += btnTaxSettings_Click;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnClose.FlatAppearance.BorderSize = 2;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnSettings.BackColor = Color.FromArgb(242, 147, 65);
		btnSettings.DialogResult = DialogResult.OK;
		btnSettings.FlatAppearance.BorderColor = Color.White;
		btnSettings.FlatAppearance.BorderSize = 0;
		btnSettings.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSettings, "btnSettings");
		btnSettings.ForeColor = Color.White;
		btnSettings.Name = "btnSettings";
		btnSettings.UseVisualStyleBackColor = false;
		btnSettings.EnabledChanged += btnEmployees_EnabledChanged;
		btnSettings.Click += btnSettings_Click;
		btnAddItemInGroup.BackColor = Color.FromArgb(95, 237, 136);
		btnAddItemInGroup.DialogResult = DialogResult.OK;
		btnAddItemInGroup.FlatAppearance.BorderColor = Color.White;
		btnAddItemInGroup.FlatAppearance.BorderSize = 0;
		btnAddItemInGroup.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddItemInGroup, "btnAddItemInGroup");
		btnAddItemInGroup.ForeColor = Color.White;
		btnAddItemInGroup.Name = "btnAddItemInGroup";
		btnAddItemInGroup.UseVisualStyleBackColor = false;
		btnAddItemInGroup.EnabledChanged += btnEmployees_EnabledChanged;
		btnAddItemInGroup.Click += btnAddItemInGroup_Click;
		btnEmployees.BackColor = Color.FromArgb(255, 192, 128);
		btnEmployees.FlatAppearance.BorderColor = Color.White;
		btnEmployees.FlatAppearance.BorderSize = 0;
		btnEmployees.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnEmployees, "btnEmployees");
		btnEmployees.ForeColor = Color.White;
		btnEmployees.Name = "btnEmployees";
		btnEmployees.UseVisualStyleBackColor = false;
		btnEmployees.EnabledChanged += btnEmployees_EnabledChanged;
		btnEmployees.Click += btnEmployees_Click;
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Name = "panel1";
		btnPromotions.BackColor = Color.FromArgb(50, 119, 155);
		btnPromotions.DialogResult = DialogResult.OK;
		btnPromotions.FlatAppearance.BorderColor = Color.White;
		btnPromotions.FlatAppearance.BorderSize = 0;
		btnPromotions.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnPromotions, "btnPromotions");
		btnPromotions.ForeColor = Color.White;
		btnPromotions.Name = "btnPromotions";
		btnPromotions.UseVisualStyleBackColor = false;
		btnPromotions.Click += btnPromotions_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdmin";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmAdmin_Load;
		panel2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
