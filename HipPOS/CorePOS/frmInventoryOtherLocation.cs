using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS;

public class frmInventoryOtherLocation : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int ItemId;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private IContainer icontainer_1;

	private Label label9;

	internal Button btnClose;

	private Label lblItemName;

	private Label label1;

	private ListView itemsAddedToPackage;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	public frmInventoryOtherLocation(int ItemId)
	{
		Class26.Ggkj0JxzN9YmC();
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.ItemId = ItemId;
		base._002Ector();
		InitializeComponent_1();
		Item item = new GClass6().Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.ItemId).FirstOrDefault();
		lblItemName.Text = item.ItemName;
		string token = SyncMethods.GetToken();
		if (!string.IsNullOrEmpty(token))
		{
			OtherLocInventoryCountResponseModel otherLocsInventory = SyncMethods.GetOtherLocsInventory(new TokenItemObject
			{
				token = token,
				ItemName = item.ItemName
			});
			if (otherLocsInventory.code == 200)
			{
				foreach (OtherLocInventoryCount item2 in otherLocsInventory.ListInventory)
				{
					ListViewItem value = new ListViewItem(new string[2]
					{
						item2.LocationName,
						item2.Qty.ToString("0.00")
					});
					itemsAddedToPackage.Items.Add(value);
				}
				return;
			}
			new NotificationLabel(this, otherLocsInventory.message, NotificationTypes.Warning).Show();
		}
		else
		{
			new NotificationLabel(this, "CloudSync not enabled.", NotificationTypes.Warning).Show();
		}
	}

	private void DkWuxxhsqS(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmInventoryOtherLocation));
		label9 = new Label();
		btnClose = new Button();
		lblItemName = new Label();
		label1 = new Label();
		itemsAddedToPackage = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		SuspendLayout();
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(0, 1);
		label9.Name = "label9";
		label9.Size = new Size(515, 35);
		label9.TabIndex = 119;
		label9.Text = "OTHER LOCATIONS INVENTORY";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 10f);
		btnClose.ForeColor = Color.White;
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(516, 1);
		btnClose.Name = "btnClose";
		btnClose.Padding = new Padding(0, 3, 0, 3);
		btnClose.Size = new Size(155, 71);
		btnClose.TabIndex = 120;
		btnClose.Text = "CLOSE";
		btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += DkWuxxhsqS;
		lblItemName.BackColor = SystemColors.AppWorkspace;
		lblItemName.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblItemName.ImeMode = ImeMode.NoControl;
		lblItemName.Location = new Point(121, 36);
		lblItemName.Name = "lblItemName";
		lblItemName.Size = new Size(394, 35);
		lblItemName.TabIndex = 233;
		lblItemName.Text = "Item Name";
		lblItemName.TextAlign = ContentAlignment.MiddleLeft;
		label1.BackColor = Color.Gray;
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(0, 36);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(0, 35);
		label1.Name = "label1";
		label1.Padding = new Padding(0, 0, 5, 0);
		label1.Size = new Size(120, 35);
		label1.TabIndex = 232;
		label1.Text = "Item Name";
		label1.TextAlign = ContentAlignment.MiddleRight;
		itemsAddedToPackage.BackColor = Color.White;
		itemsAddedToPackage.BorderStyle = BorderStyle.None;
		itemsAddedToPackage.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		itemsAddedToPackage.Font = new Font("Microsoft Sans Serif", 12f);
		itemsAddedToPackage.ForeColor = Color.FromArgb(40, 40, 40);
		itemsAddedToPackage.FullRowSelect = true;
		itemsAddedToPackage.GridLines = true;
		itemsAddedToPackage.HideSelection = false;
		itemsAddedToPackage.LabelWrap = false;
		itemsAddedToPackage.Location = new Point(1, 73);
		itemsAddedToPackage.Name = "itemsAddedToPackage";
		itemsAddedToPackage.Size = new Size(670, 460);
		itemsAddedToPackage.TabIndex = 234;
		itemsAddedToPackage.UseCompatibleStateImageBehavior = false;
		itemsAddedToPackage.View = View.Details;
		columnHeader_0.Text = "Location Name";
		columnHeader_0.Width = 562;
		columnHeader_1.Text = "Qty";
		columnHeader_1.Width = 100;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(673, 537);
		base.Controls.Add(itemsAddedToPackage);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label1);
		base.Controls.Add(btnClose);
		base.Controls.Add(label9);
		base.Name = "frmInventoryOtherLocation";
		base.Opacity = 1.0;
		Text = "frmInventoryOtherLocation";
		ResumeLayout(performLayout: false);
	}
}
