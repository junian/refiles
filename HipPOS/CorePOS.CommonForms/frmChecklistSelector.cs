using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;

namespace CorePOS.CommonForms;

public class frmChecklistSelector : frmMasterForm
{
	private Dictionary<string, string> dictionary_0;

	private string[] string_0;

	[CompilerGenerated]
	private string string_1;

	private int int_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Panel panel1;

	internal Button btnCancel;

	internal Button btnSelect;

	private VerticalScrollControl verticalScrollControl1;

	public string returnValue
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public frmChecklistSelector(string title, Dictionary<string, string> _OTList, string _existingOTList, int minSelection = 0)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		dictionary_0 = _OTList;
		if (SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled")
		{
			dictionary_0.Remove(OrderTypes.MakeToStock);
		}
		if (!string.IsNullOrEmpty(_existingOTList))
		{
			string_0 = _existingOTList.Split(',');
		}
		lblTitle.Text = title;
		int_0 = minSelection;
		verticalScrollControl1.ConnectedPanel = panel1;
	}

	private void btnSelect_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		int num = 0;
		foreach (object control in panel1.Controls)
		{
			if (control is Class17)
			{
				Class17 @class = control as Class17;
				if (@class.Checked)
				{
					list.Add(@class.Tag.ToString());
					num++;
				}
			}
		}
		if (num < int_0)
		{
			new NotificationLabel(this, "Please selected at least " + int_0, NotificationTypes.Warning).Show();
			return;
		}
		returnValue = string.Join(",", list);
		base.DialogResult = DialogResult.OK;
	}

	private void frmChecklistSelector_Load(object sender, EventArgs e)
	{
		int num = 0;
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			Class17 @class = new Class17();
			@class.Name = item.Value;
			@class.Tag = item.Key;
			@class.Location = new Point(10, 40 * num + 10);
			if (string_0 != null && string_0.Contains(item.Key))
			{
				@class.Checked = true;
			}
			else
			{
				@class.Checked = false;
			}
			panel1.Controls.Add(@class);
			Label label = new Label();
			label.Name = "lbl" + item.Value;
			label.Text = item.Value;
			label.Location = new Point(50, 40 * num + 10);
			label.Size = new Size(300, 30);
			label.Font = new Font(lblTitle.Font.FontFamily, 13f, FontStyle.Regular);
			label.ForeColor = Color.Black;
			label.BackColor = Color.White;
			label.TextAlign = ContentAlignment.MiddleLeft;
			panel1.Controls.Add(label);
			num++;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
		base.DialogResult = DialogResult.Cancel;
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
		btnCancel = new Button();
		btnSelect = new Button();
		panel1 = new Panel();
		lblTitle = new Label();
		verticalScrollControl1 = new VerticalScrollControl();
		SuspendLayout();
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.Cursor = Cursors.Default;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 16.2f);
		btnCancel.ForeColor = Color.White;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(272, 316);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(159, 88);
		btnCancel.TabIndex = 164;
		btnCancel.Text = "CANCEL";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSelect.BackColor = Color.FromArgb(47, 204, 113);
		btnSelect.Cursor = Cursors.Default;
		btnSelect.FlatAppearance.BorderColor = Color.Black;
		btnSelect.FlatAppearance.BorderSize = 0;
		btnSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		btnSelect.FlatStyle = FlatStyle.Flat;
		btnSelect.Font = new Font("Microsoft Sans Serif", 16.2f);
		btnSelect.ForeColor = Color.White;
		btnSelect.ImeMode = ImeMode.NoControl;
		btnSelect.Location = new Point(3, 316);
		btnSelect.Name = "btnSelect";
		btnSelect.Size = new Size(268, 88);
		btnSelect.TabIndex = 163;
		btnSelect.Text = "DONE";
		btnSelect.UseVisualStyleBackColor = false;
		btnSelect.Click += btnSelect_Click;
		panel1.AutoScroll = true;
		panel1.BackColor = Color.White;
		panel1.Location = new Point(3, 46);
		panel1.Margin = new Padding(10);
		panel1.Name = "panel1";
		panel1.Padding = new Padding(10);
		panel1.Size = new Size(408, 269);
		panel1.TabIndex = 162;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 13f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(4, 6);
		lblTitle.MinimumSize = new Size(356, 30);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(427, 40);
		lblTitle.TabIndex = 160;
		lblTitle.Text = "SELECT APPLICABLE ORDER TYPES";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(381, 46);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 100);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 269);
		verticalScrollControl1.TabIndex = 165;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(433, 410);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSelect);
		base.Controls.Add(panel1);
		base.Controls.Add(lblTitle);
		base.Name = "frmChecklistSelector";
		base.Opacity = 1.0;
		Text = "frmChecklistSelector";
		base.Load += frmChecklistSelector_Load;
		ResumeLayout(performLayout: false);
	}
}
