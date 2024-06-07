using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;

namespace CorePOS;

public class frmPayoutSafeDrop : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public DateTime lastSafeDropClearingDate;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private IContainer icontainer_1;

	internal Button btnPayout;

	internal Button btnSafeDrop;

	internal Button btnReverseSD;

	internal Button btnClose;

	internal Button btnClearSafeDrop;

	internal Button button1;

	public frmPayoutSafeDrop(bool showPayout)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		if (!showPayout)
		{
			btnPayout.Visible = false;
			button1.Visible = false;
			btnSafeDrop.Location = new Point(btnPayout.Location.X, btnPayout.Location.Y);
			btnSafeDrop.Size = btnPayout.Size;
			btnReverseSD.Location = new Point(btnReverseSD.Location.X - btnPayout.Width, btnReverseSD.Location.Y);
			btnClose.Size = btnReverseSD.Size;
			btnClose.Location = new Point(btnClose.Location.X - btnPayout.Width, btnReverseSD.Location.Y);
			base.Width -= btnPayout.Width;
		}
	}

	private void btnPayout_Click(object sender, EventArgs e)
	{
		MiscHelper.ProcessPayout(this);
	}

	private void btnSafeDrop_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, btnSafeDrop.Name) != null && new frmCashCounter(OrderMethods.GetTotalAmountInTil()).ShowDialog(this) == DialogResult.OK)
		{
			new NotificationLabel(this, "Safe Drop Added", NotificationTypes.Success).Show();
			GClass8.OpenCashDrawer();
		}
	}

	private void btnReverseSD_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, btnSafeDrop.Name) != null)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData("Amount to Reverse Safe Drop", 2, 8);
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
			{
				decimal numberEntered = MemoryLoadedObjects.Numpad.numberEntered;
				GClass6 gClass = new GClass6();
				Payout entity = new Payout
				{
					Amount = numberEntered,
					Reason = PayoutTypes.ReverseSafeDrop,
					DateCreated = DateTime.Now
				};
				gClass.Payouts.InsertOnSubmit(entity);
				gClass.SubmitChanges();
				new NotificationLabel(this, "Reverse Safe Drop Added", NotificationTypes.Success).Show();
			}
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		AuthMethods.LogOutUser();
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnClearSafeDrop_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.lastSafeDropClearingDate = (from a in gClass.Payouts
			where a.Reason == PayoutTypes.SafeDropClearing
			orderby a.DateCreated descending
			select a).FirstOrDefault()?.DateCreated ?? DateTime.Now.Date;
		decimal num = gClass.Payouts.Where((Payout a) => a.Reason == PayoutTypes.SafeDrop && a.DateCreated >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate).ToList().Sum((Payout a) => a.Amount) - gClass.Payouts.Where((Payout a) => a.Reason == PayoutTypes.ReverseSafeDrop && a.DateCreated >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate).ToList().Sum((Payout a) => a.Amount);
		if (num > 0m)
		{
			Payout entity = new Payout
			{
				Amount = -num,
				Reason = PayoutTypes.SafeDropClearing,
				DateCreated = DateTime.Now
			};
			gClass.Payouts.InsertOnSubmit(entity);
			gClass.SubmitChanges();
			new NotificationLabel(this, "Safe Drop Sucessfully Cleared.", NotificationTypes.Success).Show();
		}
		else
		{
			new NotificationLabel(this, "There is nothing to clear in the safe drop.", NotificationTypes.Success).Show();
		}
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
		btnPayout = new Button();
		btnSafeDrop = new Button();
		btnReverseSD = new Button();
		btnClose = new Button();
		btnClearSafeDrop = new Button();
		button1 = new Button();
		SuspendLayout();
		btnPayout.BackColor = Color.SandyBrown;
		btnPayout.FlatAppearance.BorderColor = Color.White;
		btnPayout.FlatAppearance.BorderSize = 0;
		btnPayout.FlatAppearance.MouseDownBackColor = Color.White;
		btnPayout.FlatStyle = FlatStyle.Flat;
		btnPayout.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnPayout.ForeColor = Color.White;
		btnPayout.ImeMode = ImeMode.NoControl;
		btnPayout.Location = new Point(8, 8);
		btnPayout.Name = "btnPayout";
		btnPayout.Size = new Size(120, 80);
		btnPayout.TabIndex = 162;
		btnPayout.Text = "PAYOUT";
		btnPayout.TextImageRelation = TextImageRelation.ImageAboveText;
		btnPayout.UseVisualStyleBackColor = false;
		btnPayout.Click += btnPayout_Click;
		btnSafeDrop.BackColor = Color.FromArgb(53, 143, 79);
		btnSafeDrop.FlatAppearance.BorderColor = Color.White;
		btnSafeDrop.FlatAppearance.BorderSize = 0;
		btnSafeDrop.FlatAppearance.MouseDownBackColor = Color.White;
		btnSafeDrop.FlatStyle = FlatStyle.Flat;
		btnSafeDrop.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnSafeDrop.ForeColor = Color.White;
		btnSafeDrop.ImeMode = ImeMode.NoControl;
		btnSafeDrop.Location = new Point(8, 89);
		btnSafeDrop.Name = "btnSafeDrop";
		btnSafeDrop.Size = new Size(120, 80);
		btnSafeDrop.TabIndex = 161;
		btnSafeDrop.Text = "SAFE DROP";
		btnSafeDrop.TextImageRelation = TextImageRelation.ImageAboveText;
		btnSafeDrop.UseVisualStyleBackColor = false;
		btnSafeDrop.Click += btnSafeDrop_Click;
		btnReverseSD.BackColor = Color.FromArgb(50, 119, 155);
		btnReverseSD.FlatAppearance.BorderColor = Color.White;
		btnReverseSD.FlatAppearance.BorderSize = 0;
		btnReverseSD.FlatAppearance.MouseDownBackColor = Color.White;
		btnReverseSD.FlatStyle = FlatStyle.Flat;
		btnReverseSD.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnReverseSD.ForeColor = Color.White;
		btnReverseSD.ImeMode = ImeMode.NoControl;
		btnReverseSD.Location = new Point(129, 89);
		btnReverseSD.Name = "btnReverseSD";
		btnReverseSD.Size = new Size(120, 80);
		btnReverseSD.TabIndex = 160;
		btnReverseSD.Text = "REVERSE SAFE DROP";
		btnReverseSD.TextImageRelation = TextImageRelation.ImageAboveText;
		btnReverseSD.UseVisualStyleBackColor = false;
		btnReverseSD.Click += btnReverseSD_Click;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnClose.ForeColor = Color.White;
		btnClose.ImageAlign = ContentAlignment.TopCenter;
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(250, 89);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(120, 80);
		btnClose.TabIndex = 163;
		btnClose.Text = "CLOSE";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnClearSafeDrop.BackColor = Color.FromArgb(122, 79, 148);
		btnClearSafeDrop.FlatAppearance.BorderColor = Color.White;
		btnClearSafeDrop.FlatAppearance.BorderSize = 0;
		btnClearSafeDrop.FlatAppearance.MouseDownBackColor = Color.White;
		btnClearSafeDrop.FlatStyle = FlatStyle.Flat;
		btnClearSafeDrop.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnClearSafeDrop.ForeColor = Color.White;
		btnClearSafeDrop.ImeMode = ImeMode.NoControl;
		btnClearSafeDrop.Location = new Point(129, 8);
		btnClearSafeDrop.Name = "btnClearSafeDrop";
		btnClearSafeDrop.Size = new Size(120, 80);
		btnClearSafeDrop.TabIndex = 205;
		btnClearSafeDrop.Text = "SAFE DROP CLEARING";
		btnClearSafeDrop.TextImageRelation = TextImageRelation.ImageAboveText;
		btnClearSafeDrop.UseVisualStyleBackColor = false;
		btnClearSafeDrop.Click += btnClearSafeDrop_Click;
		button1.BackColor = Color.FromArgb(42, 102, 134);
		button1.FlatAppearance.BorderColor = Color.White;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = Color.White;
		button1.FlatStyle = FlatStyle.Flat;
		button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		button1.ForeColor = Color.White;
		button1.ImeMode = ImeMode.NoControl;
		button1.Location = new Point(250, 8);
		button1.Name = "button1";
		button1.Size = new Size(120, 80);
		button1.TabIndex = 206;
		button1.TextImageRelation = TextImageRelation.ImageAboveText;
		button1.UseVisualStyleBackColor = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(378, 177);
		base.Controls.Add(button1);
		base.Controls.Add(btnClearSafeDrop);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnPayout);
		base.Controls.Add(btnSafeDrop);
		base.Controls.Add(btnReverseSD);
		base.Name = "frmPayoutSafeDrop";
		base.Opacity = 1.0;
		Text = "frmPayoutSafeDrop";
		ResumeLayout(performLayout: false);
	}
}
