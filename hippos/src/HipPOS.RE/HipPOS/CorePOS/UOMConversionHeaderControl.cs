using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class UOMConversionHeaderControl : UserControl
{
	private IContainer icontainer_0;

	private Label lblUOM;

	private Label lblOp;

	private Label lblFac;

	private Label lblSamp;

	public UOMConversionHeaderControl(FlowLayoutPanel _Panel)
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.UOMConversionHeaderControl));
		this.lblUOM = new System.Windows.Forms.Label();
		this.lblOp = new System.Windows.Forms.Label();
		this.lblFac = new System.Windows.Forms.Label();
		this.lblSamp = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblUOM.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblUOM, "lblUOM");
		this.lblUOM.ForeColor = System.Drawing.Color.White;
		this.lblUOM.Name = "lblUOM";
		this.lblOp.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblOp, "lblOp");
		this.lblOp.ForeColor = System.Drawing.Color.White;
		this.lblOp.Name = "lblOp";
		this.lblFac.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblFac, "lblFac");
		this.lblFac.ForeColor = System.Drawing.Color.White;
		this.lblFac.Name = "lblFac";
		this.lblSamp.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		componentResourceManager.ApplyResources(this.lblSamp, "lblSamp");
		this.lblSamp.ForeColor = System.Drawing.Color.White;
		this.lblSamp.Name = "lblSamp";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.lblSamp);
		base.Controls.Add(this.lblFac);
		base.Controls.Add(this.lblOp);
		base.Controls.Add(this.lblUOM);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "UOMConversionHeaderControl";
		base.ResumeLayout(false);
	}
}
