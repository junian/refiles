using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;

namespace CorePOS;

public class PatronItemControl : UserControl
{
	public MouseEventHandler AddItem_Click;

	public MouseEventHandler ScrollMouseDown;

	public MouseEventHandler ScrollMouseUp;

	public MouseEventHandler ScrollMouseMove;

	[CompilerGenerated]
	private Item item_0;

	private Item item_1;

	private bool bool_0;

	private IContainer icontainer_0;

	private PictureBox picItem;

	private Label lblItemName;

	private Label lblItemPrice;

	private Label lblDescription;

	private PictureBox btnAddItem;

	private Timer timer_0;

	private Class21 lblOnSale;

	public Item itemReturn
	{
		[CompilerGenerated]
		get
		{
			return item_0;
		}
		[CompilerGenerated]
		set
		{
			item_0 = value;
		}
	}

	public PatronItemControl(Item item)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent();
		item_1 = item;
		int num = item.ItemName.Length / 30;
		if (num < 1)
		{
			num = 1;
		}
		lblItemName.Height *= num;
		if (string.IsNullOrEmpty(item.Description))
		{
			return;
		}
		lblDescription.Location = new Point(lblItemName.Location.X, lblItemName.Location.Y + lblItemName.Height + 10);
		lblDescription.Width = base.Width - 300;
		if (item.Description.Length > 160)
		{
			int num2 = (base.Width - 300) / 8;
			int num3 = item.Description.Length / num2;
			int num4 = (int)lblDescription.Font.Size * 2;
			base.Height = num3 * num4 + 50;
			if (base.Height < 175)
			{
				base.Height = 175;
			}
			lblDescription.Height = num3 * num4;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
	}

	private void PatronItemControl_Load(object sender, EventArgs e)
	{
		lblItemName.Width = base.Width - 320;
		lblItemName.Text = item_1.ItemName.Replace("&", "&&");
		lblItemPrice.TextAlign = ContentAlignment.MiddleRight;
		Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(item_1.ItemID);
		if (promoSaleItemById != null)
		{
			lblItemPrice.Text = $"{promoSaleItemById.GetDiscountAmount.Value:C}";
			lblOnSale.Visible = true;
			lblOnSale.Text = $"{item_1.ItemPrice:C}";
		}
		else
		{
			lblItemPrice.Text = $"{item_1.ItemPrice:C}";
		}
		if (!string.IsNullOrEmpty(item_1.Description))
		{
			lblDescription.Text = item_1.Description.Replace("&", "&&");
		}
		else
		{
			lblDescription.Text = string.Empty;
		}
		timer_0.Enabled = true;
		base.MouseDown += PatronItemControl_MouseDown;
		base.MouseUp += PatronItemControl_MouseUp;
		base.MouseMove += PatronItemControl_MouseMove;
		foreach (Control control in base.Controls)
		{
			if (control.Name != "btnAddItem" && control.Name != "picItem")
			{
				control.MouseDown += PatronItemControl_MouseDown;
				control.MouseUp += PatronItemControl_MouseUp;
				control.MouseMove += PatronItemControl_MouseMove;
			}
		}
	}

	private void PatronItemControl_MouseDown(object sender, MouseEventArgs e)
	{
		if (ScrollMouseDown != null)
		{
			ScrollMouseDown(sender, e);
		}
	}

	private void PatronItemControl_MouseUp(object sender, MouseEventArgs e)
	{
		if (ScrollMouseUp != null)
		{
			ScrollMouseUp(sender, e);
		}
	}

	private void PatronItemControl_MouseMove(object sender, MouseEventArgs e)
	{
		if (ScrollMouseMove != null)
		{
			ScrollMouseMove(sender, e);
		}
	}

