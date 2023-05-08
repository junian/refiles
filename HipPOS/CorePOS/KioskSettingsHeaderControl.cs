using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class KioskSettingsHeaderControl : UserControl
{
	private IContainer icontainer_0;

	public Label lblDefaultPrinter;

	private Label lblPaymentTerminal;

	private Label lblProductKey;

	private Label lblDeviceName;

	public KioskSettingsHeaderControl()
	{
		Class26.Ggkj0JxzN9YmC();
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.KioskSettingsHeaderControl));
		this.lblDefaultPrinter = new System.Windows.Forms.Label();
		this.lblPaymentTerminal = new System.Windows.Forms.Label();
		this.lblProductKey = new System.Windows.Forms.Label();
		this.lblDeviceName = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblDefaultPrinter.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblDefaultPrinter, "lblDefaultPrinter");
		this.lblDefaultPrinter.ForeColor = System.Drawing.Color.White;
		this.lblDefaultPrinter.Name = "lblDefaultPrinter";
		this.lblPaymentTerminal.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblPaymentTerminal, "lblPaymentTerminal");
		this.lblPaymentTerminal.ForeColor = System.Drawing.Color.White;
		this.lblPaymentTerminal.Name = "lblPaymentTerminal";
		this.lblProductKey.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblProductKey, "lblProductKey");
		this.lblProductKey.ForeColor = System.Drawing.Color.White;
		this.lblProductKey.Name = "lblProductKey";
		this.lblDeviceName.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblDeviceName, "lblDeviceName");
		this.lblDeviceName.ForeColor = System.Drawing.Color.White;
		this.lblDeviceName.Name = "lblDeviceName";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.lblDefaultPrinter);
		base.Controls.Add(this.lblPaymentTerminal);
		base.Controls.Add(this.lblProductKey);
		base.Controls.Add(this.lblDeviceName);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "KioskSettingsHeaderControl";
		base.ResumeLayout(false);
	}
}
