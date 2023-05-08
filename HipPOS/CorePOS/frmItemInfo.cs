using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace CorePOS;

public class frmItemInfo : frmMasterForm
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

	private IContainer icontainer_1;

	private Panel panel1;

	private PictureBox pbItemImage;

	private Label label9;

	private Panel panel2;

	private Label lblItemName;

	private Label label3;

	private Label label1;

	private Label lblPrice;

	private Label label2;

	private Label lblNotes;

	private Label label5;

	private PictureBox pictureBox1;

	private Label lblSalePrice;

	private Label label4;

	private Label lblDescription;

	public DateTime StartTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public DateTime EndTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_1;
		}
		[CompilerGenerated]
		set
		{
			dateTime_1 = value;
		}
	}

	public frmItemInfo(string name, byte[] bytesPic, string desc, string price, string notes, string salePrice = "")
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		base.Width = (int)((double)Screen.FromControl(this).Bounds.Width * 0.7);
		base.Height = (int)((double)Screen.FromControl(this).Bounds.Height * 0.5);
		pbItemImage.Width = (int)((double)base.Width * 0.44);
		panel2.Location = new Point(pbItemImage.Location.X + pbItemImage.Width, panel2.Location.Y);
		panel2.Size = new Size(base.Width - pbItemImage.Width - 10, panel2.Height);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size - 2f, FontStyle.Bold);
			label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2f, FontStyle.Bold);
		}
		using (MemoryStream stream = new MemoryStream(bytesPic))
		{
			Bitmap image = new Bitmap(Image.FromStream(stream), new Size(pbItemImage.Width, pbItemImage.Height));
			pbItemImage.Image = image;
		}
		lblItemName.Text = name;
		lblDescription.Text = (string.IsNullOrEmpty(desc) ? "" : desc.Replace("&", "&&"));
		lblPrice.Text = price;
		lblNotes.Text = notes;
		if (!string.IsNullOrEmpty(salePrice))
		{
			lblSalePrice.Text = salePrice;
			lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);
		}
		else
		{
			lblSalePrice.Visible = false;
			label4.Visible = false;
			lblNotes.Location = new Point(lblNotes.Location.X, lblPrice.Bottom + 1);
			label5.Location = new Point(label5.Location.X, lblPrice.Bottom + 1);
		}
		label3.Location = new Point(label3.Location.X, lblNotes.Bottom + 1);
		lblDescription.Location = new Point(lblDescription.Location.X, label3.Location.Y);
		lblDescription.MaximumSize = new Size(panel2.Width - 120, 0);
	}

	private void YsseqPecMa(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void method_3(object sender, EventArgs e)
	{
		lblItemName.Focus();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmItemInfo));
		panel1 = new Panel();
		panel2 = new Panel();
		lblDescription = new Label();
		label4 = new Label();
		lblSalePrice = new Label();
		lblNotes = new Label();
		label5 = new Label();
		lblPrice = new Label();
		label2 = new Label();
		label3 = new Label();
		lblItemName = new Label();
		label1 = new Label();
		pictureBox1 = new PictureBox();
		pbItemImage = new PictureBox();
		label9 = new Label();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)pbItemImage).BeginInit();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(pbItemImage);
		panel1.Controls.Add(label9);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(panel2, "panel2");
		panel2.BorderStyle = BorderStyle.FixedSingle;
		panel2.Controls.Add(lblDescription);
		panel2.Controls.Add(label4);
		panel2.Controls.Add(lblSalePrice);
		panel2.Controls.Add(lblNotes);
		panel2.Controls.Add(label5);
		panel2.Controls.Add(lblPrice);
		panel2.Controls.Add(label2);
		panel2.Controls.Add(label3);
		panel2.Controls.Add(lblItemName);
		panel2.Controls.Add(label1);
		panel2.Name = "panel2";
		componentResourceManager.ApplyResources(lblDescription, "lblDescription");
		lblDescription.BackColor = Color.FromArgb(35, 39, 56);
		lblDescription.ForeColor = Color.White;
		lblDescription.Name = "lblDescription";
		label4.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.FromArgb(132, 146, 146);
		label4.Name = "label4";
		componentResourceManager.ApplyResources(lblSalePrice, "lblSalePrice");
		lblSalePrice.BackColor = Color.FromArgb(35, 39, 56);
		lblSalePrice.ForeColor = Color.White;
		lblSalePrice.Name = "lblSalePrice";
		componentResourceManager.ApplyResources(lblNotes, "lblNotes");
		lblNotes.BackColor = Color.FromArgb(35, 39, 56);
		lblNotes.ForeColor = Color.White;
		lblNotes.Name = "lblNotes";
		label5.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.FromArgb(132, 146, 146);
		label5.Name = "label5";
		componentResourceManager.ApplyResources(lblPrice, "lblPrice");
		lblPrice.BackColor = Color.FromArgb(35, 39, 56);
		lblPrice.ForeColor = Color.White;
		lblPrice.Name = "lblPrice";
		label2.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.FromArgb(132, 146, 146);
		label2.Name = "label2";
		label3.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.FromArgb(132, 146, 146);
		label3.Name = "label3";
		lblItemName.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(lblItemName, "lblItemName");
		lblItemName.ForeColor = Color.White;
		lblItemName.Name = "lblItemName";
		label1.BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.FromArgb(132, 146, 146);
		label1.Name = "label1";
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		componentResourceManager.ApplyResources(pbItemImage, "pbItemImage");
		pbItemImage.BorderStyle = BorderStyle.FixedSingle;
		pbItemImage.Name = "pbItemImage";
		pbItemImage.TabStop = false;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(panel1);
		base.Name = "frmItemInfo";
		base.Opacity = 1.0;
		panel1.ResumeLayout(performLayout: false);
		panel2.ResumeLayout(performLayout: false);
		panel2.PerformLayout();
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)pbItemImage).EndInit();
		ResumeLayout(performLayout: false);
	}
}
