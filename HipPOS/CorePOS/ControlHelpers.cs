using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public static class ControlHelpers
{
	public enum MoveDirection
	{
		Up = -1,
		Down = 1
	}

	public static int ControlWidthFixer(Control ParentControl, double BootstrapColumnInt)
	{
		return Convert.ToInt32(Convert.ToDouble(ParentControl.Size.Width) * BootstrapColumnInt / 12.0);
	}

	public static void TimePick_Click(object sender)
	{
		DateTimePicker dateTimePicker = sender as DateTimePicker;
		frmTimePicker frmTimePicker2 = new frmTimePicker(dateTimePicker.Value);
		if (frmTimePicker2.ShowDialog() == DialogResult.OK)
		{
			dateTimePicker.Value = frmTimePicker2.Time;
		}
	}

	public static void txt_click(object sender)
	{
		try
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
			Control parent;
			try
			{
				RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
				CS_0024_003C_003E8__locals0.name = radTextBoxControl.Name.Replace("txt", string.Empty);
				parent = radTextBoxControl.Parent;
			}
			catch
			{
				TextBox textBox = sender as TextBox;
				CS_0024_003C_003E8__locals0.name = textBox.Name.Replace("txt", string.Empty);
				parent = textBox.Parent;
			}
			Button button = (from c in parent.Controls.OfType<Button>()
				where c.Name.Contains(CS_0024_003C_003E8__locals0.name)
				select c).FirstOrDefault();
			if (button == null)
			{
				button = (from c in parent.Parent.Controls.OfType<Button>()
					where c.Name.Contains(CS_0024_003C_003E8__locals0.name)
					select c).FirstOrDefault();
			}
			button.PerformClick();
		}
		catch
		{
		}
	}

	public static double GetAngleByLocationWithCenter(Point center, Point currentLocation)
	{
		double y = currentLocation.Y - center.Y;
		double x = currentLocation.X - center.X;
		return Math.Atan2(y, x) * 180.0 / Math.PI;
	}

	public static double GetDistanceBetween2Points(Point start, Point end)
	{
		return Math.Sqrt(Math.Pow(end.X - start.X, 2.0) + Math.Pow(end.Y - start.Y, 2.0));
	}

	public static Point GetRotatedRectangleCoords(int num, int angleDegrees, Point center, int width, int height)
	{
		double num2 = Math.PI * (double)angleDegrees / 180.0;
		double num3 = width;
		double num4 = height;
		switch (num)
		{
		case 2:
			num3 = 0.0 - num3;
			break;
		case 3:
			num3 = 0.0 - num3;
			num4 = 0.0 - num4;
			break;
		case 4:
			num4 = 0.0 - num4;
			break;
		}
		double num5 = (double)center.X + num3 * Math.Cos(num2) - num4 * Math.Sin(num2);
		double num6 = (double)center.Y + num3 * Math.Sin(num2) + num4 * Math.Cos(num2);
		return new Point((int)num5, (int)num6);
	}

	public static bool IsPointInPolygon4(PointF[] polygon, PointF testPoint)
	{
		bool flag = false;
		int num = polygon.Count() - 1;
		for (int i = 0; i < polygon.Count(); i++)
		{
			if (((polygon[i].Y < testPoint.Y && polygon[num].Y >= testPoint.Y) || (polygon[num].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)) && polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[num].Y - polygon[i].Y) * (polygon[num].X - polygon[i].X) < testPoint.X)
			{
				flag = !flag;
			}
			num = i;
		}
		return flag;
	}

	public static void MoveListViewItems(ListView sender, MoveDirection direction)
	{
		if (sender.SelectedItems.Count <= 0 || ((direction != MoveDirection.Down || sender.SelectedItems[sender.SelectedItems.Count - 1].Index >= sender.Items.Count - 1) && (direction != MoveDirection.Up || sender.SelectedItems[0].Index <= 0)))
		{
			return;
		}
		foreach (ListViewItem selectedItem in sender.SelectedItems)
		{
			int index = (int)(selectedItem.Index + direction);
			sender.Items.RemoveAt(selectedItem.Index);
			sender.Items.Insert(index, selectedItem);
		}
	}

	public static void ToggleSwitchLanguageChange(Form frm)
	{
		List<Control> list = FilterControls(frm, (Control c) => c.GetType().ToString() == "Telerik.WinControls.UI.RadToggleSwitch").ToList();
		if (list.Count <= 0)
		{
			return;
		}
		list.ForEach(delegate(Control x)
		{
			RadToggleSwitch radToggleSwitch = (RadToggleSwitch)x;
			if (radToggleSwitch.OnText == "YES")
			{
				radToggleSwitch.OnText = Resources.YES;
				radToggleSwitch.OffText = Resources.NO;
			}
			else if (radToggleSwitch.OnText == "ON")
			{
				radToggleSwitch.OnText = Resources.ON;
				radToggleSwitch.OffText = Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "MONDAY ON")
			{
				radToggleSwitch.OnText = Resources.Monday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Monday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "TUESDAY ON")
			{
				radToggleSwitch.OnText = Resources.Tuesday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Tuesday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "WEDNESDAY ON")
			{
				radToggleSwitch.OnText = Resources.Wednesday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Wednesday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "THURSDAY ON")
			{
				radToggleSwitch.OnText = Resources.Thursday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Thursday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "FRIDAY ON")
			{
				radToggleSwitch.OnText = Resources.Friday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Friday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "SATURDAY ON")
			{
				radToggleSwitch.OnText = Resources.Saturday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Saturday.ToUpper() + " " + Resources.OFF;
			}
			else if (radToggleSwitch.OnText == "SUNDAY ON")
			{
				radToggleSwitch.OnText = Resources.Sunday.ToUpper() + " " + Resources.ON;
				radToggleSwitch.OffText = Resources.Sunday.ToUpper() + " " + Resources.OFF;
			}
		});
	}

	public static Control[] FilterControls(Control start, Func<Control, bool> isMatch)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.isMatch = isMatch;
		_003C_003Ec__DisplayClass10_.matches = new List<Control>();
		_003C_003Ec__DisplayClass10_.filter = null;
		(_003C_003Ec__DisplayClass10_.filter = delegate(Control c)
		{
			if (_003C_003Ec__DisplayClass10_.isMatch(c))
			{
				_003C_003Ec__DisplayClass10_.matches.Add(c);
			}
			foreach (Control control in c.Controls)
			{
				_003C_003Ec__DisplayClass10_.filter(control);
			}
		})(start);
		return _003C_003Ec__DisplayClass10_.matches.ToArray();
	}

	public static void ClearControlsInPanel(Panel pnl)
	{
		if (pnl.Controls.Count <= 0)
		{
			return;
		}
		List<Control> list = new List<Control>();
		foreach (Control control in pnl.Controls)
		{
			list.Add(control);
		}
		pnl.Controls.Clear();
		foreach (Control item in list)
		{
			if (item is ListView)
			{
				foreach (ColumnHeader column in (item as ListView).Columns)
				{
					column.Dispose();
				}
			}
			if (item is Panel)
			{
				ClearControlsInPanel((Panel)item);
			}
			if (item is Form)
			{
				ClearControlsInForm((Form)item);
			}
			item.Dispose();
		}
	}

	public static void ClearControlsInForm(Form frm)
	{
		if (frm.Controls.Count <= 0)
		{
			return;
		}
		List<Control> list = new List<Control>();
		foreach (Control control in frm.Controls)
		{
			list.Add(control);
		}
		frm.Controls.Clear();
		foreach (Control item in list)
		{
			if (item is ListView)
			{
				foreach (ColumnHeader column in (item as ListView).Columns)
				{
					column.Dispose();
				}
			}
			if (item is Panel)
			{
				ClearControlsInPanel((Panel)item);
			}
			item.Dispose();
		}
	}

	public static void ClearControlsInControl(Control control)
	{
		if (control.Controls.Count <= 0)
		{
			return;
		}
		List<Control> list = new List<Control>();
		foreach (Control control2 in control.Controls)
		{
			list.Add(control2);
		}
		control.Controls.Clear();
		foreach (Control item in list)
		{
			if (item is ListView)
			{
				foreach (ColumnHeader column in (item as ListView).Columns)
				{
					column.Dispose();
				}
			}
			else if (item is Panel)
			{
				ClearControlsInPanel((Panel)item);
			}
			else if (item is Form)
			{
				ClearControlsInForm((Form)item);
			}
			else if (item is CustomListViewTelerik)
			{
				foreach (ListViewDetailColumn column2 in (item as CustomListViewTelerik).Columns)
				{
					column2.Dispose();
				}
			}
			item.Dispose();
		}
	}

	public static void ShowNowServingScreen()
	{
		if ((frmStationServingScreen)Application.OpenForms["frmStationServingScreen"] != null)
		{
			return;
		}
		bool flag = false;
		Rectangle rectangle = default(Rectangle);
		if (AppSettings.ScreenCount == 1)
		{
			if (new frmMessageBox("Are you sure you want to display \"Now Serving\" on the main screen?", "", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				flag = true;
				rectangle = AppSettings.MainScreen.Bounds;
			}
		}
		else if (AppSettings.ScreenCount == 2)
		{
			flag = true;
			rectangle = AppSettings.SecondaryScreen.Bounds;
		}
		else
		{
			flag = true;
			rectangle = AppSettings.ThirdScreen.Bounds;
		}
		if (flag)
		{
			frmStationServingScreen obj = new frmStationServingScreen();
			obj.WindowState = FormWindowState.Normal;
			obj.TopMost = true;
			obj.Size = new Size(rectangle.Width, rectangle.Height);
			obj.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			obj.StartPosition = FormStartPosition.Manual;
			obj.Show();
			((frmSplash)Application.OpenForms["frmSplash"])?.ChangeNowServingText("CLOSE NOW SERVING");
		}
	}

	public static void CloseNowServingScreen()
	{
		frmStationServingScreen frmStationServingScreen2 = null;
		frmStationServingScreen2 = (frmStationServingScreen)Application.OpenForms["frmStationServingScreen"];
		if (frmStationServingScreen2 != null)
		{
			frmStationServingScreen2.Close();
			frmStationServingScreen2.Dispose();
			GC.Collect();
		}
		((frmSplash)Application.OpenForms["frmSplash"])?.ChangeNowServingText(Resources.NOW_SERVING);
	}
}
