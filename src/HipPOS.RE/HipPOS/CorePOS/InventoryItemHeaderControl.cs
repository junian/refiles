using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class InventoryItemHeaderControl : UserControl
{
	private IContainer icontainer_0;

	private Label lblItemName;

	private Label lblGroupName;

	private Label lblQty;

	private Label lblChange;

	private Label lblNew;

	private Label lblButtons;

	private Label lblUOM;

	private Label lblComment;

	public InventoryItemHeaderControl(FlowLayoutPanel _PanelItems)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent();
		base.Width = _PanelItems.Width - 20;
		lblGroupName.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0);
		lblItemName.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) - 2;
		lblItemName.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) + 1;
		lblUOM.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		lblUOM.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 4.0);
		lblQty.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		lblQty.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 5.0) + 1;
		lblChange.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		lblChange.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 6.0) + 1;
		lblNew.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		lblNew.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 7.0) + 1;
		if (MemoryLoadedObjects.isMultipleLocation)
		{
			lblComment.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
			lblComment.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 8.0) + 2;
			lblButtons.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 3.0) - 1;
			lblButtons.Left = lblComment.Right + 1;
		}
		else
		{
			lblComment.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) - 1;
			lblComment.Left = lblNew.Right + 2;
			lblButtons.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) - 1;
			lblButtons.Left = lblComment.Right + 1;
		}
	}

	private void method_0(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.InventoryItemHeaderControl));
		this.lblItemName = new System.Windows.Forms.Label();
		this.lblGroupName = new System.Windows.Forms.Label();
		this.lblQty = new System.Windows.Forms.Label();
		this.lblChange = new System.Windows.Forms.Label();
		this.lblNew = new System.Windows.Forms.Label();
		this.lblButtons = new System.Windows.Forms.Label();
		this.lblUOM = new System.Windows.Forms.Label();
		this.lblComment = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblItemName.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblItemName, "lblItemName");
		this.lblItemName.ForeColor = System.Drawing.Color.White;
		this.lblItemName.Name = "lblItemName";
		this.lblGroupName.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblGroupName, "lblGroupName");
		this.lblGroupName.ForeColor = System.Drawing.Color.White;
		this.lblGroupName.Name = "lblGroupName";
		this.lblQty.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblQty, "lblQty");
		this.lblQty.ForeColor = System.Drawing.Color.White;
		this.lblQty.Name = "lblQty";
		this.lblChange.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblChange, "lblChange");
		this.lblChange.ForeColor = System.Drawing.Color.White;
		this.lblChange.Name = "lblChange";
		this.lblNew.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblNew, "lblNew");
		this.lblNew.ForeColor = System.Drawing.Color.White;
		this.lblNew.Name = "lblNew";
		this.lblButtons.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblButtons, "lblButtons");
		this.lblButtons.ForeColor = System.Drawing.Color.White;
		this.lblButtons.Name = "lblButtons";
		this.lblUOM.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblUOM, "lblUOM");
		this.lblUOM.ForeColor = System.Drawing.Color.White;
		this.lblUOM.Name = "lblUOM";
		this.lblComment.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(this.lblComment, "lblComment");
		this.lblComment.ForeColor = System.Drawing.Color.White;
		this.lblComment.Name = "lblComment";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.lblComment);
		base.Controls.Add(this.lblUOM);
		base.Controls.Add(this.lblButtons);
		base.Controls.Add(this.lblNew);
		base.Controls.Add(this.lblChange);
		base.Controls.Add(this.lblQty);
		base.Controls.Add(this.lblGroupName);
		base.Controls.Add(this.lblItemName);
		this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "InventoryItemHeaderControl";
		base.ResumeLayout(false);
	}
}
