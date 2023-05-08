using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CorePOS;

public class frmSingleImageViewer : frmMasterForm
{
	private byte[] byte_0;

	private Size? nullable_0;

	private IContainer icontainer_1;

	private PictureBox imageContainer;

	private PictureBox xIcon;

	public frmSingleImageViewer(byte[] base64BytesImage, Size? ContainerSize = null)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		byte_0 = base64BytesImage;
		nullable_0 = ContainerSize;
	}

	private void frmSingleImageViewer_Load(object sender, EventArgs e)
	{
		Size size = ((!nullable_0.HasValue) ? new Size(imageContainer.Width, imageContainer.Height) : new Size(nullable_0.Value.Width, nullable_0.Value.Height));
		using (MemoryStream stream = new MemoryStream(byte_0))
		{
			Bitmap image = new Bitmap(Image.FromStream(stream), new Size(size.Width, size.Height));
			imageContainer.Image = image;
			Size size4 = (base.Size = (imageContainer.Size = new Size(size.Width, size.Height)));
		}
		CenterToScreen();
	}

	private void imageContainer_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void xIcon_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		imageContainer.Dispose();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSingleImageViewer));
		xIcon = new PictureBox();
		imageContainer = new PictureBox();
		((ISupportInitialize)xIcon).BeginInit();
		((ISupportInitialize)imageContainer).BeginInit();
		SuspendLayout();
		xIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		xIcon.BackColor = Color.FromArgb(235, 107, 86);
		xIcon.Image = (Image)componentResourceManager.GetObject("xIcon.Image");
		xIcon.ImeMode = ImeMode.NoControl;
		xIcon.Location = new Point(752, 4);
		xIcon.Name = "xIcon";
		xIcon.Size = new Size(55, 55);
		xIcon.SizeMode = PictureBoxSizeMode.StretchImage;
		xIcon.TabIndex = 236;
		xIcon.TabStop = false;
		xIcon.Click += xIcon_Click;
		imageContainer.Location = new Point(1, 0);
		imageContainer.Name = "imageContainer";
		imageContainer.Size = new Size(100, 50);
		imageContainer.TabIndex = 0;
		imageContainer.TabStop = false;
		imageContainer.Click += imageContainer_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(811, 495);
		base.Controls.Add(xIcon);
		base.Controls.Add(imageContainer);
		base.Name = "frmSingleImageViewer";
		base.Opacity = 1.0;
		Text = "frmSingleImageViewer";
		base.Load += frmSingleImageViewer_Load;
		((ISupportInitialize)xIcon).EndInit();
		((ISupportInitialize)imageContainer).EndInit();
		ResumeLayout(performLayout: false);
	}
}
