using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class TerminalSettingsHeaderControl : UserControl
{
	private IContainer icontainer_0;

	public Label lblDefaultPrinter;

	private Label lblPaymentTerminal;

	private Label lblProductKey;

	private Label lblDeviceName;

	public Label label1;

	public TerminalSettingsHeaderControl()
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.TerminalSettingsHeaderControl));
		this.lblDefaultPrinter = new System.Windows.Forms.Label();
		this.lblPaymentTerminal = new System.Windows.Forms.Label();
		this.lblProductKey = new System.Windows.Forms.Label();
		this.lblDeviceName = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
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
		this.label1.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Name = "label1";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.label1);
		base.Controls.Add(this.lblDefaultPrinter);
		base.Controls.Add(this.lblPaymentTerminal);
		base.Controls.Add(this.lblProductKey);
		base.Controls.Add(this.lblDeviceName);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "TerminalSettingsHeaderControl";
		base.ResumeLayout(false);
	}
}
