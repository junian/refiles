using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class DeliveryFeeCalculationHeaderControl : UserControl
{
	private IContainer icontainer_0;

	private Label lblFrom;

	private Label lblTo;

	private Label lblSample;

	public Label lblCharge;

	public DeliveryFeeCalculationHeaderControl()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.DeliveryFeeCalculationHeaderControl));
		this.lblFrom = new System.Windows.Forms.Label();
		this.lblTo = new System.Windows.Forms.Label();
		this.lblSample = new System.Windows.Forms.Label();
		this.lblCharge = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblFrom.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblFrom, "lblFrom");
		this.lblFrom.ForeColor = System.Drawing.Color.White;
		this.lblFrom.Name = "lblFrom";
		this.lblTo.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblTo, "lblTo");
		this.lblTo.ForeColor = System.Drawing.Color.White;
		this.lblTo.Name = "lblTo";
		this.lblSample.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblSample, "lblSample");
		this.lblSample.ForeColor = System.Drawing.Color.White;
		this.lblSample.Name = "lblSample";
		this.lblCharge.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblCharge, "lblCharge");
		this.lblCharge.ForeColor = System.Drawing.Color.White;
		this.lblCharge.Name = "lblCharge";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.lblCharge);
		base.Controls.Add(this.lblSample);
		base.Controls.Add(this.lblTo);
		base.Controls.Add(this.lblFrom);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "DeliveryFeeCalculationHeaderControl";
		base.ResumeLayout(false);
	}
}
