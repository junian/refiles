using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmManagePaymentTypesSortOrder : frmMasterForm
{
	private bool bool_0;

	private int int_0;

	private int int_1;

	private Button button_0;

	private bool bool_1;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnOkay;

	internal Button btnDown;

	internal Button btnUp;

	private Button btnAddEmptyRow;

	private Button btnRemoveRow;

	private Button btnSortByName;

	private FlowLayoutPanel pnlTenderTypes;

	public frmManagePaymentTypesSortOrder()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = true;
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManagePaymentTypesSortOrder_Load(object sender, EventArgs e)
	{
		if (bool_0)
		{
			btnSortByName.Text = "SORT BY NAME ASC";
		}
		else
		{
			btnSortByName.Text = "SORT BY NAME DESC";
		}
		Button button = btnUp;
		btnDown.Enabled = false;
		button.Enabled = false;
		method_3();
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		try
		{
			GClass6 gClass = new GClass6();
			int num = 0;
			using (List<Control>.Enumerator enumerator = pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList()
				.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
					CS_0024_003C_003E8__locals0.btn = (Button)enumerator.Current;
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.btn.Text))
					{
						PaymentType paymentType = gClass.PaymentTypes.Where((PaymentType x) => x.Id == (int)CS_0024_003C_003E8__locals0.btn.Tag).FirstOrDefault();
						if (paymentType != null)
						{
							paymentType.SortOrder = num;
						}
					}
					num++;
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
			new NotificationLabel(this, Resources.Sort_orders_have_been_saved_su, NotificationTypes.Success).Show();
		}
		catch
		{
			new NotificationLabel(this, Resources.An_error_has_occurred_trying_t4, NotificationTypes.Warning).Show();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		if (bool_1)
		{
			GClass6 gClass = new GClass6();
			gClass.Terminals.ToList().ForEach(delegate(Terminal a)
			{
				a.AppRestartRequired = true;
			});
			try
			{
				gClass.SubmitChanges(ConflictMode.ContinueOnConflict);
			}
			catch (ChangeConflictException ex)
			{
				Console.WriteLine(ex.Message);
				foreach (ObjectChangeConflict changeConflict in gClass.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
				}
			}
		}
		Close();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		int_0 = 0;
		foreach (PaymentType item in gClass.PaymentTypes.OrderBy((PaymentType x) => x.SortOrder))
		{
			for (int i = 0; i < 14; i++)
			{
				if (int_0 != item.SortOrder)
				{
					method_5(int_0);
					int_0++;
					continue;
				}
				method_4(item.Name, item.Id);
				int_0++;
				break;
			}
		}
	}

	private void method_4(string string_0, int int_2)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(50, 119, 155);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderColor = Color.Black;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.ForeColor = Color.White;
		button.Name = "btn" + string_0;
		button.Text = string_0.ToUpper();
		button.Tag = int_2;
		button.Size = new Size(125, 63);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Click += method_6;
		pnlTenderTypes.Controls.Add(button);
	}

	private void method_5(int int_2)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(35, 39, 56);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 39, 56);
		button.Name = "btnPlaceHolder_" + int_1;
		button.Text = string.Empty;
		button.Size = new Size(125, 63);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Click += method_6;
		pnlTenderTypes.Controls.Add(button);
		pnlTenderTypes.Controls.SetChildIndex(button, int_2);
		int_1++;
	}

	private void method_6(object sender, EventArgs e)
	{
		button_0 = (Button)sender;
		foreach (Button item in pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			if (!string.IsNullOrEmpty(item.Text))
			{
				item.BackColor = Color.FromArgb(50, 119, 155);
			}
			else
			{
				item.BackColor = Color.FromArgb(35, 39, 56);
			}
		}
		button_0.BackColor = Color.SandyBrown;
		int num = pnlTenderTypes.Controls.IndexOf(button_0);
		if (num == int_0 - 1)
		{
			btnUp.Enabled = true;
			btnDown.Enabled = false;
		}
		else if (num == 0)
		{
			btnUp.Enabled = false;
			btnDown.Enabled = true;
		}
		else
		{
			Button button2 = btnUp;
			btnDown.Enabled = true;
			button2.Enabled = true;
		}
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		int num = pnlTenderTypes.Controls.IndexOf(button_0);
		if (num > 0)
		{
			int num2 = num - 1;
			Button button = (Button)pnlTenderTypes.Controls[num2];
			if (button != null)
			{
				pnlTenderTypes.Controls.SetChildIndex(button_0, num2);
				pnlTenderTypes.Controls.SetChildIndex(button, num);
			}
			btnDown.Enabled = true;
			if (num2 == 0)
			{
				btnUp.Enabled = false;
			}
			else
			{
				btnUp.Enabled = true;
			}
		}
		else
		{
			btnUp.Enabled = false;
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		int num = pnlTenderTypes.Controls.IndexOf(button_0);
		if (num < int_0 - 1)
		{
			int num2 = num + 1;
			if (pnlTenderTypes.Controls.Count > num2)
			{
				Button button = (Button)pnlTenderTypes.Controls[num2];
				if (button != null)
				{
					pnlTenderTypes.Controls.SetChildIndex(button_0, num2);
					pnlTenderTypes.Controls.SetChildIndex(button, num);
				}
				btnUp.Enabled = true;
				if (num2 >= int_0 - 1)
				{
					btnDown.Enabled = false;
				}
				else
				{
					btnDown.Enabled = true;
				}
			}
		}
		else
		{
			btnDown.Enabled = false;
		}
	}

	private void btnAddEmptyRow_Click(object sender, EventArgs e)
	{
		int num = pnlTenderTypes.Controls.Count - 1;
		if (button_0 != null)
		{
			num = pnlTenderTypes.Controls.IndexOf(button_0);
		}
		method_5(num + 1);
	}

	private void btnRemoveRow_Click(object sender, EventArgs e)
	{
		if (button_0 != null)
		{
			if (string.IsNullOrEmpty(button_0.Text))
			{
				int num = pnlTenderTypes.Controls.IndexOf(button_0);
				pnlTenderTypes.Controls.Remove(button_0);
				if (num >= pnlTenderTypes.Controls.Count)
				{
					num--;
				}
				button_0 = (Button)pnlTenderTypes.Controls[num];
				if (button_0 != null)
				{
					button_0.PerformClick();
				}
			}
			else
			{
				new NotificationLabel(this, "Can only remove empty placeholders.", NotificationTypes.Notification).Show();
			}
		}
		else
		{
			new NotificationLabel(this, "Please select an empty slot to remove.", NotificationTypes.Notification).Show();
		}
	}

	private void btnUp_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void btnSortByName_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (bool_0)
		{
			foreach (Button item in from Button x in pnlTenderTypes.Controls.OfType<Button>()
				orderby x.Text
				select x)
			{
				pnlTenderTypes.Controls.SetChildIndex(item, num);
				num++;
			}
		}
		else
		{
			foreach (Button item2 in from Button x in pnlTenderTypes.Controls.OfType<Button>()
				orderby x.Text descending
				select x)
			{
				pnlTenderTypes.Controls.SetChildIndex(item2, num);
				num++;
			}
		}
		bool_0 = !bool_0;
		if (bool_0)
		{
			btnSortByName.Text = "SORT BY NAME ASC";
		}
		else
		{
			btnSortByName.Text = "SORT BY NAME DESC";
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManagePaymentTypesSortOrder));
		btnCancel = new Button();
		btnOkay = new Button();
		label9 = new Label();
		btnDown = new Button();
		btnUp = new Button();
		btnAddEmptyRow = new Button();
		btnRemoveRow = new Button();
		btnSortByName = new Button();
		pnlTenderTypes = new FlowLayoutPanel();
		SuspendLayout();
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOkay, "btnOkay");
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.Name = "btnOkay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnDown, "btnDown");
		btnDown.ForeColor = Color.White;
		btnDown.Name = "btnDown";
		btnDown.Tag = "";
		btnDown.UseVisualStyleBackColor = false;
		btnDown.EnabledChanged += btnUp_EnabledChanged;
		btnDown.Click += btnDown_Click;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnUp, "btnUp");
		btnUp.ForeColor = Color.White;
		btnUp.Name = "btnUp";
		btnUp.Tag = "";
		btnUp.UseVisualStyleBackColor = false;
		btnUp.EnabledChanged += btnUp_EnabledChanged;
		btnUp.Click += btnUp_Click;
		btnAddEmptyRow.BackColor = Color.FromArgb(50, 119, 155);
		btnAddEmptyRow.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddEmptyRow, "btnAddEmptyRow");
		btnAddEmptyRow.ForeColor = SystemColors.ButtonFace;
		btnAddEmptyRow.Name = "btnAddEmptyRow";
		btnAddEmptyRow.UseVisualStyleBackColor = false;
		btnAddEmptyRow.Click += btnAddEmptyRow_Click;
		btnRemoveRow.BackColor = Color.SandyBrown;
		btnRemoveRow.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnRemoveRow, "btnRemoveRow");
		btnRemoveRow.ForeColor = SystemColors.ButtonFace;
		btnRemoveRow.Name = "btnRemoveRow";
		btnRemoveRow.UseVisualStyleBackColor = false;
		btnRemoveRow.Click += btnRemoveRow_Click;
		btnSortByName.BackColor = Color.FromArgb(53, 152, 220);
		btnSortByName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSortByName, "btnSortByName");
		btnSortByName.ForeColor = SystemColors.ButtonFace;
		btnSortByName.Name = "btnSortByName";
		btnSortByName.UseVisualStyleBackColor = false;
		btnSortByName.Click += btnSortByName_Click;
		componentResourceManager.ApplyResources(pnlTenderTypes, "pnlTenderTypes");
		pnlTenderTypes.Name = "pnlTenderTypes";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(pnlTenderTypes);
		base.Controls.Add(btnSortByName);
		base.Controls.Add(btnRemoveRow);
		base.Controls.Add(btnAddEmptyRow);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label9);
		base.Name = "frmManagePaymentTypesSortOrder";
		base.Opacity = 1.0;
		base.Load += frmManagePaymentTypesSortOrder_Load;
		ResumeLayout(performLayout: false);
	}
}