	private void btnAddItem_MouseDown(object sender, MouseEventArgs e)
	{
		itemReturn = item_1;
		if (AddItem_Click != null)
		{
			AddItem_Click(sender, e);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		string text = (from m in new GClass6().ItemImages
			where m.ItemID == item_1.ItemID
			select m into a
			select a.ImageAsText).FirstOrDefault();
		if (!string.IsNullOrEmpty(text) && text != "NoImage")
		{
			using MemoryStream stream = new MemoryStream(Convert.FromBase64String(text));
			Bitmap image = new Bitmap(Image.FromStream(stream), new Size(picItem.Width, picItem.Height));
			picItem.Image = image;
		}
		else
		{
			using MemoryStream stream2 = new MemoryStream(MemoryLoadedObjects.blankImageByte);
			Bitmap image2 = new Bitmap(Image.FromStream(stream2), new Size(picItem.Width, picItem.Height));
			picItem.Image = image2;
		}
		timer_0.Enabled = false;
	}

	private void picItem_Click(object sender, EventArgs e)
	{
		ItemImage itemImage = new GClass6().ItemImages.Where((ItemImage m) => m.ItemID == item_1.ItemID).FirstOrDefault();
		byte[] base64BytesImage = ((itemImage == null || string.IsNullOrEmpty(itemImage.ImageAsText) || !(itemImage.ImageAsText != "NoImage")) ? MemoryLoadedObjects.blankImageByte : ((!string.IsNullOrEmpty(itemImage.ImageAsTextHighRes)) ? Convert.FromBase64String(itemImage.ImageAsTextHighRes) : Convert.FromBase64String(itemImage.ImageAsText)));
		Size size = new Size((int)((double)base.Parent.Parent.Width * 0.6), (int)((double)base.Parent.Parent.Height * 0.6));
		float num = size.Width / size.Height;
		float num2 = 1.3333334f;
		Size value = new Size(1, 1);
		if (num < num2)
		{
			value.Width = size.Width;
			value.Height = (int)((float)value.Width / num2);
		}
		else
		{
			value.Width = (int)((float)value.Height / num2);
			value.Height = size.Height;
		}
		new frmSingleImageViewer(base64BytesImage, value).ShowDialog(this);
	}

	private void lblItemName_Click(object sender, EventArgs e)
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
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.PatronItemControl));
		this.picItem = new System.Windows.Forms.PictureBox();
		this.lblItemName = new System.Windows.Forms.Label();
		this.lblDescription = new System.Windows.Forms.Label();
		this.btnAddItem = new System.Windows.Forms.PictureBox();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.lblItemPrice = new System.Windows.Forms.Label();
		this.lblOnSale = new Class21();
		((System.ComponentModel.ISupportInitialize)this.picItem).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnAddItem).BeginInit();
		base.SuspendLayout();
		this.picItem.BackColor = System.Drawing.Color.LightGray;
		this.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picItem.Location = new System.Drawing.Point(11, 12);
		this.picItem.Name = "picItem";
		this.picItem.Size = new System.Drawing.Size(200, 150);
		this.picItem.TabIndex = 0;
		this.picItem.TabStop = false;
		this.picItem.Click += new System.EventHandler(picItem_Click);
		this.lblItemName.AutoSize = true;
		this.lblItemName.BackColor = System.Drawing.Color.White;
		this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblItemName.ForeColor = System.Drawing.Color.Black;
		this.lblItemName.Location = new System.Drawing.Point(220, 13);
		this.lblItemName.Name = "lblItemName";
		this.lblItemName.Size = new System.Drawing.Size(126, 24);
		this.lblItemName.TabIndex = 1;
		this.lblItemName.Text = "lblItemName";
		this.lblItemName.Click += new System.EventHandler(lblItemName_Click);
		this.lblDescription.BackColor = System.Drawing.Color.White;
		this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(80, 0, 0);
		this.lblDescription.Location = new System.Drawing.Point(221, 39);
		this.lblDescription.Name = "lblDescription";
		this.lblDescription.Size = new System.Drawing.Size(69, 22);
		this.lblDescription.TabIndex = 3;
		this.lblDescription.Text = "lblDesc";
		this.btnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnAddItem.BackColor = System.Drawing.Color.White;
		this.btnAddItem.Image = (System.Drawing.Image)resources.GetObject("btnAddItem.Image");
		this.btnAddItem.Location = new System.Drawing.Point(576, 50);
		this.btnAddItem.Margin = new System.Windows.Forms.Padding(10);
		this.btnAddItem.Name = "btnAddItem";
		this.btnAddItem.Padding = new System.Windows.Forms.Padding(10);
		this.btnAddItem.Size = new System.Drawing.Size(70, 70);
		this.btnAddItem.TabIndex = 5;
		this.btnAddItem.TabStop = false;
		this.btnAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(btnAddItem_MouseDown);
		this.timer_0.Interval = 500;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.lblItemPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblItemPrice.BackColor = System.Drawing.Color.White;
		this.lblItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblItemPrice.Location = new System.Drawing.Point(511, 15);
		this.lblItemPrice.Name = "lblItemPrice";
		this.lblItemPrice.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		this.lblItemPrice.Size = new System.Drawing.Size(135, 20);
		this.lblItemPrice.TabIndex = 2;
		this.lblItemPrice.Text = "$0.00";
		this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblOnSale.BackColor = System.Drawing.Color.White;
		this.lblOnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, 0);
		this.lblOnSale.ForeColor = System.Drawing.Color.Black;
		this.lblOnSale.Location = new System.Drawing.Point(511, 34);
		this.lblOnSale.Name = "lblOnSale";
		this.lblOnSale.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
		this.lblOnSale.Size = new System.Drawing.Size(135, 18);
		this.lblOnSale.TabIndex = 6;
		this.lblOnSale.Text = "lblOnSale";
		this.lblOnSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblOnSale.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.lblItemPrice);
		base.Controls.Add(this.lblOnSale);
		base.Controls.Add(this.btnAddItem);
		base.Controls.Add(this.lblDescription);
		base.Controls.Add(this.lblItemName);
		base.Controls.Add(this.picItem);
		this.DoubleBuffered = true;
		base.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
		base.Name = "PatronItemControl";
		base.Size = new System.Drawing.Size(650, 175);
		base.Load += new System.EventHandler(PatronItemControl_Load);
		((System.ComponentModel.ISupportInitialize)this.picItem).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnAddItem).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
