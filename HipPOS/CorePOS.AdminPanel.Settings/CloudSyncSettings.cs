using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class CloudSyncSettings : UserControl
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Control ctrl;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Label lbl;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Label lbl;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	private bool bool_0;

	private IQueryable<Setting> iqueryable_0;

	private IContainer icontainer_0;

	private Label label_api_key;

	private Label label_0;

	private PictureBox pictureBox1;

	private Label label2;

	private Label label1;

	private Label label3;

	private Label label_cloudsync_station;

	private Label lblSyncStation;

	private Label label4;

	private PictureBox pictureBox2;

	private Label label_cloudsync_time_range;

	private RadToggleSwitch chkTimeRange;

	private Label label13;

	private PictureBox pictureBox7;

	private Label label14;

	private Label label6;

	private Label lblOnlineOrderSetting;

	private PictureBox pictureBox13;

	private Label label_loyalty_processor_desc;

	private Label label_online_ordering_settings_title;

	private PictureBox pictureBox17;

	private RadToggleSwitch chkRunSyncService;

	private Label label_capacity_desc;

	private Label label_capacity_title;

	private Panel panel1;

	public CloudSyncSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		// base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		IEnumerator enumerator = base.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
				CS_0024_003C_003E8__locals0.ctrl = (Control)enumerator.Current;
				if (CS_0024_003C_003E8__locals0.ctrl.Tag == null)
				{
					continue;
				}
				Setting setting = iqueryable_0.Where((Setting a) => a.Key == CS_0024_003C_003E8__locals0.ctrl.Tag.ToString()).FirstOrDefault();
				if (setting == null)
				{
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.GetType().Name == "Label")
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("label"))
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
					}
				}
				else if (setting.Value.Contains("ON"))
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = true;
				}
				else
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = false;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		Setting setting2 = iqueryable_0.Where((Setting s) => label_cloudsync_time_range.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting2.Value.Contains("ON"))
		{
			chkTimeRange.Value = true;
			label_cloudsync_time_range.Text = setting2.Value;
		}
		else
		{
			chkTimeRange.Value = false;
			label_cloudsync_time_range.Text = setting2.Value;
		}
		if (Helper.GetConnectionString().Contains("AttachDbFilename"))
		{
			panel1.Visible = false;
		}
		else if (iqueryable_0.Where((Setting a) => a.Key == chkRunSyncService.Tag.ToString()).FirstOrDefault().Value.Contains("ON"))
		{
			chkRunSyncService.Value = true;
		}
		else
		{
			chkRunSyncService.Value = false;
		}
		bool_0 = false;
	}

	private void label_0_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.lbl = (Label)sender;
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.lbl.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_The_CloudSync_API_Key, 0, 128, setting.Value);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			string value = (label_api_key.Text = MemoryLoadedObjects.Keyboard.textEntered);
			setting.Value = value;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.lbl.Tag.ToString(), label_api_key.Text);
			if (new frmMessageBox(Resources.Hippos_needs_to_be_restarted_f, Resources.Settings_changed, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	private void lblSyncStation_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.lbl = (Label)sender;
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.lbl.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			string value = (label_cloudsync_station.Text = Environment.MachineName);
			setting.Value = value;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.lbl.Tag.ToString(), label_cloudsync_station.Text);
			if (new frmMessageBox(Resources.Hippos_needs_to_be_restarted_f, Resources.Settings_changed, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	private void chkTimeRange_Click(object sender, EventArgs e)
	{
	}

	private void chkTimeRange_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => label_cloudsync_time_range.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (chkTimeRange.Value)
		{
			frmTimeRangeSelect frmTimeRangeSelect = new frmTimeRangeSelect();
			if (frmTimeRangeSelect.ShowDialog() == DialogResult.OK)
			{
				if (new frmMessageBox(Resources.Please_make_sure_that_your_POS).ShowDialog(this) == DialogResult.OK)
				{
					label_cloudsync_time_range.Text = "ON|" + frmTimeRangeSelect.StartTime.ToLongTimeString() + "|" + frmTimeRangeSelect.EndTime.ToLongTimeString();
				}
			}
			else
			{
				label_cloudsync_time_range.Text = "OFF";
				chkTimeRange.Value = false;
			}
		}
		else
		{
			label_cloudsync_time_range.Text = "OFF";
		}
		setting.Value = label_cloudsync_time_range.Text;
		Helper.SubmitChangesWithCatch(gclass6_0);
		SettingsHelper.SetSettingValueByKey(label_cloudsync_time_range.Tag.ToString(), label_cloudsync_time_range.Text);
	}

	private void lblOnlineOrderSetting_Click(object sender, EventArgs e)
	{
		new frmOnlineOrderSyncSettings().Show(this);
	}

	private void chkRunSyncService_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkRunSyncService.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.ToUpper().Equals("ON"))
			{
				setting.Value = "OFF";
			}
			else
			{
				setting.Value = "ON";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(chkRunSyncService.Tag.ToString(), setting.Value);
			if (new frmMessageBox(Resources.Hippos_needs_to_be_restarted_f, Resources.Settings_Changed0, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.CloudSyncSettings));
		this.label_api_key = new System.Windows.Forms.Label();
		this.label_0 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label_cloudsync_station = new System.Windows.Forms.Label();
		this.lblSyncStation = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label_cloudsync_time_range = new System.Windows.Forms.Label();
		this.chkTimeRange = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label13 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label14 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.lblOnlineOrderSetting = new System.Windows.Forms.Label();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.label_loyalty_processor_desc = new System.Windows.Forms.Label();
		this.label_online_ordering_settings_title = new System.Windows.Forms.Label();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.chkRunSyncService = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_capacity_desc = new System.Windows.Forms.Label();
		this.label_capacity_title = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkTimeRange).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkRunSyncService).BeginInit();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.label_api_key, "label_api_key");
		this.label_api_key.ForeColor = System.Drawing.Color.Gray;
		this.label_api_key.Name = "label_api_key";
		this.label_api_key.Tag = "cloudsync_api_key";
		componentResourceManager.ApplyResources(this.label_0, "lblAPIKey");
		this.label_0.ForeColor = System.Drawing.Color.RoyalBlue;
		this.label_0.Name = "lblAPIKey";
		this.label_0.Tag = "cloudsync_api_key";
		this.label_0.Click += new System.EventHandler(label_0_Click);
		componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		this.label2.Tag = "";
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		componentResourceManager.ApplyResources(this.label3, "label3");
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		componentResourceManager.ApplyResources(this.label_cloudsync_station, "label_cloudsync_station");
		this.label_cloudsync_station.ForeColor = System.Drawing.Color.Gray;
		this.label_cloudsync_station.Name = "label_cloudsync_station";
		this.label_cloudsync_station.Tag = "cloudsync_station";
		componentResourceManager.ApplyResources(this.lblSyncStation, "lblSyncStation");
		this.lblSyncStation.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblSyncStation.Name = "lblSyncStation";
		this.lblSyncStation.Tag = "cloudsync_station";
		this.lblSyncStation.Click += new System.EventHandler(lblSyncStation_Click);
		componentResourceManager.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this.label_cloudsync_time_range, "label_cloudsync_time_range");
		this.label_cloudsync_time_range.ForeColor = System.Drawing.Color.Gray;
		this.label_cloudsync_time_range.Name = "label_cloudsync_time_range";
		this.label_cloudsync_time_range.Tag = "cloudsync_time_range";
		componentResourceManager.ApplyResources(this.chkTimeRange, "chkTimeRange");
		this.chkTimeRange.Name = "chkTimeRange";
		this.chkTimeRange.Tag = "cloudsync_time_range";
		this.chkTimeRange.ThumbTickness = 27;
		this.chkTimeRange.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkTimeRange.Value = false;
		this.chkTimeRange.ValueChanged += new System.EventHandler(chkTimeRange_ValueChanged);
		this.chkTimeRange.Click += new System.EventHandler(chkTimeRange_Click);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTimeRange.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTimeRange.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTimeRange.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTimeRange.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTimeRange.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTimeRange.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTimeRange.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.label13, "label13");
		this.label13.BackColor = System.Drawing.Color.Transparent;
		this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		componentResourceManager.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		componentResourceManager.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		this.label14.Tag = "";
		componentResourceManager.ApplyResources(this.label6, "label6");
		this.label6.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label6.ForeColor = System.Drawing.Color.White;
		this.label6.Name = "label6";
		componentResourceManager.ApplyResources(this.lblOnlineOrderSetting, "lblOnlineOrderSetting");
		this.lblOnlineOrderSetting.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblOnlineOrderSetting.Name = "lblOnlineOrderSetting";
		this.lblOnlineOrderSetting.Click += new System.EventHandler(lblOnlineOrderSetting_Click);
		componentResourceManager.ApplyResources(this.pictureBox13, "pictureBox13");
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.TabStop = false;
		componentResourceManager.ApplyResources(this.label_loyalty_processor_desc, "label_loyalty_processor_desc");
		this.label_loyalty_processor_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_loyalty_processor_desc.Name = "label_loyalty_processor_desc";
		this.label_loyalty_processor_desc.Tag = "";
		this.label_online_ordering_settings_title.BackColor = System.Drawing.Color.Transparent;
		this.label_online_ordering_settings_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_online_ordering_settings_title, "label_online_ordering_settings_title");
		this.label_online_ordering_settings_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_online_ordering_settings_title.Name = "label_online_ordering_settings_title";
		componentResourceManager.ApplyResources(this.pictureBox17, "pictureBox17");
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.TabStop = false;
		componentResourceManager.ApplyResources(this.chkRunSyncService, "chkRunSyncService");
		this.chkRunSyncService.Name = "chkRunSyncService";
		this.chkRunSyncService.Tag = "run_sync_service";
		this.chkRunSyncService.ThumbTickness = 27;
		this.chkRunSyncService.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkRunSyncService.Value = false;
		this.chkRunSyncService.ValueChanged += new System.EventHandler(chkRunSyncService_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkRunSyncService.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkRunSyncService.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkRunSyncService.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkRunSyncService.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkRunSyncService.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkRunSyncService.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkRunSyncService.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.label_capacity_desc, "label_capacity_desc");
		this.label_capacity_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_capacity_desc.Name = "label_capacity_desc";
		this.label_capacity_desc.Tag = "";
		this.label_capacity_title.BackColor = System.Drawing.Color.Transparent;
		this.label_capacity_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_capacity_title, "label_capacity_title");
		this.label_capacity_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_capacity_title.Name = "label_capacity_title";
		this.panel1.Controls.Add(this.chkRunSyncService);
		this.panel1.Controls.Add(this.pictureBox17);
		this.panel1.Controls.Add(this.label_capacity_title);
		this.panel1.Controls.Add(this.label_capacity_desc);
		componentResourceManager.ApplyResources(this.panel1, "panel1");
		this.panel1.Name = "panel1";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.lblOnlineOrderSetting);
		base.Controls.Add(this.pictureBox13);
		base.Controls.Add(this.label_loyalty_processor_desc);
		base.Controls.Add(this.label_online_ordering_settings_title);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label_cloudsync_time_range);
		base.Controls.Add(this.chkTimeRange);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label_cloudsync_station);
		base.Controls.Add(this.lblSyncStation);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label_api_key);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "CloudSyncSettings";
		componentResourceManager.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkTimeRange).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkRunSyncService).EndInit();
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
