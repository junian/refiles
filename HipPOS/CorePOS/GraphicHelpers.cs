using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS;

public static class GraphicHelpers
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string sectionName;

		public Func<Layout, bool> _003C_003E9__0;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CDrawEditLayout_003Eb__0(Layout l)
		{
			return l.Section == sectionName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public string sectionName;

		public Func<Layout, bool> _003C_003E9__0;

		public Func<Layout, bool> _003C_003E9__1;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CDrawLayout_003Eb__0(Layout l)
		{
			if (l.Rotation == 'A')
			{
				return l.Section == sectionName;
			}
			return false;
		}

		internal bool _003CDrawLayout_003Eb__1(Layout l)
		{
			if (l.Rotation == 'O')
			{
				return l.Section == sectionName;
			}
			return false;
		}
	}

	public static void FillRotatedRectangleWithText(Graphics g, Brush b, int angle, int x, int y, int xSize, int ySize, string text, Font textFont, Color textColor, StringFormat format)
	{
		int num = Math.Max(xSize, ySize);
		Size size = new Size(num * 2 + num / 2, num * 2 + num / 2);
		int x2 = size.Width / 2 + x;
		int y2 = size.Height / 2 + y;
		Point point = new Point(x2, y2);
		Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angle, point, ySize, xSize);
		Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angle, point, ySize, xSize);
		Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angle, point, ySize, xSize);
		Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angle, point, ySize, xSize);
		Point[] points = new Point[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 };
		g.FillPolygon(b, points);
		SolidBrush brush = new SolidBrush(textColor);
		g.DrawString(text, textFont, brush, point, format);
	}

	public static void FillFlatRectangleWithText(Graphics g, Brush b, int x, int y, int xSize, int ySize, string text, Font textFont, Color textColor, StringFormat format, int scalePosition, string tableName, Dictionary<string, Point> capacityLabelList)
	{
		int num = text.Length * ((text.Length > 3) ? 6 : 5);
		Point point = new Point(x + xSize - 29 - num - (scalePosition - 5) * 2, y + ySize / 2 - (scalePosition - 5) / 2);
		g.FillRectangle(b, x - (scalePosition - 5) * 4, y - (scalePosition - 5), xSize - (5 - scalePosition) * 4, ySize - (5 - scalePosition));
		capacityLabelList?.Add(tableName, new Point(x - (scalePosition - 5) * 4, y - (scalePosition - 5)));
		SolidBrush brush = new SolidBrush(textColor);
		g.DrawString(text, textFont, brush, point, format);
	}

	public static void FillFlatRectangleWithTextTrimmed(Graphics g, Brush b, int x, int y, int xSize, int ySize, string text, Font textFont, Color textColor, StringFormat format, int scalePosition, string tableName, Dictionary<string, Point> capacityLabelList)
	{
		int num = text.Length * ((text.Length > 3) ? 6 : 5);
		Point point = new Point(x + xSize - 12 - num - (scalePosition - 5) * 2, y + ySize / 2 - (scalePosition - 5) / 2);
		g.FillRectangle(b, x - (scalePosition - 5) * 4, y - (scalePosition - 5), xSize - (5 - scalePosition) * 4, ySize - (5 - scalePosition));
		SolidBrush brush = new SolidBrush(textColor);
		g.DrawString(text.ToUpper(), textFont, brush, point, format);
	}

	public static Point GetCapacityLocationRectTable(Point[] points, Size capacity)
	{
		Point point = new Point(0, 0);
		int num = 9999;
		int num2 = 9999;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		bool flag = false;
		for (int i = 0; i < 4; i++)
		{
			if (points[i].X < num2)
			{
				num2 = points[i].X;
			}
			if (points[i].X > num4)
			{
				num4 = points[i].X;
			}
			if (points[i].Y < num)
			{
				num = points[i].Y;
			}
			if (points[i].Y > num3)
			{
				num3 = points[i].Y;
				point = points[i];
			}
			if (flag || i <= 0)
			{
				continue;
			}
			for (int j = 0; j < i; j++)
			{
				if (points[j].Y + 10 >= points[i].Y && points[j].Y - 10 <= points[i].Y)
				{
					flag = true;
				}
			}
		}
		int num7 = num4 - num2;
		num5 = point.Y - capacity.Height;
		num6 = ((point.X > num2 + num7 / 2 && !flag) ? (point.X - capacity.Width + 10) : ((point.X < num2 + num7 / 2 && !flag) ? (point.X - 10) : ((!flag) ? (point.X + num7 / 2 - capacity.Width / 2) : (num4 - capacity.Width))));
		return new Point(num6, num5);
	}

	public static Point[] GetFourPolygonPoints(Layout layout, out Point center, double scale)
	{
		int num = layout.NumOfSeats.Value;
		if (num <= 2)
		{
			num++;
		}
		int num2 = (int)(40.0 * scale);
		int num3 = (int)((double)(15 * num) * scale);
		int angleOfRotation = layout.AngleOfRotation;
		int num4 = Math.Max(num2, num3);
		Size size = new Size(num4 * 2 + num4 / 2, num4 * 2 + num4 / 2);
		int num5 = size.Width / 2 + layout.X.Value;
		int num6 = size.Height / 2 + layout.Y.Value;
		center = new Point((int)((double)num5 * scale), (int)((double)num6 * scale));
		Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angleOfRotation, center, num3, num2);
		Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angleOfRotation, center, num3, num2);
		Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angleOfRotation, center, num3, num2);
		Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angleOfRotation, center, num3, num2);
		return new Point[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 };
	}

	public static int GetCapacityLabelWidth(string text)
	{
		return 20 + text.Length * 10;
	}

	private static void smethod_0(Graphics graphics_0, Image image_0, int int_0, int int_1, int int_2, int int_3, int int_4, double double_0 = 1.0)
	{
		int num = int_3 + 30;
		int num2 = int_4 + 30;
		Bitmap bitmap = new Bitmap((num > num2) ? num : num2, (num > num2) ? num : num2);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		Matrix transform = graphics.Transform;
		transform.RotateAt(int_0, new PointF(bitmap.Width / 2, bitmap.Height / 2), MatrixOrder.Append);
		graphics.Transform = transform;
		graphics.DrawImage(image_0, new PointF((bitmap.Width - image_0.Width) / 2, (bitmap.Height - image_0.Height) / 2));
		graphics_0.DrawImage(bitmap, (float)((double)int_1 * double_0), (float)((double)int_2 * double_0), (float)((double)bitmap.Width * double_0), (float)((double)bitmap.Height * double_0));
	}

	public static void DrawEditLayout(PaintEventArgs e, List<Layout> currentLayout, string sectionName, Image imageLabel, Image plantImage, Image benchImage, Image chairImage, int scalePosition, Point ScrollValue)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.sectionName = sectionName;
		SolidBrush brush = new SolidBrush(Color.FromArgb(255, Color.White));
		SolidBrush brush2 = new SolidBrush(ColorPalette.PictonBlue);
		new SolidBrush(Color.FromArgb(255, Color.Black));
		SolidBrush b = new SolidBrush(HelperMethods.GetColor("147, 101, 184"));
		Font font = new Font("Arial", 17 - (9 - scalePosition), FontStyle.Regular);
		Font textFont = new Font("Arial", (float)(9.0 - (double)(5 - scalePosition) / 2.0), FontStyle.Regular);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		StringFormat stringFormat2 = new StringFormat();
		stringFormat2.Alignment = StringAlignment.Near;
		stringFormat2.LineAlignment = StringAlignment.Center;
		double num = (double)scalePosition / 5.0 - 0.1 * ((double)scalePosition - 5.0);
		foreach (Layout item in currentLayout.Where((Layout l) => l.Section == CS_0024_003C_003E8__locals0.sectionName))
		{
			int num2 = item.Y.Value - ScrollValue.Y;
			int num3 = item.X.Value - ScrollValue.X;
			if (item.Rotation == 'A')
			{
				Graphics graphics = e.Graphics;
				int num4 = ((item.Rotation == 'B') ? num3 : (item.NumOfSeats.Value / 2 + num3));
				int num5 = ((item.Rotation == 'B') ? (item.NumOfSeats.Value / 2 + num2) : num2);
				int angleDegrees = ((item.Rotation == 'B') ? 90 : item.AngleOfRotation);
				Point center = new Point((int)((double)num4 * num), (int)((double)num5 * num));
				int width = (int)((double)(item.NumOfSeats.Value / 2) * num);
				int height = (((int)(5.0 * num) == 0) ? 1 : ((int)(5.0 * num)));
				Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angleDegrees, center, width, height);
				Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angleDegrees, center, width, height);
				Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angleDegrees, center, width, height);
				Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angleDegrees, center, width, height);
				Point[] points = new Point[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 };
				graphics.FillPolygon(brush, points);
			}
			else if (item.Rotation == 'H')
			{
				Graphics graphics2 = e.Graphics;
				if (!item.Round)
				{
					int num6 = item.NumOfSeats.Value;
					if (num6 <= 2)
					{
						num6++;
					}
					int num7 = (int)(double)(15 * num6);
					int angleOfRotation = item.AngleOfRotation;
					int num8 = Math.Max(40, num7);
					Size size = new Size(num8 * 2 + num8 / 2, num8 * 2 + num8 / 2);
					int num9 = size.Width / 2 + num3;
					int num10 = size.Height / 2 + num2;
					Point point = new Point((int)((double)num9 * num), (int)((double)num10 * num));
					Point rotatedRectangleCoords5 = ControlHelpers.GetRotatedRectangleCoords(1, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
					Point rotatedRectangleCoords6 = ControlHelpers.GetRotatedRectangleCoords(2, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
					Point rotatedRectangleCoords7 = ControlHelpers.GetRotatedRectangleCoords(3, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
					Point rotatedRectangleCoords8 = ControlHelpers.GetRotatedRectangleCoords(4, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
					Point[] points2 = new Point[4] { rotatedRectangleCoords5, rotatedRectangleCoords6, rotatedRectangleCoords7, rotatedRectangleCoords8 };
					if (item.CurrentGuests > 0)
					{
						graphics2.FillPolygon(brush2, points2);
					}
					else
					{
						graphics2.FillPolygon(brush, points2);
					}
					graphics2.DrawString(item.TableName, font, new SolidBrush(Color.Black), point, stringFormat);
					int currentGuests = item.CurrentGuests;
					string text = ((currentGuests < 0) ? "0" : currentGuests.ToString()) + "/" + item.NumOfSeats.Value;
					int capacityLabelWidth = GetCapacityLabelWidth(text);
					Size capacity = new Size(capacityLabelWidth, 20);
					Point capacityLocationRectTable = GetCapacityLocationRectTable(points2, capacity);
					FillFlatRectangleWithText(graphics2, b, capacityLocationRectTable.X, capacityLocationRectTable.Y, capacity.Width, capacity.Height, text, textFont, Color.White, stringFormat2, 5, item.TableName, null);
					graphics2.DrawImage(imageLabel, capacityLocationRectTable.X + capacity.Width - 24, capacityLocationRectTable.Y, 20, 20);
				}
				else
				{
					int value = item.NumOfSeats.Value;
					int num11 = (int)((double)(60 + value * 4) * num);
					Size size2 = new Size(num11, num11);
					Point point2 = new Point((int)((double)num3 * num), (int)((double)num2 * num));
					graphics2.SmoothingMode = SmoothingMode.HighQuality;
					if (item.CurrentGuests > 0)
					{
						graphics2.FillEllipse(brush2, point2.X, point2.Y, size2.Width - 1, size2.Height - 1);
					}
					else
					{
						graphics2.FillEllipse(brush, point2.X, point2.Y, size2.Width - 1, size2.Height - 1);
					}
					graphics2.DrawString(point: new Point(point2.X + size2.Width / 2, point2.Y + size2.Height / 2), s: item.TableName, font: font, brush: new SolidBrush(Color.Black), format: stringFormat);
					int currentGuests2 = item.CurrentGuests;
					string text2 = ((currentGuests2 < 0) ? "0" : currentGuests2.ToString()) + "/" + item.NumOfSeats.Value;
					int capacityLabelWidth2 = GetCapacityLabelWidth(text2);
					Size size3 = new Size(capacityLabelWidth2, 20);
					Point point4 = new Point(point2.X + size2.Width - size3.Width, point2.Y + size2.Height - size3.Height);
					FillFlatRectangleWithText(graphics2, b, point4.X, point4.Y, size3.Width, size3.Height, text2, textFont, Color.White, stringFormat2, scalePosition, item.TableName, null);
					graphics2.DrawImage(imageLabel, point4.X + size3.Width - 24, point4.Y, 20, 20);
				}
			}
			else if (item.Rotation == 'O')
			{
				Graphics graphics3 = e.Graphics;
				if (item.TableName.Contains(TransparentLabelType.Plant))
				{
					smethod_0(graphics3, plantImage, item.AngleOfRotation, num3, num2, plantImage.Width, plantImage.Height, num);
				}
				else if (item.TableName.Contains(TransparentLabelType.Bench))
				{
					smethod_0(graphics3, benchImage, item.AngleOfRotation, num3, num2, benchImage.Width, benchImage.Height, num);
				}
				else if (item.TableName.Contains(TransparentLabelType.Chair))
				{
					smethod_0(graphics3, chairImage, item.AngleOfRotation, num3, num2, chairImage.Width, chairImage.Height, num);
				}
			}
		}
	}

	public static Dictionary<string, Point> DrawLayout(object sender, PaintEventArgs e, List<Layout> objectsAndWalls, List<TableModel> tables, string sectionName, Image imageLabel, Image plantImage, Image benchImage, Image chairImage, int scalePosition, bool capacityOn)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.sectionName = sectionName;
		Dictionary<string, Point> dictionary = new Dictionary<string, Point>();
		Panel panel = sender as Panel;
		SolidBrush brush = new SolidBrush(Color.FromArgb(255, Color.White));
		SolidBrush brush2 = new SolidBrush(ColorPalette.PictonBlue);
		new SolidBrush(Color.FromArgb(255, Color.Black));
		SolidBrush brush3 = new SolidBrush(ColorPalette.Fern);
		SolidBrush brush4 = new SolidBrush(Color.FromArgb(255, 192, 128));
		SolidBrush b = new SolidBrush(HelperMethods.GetColor("147, 101, 184"));
		new SolidBrush(HelperMethods.GetColor("176, 124, 219"));
		new SolidBrush(HelperMethods.GetColor("55,38,69"));
		Font font = new Font("Arial", 17 - (9 - scalePosition), FontStyle.Regular);
		new Font("Arial", 14 - (9 - scalePosition), FontStyle.Regular);
		Font textFont = new Font("Arial", (float)(9.0 - (double)(5 - scalePosition) / 2.0), FontStyle.Regular);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		StringFormat stringFormat2 = new StringFormat();
		stringFormat2.Alignment = StringAlignment.Near;
		stringFormat2.LineAlignment = StringAlignment.Center;
		e.Graphics.TranslateTransform(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y);
		double num = (double)scalePosition / 5.0 - 0.1 * ((double)scalePosition - 5.0);
		foreach (Layout item in objectsAndWalls.Where((Layout l) => l.Rotation == 'A' && l.Section == CS_0024_003C_003E8__locals0.sectionName))
		{
			Graphics graphics = e.Graphics;
			int? num2 = item.Rotation;
			int num3 = 66;
			int num4 = ((num2 == 66) ? item.X.Value : (item.NumOfSeats.Value / 2 + item.X.Value));
			num2 = item.Rotation;
			num3 = 66;
			int num5 = ((num2 == 66) ? (item.NumOfSeats.Value / 2 + item.Y.Value) : item.Y.Value);
			num2 = item.Rotation;
			num3 = 66;
			int angleDegrees = ((num2 == 66) ? 90 : item.AngleOfRotation);
			Point center = new Point((int)((double)num4 * num), (int)((double)num5 * num));
			int width = (int)((double)(item.NumOfSeats.Value / 2) * num);
			int height = (((int)(5.0 * num) == 0) ? 1 : ((int)(5.0 * num)));
			Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angleDegrees, center, width, height);
			Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angleDegrees, center, width, height);
			Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angleDegrees, center, width, height);
			Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angleDegrees, center, width, height);
			Point[] points = new Point[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 };
			graphics.FillPolygon(brush, points);
		}
		foreach (Layout item2 in objectsAndWalls.Where((Layout l) => l.Rotation == 'O' && l.Section == CS_0024_003C_003E8__locals0.sectionName))
		{
			Graphics graphics2 = e.Graphics;
			if (item2.TableName.Contains(TransparentLabelType.Plant))
			{
				smethod_0(graphics2, plantImage, item2.AngleOfRotation, item2.X.Value, item2.Y.Value, plantImage.Width, plantImage.Height, num);
			}
			else if (item2.TableName.Contains(TransparentLabelType.Bench))
			{
				smethod_0(graphics2, benchImage, item2.AngleOfRotation, item2.X.Value, item2.Y.Value, benchImage.Width, benchImage.Height, num);
			}
			else if (item2.TableName.Contains(TransparentLabelType.Chair))
			{
				smethod_0(graphics2, chairImage, item2.AngleOfRotation, item2.X.Value, item2.Y.Value, chairImage.Width, chairImage.Height, num);
			}
		}
		foreach (TableModel table in tables)
		{
			string text = "";
			if (!string.IsNullOrEmpty(table.EmployeeAssigned) && SettingsHelper.GetSettingValueByKey("show_employee_table") == "ON")
			{
				text = table.EmployeeAssigned;
			}
			Graphics graphics3 = e.Graphics;
			if (!table.isRound)
			{
				int num6 = table.TotalCapacity;
				if (num6 <= 2)
				{
					num6++;
				}
				int num7 = (int)(double)(15 * num6);
				int angleOfRotation = table.angleOfRotation;
				int num8 = Math.Max(40, num7);
				Size size = new Size(num8 * 2 + num8 / 2, num8 * 2 + num8 / 2);
				int num9 = size.Width / 2 + table.Location.X;
				int num10 = size.Height / 2 + table.Location.Y;
				Point point = new Point((int)((double)num9 * num), (int)((double)num10 * num));
				Point rotatedRectangleCoords5 = ControlHelpers.GetRotatedRectangleCoords(1, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
				Point rotatedRectangleCoords6 = ControlHelpers.GetRotatedRectangleCoords(2, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
				Point rotatedRectangleCoords7 = ControlHelpers.GetRotatedRectangleCoords(3, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
				Point rotatedRectangleCoords8 = ControlHelpers.GetRotatedRectangleCoords(4, angleOfRotation, point, (int)((double)num7 * num), (int)(40.0 * num));
				Point[] points2 = new Point[4] { rotatedRectangleCoords5, rotatedRectangleCoords6, rotatedRectangleCoords7, rotatedRectangleCoords8 };
				if (!(table.Status == TableStatus.Open) && !(table.Status == TableStatus.Reserved))
				{
					if (table.Status == TableStatus.Paid)
					{
						graphics3.FillPolygon(brush3, points2);
					}
					else if (table.Status == TableStatus.Seated)
					{
						if (capacityOn)
						{
							graphics3.FillPolygon(brush4, points2);
						}
						else
						{
							graphics3.FillPolygon(brush, points2);
						}
					}
					else
					{
						graphics3.FillPolygon(brush2, points2);
					}
				}
				else
				{
					graphics3.FillPolygon(brush, points2);
				}
				graphics3.DrawString(table.TableName, font, new SolidBrush(Color.Black), point, stringFormat);
				string empty = string.Empty;
				empty = ((!capacityOn) ? (" " + table.TotalCapacity) : (((table.currentGuests < 0) ? "0" : table.currentGuests.ToString()) + "/" + table.TotalCapacity));
				int capacityLabelWidth = GetCapacityLabelWidth(empty);
				Size capacity = new Size(capacityLabelWidth, 20);
				Point capacityLocationRectTable = GetCapacityLocationRectTable(points2, capacity);
				FillFlatRectangleWithText(graphics3, b, capacityLocationRectTable.X, capacityLocationRectTable.Y, capacity.Width, capacity.Height, empty, textFont, Color.White, stringFormat2, scalePosition, table.TableName, dictionary);
				graphics3.DrawImage(imageLabel, capacityLocationRectTable.X + capacity.Width - 24 - (scalePosition - 5), capacityLocationRectTable.Y - (scalePosition - 5), 20 - (5 - scalePosition), 20 - (5 - scalePosition));
				if (!string.IsNullOrEmpty(text))
				{
					int num11 = GetCapacityLabelWidth(text) - 20;
					Size size2 = new Size(num11, 20);
					Point point2 = new Point(capacityLocationRectTable.X - (num11 - capacityLabelWidth), capacityLocationRectTable.Y + (20 - (5 - scalePosition)) - 1);
					FillFlatRectangleWithTextTrimmed(graphics3, b, point2.X, point2.Y, size2.Width, size2.Height, text, textFont, Color.White, stringFormat2, scalePosition, table.TableName, null);
				}
				continue;
			}
			int totalCapacity = table.TotalCapacity;
			int num12 = (int)((double)(60 + totalCapacity * 4) * num);
			Size size3 = new Size(num12, num12);
			Point point3 = new Point((int)((double)table.Location.X * num), (int)((double)table.Location.Y * num));
			graphics3.SmoothingMode = SmoothingMode.HighQuality;
			if (!(table.Status == TableStatus.Open) && !(table.Status == TableStatus.Reserved))
			{
				if (table.Status == TableStatus.Paid)
				{
					graphics3.FillEllipse(brush3, point3.X, point3.Y, size3.Width - 1, size3.Height - 1);
				}
				else if (table.Status == TableStatus.Seated)
				{
					if (capacityOn)
					{
						graphics3.FillEllipse(brush4, point3.X, point3.Y, size3.Width - 1, size3.Height - 1);
					}
					else
					{
						graphics3.FillEllipse(brush, point3.X, point3.Y, size3.Width - 1, size3.Height - 1);
					}
				}
				else
				{
					graphics3.FillEllipse(brush2, point3.X, point3.Y, size3.Width - 1, size3.Height - 1);
				}
			}
			else
			{
				graphics3.FillEllipse(brush, point3.X, point3.Y, size3.Width - 1, size3.Height - 1);
			}
			graphics3.DrawString(point: new Point(point3.X + size3.Width / 2, point3.Y + size3.Height / 2), s: table.TableName, font: font, brush: new SolidBrush(Color.Black), format: stringFormat);
			string empty2 = string.Empty;
			empty2 = ((!capacityOn) ? (" " + table.TotalCapacity) : (((table.currentGuests < 0) ? "0" : table.currentGuests.ToString()) + "/" + table.TotalCapacity));
			int capacityLabelWidth2 = GetCapacityLabelWidth(empty2);
			Size size4 = new Size(capacityLabelWidth2, 20);
			Point point5 = new Point(point3.X + size3.Width - size4.Width, point3.Y + size3.Height - size4.Height);
			FillFlatRectangleWithText(graphics3, b, point5.X, point5.Y, size4.Width, size4.Height, empty2, textFont, Color.White, stringFormat2, scalePosition, table.TableName, dictionary);
			graphics3.DrawImage(imageLabel, point5.X + size4.Width - 24 - (scalePosition - 5), point5.Y - (scalePosition - 5), 20 - (5 - scalePosition), 20 - (5 - scalePosition));
			if (!string.IsNullOrEmpty(text))
			{
				int num13 = GetCapacityLabelWidth(text) - 20;
				Size size5 = new Size(num13, 20);
				Point point6 = new Point(point5.X - (num13 - capacityLabelWidth2), point5.Y + (20 - (5 - scalePosition)) - 1);
				FillFlatRectangleWithTextTrimmed(graphics3, b, point6.X, point6.Y, size5.Width, size5.Height, text, textFont, Color.White, stringFormat2, scalePosition, table.TableName, null);
			}
		}
		return dictionary;
	}
}
