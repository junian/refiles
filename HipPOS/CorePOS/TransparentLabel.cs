using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;

namespace CorePOS;

public class TransparentLabel : Label
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public Bitmap bmp;

		public _003C_003Ec__DisplayClass21_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003COnPaint_003Eb__3(Control c)
		{
			c.DrawToBitmap(bmp, c.Bounds);
		}
	}

	public int angle;

	public int xSize;

	public int ySize;

	public int flagType;

	public StringAlignment textAlign;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private PictureBox plantImage;

	private PictureBox MpsFaBprZeo;

	private PictureBox chairImage;

	private PictureBox drinkImage;

	private PictureBox foodImage;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private int int_1;

	public Color transparentBackColor;

	[CompilerGenerated]
	private string string_0;

	public int Opacity
	{
		get
		{
			return (int)(float.Parse(int_1.ToString()) / 255f * 100f);
		}
		set
		{
			if (value >= 0 && value <= 100)
			{
				int_1 = (int)((float)value / 100f * 255f);
			}
			Invalidate();
		}
	}

	public Color TransparentBackColor
	{
		get
		{
			return transparentBackColor;
		}
		set
		{
			transparentBackColor = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public override Color BackColor
	{
		get
		{
			return Color.Transparent;
		}
		set
		{
			base.BackColor = Color.Transparent;
		}
	}

	public string Status
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

	public TransparentLabel()
	{
		Class26.Ggkj0JxzN9YmC();
		xSize = 30;
		ySize = 30;
		flagType = 1;
		int_0 = 30;
		base._002Ector();
		IfwFaLobtLR();
		string text = "Flat";
		transparentBackColor = Color.White;
		int_1 = 255;
		BackColor = Color.Transparent;
		flagType = 1;
		textAlign = StringAlignment.Center;
		if (text == TransparentLabelType.Round)
		{
			bool_0 = true;
		}
		else if (text == TransparentLabelType.Rotated)
		{
			bool_1 = true;
			xSize = 30;
			ySize = 30;
			int_0 = Math.Max(xSize, ySize);
			base.Size = new Size(int_0 * 2 + int_0 / 2, int_0 * 2 + int_0 / 2);
		}
		else if (text == TransparentLabelType.Plant)
		{
			bool_2 = true;
		}
		else if (text == TransparentLabelType.Bench)
		{
			bool_3 = true;
		}
		else if (text == TransparentLabelType.Chair)
		{
			bool_4 = true;
		}
		else if (text == TransparentLabelType.Food)
		{
			bool_5 = true;
		}
		else if (text == TransparentLabelType.Drink)
		{
			bool_6 = true;
		}
		else
		{
			bool_0 = false;
			bool_1 = false;
		}
	}

	public TransparentLabel(string transparentLabelType = "Flat", int _xSize = 30, int _ySize = 30, int _flatType = 1)
	{
		Class26.Ggkj0JxzN9YmC();
		xSize = 30;
		ySize = 30;
		flagType = 1;
		int_0 = 30;
		base._002Ector();
		IfwFaLobtLR();
		transparentBackColor = Color.White;
		int_1 = 255;
		BackColor = Color.Transparent;
		flagType = _flatType;
		if (transparentLabelType == TransparentLabelType.Round)
		{
			bool_0 = true;
		}
		else if (transparentLabelType == TransparentLabelType.Rotated)
		{
			bool_1 = true;
			xSize = _xSize;
			ySize = _ySize;
			int_0 = Math.Max(xSize, ySize);
			base.Size = new Size(int_0 * 2 + int_0 / 2, int_0 * 2 + int_0 / 2);
		}
		else if (transparentLabelType == TransparentLabelType.Plant)
		{
			bool_2 = true;
		}
		else if (transparentLabelType == TransparentLabelType.Bench)
		{
			bool_3 = true;
		}
		else if (transparentLabelType == TransparentLabelType.Chair)
		{
			bool_4 = true;
		}
		else if (transparentLabelType == TransparentLabelType.Food)
		{
			bool_5 = true;
		}
		else if (transparentLabelType == TransparentLabelType.Drink)
		{
			bool_6 = true;
		}
		else
		{
			bool_0 = false;
			bool_1 = false;
		}
	}

	private static Bitmap smethod_0(Image image_0, int int_2, int int_3, float float_0)
	{
		int num = int_2 + 30;
		int num2 = int_3 + 30;
		Bitmap bitmap = new Bitmap((num > num2) ? num : num2, (num > num2) ? num : num2);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		_ = (float)bitmap.Width / 2f;
		_ = (float)bitmap.Height / 2f;
		Matrix transform = graphics.Transform;
		transform.RotateAt(float_0, new PointF(bitmap.Width / 2, bitmap.Height / 2), MatrixOrder.Append);
		graphics.Transform = transform;
		graphics.DrawImage(image_0, new PointF((bitmap.Width - image_0.Width) / 2, (bitmap.Height - image_0.Height) / 2));
		return bitmap;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.Parent == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.bmp = new Bitmap(base.Parent.Width, base.Parent.Height);
		try
		{
			(from control_0 in (from Control control_0 in base.Parent.Controls
					where base.Parent.Controls.GetChildIndex(control_0) > base.Parent.Controls.GetChildIndex(this)
					select control_0).Where(delegate(Control control_0)
				{
					if (control_0.Bounds.IntersectsWith(base.Bounds) && control_0.Visible)
					{
						_ = control_0.Bounds;
						return true;
					}
					return false;
				})
				orderby base.Parent.Controls.GetChildIndex(control_0) descending
				select control_0).ToList().ForEach(delegate(Control c)
			{
				c.DrawToBitmap(CS_0024_003C_003E8__locals0.bmp, c.Bounds);
			});
			e.Graphics.DrawImage(CS_0024_003C_003E8__locals0.bmp, -base.Left, -base.Top);
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(int_1, TransparentBackColor)))
			{
				if (bool_0)
				{
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					e.Graphics.FillEllipse(brush, base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
				}
				else if (bool_1)
				{
					if (flagType == 1)
					{
						int num = base.Width;
						int num2 = base.Height;
						if (!base.DesignMode)
						{
							Point center = new Point(num / 2, num2 / 2);
							Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angle, center, ySize, xSize);
							Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angle, center, ySize, xSize);
							Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angle, center, ySize, xSize);
							Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angle, center, ySize, xSize);
							Point[] points = new Point[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 };
							e.Graphics.FillPolygon(brush, points);
						}
					}
					else if (flagType == 2)
					{
						e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
						e.Graphics.FillEllipse(brush, base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
					}
					else if (flagType == 3)
					{
						Image image = plantImage.Image;
						Bitmap image2 = smethod_0(image, image.Width, image.Height, angle);
						e.Graphics.DrawImage(image2, base.ClientRectangle.X, base.ClientRectangle.Y);
						e.Graphics.DrawRectangle(new Pen(Color.FromArgb(1, 110, 211)), new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1));
					}
					else if (flagType == 4)
					{
						Image image3 = MpsFaBprZeo.Image;
						Bitmap image4 = smethod_0(image3, image3.Width, image3.Height, angle);
						e.Graphics.DrawImage(image4, base.ClientRectangle.X, base.ClientRectangle.Y);
						e.Graphics.DrawRectangle(new Pen(Color.FromArgb(1, 110, 211)), new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1));
					}
					else if (flagType == 5)
					{
						Image image5 = chairImage.Image;
						Bitmap image6 = smethod_0(image5, image5.Width, image5.Height, angle);
						e.Graphics.DrawImage(image6, base.ClientRectangle.X, base.ClientRectangle.Y);
						e.Graphics.DrawRectangle(new Pen(Color.FromArgb(1, 110, 211)), new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1));
					}
				}
				else if (bool_2)
				{
					Image image7 = plantImage.Image;
					e.Graphics.DrawImage(image7, base.ClientRectangle, new Rectangle(0, 0, image7.Size.Width, image7.Size.Height), GraphicsUnit.Pixel);
				}
				else if (bool_3)
				{
					Image image8 = MpsFaBprZeo.Image;
					e.Graphics.DrawImage(image8, base.ClientRectangle, new Rectangle(0, 0, image8.Size.Width, image8.Size.Height), GraphicsUnit.Pixel);
				}
				else if (bool_4)
				{
					Image image9 = chairImage.Image;
					e.Graphics.DrawImage(image9, base.ClientRectangle, new Rectangle(0, 0, image9.Size.Width, image9.Size.Height), GraphicsUnit.Pixel);
				}
				else if (bool_5)
				{
					Image image10 = foodImage.Image;
					e.Graphics.DrawImage(image10, base.ClientRectangle, new Rectangle(0, 0, image10.Size.Width, image10.Size.Height), GraphicsUnit.Pixel);
				}
				else if (bool_6)
				{
					Image image11 = drinkImage.Image;
					e.Graphics.DrawImage(image11, base.ClientRectangle, new Rectangle(0, 0, image11.Size.Width, image11.Size.Height), GraphicsUnit.Pixel);
				}
				else
				{
					e.Graphics.FillRectangle(brush, base.ClientRectangle);
				}
			}
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = textAlign;
			stringFormat.LineAlignment = StringAlignment.Center;
			SolidBrush brush2 = new SolidBrush(ForeColor);
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.DrawString(Text, Font, brush2, base.ClientRectangle, stringFormat);
		}
		catch
		{
		}
		finally
		{
			if (CS_0024_003C_003E8__locals0.bmp != null)
			{
				((IDisposable)CS_0024_003C_003E8__locals0.bmp).Dispose();
			}
		}
	}

	private void IfwFaLobtLR()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TransparentLabel));
		plantImage = new PictureBox();
		MpsFaBprZeo = new PictureBox();
		chairImage = new PictureBox();
		drinkImage = new PictureBox();
		foodImage = new PictureBox();
		((ISupportInitialize)plantImage).BeginInit();
		((ISupportInitialize)MpsFaBprZeo).BeginInit();
		((ISupportInitialize)chairImage).BeginInit();
		((ISupportInitialize)drinkImage).BeginInit();
		((ISupportInitialize)foodImage).BeginInit();
		SuspendLayout();
		plantImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		plantImage.BackColor = Color.Transparent;
		plantImage.Image = (Image)componentResourceManager.GetObject("plantImage.Image");
		plantImage.Location = new Point(922, 571);
		plantImage.Name = "plantImage";
		plantImage.Size = new Size(34, 32);
		plantImage.SizeMode = PictureBoxSizeMode.StretchImage;
		plantImage.TabIndex = 125;
		plantImage.TabStop = false;
		plantImage.Visible = false;
		MpsFaBprZeo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		MpsFaBprZeo.BackColor = Color.Transparent;
		MpsFaBprZeo.Image = (Image)componentResourceManager.GetObject("benchImage.Image");
		MpsFaBprZeo.Location = new Point(922, 571);
		MpsFaBprZeo.Name = "benchImage";
		MpsFaBprZeo.Size = new Size(34, 32);
		MpsFaBprZeo.SizeMode = PictureBoxSizeMode.StretchImage;
		MpsFaBprZeo.TabIndex = 125;
		MpsFaBprZeo.TabStop = false;
		MpsFaBprZeo.Visible = false;
		chairImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		chairImage.BackColor = Color.Transparent;
		chairImage.Image = (Image)componentResourceManager.GetObject("chairImage.Image");
		chairImage.Location = new Point(922, 571);
		chairImage.Name = "chairImage";
		chairImage.Size = new Size(34, 32);
		chairImage.SizeMode = PictureBoxSizeMode.StretchImage;
		chairImage.TabIndex = 125;
		chairImage.TabStop = false;
		chairImage.Visible = false;
		drinkImage.BackColor = Color.Transparent;
		drinkImage.Image = (Image)componentResourceManager.GetObject("drinkImage.Image");
		drinkImage.Location = new Point(51, 632);
		drinkImage.Name = "drinkImage";
		drinkImage.Size = new Size(42, 40);
		drinkImage.SizeMode = PictureBoxSizeMode.StretchImage;
		drinkImage.TabIndex = 104;
		drinkImage.TabStop = false;
		drinkImage.Visible = false;
		foodImage.BackColor = Color.Transparent;
		foodImage.Image = (Image)componentResourceManager.GetObject("foodImage.Image");
		foodImage.Location = new Point(3, 632);
		foodImage.Name = "foodImage";
		foodImage.Size = new Size(42, 40);
		foodImage.SizeMode = PictureBoxSizeMode.StretchImage;
		foodImage.TabIndex = 103;
		foodImage.TabStop = false;
		foodImage.Visible = false;
		((ISupportInitialize)plantImage).EndInit();
		((ISupportInitialize)MpsFaBprZeo).EndInit();
		((ISupportInitialize)chairImage).EndInit();
		((ISupportInitialize)drinkImage).EndInit();
		((ISupportInitialize)foodImage).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_0(Control control_0)
	{
		return base.Parent.Controls.GetChildIndex(control_0) > base.Parent.Controls.GetChildIndex(this);
	}

	[CompilerGenerated]
	private bool method_1(Control control_0)
	{
		if (control_0.Bounds.IntersectsWith(base.Bounds) && control_0.Visible)
		{
			_ = control_0.Bounds;
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private int method_2(Control control_0)
	{
		return base.Parent.Controls.GetChildIndex(control_0);
	}
}
