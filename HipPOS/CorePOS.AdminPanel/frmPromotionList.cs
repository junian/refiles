using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel;

public class frmPromotionList : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int promoId;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int promoId;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private int int_0;

	private IContainer icontainer_1;

	private Label label10;

	private Label lblCol2;

	private Label lblCol3;

	private Label lblCol1;

	private CustomListViewTelerik radListPromotions;

	internal Button btnChangeStatus;

	internal Button btnDelete;

	internal Button btnEdit;

	internal Button btnNew;

	public frmPromotionList()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmPromotionList_Load(object sender, EventArgs e)
	{
		KmuFiaswMpU();
		method_3();
	}

	private void KmuFiaswMpU()
	{
		radListPromotions.Columns[0].Width = lblCol1.Width + 1;
		radListPromotions.Columns[1].Width = lblCol2.Width + 1;
		radListPromotions.Columns[2].Width = lblCol3.Width - 20;
	}

	private void method_3()
	{
		radListPromotions.Items.Clear();
		foreach (Promotion item2 in (from a in new GClass6().Promotions
			where a.IsDeleted == false && a.GetDiscountUOM != "@"
			orderby a.DateCreated descending
			select a).ToList())
		{
			string[] values = new string[4]
			{
				item2.PromoName,
				item2.PromoCode,
				item2.Active ? "ACTIVE" : "INACTIVE",
				item2.PromoId.ToString()
			};
			ListViewDataItem item = new ListViewDataItem("", values);
			radListPromotions.Items.Add(item);
		}
		if (radListPromotions.Items.Count > 0)
		{
			radListPromotions.SelectedIndex = int_0;
		}
	}

	private void btnChangeStatus_Click(object sender, EventArgs e)
	{
		if (radListPromotions.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.promoId = Convert.ToInt32(radListPromotions.SelectedItems[0].SubItems[3].ToString());
			Promotion promotion = gClass.Promotions.Where((Promotion a) => a.PromoId == CS_0024_003C_003E8__locals0.promoId).FirstOrDefault();
			if (promotion != null)
			{
				promotion.Active = !promotion.Active;
				promotion.Synced = false;
				gClass.SubmitChanges();
				int_0 = radListPromotions.SelectedIndex;
				method_3();
				MemoryLoadedObjects.RefreshPromotions();
			}
		}
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		if (radListPromotions.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.promoId = Convert.ToInt32(radListPromotions.SelectedItems[0].SubItems[3].ToString());
			Promotion promotion = gClass.Promotions.Where((Promotion a) => a.PromoId == CS_0024_003C_003E8__locals0.promoId).FirstOrDefault();
			if (promotion != null)
			{
				promotion.IsDeleted = true;
				promotion.Synced = false;
				gClass.SubmitChanges();
				method_3();
				MemoryLoadedObjects.RefreshPromotions();
			}
		}
	}

	private void btnEdit_Click(object sender, EventArgs e)
	{
		if (radListPromotions.SelectedItems.Count > 0)
		{
			new GClass6();
			new frmAddEditPromotions(Convert.ToInt32(radListPromotions.SelectedItems[0].SubItems[3].ToString())).ShowDialog();
			method_3();
		}
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		new frmAddEditPromotions().ShowDialog();
		method_3();
	}

	private void radListPromotions_SelectedItemChanged(object sender, EventArgs e)
	{
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
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "Column 0");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Column 1");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 2", "Column 2");
		ListViewDataItem listViewDataItem = new ListViewDataItem("ListViewItem 1");
		label10 = new Label();
		lblCol2 = new Label();
		lblCol3 = new Label();
		lblCol1 = new Label();
		radListPromotions = new CustomListViewTelerik();
		btnChangeStatus = new Button();
		btnDelete = new Button();
		btnEdit = new Button();
		btnNew = new Button();
		((ISupportInitialize)radListPromotions).BeginInit();
		SuspendLayout();
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label10.ForeColor = Color.White;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(0, -1);
		label10.MinimumSize = new Size(720, 35);
		label10.Name = "label10";
		label10.Size = new Size(724, 35);
		label10.TabIndex = 119;
		label10.Text = "PROMOTIONS";
		label10.TextAlign = ContentAlignment.MiddleCenter;
		lblCol2.BackColor = Color.FromArgb(61, 142, 185);
		lblCol2.Font = new Font("Microsoft Sans Serif", 10f);
		lblCol2.ForeColor = Color.White;
		lblCol2.ImeMode = ImeMode.NoControl;
		lblCol2.Location = new Point(374, 34);
		lblCol2.Margin = new Padding(0, 0, 0, 1);
		lblCol2.MinimumSize = new Size(0, 35);
		lblCol2.Name = "lblCol2";
		lblCol2.Size = new Size(211, 35);
		lblCol2.TabIndex = 230;
		lblCol2.Text = "Promotion Reason Code";
		lblCol2.TextAlign = ContentAlignment.MiddleCenter;
		lblCol3.BackColor = Color.FromArgb(61, 142, 185);
		lblCol3.Font = new Font("Microsoft Sans Serif", 10f);
		lblCol3.ForeColor = Color.White;
		lblCol3.ImeMode = ImeMode.NoControl;
		lblCol3.Location = new Point(586, 34);
		lblCol3.Margin = new Padding(0, 0, 0, 1);
		lblCol3.MinimumSize = new Size(0, 35);
		lblCol3.Name = "lblCol3";
		lblCol3.Size = new Size(138, 35);
		lblCol3.TabIndex = 229;
		lblCol3.Text = "Status";
		lblCol3.TextAlign = ContentAlignment.MiddleCenter;
		lblCol1.BackColor = Color.FromArgb(61, 142, 185);
		lblCol1.Font = new Font("Microsoft Sans Serif", 10f);
		lblCol1.ForeColor = Color.White;
		lblCol1.ImeMode = ImeMode.NoControl;
		lblCol1.Location = new Point(0, 34);
		lblCol1.Margin = new Padding(0, 0, 0, 1);
		lblCol1.MinimumSize = new Size(0, 35);
		lblCol1.Name = "lblCol1";
		lblCol1.Size = new Size(373, 35);
		lblCol1.TabIndex = 228;
		lblCol1.Text = "Promotion Name";
		lblCol1.TextAlign = ContentAlignment.MiddleCenter;
		radListPromotions.AllowArbitraryItemHeight = true;
		radListPromotions.AllowEdit = false;
		radListPromotions.AllowRemove = false;
		listViewDetailColumn.HeaderText = "Column 0";
		listViewDetailColumn2.HeaderText = "Column 1";
		listViewDetailColumn3.HeaderText = "Column 2";
		radListPromotions.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2, listViewDetailColumn3);
		radListPromotions.EnableKineticScrolling = true;
		radListPromotions.Font = new Font("Microsoft Sans Serif", 13.5f, FontStyle.Bold);
		listViewDataItem.Text = "ListViewItem 1";
		radListPromotions.Items.AddRange(listViewDataItem);
		radListPromotions.ItemSpacing = -1;
		radListPromotions.Location = new Point(1, 70);
		radListPromotions.Name = "radListPromotions";
		radListPromotions.ShowColumnHeaders = false;
		radListPromotions.ShowGridLines = true;
		radListPromotions.Size = new Size(723, 433);
		radListPromotions.TabIndex = 227;
		radListPromotions.Text = "radListView1";
		radListPromotions.ViewType = ListViewType.DetailsView;
		radListPromotions.SelectedItemChanged += radListPromotions_SelectedItemChanged;
		btnChangeStatus.BackColor = Color.FromArgb(214, 142, 81);
		btnChangeStatus.FlatAppearance.BorderColor = Color.Black;
		btnChangeStatus.FlatAppearance.BorderSize = 0;
		btnChangeStatus.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChangeStatus.FlatStyle = FlatStyle.Flat;
		btnChangeStatus.Font = new Font("Microsoft Sans Serif", 9.75f);
		btnChangeStatus.ForeColor = Color.White;
		btnChangeStatus.ImeMode = ImeMode.NoControl;
		btnChangeStatus.Location = new Point(1, 504);
		btnChangeStatus.Name = "btnChangeStatus";
		btnChangeStatus.Size = new Size(138, 71);
		btnChangeStatus.TabIndex = 231;
		btnChangeStatus.Text = "MAKE INACTIVE/ACTIVE";
		btnChangeStatus.UseVisualStyleBackColor = false;
		btnChangeStatus.Click += btnChangeStatus_Click;
		btnDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnDelete.FlatAppearance.BorderColor = Color.Black;
		btnDelete.FlatAppearance.BorderSize = 0;
		btnDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDelete.FlatStyle = FlatStyle.Flat;
		btnDelete.Font = new Font("Microsoft Sans Serif", 9.75f);
		btnDelete.ForeColor = Color.White;
		btnDelete.ImeMode = ImeMode.NoControl;
		btnDelete.Location = new Point(140, 504);
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new Size(125, 71);
		btnDelete.TabIndex = 232;
		btnDelete.Text = "DELETE";
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		btnEdit.BackColor = Color.FromArgb(65, 168, 95);
		btnEdit.FlatAppearance.BorderColor = Color.Black;
		btnEdit.FlatAppearance.BorderSize = 0;
		btnEdit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnEdit.FlatStyle = FlatStyle.Flat;
		btnEdit.Font = new Font("Microsoft Sans Serif", 9.75f);
		btnEdit.ForeColor = Color.White;
		btnEdit.ImeMode = ImeMode.NoControl;
		btnEdit.Location = new Point(266, 504);
		btnEdit.Name = "btnEdit";
		btnEdit.Size = new Size(125, 71);
		btnEdit.TabIndex = 233;
		btnEdit.Text = "EDIT";
		btnEdit.UseVisualStyleBackColor = false;
		btnEdit.Click += btnEdit_Click;
		btnNew.BackColor = Color.FromArgb(50, 119, 155);
		btnNew.FlatAppearance.BorderColor = Color.Black;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNew.FlatStyle = FlatStyle.Flat;
		btnNew.Font = new Font("Microsoft Sans Serif", 9.75f);
		btnNew.ForeColor = Color.White;
		btnNew.ImeMode = ImeMode.NoControl;
		btnNew.Location = new Point(392, 504);
		btnNew.Name = "btnNew";
		btnNew.Size = new Size(125, 71);
		btnNew.TabIndex = 234;
		btnNew.Text = "NEW";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(724, 584);
		base.Controls.Add(btnNew);
		base.Controls.Add(btnEdit);
		base.Controls.Add(btnDelete);
		base.Controls.Add(btnChangeStatus);
		base.Controls.Add(lblCol2);
		base.Controls.Add(lblCol3);
		base.Controls.Add(lblCol1);
		base.Controls.Add(radListPromotions);
		base.Controls.Add(label10);
		base.Name = "frmPromotionList";
		base.Opacity = 1.0;
		Text = "frmPromotionList";
		base.Load += frmPromotionList_Load;
		((ISupportInitialize)radListPromotions).EndInit();
		ResumeLayout(performLayout: false);
	}
}
