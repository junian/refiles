using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class frmPaymentEntryMethodSelection : frmMasterForm
{
	private IContainer exoNaPido9;

	internal Button btnCancel;

	internal Button btnCash;

	internal Button btnPaymentTerminal;

	internal Button btnManualEntry;

	public frmPaymentEntryMethodSelection()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void btnPaymentTerminal_Click(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && exoNaPido9 != null)
		{
			exoNaPido9.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPaymentEntryMethodSelection));
		btnCancel = new Button();
		btnCash = new Button();
		btnPaymentTerminal = new Button();
		btnManualEntry = new Button();
		SuspendLayout();
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCash.BackColor = Color.FromArgb(50, 119, 155);
		btnCash.FlatAppearance.BorderColor = Color.Black;
		btnCash.FlatAppearance.BorderSize = 0;
		btnCash.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCash, "btnCash");
		btnCash.ForeColor = Color.White;
		btnCash.Name = "btnCash";
		btnCash.Tag = "";
		btnCash.UseVisualStyleBackColor = false;
		btnPaymentTerminal.BackColor = Color.FromArgb(50, 119, 155);
		btnPaymentTerminal.DialogResult = DialogResult.Yes;
		btnPaymentTerminal.FlatAppearance.BorderColor = Color.Black;
		btnPaymentTerminal.FlatAppearance.BorderSize = 0;
		btnPaymentTerminal.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnPaymentTerminal, "btnPaymentTerminal");
		btnPaymentTerminal.ForeColor = Color.White;
		btnPaymentTerminal.Name = "btnPaymentTerminal";
		btnPaymentTerminal.Tag = "";
		btnPaymentTerminal.UseVisualStyleBackColor = false;
		btnPaymentTerminal.Click += btnPaymentTerminal_Click;
		btnManualEntry.BackColor = Color.FromArgb(50, 119, 155);
		btnManualEntry.DialogResult = DialogResult.No;
		btnManualEntry.FlatAppearance.BorderColor = Color.Black;
		btnManualEntry.FlatAppearance.BorderSize = 0;
		btnManualEntry.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnManualEntry, "btnManualEntry");
		btnManualEntry.ForeColor = Color.White;
		btnManualEntry.Name = "btnManualEntry";
		btnManualEntry.Tag = "";
		btnManualEntry.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnManualEntry);
		base.Controls.Add(btnPaymentTerminal);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnCash);
		base.Name = "frmPaymentEntryMethodSelection";
		base.Opacity = 1.0;
		ResumeLayout(performLayout: false);
	}
}
