using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal class Class17 : CheckBox
{
	private int int_0;

	private int int_1;

	private PictureBox picUncheck;

	private PictureBox picHover;

	private PictureBox picChecked;

	private int int_2;

	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = false;
		}
	}

	public Class17(int int_3 = 30, int int_4 = 30, int int_5 = 30, string string_0 = "")
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		method_0();
		Text = string_0;
		TextAlign = ContentAlignment.MiddleRight;
		int_0 = int_4;
		int_1 = int_3;
		int_2 = int_5;
	}

	public Class17()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		method_0();
		Text = string.Empty;
		TextAlign = ContentAlignment.MiddleRight;
		int_0 = 30;
		int_1 = 30;
		int_2 = 30;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		base.Height = int_0;
		base.Width = int_1;
		int num = int_2;
		Rectangle destRect = new Rectangle(new Point(0, 0), new Size(num, num));
		Image image = picChecked.Image;
		image = ((!base.Checked) ? picUncheck.Image : picChecked.Image);
		e.Graphics.DrawImage(image, destRect, new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
	}

	private void method_0()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Class17));
		picUncheck = new PictureBox();
		picHover = new PictureBox();
		picChecked = new PictureBox();
		((ISupportInitialize)picUncheck).BeginInit();
		((ISupportInitialize)picHover).BeginInit();
		((ISupportInitialize)picChecked).BeginInit();
		SuspendLayout();
		picUncheck.Image = (Image)componentResourceManager.GetObject("picUncheck.Image");
		picUncheck.Location = new Point(0, 0);
		picUncheck.Name = "picUncheck";
		picUncheck.Size = new Size(100, 50);
		picUncheck.TabIndex = 0;
		picUncheck.TabStop = false;
		picHover.Image = (Image)componentResourceManager.GetObject("picHover.Image");
		picHover.Location = new Point(0, 0);
		picHover.Name = "picHover";
		picHover.Size = new Size(100, 50);
		picHover.TabIndex = 0;
		picHover.TabStop = false;
		picChecked.Image = (Image)componentResourceManager.GetObject("picChecked.Image");
		picChecked.Location = new Point(0, 0);
		picChecked.Name = "picChecked";
		picChecked.Size = new Size(100, 50);
		picChecked.TabIndex = 0;
		picChecked.TabStop = false;
		((ISupportInitialize)picUncheck).EndInit();
		((ISupportInitialize)picHover).EndInit();
		((ISupportInitialize)picChecked).EndInit();
		ResumeLayout(performLayout: false);
	}
}
