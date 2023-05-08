using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Data;

namespace CorePOS.AdminPanel.Settings;

public class Template : UserControl
{
	private GClass6 gclass6_0;

	private IContainer icontainer_0;

	private Label label3;

	private Label label_cloudsync_station;

	private Label lblSyncStation;

	private Label label4;

	private PictureBox pictureBox2;

	public Template()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent();
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.Template));
		this.label3 = new System.Windows.Forms.Label();
		this.label_cloudsync_station = new System.Windows.Forms.Label();
		this.lblSyncStation = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label3, "label3");
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
		componentResourceManager.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label_cloudsync_station);
		base.Controls.Add(this.lblSyncStation);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.pictureBox2);
		base.Name = "Template";
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
	}
}
