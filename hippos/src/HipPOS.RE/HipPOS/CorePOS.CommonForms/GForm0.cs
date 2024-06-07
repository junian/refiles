using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS.CommonForms;

public class GForm0 : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int groupId;

		public GForm0 _003C_003E4__this;

		public _003C_003Ec__DisplayClass26_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadOptionsFromGroup_003Eb__0(usp_ItemOptionsResult x)
		{
			if (x.ItemID == _003C_003E4__this.int_1 && x.Tab.ToUpper() == _003C_003E4__this.string_4.ToUpper() && !x.ToBeDeleted)
			{
				return x.GroupID == groupId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<string> list_2;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	private Dictionary<string, string> dictionary_0;

	private string[] string_3;

	private int int_0;

	private int int_1;

	private string string_4;

	private IContainer icontainer_1;

	private VerticalScrollControl verticalScrollControl1;

	internal Button btnCancel;

	internal Button btnSelect;

	private Panel panel1;

	private Label lblTitle;

	private Class19 ddlSelect;

	private Label label_0;

	private Label lblChecklistTitle;

	public string SelectedDependentGroup
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public List<string> chklistValue
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public string DDLTitle
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

	public string ChecklistTitle
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public GForm0(string title, string[] _existingOptList, Dictionary<string, string> group, int selectedGroupDependency, int selectedItem, string selectedTab)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		lblTitle.Text = title;
		ddlSelect.DataSource = new BindingSource(group, null);
		ddlSelect.DisplayMember = "Value";
		ddlSelect.ValueMember = "Key";
		verticalScrollControl1.ConnectedPanel = panel1;
		string_3 = _existingOptList;
		int_0 = selectedGroupDependency;
		int_1 = selectedItem;
		string_4 = selectedTab;
	}

	private void btnSelect_Click(object sender, EventArgs e)
	{
		SelectedDependentGroup = ((KeyValuePair<string, string>)ddlSelect.SelectedItem).Key;
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
		chklistValue = list;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3();
	}

	private void GForm0_Load(object sender, EventArgs e)
	{
		ddlSelect.SelectedValue = int_0.ToString();
		method_3();
	}

	private void method_3()
	{
		panel1.Controls.Clear();
		if (ddlSelect.SelectedValue == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.groupId = Convert.ToInt32(((KeyValuePair<string, string>)ddlSelect.SelectedItem).Key);
		if (CS_0024_003C_003E8__locals0.groupId <= 0)
		{
			return;
		}
		List<usp_ItemOptionsResult> source = (from x in new GClass6().usp_ItemOptions()
			where x.ItemID == CS_0024_003C_003E8__locals0._003C_003E4__this.int_1 && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_4.ToUpper() && !x.ToBeDeleted && x.GroupID == CS_0024_003C_003E8__locals0.groupId
			select x).ToList();
		dictionary_0 = source.ToDictionary((usp_ItemOptionsResult a) => a.ItemWithOptionID.ToString(), (usp_ItemOptionsResult b) => b.ItemName);
		label_0.Text = DDLTitle;
		lblChecklistTitle.Text = ChecklistTitle;
		int num = 0;
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			Class17 @class = new Class17();
			@class.Name = item.Value;
			@class.Tag = item.Key;
			@class.Location = new Point(10, 40 * num + 10);
			if (string_3 != null && string_3.Contains(item.Key))
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
		verticalScrollControl1 = new VerticalScrollControl();
		btnCancel = new Button();
		btnSelect = new Button();
		panel1 = new Panel();
		lblTitle = new Label();
		ddlSelect = new Class19();
		label_0 = new Label();
		lblChecklistTitle = new Label();
		SuspendLayout();
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(376, 106);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 100);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 316);
		verticalScrollControl1.TabIndex = 170;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.Cursor = Cursors.Default;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 16.2f);
		btnCancel.ForeColor = Color.White;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(267, 422);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(159, 88);
		btnCancel.TabIndex = 169;
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
		btnSelect.Location = new Point(-2, 421);
		btnSelect.Name = "btnSelect";
		btnSelect.Size = new Size(268, 88);
		btnSelect.TabIndex = 168;
		btnSelect.Text = "DONE";
		btnSelect.UseVisualStyleBackColor = false;
		btnSelect.Click += btnSelect_Click;
		panel1.AutoScroll = true;
		panel1.BackColor = Color.White;
		panel1.Location = new Point(-2, 106);
		panel1.Margin = new Padding(10);
		panel1.Name = "panel1";
		panel1.Padding = new Padding(10);
		panel1.Size = new Size(408, 315);
		panel1.TabIndex = 167;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 13f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-1, -3);
		lblTitle.MinimumSize = new Size(356, 30);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(427, 40);
		lblTitle.TabIndex = 166;
		lblTitle.Text = "SELECT APPLICABLE ORDER TYPES";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		ddlSelect.BackColor = Color.White;
		ddlSelect.DrawMode = DrawMode.OwnerDrawVariable;
		ddlSelect.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlSelect.FlatStyle = FlatStyle.Flat;
		ddlSelect.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlSelect.ForeColor = Color.FromArgb(40, 40, 40);
		ddlSelect.FormattingEnabled = true;
		ddlSelect.ItemHeight = 27;
		ddlSelect.Items.AddRange(new object[2] { "Vertical", "Horizontal" });
		ddlSelect.Location = new Point(114, 38);
		ddlSelect.Margin = new Padding(4, 5, 4, 5);
		ddlSelect.Name = "ddlSelect";
		ddlSelect.Size = new Size(312, 33);
		ddlSelect.TabIndex = 221;
		ddlSelect.SelectedIndexChanged += ddlSelect_SelectedIndexChanged;
		label_0.BackColor = Color.Gray;
		label_0.FlatStyle = FlatStyle.Flat;
		label_0.Font = new Font("Microsoft Sans Serif", 12f);
		label_0.ForeColor = Color.White;
		label_0.ImeMode = ImeMode.NoControl;
		label_0.Location = new Point(-2, 38);
		label_0.Margin = new Padding(2, 0, 2, 0);
		label_0.Name = "lblDDLTitle";
		label_0.Size = new Size(115, 33);
		label_0.TabIndex = 222;
		label_0.Text = "Groups";
		label_0.TextAlign = ContentAlignment.MiddleRight;
		lblChecklistTitle.BackColor = Color.Gray;
		lblChecklistTitle.FlatStyle = FlatStyle.Flat;
		lblChecklistTitle.Font = new Font("Microsoft Sans Serif", 12f);
		lblChecklistTitle.ForeColor = Color.White;
		lblChecklistTitle.ImeMode = ImeMode.NoControl;
		lblChecklistTitle.Location = new Point(-1, 72);
		lblChecklistTitle.Margin = new Padding(2, 0, 2, 0);
		lblChecklistTitle.Name = "lblChecklistTitle";
		lblChecklistTitle.Size = new Size(427, 33);
		lblChecklistTitle.TabIndex = 223;
		lblChecklistTitle.Text = "Option List";
		lblChecklistTitle.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(428, 515);
		base.Controls.Add(lblChecklistTitle);
		base.Controls.Add(label_0);
		base.Controls.Add(ddlSelect);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSelect);
		base.Controls.Add(panel1);
		base.Controls.Add(lblTitle);
		base.Name = "frmDDLUnderCheckList";
		base.Opacity = 1.0;
		Text = "frmDDLUnderCheckList";
		base.Load += GForm0_Load;
		ResumeLayout(performLayout: false);
	}
}
