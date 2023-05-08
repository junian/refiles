using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmEditLayout : frmMasterForm
{
	private Control control_0;

	private Point point_0;

	private Point point_1;

	private float float_0;

	private float float_1;

	private short short_0;

	private List<string> list_2;

	private GClass6 gclass6_0;

	private List<Layout> list_3;

	private Layout layout_0;

	private TransparentLabel Selector;

	private int int_0;

	private List<Layout> list_4;

	private int int_1;

	[CompilerGenerated]
	private string string_0;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private int int_4;

	private Label label_0;

	private int int_5;

	private IContainer icontainer_1;

	private BufferedPanel pnlLayoutArea;

	internal Button btnCancel;

	internal Button btnAddTable;

	internal Button btnRemoveTable;

	internal Button btnEditTable;

	internal Button button_0;

	internal Button btnRight;

	internal Button btnLeft;

	private Label lblSectionName;

	private Label label10;

	private PictureBox pictureBoxGuest;

	internal Button btnSave;

	internal Button btnSetAsDefault;

	private PictureBox pictureBoxRotate;

	internal Button btnAddPlant;

	internal Button btnAddChair;

	internal Button btnAddBench;

	private PictureBox plantImage;

	private PictureBox benchImage;

	private PictureBox chairImage;

	private PictureBox pictureBox_0;

	internal Button btnGrid;

	private Label lblTraining;

	private PictureBox pbZoomOut;

	private PictureBox pbZoomIn;

	internal Button iSvAtFahAx;

	public string returnTableName
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

	public frmEditLayout(int _appointmentId = 0, int fromAdmin = 0)
	{
		Class26.Ggkj0JxzN9YmC();
		float_0 = (float)Screen.PrimaryScreen.Bounds.Width / 1400f;
		float_1 = (float)Screen.PrimaryScreen.Bounds.Height / 900f;
		list_2 = new List<string>();
		gclass6_0 = new GClass6();
		list_3 = new List<Layout>();
		layout_0 = new Layout();
		Selector = new TransparentLabel(TransparentLabelType.Rotated, 5, 51);
		int_0 = 1;
		list_4 = new List<Layout>();
		int_5 = 5;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			btnGrid.Font = new Font(btnGrid.Font.FontFamily, btnGrid.Font.Size - 1.25f);
		}
		int_2 = _appointmentId;
		list_2 = new List<string>();
		list_3 = gclass6_0.Layouts.ToList();
		int_3 = fromAdmin;
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Visible = true;
		}
		else
		{
			lblTraining.Visible = false;
		}
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	private void frmEditLayout_Load(object sender, EventArgs e)
	{
		Terminal this_terminal = MemoryLoadedObjects.this_terminal;
		if (this_terminal != null)
		{
			int_5 = (this_terminal.LayoutZoomValue.HasValue ? this_terminal.LayoutZoomValue.Value : 5);
		}
		btnSave.Enabled = false;
		if (int_2 != 0)
		{
			button_0.Visible = false;
			btnAddTable.Visible = false;
			btnEditTable.Visible = false;
			btnRemoveTable.Visible = false;
			btnSave.Visible = false;
			label10.Text = Resources.Select_a_Table_for_Reservation;
		}
		if (Screen.PrimaryScreen.Bounds.Width <= 1280)
		{
			base.WindowState = FormWindowState.Maximized;
		}
		pnlLayoutArea.Scroll += pnlLayoutArea_Scroll;
		method_4();
	}

	private void method_3()
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.terminal = MemoryLoadedObjects.this_terminal;
		if (CS_0024_003C_003E8__locals0.terminal == null || string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.terminal.DefaultLayoutSectionName))
		{
			return;
		}
		int num = list_2.FindIndex((string a) => a == CS_0024_003C_003E8__locals0.terminal.DefaultLayoutSectionName);
		if (num != -1)
		{
			short_0 = (short)num;
			if (short_0 == 0)
			{
				btnLeft.Enabled = false;
				btnRight.Enabled = true;
			}
			else if (short_0 > 0)
			{
				btnLeft.Enabled = true;
				btnRight.Enabled = true;
			}
			if (short_0 == list_2.Count - 1)
			{
				btnRight.Enabled = false;
			}
			else
			{
				btnRight.Enabled = true;
			}
		}
		else if (list_2.Count > 1)
		{
			btnRight.Enabled = true;
		}
		else
		{
			btnRight.Enabled = false;
		}
	}

	private void method_4()
	{
		method_6();
		method_3();
		method_5();
		if (list_3.Count() != 0)
		{
			int_1 = list_3.Max((Layout l) => l.TableID) + 1;
		}
		else
		{
			int_1++;
		}
	}

	private void method_5()
	{
		if (list_2.Count() != 0)
		{
			lblSectionName.Text = list_2[short_0];
		}
		method_7();
	}

	private void method_6()
	{
		list_2 = (from l in list_3
			orderby l.Section
			select l.Section).Distinct().ToList();
		if (list_2.Count > 1)
		{
			btnRight.Enabled = true;
		}
	}

	private void method_7()
	{
		pnlLayoutArea.Invalidate();
		pnlLayoutArea.Controls.Clear();
		btnEditTable.Enabled = false;
		btnRemoveTable.Enabled = false;
		method_8();
	}

	private void method_8()
	{
		Selector = new TransparentLabel(TransparentLabelType.Rotated, 5, 51);
		Selector.Name = "Selector";
		Selector.Tag = "Active;";
		Selector.BackColor = Color.White;
		Selector.FlatStyle = FlatStyle.Flat;
		Selector.transparentBackColor = Color.White;
		Selector.textAlign = StringAlignment.Center;
		Selector.Font = new Font("Arial", 14f, FontStyle.Regular);
		Selector.Location = new Point(pnlLayoutArea.Width / 2, pnlLayoutArea.Height / 2);
		Selector.Click += Selector_Click;
		Selector.MouseDown += Selector_MouseDown;
		Selector.MouseMove += Selector_MouseMove;
		Selector.MouseUp += Selector_MouseUp;
		Selector.Size = new Size(500, 500);
		pnlLayoutArea.Controls.Add(Selector);
		TransparentLabel transparentLabel = new TransparentLabel(TransparentLabelType.Round);
		transparentLabel.Name = "Rotator";
		transparentLabel.Size = new Size(30, 30);
		transparentLabel.transparentBackColor = Color.FromArgb(35, 39, 56);
		Point point = ControlHelpers.GetRotatedRectangleCoords(center: new Point(Selector.Width / 2, Selector.Height / 2), num: 1, angleDegrees: Selector.angle, width: Selector.ySize, height: Selector.xSize);
		transparentLabel.Location = new Point(point.X - transparentLabel.Width / 2, point.Y - transparentLabel.Height / 2);
		Selector.Controls.Add(transparentLabel);
		PictureBox pictureBox = base.Controls.Find("pictureBoxRotate", searchAllChildren: true).FirstOrDefault() as PictureBox;
		PictureBox pictureBox2 = new PictureBox();
		pictureBox2.Image = pictureBox.Image;
		pictureBox2.BackColor = Color.Transparent;
		pictureBox2.SizeMode = pictureBox.SizeMode;
		pictureBox2.Size = new Size(transparentLabel.Height, transparentLabel.Height);
		pictureBox2.Left = transparentLabel.Width - transparentLabel.Height - 2;
		pictureBox2.MouseDown += method_14;
		pictureBox2.MouseMove += method_15;
		pictureBox2.MouseUp += method_16;
		transparentLabel.Controls.Add(pictureBox2);
		Selector.Visible = false;
	}

	private void pnlLayoutArea_Paint(object sender, PaintEventArgs e)
	{
		if (!bool_0)
		{
			GraphicHelpers.DrawEditLayout(e, list_3, lblSectionName.Text, pictureBoxGuest.Image, plantImage.Image, benchImage.Image, chairImage.Image, int_5, new Point(pnlLayoutArea.HorizontalScroll.Value, pnlLayoutArea.VerticalScroll.Value));
		}
	}

	private void pnlLayoutArea_Scroll(object sender, ScrollEventArgs e)
	{
		pnlLayoutArea.Invalidate();
	}

	private void method_9(Layout layout_1, int int_6, int int_7, int int_8, double double_0)
	{
		int_6 = (int)((double)int_6 * double_0);
		int_7 = (int)((double)int_7 * double_0);
		Selector.Name = layout_1.TableName;
		Selector.Text = "";
		Selector.angle = layout_1.AngleOfRotation;
		Selector.flagType = int_8;
		Selector.Location = new Point((int)((double)Convert.ToInt16(layout_1.X) * double_0), (int)((double)Convert.ToInt16(layout_1.Y) * double_0));
		Selector.TabIndex = 0;
		switch (int_8)
		{
		case 3:
			Selector.ySize = 21;
			break;
		case 4:
			Selector.ySize = 31;
			break;
		default:
			Selector.ySize = 21;
			break;
		}
		Selector.ForeColor = Color.Black;
		Selector.Size = new Size((int_6 > int_7) ? int_6 : int_7, (int_6 > int_7) ? int_6 : int_7);
		Selector.Tag = ((Selector.Tag.ToString().Split(';')[0] == "Active") ? "Active;selected" : "nonActive;selected");
		TransparentLabel transparentLabel = (TransparentLabel)Selector.Controls.Find(Resources.Rotator, searchAllChildren: true).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.Visible = true;
			Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, Selector.angle, new Point(Selector.Width / 2, Selector.Height / 2), Selector.ySize, Selector.xSize);
			transparentLabel.Location = new Point(rotatedRectangleCoords.X - transparentLabel.Width / 2, rotatedRectangleCoords.Y - transparentLabel.Height / 2);
		}
	}

	private void method_10(Layout layout_1, Point point_2, double double_0 = 1.0)
	{
		Selector.Name = layout_1.TableName;
		Selector.Text = "";
		Selector.angle = ((layout_1.Rotation == 'B') ? 90 : layout_1.AngleOfRotation);
		Selector.xSize = (int)(5.0 * double_0);
		Selector.ySize = (int)((double)(layout_1.NumOfSeats.Value / 2) * double_0);
		Selector.flagType = 1;
		Selector.transparentBackColor = Color.FromArgb(1, 110, 211);
		Selector.ForeColor = Color.White;
		Selector.Size = new Size(500, 500);
		Selector.Location = new Point(point_2.X - 250, point_2.Y - 250);
		Selector.BorderStyle = BorderStyle.None;
		Selector.Tag = ((Selector.Tag.ToString().Split(';')[0] == "Active") ? "Active;selected" : "nonActive;selected");
		TransparentLabel transparentLabel = (TransparentLabel)Selector.Controls.Find("Rotator", searchAllChildren: true).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.Visible = true;
			Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, Selector.angle, new Point(250, 250), Selector.ySize, Selector.xSize);
			transparentLabel.Location = new Point(rotatedRectangleCoords.X - transparentLabel.Width / 2, rotatedRectangleCoords.Y - transparentLabel.Height / 2);
		}
	}

	private void method_11(Layout layout_1, Size size_0, int int_6, int int_7, bool bool_1, double double_0)
	{
		Selector.Name = layout_1.TableName;
		Selector.Text = layout_1.TableName;
		Selector.angle = ((!bool_1) ? layout_1.AngleOfRotation : 0);
		Selector.xSize = ((!bool_1) ? int_6 : 0);
		Selector.ySize = ((!bool_1) ? int_7 : 0);
		Selector.flagType = ((!bool_1) ? 1 : 2);
		Selector.transparentBackColor = Color.FromArgb(1, 110, 211);
		Selector.ForeColor = Color.White;
		if (bool_1)
		{
			Selector.Size = new Size(size_0.Width, size_0.Height);
			Selector.Location = new Point((int)((double)layout_1.X.Value * double_0), (int)((double)layout_1.Y.Value * double_0));
		}
		else
		{
			Selector.Size = new Size(size_0.Width + 30, size_0.Height + 30);
			Selector.Location = new Point((int)((double)layout_1.X.Value * double_0) - 15, (int)((double)layout_1.Y.Value * double_0) - 15);
		}
		Selector.BorderStyle = BorderStyle.None;
		Selector.Tag = ((Selector.Tag.ToString().Split(';')[0] == "Active") ? "Active;selected" : "nonActive;selected");
		TransparentLabel transparentLabel = (TransparentLabel)Selector.Controls.Find("Rotator", searchAllChildren: true).FirstOrDefault();
		if (transparentLabel != null)
		{
			if (!bool_1)
			{
				transparentLabel.Visible = true;
				Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, Selector.angle, new Point(Selector.Width / 2, Selector.Height / 2), Selector.ySize, Selector.xSize);
				transparentLabel.Location = new Point(rotatedRectangleCoords.X - transparentLabel.Width / 2, rotatedRectangleCoords.Y - transparentLabel.Height / 2);
			}
			else
			{
				transparentLabel.Visible = false;
			}
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		btnSave.Enabled = true;
		int_0 = 0;
		method_12('A');
	}

	private void method_12(char char_0)
	{
		Point point_ = new Point(40, 5);
		Layout layout = new Layout
		{
			TableName = "wall " + int_1,
			Rotation = 'A',
			Section = lblSectionName.Text,
			AngleOfRotation = 0,
			NumOfSeats = 80,
			X = point_.X - 40,
			Y = point_.Y - 5,
			Active = true
		};
		list_4.Add(layout);
		int_1++;
		list_3.Add(layout);
		method_10(layout, point_);
		Selector.Visible = true;
	}

	private void btnAddTable_Click(object sender, EventArgs e)
	{
		TransparentLabel transparentLabel = new TransparentLabel();
		transparentLabel.Text = Resources.New_Table;
		transparentLabel.Font = new Font("Arial", 14f, FontStyle.Regular);
		transparentLabel.Tag = "Active;";
		transparentLabel.TransparentBackColor = Color.White;
		transparentLabel.FlatStyle = FlatStyle.Flat;
		transparentLabel.Location = new Point(0, 0);
		transparentLabel.TabIndex = 0;
		transparentLabel.ForeColor = Color.Black;
		transparentLabel.Size = new Size(80, 60);
		SizeF factor = new SizeF(float_0, float_1);
		transparentLabel.Scale(factor);
		transparentLabel.MouseDown += Selector_MouseDown;
		transparentLabel.MouseMove += Selector_MouseMove;
		transparentLabel.MouseUp += Selector_MouseUp;
		pnlLayoutArea.Controls.Add(transparentLabel);
		transparentLabel.BringToFront();
		Selector_Click(transparentLabel, EventArgs.Empty);
		btnEditTable_Click(transparentLabel, EventArgs.Empty);
		int_0 = 0;
		btnSave.Enabled = true;
	}

	private void btnEditTable_Click(object sender, EventArgs e)
	{
		foreach (Control control in pnlLayoutArea.Controls)
		{
			if (!(control.Tag.ToString().Split(';')[1] == "selected"))
			{
				continue;
			}
			if (gclass6_0.Layouts.Where((Layout a) => a.Section == lblSectionName.Text).FirstOrDefault() == null)
			{
				method_13();
			}
			TransparentLabel transparentLabel = (TransparentLabel)control;
			frmEditLayoutTableEdit frmEditLayoutTableEdit2 = ((transparentLabel.Text == Resources.New_Table) ? new frmEditLayoutTableEdit(transparentLabel, list_3, Resources.NEW_TABLE0) : new frmEditLayoutTableEdit(transparentLabel, list_3));
			if (frmEditLayoutTableEdit2.ShowDialog(this) == DialogResult.OK)
			{
				Layout addedTable = frmEditLayoutTableEdit2.AddedTable;
				if (addedTable != null)
				{
					list_4.Add(addedTable);
					list_3.Add(addedTable);
				}
				method_6();
				method_7();
				int_0 = 0;
				btnSave.Enabled = true;
				method_20(frmEditLayoutTableEdit2.NewTableName);
			}
			else if (transparentLabel.Text == Resources.New_Table)
			{
				pnlLayoutArea.Controls.Remove(transparentLabel);
			}
			break;
		}
	}

	private void btnRemoveTable_Click(object sender, EventArgs e)
	{
		IEnumerator enumerator = pnlLayoutArea.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
				CS_0024_003C_003E8__locals0.control = (Control)enumerator.Current;
				if (!(CS_0024_003C_003E8__locals0.control.Tag.ToString().Split(';')[1] == "selected"))
				{
					continue;
				}
				OccupiedTable occupiedTable = (from a in new OrderMethods().OccupiedTables().ToList()
					where a.TableName == CS_0024_003C_003E8__locals0.control.Name.Replace("\n", string.Empty)
					select a).FirstOrDefault();
				Layout layout = list_3.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.control.Name.Replace("\n", string.Empty)).FirstOrDefault();
				if (occupiedTable == null && layout.CurrentGuests == 0)
				{
					Layout layout2 = gclass6_0.Layouts.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.control.Name.Replace("\n", string.Empty)).FirstOrDefault();
					if (layout2 != null)
					{
						string text = CS_0024_003C_003E8__locals0.control.Name.ToLower();
						if (!text.Contains(TransparentLabelType.Wall) && !text.Contains(TransparentLabelType.Chair) && !text.Contains(TransparentLabelType.Bench) && !text.Contains(TransparentLabelType.Plant))
						{
							if (new frmMessageBox(Resources.Are_you_sure_you_want_to_remov1, Resources._Remove, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
							{
								gclass6_0.Layouts.DeleteOnSubmit(layout2);
								list_3.Remove(layout2);
							}
						}
						else
						{
							gclass6_0.Layouts.DeleteOnSubmit(layout2);
							list_3.Remove(layout2);
						}
					}
					else
					{
						Layout layout3 = list_3.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.control.Name.Replace("\n", string.Empty)).FirstOrDefault();
						if (layout3 != null)
						{
							list_3.Remove(layout3);
						}
						Layout layout4 = list_4.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.control.Name.Replace("\n", string.Empty)).FirstOrDefault();
						if (layout4 != null)
						{
							list_4.Remove(layout4);
						}
					}
					method_7();
					int_0 = 0;
					btnSave.Enabled = true;
				}
				else
				{
					new frmMessageBox(Resources.Table_cannot_be_removed_Table_, Resources.Remove_Error).ShowDialog(this);
				}
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public void btnCancel_Click(object sender, EventArgs e)
	{
		if (int_2 != 0)
		{
			base.DialogResult = DialogResult.Cancel;
			return;
		}
		if (int_0 == 0 && new frmMessageBox(Resources.Are_you_sure_you_want_to_quit_, Resources.Changes_Not_Saved, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			Close();
			if (int_3 != 1)
			{
				Selector.Dispose();
				pnlLayoutArea.Dispose();
				Dispose(disposing: true);
			}
			base.DialogResult = DialogResult.Cancel;
		}
		if (int_0 == 1)
		{
			Close();
			if (int_3 != 1)
			{
				Selector.Dispose();
				pnlLayoutArea.Dispose();
				Dispose(disposing: true);
			}
			base.DialogResult = DialogResult.Cancel;
		}
	}

	private void btnRight_Click(object sender, EventArgs e)
	{
		if (short_0 < list_2.Count - 1)
		{
			short_0++;
			method_5();
			if (short_0 == 0)
			{
				btnLeft.Enabled = false;
			}
			else
			{
				btnLeft.Enabled = true;
			}
			if (short_0 == list_2.Count - 1)
			{
				btnRight.Enabled = false;
			}
			else
			{
				btnRight.Enabled = true;
			}
		}
	}

	private void btnLeft_Click(object sender, EventArgs e)
	{
		if (short_0 > 0)
		{
			short_0--;
			method_5();
			if (short_0 == 0)
			{
				btnLeft.Enabled = false;
			}
			else
			{
				btnLeft.Enabled = true;
			}
			if (short_0 == list_2.Count - 1)
			{
				btnRight.Enabled = false;
			}
			else
			{
				btnRight.Enabled = true;
			}
		}
	}

	private void btnLeft_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.BackColor = Color.Gray;
		}
		else
		{
			button.BackColor = Color.FromArgb(61, 142, 185);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_13()
	{
		try
		{
			Helper.SubmitChangesWithCatch(gclass6_0);
			foreach (Layout item in list_4)
			{
				gclass6_0.Layouts.InsertOnSubmit(item);
				Helper.SubmitChangesWithCatch(gclass6_0);
			}
			list_4.Clear();
			int_0 = 1;
			new NotificationLabel(this, Resources.Changes_successfully_saved, NotificationTypes.Success).Show();
			btnSave.Enabled = false;
		}
		catch (Exception ex)
		{
			new NotificationLabel(this, Resources.Something_went_wrong_We_were_u, NotificationTypes.Warning).Show();
			NotificationMethods.sendCrashStringOnly(AppSettings.AppVersion, "", ex.Message);
		}
	}

	private void btnSetAsDefault_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_set + lblSectionName.Text + Resources._as_the_default_section_layout, Resources.Default_Layout, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			Terminal terminal = gClass.Terminals.Where((Terminal o) => o.SystemName.ToUpper() == Environment.MachineName.ToUpper()).FirstOrDefault();
			if (terminal != null)
			{
				terminal.DefaultLayoutSectionName = lblSectionName.Text;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
	}

	private void btnGrid_Click(object sender, EventArgs e)
	{
		if (int_4 == 0)
		{
			pnlLayoutArea.BackgroundImage = pictureBox_0.Image;
			int_4 = 1;
		}
		else
		{
			pnlLayoutArea.BackgroundImage = null;
			int_4 = 0;
		}
	}

	private void method_14(object sender, MouseEventArgs e)
	{
		bool_0 = false;
		PictureBox pictureBox = (PictureBox)sender;
		control_0 = pictureBox.Parent;
		Cursor = Cursors.Hand;
		point_1 = new Point(control_0.Parent.Width / 2, control_0.Parent.Height / 2);
		Layout layout = list_3.Where((Layout layout_1) => layout_1.TableName == control_0.Parent.Name.Replace("\n", string.Empty)).FirstOrDefault();
		if (layout != null)
		{
			layout_0 = layout;
			list_3.Remove(layout);
		}
		control_0.BackColor = Color.Transparent;
		int_0 = 0;
		btnSave.Enabled = true;
	}

	private void method_15(object sender, MouseEventArgs e)
	{
		PictureBox pictureBox = (PictureBox)sender;
		if (control_0 == null || control_0 != pictureBox.Parent)
		{
			return;
		}
		if (label_0 == null)
		{
			bool_0 = true;
			label_0 = new Label();
			method_18(pnlLayoutArea);
			Selector.BringToFront();
		}
		TransparentLabel transparentLabel = (TransparentLabel)pictureBox.Parent;
		TransparentLabel transparentLabel2 = (TransparentLabel)transparentLabel.Parent;
		Point point = transparentLabel2.PointToClient(Cursor.Position);
		if (transparentLabel2.Name.Contains(TransparentLabelType.Wall))
		{
			transparentLabel2.angle = (int)(ControlHelpers.GetAngleByLocationWithCenter(point_1, point) - 75.0) + 90;
			int num = (int)(ControlHelpers.GetDistanceBetween2Points(point, point_1) * 2.0) - 30;
			if (num > 50 && num < 220)
			{
				transparentLabel2.ySize = num;
			}
			else if (num <= 50)
			{
				transparentLabel2.ySize = 51;
			}
			else
			{
				transparentLabel2.ySize = 219;
			}
		}
		else
		{
			transparentLabel2.angle = (int)(ControlHelpers.GetAngleByLocationWithCenter(point_1, point) - 40.0) % 360;
		}
		bool_0 = true;
		transparentLabel2.Invalidate();
		Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, transparentLabel2.angle, point_1, transparentLabel2.ySize, transparentLabel2.xSize);
		transparentLabel.Location = new Point(rotatedRectangleCoords.X - transparentLabel.Width / 2, rotatedRectangleCoords.Y - transparentLabel.Height / 2);
	}

	private void method_16(object sender, MouseEventArgs e)
	{
		TransparentLabel transparentLabel = (TransparentLabel)((PictureBox)sender).Parent;
		TransparentLabel transparentLabel2 = (TransparentLabel)transparentLabel.Parent;
		Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, transparentLabel2.angle, point_1, transparentLabel2.ySize, transparentLabel2.xSize);
		transparentLabel.Location = new Point(rotatedRectangleCoords.X - transparentLabel.Width / 2, rotatedRectangleCoords.Y - transparentLabel.Height / 2);
		if (layout_0 != null)
		{
			layout_0.AngleOfRotation = transparentLabel2.angle;
			list_3.Add(layout_0);
		}
		layout_0 = null;
		pnlLayoutArea.Controls.Remove(label_0);
		label_0 = null;
		bool_0 = false;
		control_0 = null;
		Cursor = Cursors.Default;
	}

	private void method_17(Layout layout_1)
	{
		if (layout_1.CurrentGuests <= 0 && !layout_1.AppointmentID.HasValue)
		{
			returnTableName = layout_1.TableName;
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			new frmMessageBox(Resources.Table_is_already_occupied_plea, Resources.Table_Occupied).ShowDialog(this);
			base.DialogResult = DialogResult.None;
		}
	}

	private void Selector_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (sender is TransparentLabel)
		{
			TransparentLabel transparentLabel = (TransparentLabel)sender;
			Point point = transparentLabel.PointToClient(Cursor.Position);
			Point center = new Point(transparentLabel.Width / 2, transparentLabel.Height / 2);
			Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, transparentLabel.angle, center, transparentLabel.ySize, transparentLabel.xSize);
			Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, transparentLabel.angle, center, transparentLabel.ySize, transparentLabel.xSize);
			Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, transparentLabel.angle, center, transparentLabel.ySize, transparentLabel.xSize);
			Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, transparentLabel.angle, center, transparentLabel.ySize, transparentLabel.xSize);
			if (!ControlHelpers.IsPointInPolygon4(new PointF[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 }, point))
			{
				Selector.Visible = false;
				pnlLayoutArea_MouseClick(pnlLayoutArea, null);
			}
			transparentLabel.BringToFront();
			foreach (Control control3 in pnlLayoutArea.Controls)
			{
				control3.Tag = ((control3.Tag.ToString().Split(';')[0] == "Active") ? "Active;" : "nonActive;");
				control3.ForeColor = Color.Black;
			}
			foreach (TransparentLabel item in (from c in pnlLayoutArea.Controls.OfType<TransparentLabel>()
				where c.TransparentBackColor == Color.SteelBlue
				select c).ToList())
			{
				item.transparentBackColor = ((item.Tag.ToString().Split(';')[0] == "Active") ? Color.White : Color.Gray);
				item.transparentBackColor = ((GuestMethods.GetCurrentTableGuestCapacity(transparentLabel.Name) > 0) ? ColorPalette.PictonBlue : transparentLabel.transparentBackColor);
			}
			transparentLabel.Tag = ((transparentLabel.Tag.ToString().Split(';')[0] == "Active") ? "Active;selected" : "nonActive;selected");
			transparentLabel.transparentBackColor = Color.FromArgb(1, 110, 211);
			transparentLabel.ForeColor = Color.White;
			if (!transparentLabel.Name.Contains(TransparentLabelType.Wall) && !transparentLabel.Name.Contains(TransparentLabelType.Plant) && !transparentLabel.Name.Contains(TransparentLabelType.Bench) && !transparentLabel.Name.Contains(TransparentLabelType.Chair))
			{
				btnEditTable.Enabled = true;
			}
			else
			{
				btnEditTable.Enabled = false;
			}
			btnRemoveTable.Enabled = true;
			return;
		}
		Button button = (Button)sender;
		foreach (Control control4 in pnlLayoutArea.Controls)
		{
			control4.Tag = ((control4.Tag.ToString().Split(';')[0] == "Active") ? "Active;" : "nonActive;");
			control4.BackColor = ((control4.Tag.ToString().Split(';')[0] == "Active") ? Color.White : Color.Gray);
			control4.ForeColor = Color.Black;
		}
		button.Tag = ((button.Tag.ToString().Split(';')[0] == "Active") ? "Active;selected" : "nonActive;selected");
		button.BackColor = Color.SteelBlue;
		button.ForeColor = Color.White;
		if (!button.Name.Contains(TransparentLabelType.Wall))
		{
			btnEditTable.Enabled = true;
		}
		else
		{
			btnEditTable.Enabled = false;
		}
		btnRemoveTable.Enabled = true;
	}

	private void Selector_MouseDown(object sender, MouseEventArgs e)
	{
		bool_0 = false;
		control_0 = sender as Control;
		point_0 = e.Location;
		Layout layout = list_3.Where((Layout layout_1) => layout_1.TableName == control_0.Name.Replace("\n", string.Empty)).FirstOrDefault();
		if (layout != null)
		{
			layout_0 = layout;
			list_3.Remove(layout);
		}
		Cursor = Cursors.Hand;
		int_0 = 0;
		btnSave.Enabled = true;
	}

	private void Selector_MouseMove(object sender, MouseEventArgs e)
	{
		if (control_0 != null && control_0 == sender)
		{
			if (label_0 == null)
			{
				label_0 = new Label();
				method_18(pnlLayoutArea);
				Selector.BringToFront();
			}
			bool_0 = true;
			Point location = control_0.Location;
			int dx = e.Location.X - point_0.X;
			int dy = e.Location.Y - point_0.Y;
			location.Offset(dx, dy);
			if (location.X + control_0.Width / 2 < 0)
			{
				location.X = -(control_0.Width / 2);
			}
			if (location.Y + control_0.Height / 2 < 0)
			{
				location.Y = -(control_0.Height / 2);
			}
			control_0.Location = location;
			int_0 = 0;
			btnSave.Enabled = true;
		}
	}

	private void method_18(Control control_1)
	{
		Bitmap image = new Bitmap(control_1.ClientRectangle.Size.Width, control_1.ClientRectangle.Size.Height);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			GraphicHelpers.DrawEditLayout(new PaintEventArgs(graphics, control_1.ClientRectangle), list_3, lblSectionName.Text, pictureBoxGuest.Image, plantImage.Image, benchImage.Image, chairImage.Image, int_5, new Point(pnlLayoutArea.HorizontalScroll.Value, pnlLayoutArea.VerticalScroll.Value));
		}
		label_0.Size = new Size(control_1.ClientRectangle.Size.Width, control_1.ClientRectangle.Size.Height);
		label_0.Location = new Point(0, 0);
		label_0.Image = image;
		control_1.Controls.Add(label_0);
		label_0.BringToFront();
	}

	private void Selector_MouseUp(object sender, MouseEventArgs e)
	{
		control_0 = null;
		Cursor = Cursors.Default;
		try
		{
			_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass58_0();
			pnlLayoutArea.Controls.Remove(label_0);
			label_0 = null;
			bool_0 = false;
			if (layout_0 != null)
			{
				list_3.Add(layout_0);
			}
			layout_0 = null;
			CS_0024_003C_003E8__locals0.btn = (TransparentLabel)sender;
			double num = (double)int_5 / 5.0 - 0.1 * ((double)int_5 - 5.0);
			Layout layout = list_3.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.btn.Name.Replace("\n", string.Empty)).FirstOrDefault();
			if (layout != null)
			{
				double num2 = (double)CS_0024_003C_003E8__locals0.btn.Location.X / num;
				double num3 = (double)CS_0024_003C_003E8__locals0.btn.Location.Y / num;
				double num4 = (double)CS_0024_003C_003E8__locals0.btn.ySize / num;
				if (layout.TableName.Contains(TransparentLabelType.Wall))
				{
					layout.X = (int)num2 - (int)num4 + (int)(250.0 / num);
					layout.Y = (int)num3 + (int)(250.0 / num);
					layout.NumOfSeats = (int)num4 * 2;
					layout.AngleOfRotation = CS_0024_003C_003E8__locals0.btn.angle;
				}
				else
				{
					if (layout.Round)
					{
						layout.X = (int)num2;
						layout.Y = (int)num3;
					}
					else if (!layout.TableName.Contains(TransparentLabelType.Plant) && !layout.TableName.Contains(TransparentLabelType.Bench) && !layout.TableName.Contains(TransparentLabelType.Chair))
					{
						layout.X = (int)num2 + (int)(15.0 / num);
						layout.Y = (int)num3 + (int)(15.0 / num);
					}
					else
					{
						layout.X = (int)num2;
						layout.Y = (int)num3;
					}
					layout.AngleOfRotation = CS_0024_003C_003E8__locals0.btn.angle;
				}
			}
			layout.Y += pnlLayoutArea.VerticalScroll.Value;
			layout.X += pnlLayoutArea.HorizontalScroll.Value;
			pnlLayoutArea.Invalidate();
		}
		catch
		{
			_003C_003Ec__DisplayClass58_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass58_1();
			CS_0024_003C_003E8__locals1.btn = (Button)sender;
			Layout layout2 = list_3.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals1.btn.Name.Replace("\n", string.Empty)).FirstOrDefault();
			if (layout2 != null)
			{
				layout2.X = CS_0024_003C_003E8__locals1.btn.Location.X;
				layout2.Y = CS_0024_003C_003E8__locals1.btn.Location.Y;
			}
		}
		int_0 = 0;
		btnSave.Enabled = true;
	}

	private void method_19(string string_1, int int_6, int int_7, int int_8)
	{
		Point point = new Point(40, 5);
		Layout layout = new Layout
		{
			TableName = string_1 + " " + int_1,
			Rotation = 'O',
			Section = lblSectionName.Text,
			AngleOfRotation = 0,
			NumOfSeats = 100,
			X = point.X - 40,
			Y = point.Y - 5,
			Active = true
		};
		list_4.Add(layout);
		list_3.Add(layout);
		int_1++;
		method_9(layout, int_6 + 30, int_7 + 30, int_8, 1.0);
		Selector.Visible = true;
		int_0 = 0;
		btnSave.Enabled = true;
	}

	private void btnAddPlant_Click(object sender, EventArgs e)
	{
		method_19(TransparentLabelType.Plant, 42, 44, 3);
	}

	private void btnAddBench_Click(object sender, EventArgs e)
	{
		method_19(TransparentLabelType.Bench, 62, 34, 4);
	}

	private void btnAddChair_Click(object sender, EventArgs e)
	{
		method_19(TransparentLabelType.Chair, 38, 40, 5);
	}

	private void btnSave_EnabledChanged(object sender, EventArgs e)
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

	private void method_20(string string_1)
	{
		double num = (double)int_5 / 5.0 - 0.1 * ((double)int_5 - 5.0);
		foreach (Layout item in list_3.Where((Layout layout_1) => layout_1.Section == lblSectionName.Text))
		{
			if ((item.Rotation != 'H' && item.Rotation != 'V') || !(item.TableName == string_1))
			{
				continue;
			}
			if (!item.Round)
			{
				int num2 = item.NumOfSeats.Value;
				if (num2 <= 2)
				{
					num2++;
				}
				int num3 = (int)(40.0 * num);
				int num4 = (int)((double)(15 * num2) * num);
				_ = item.AngleOfRotation;
				int num5 = Math.Max(num3, num4);
				Size size_ = new Size(num5 * 2 + num5 / 2, num5 * 2 + num5 / 2);
				int num6 = (int)((double)(size_.Width / 2) + (double)item.X.Value * num);
				int num7 = (int)((double)(size_.Height / 2) + (double)item.Y.Value * num);
				new Point(num6, num7);
				if (int_2 != 0)
				{
					method_17(item);
					break;
				}
				method_11(item, size_, num3, num4, bool_1: false, num);
				btnRemoveTable.Enabled = true;
				btnEditTable.Enabled = true;
				Selector.Visible = true;
			}
			else
			{
				int value = item.NumOfSeats.Value;
				int num8 = (int)((double)(60 + value * 4) * num);
				Size size_2 = new Size(num8, num8);
				if (int_2 != 0)
				{
					method_17(item);
					break;
				}
				method_11(item, size_2, num8, num8, bool_1: true, num);
				btnRemoveTable.Enabled = true;
				btnEditTable.Enabled = true;
				Selector.Visible = true;
			}
			break;
		}
	}

	private void pnlLayoutArea_MouseClick(object sender, MouseEventArgs e)
	{
		PointF testPoint = ((Panel)sender).PointToClient(Cursor.Position);
		double num = (double)this.int_5 / 5.0 - 0.1 * ((double)this.int_5 - 5.0);
		foreach (Layout item in list_3.Where((Layout layout_1) => layout_1.Section == lblSectionName.Text).ToList())
		{
			if ((item.Rotation == 'A' || item.Rotation == 'B') && this.int_2 == 0)
			{
				int num2 = ((item.Rotation == 'B') ? item.X.Value : (item.NumOfSeats.Value / 2 + item.X.Value));
				int num3 = ((item.Rotation == 'B') ? (item.NumOfSeats.Value / 2 + item.Y.Value) : item.Y.Value);
				int angleDegrees = ((item.Rotation == 'B') ? 90 : item.AngleOfRotation);
				Point point = new Point((int)((double)num2 * num), (int)((double)num3 * num));
				int num4 = (int)((double)(item.NumOfSeats.Value / 2) * num);
				int num5 = (((int)(5.0 * num) == 0) ? 1 : ((int)(5.0 * num)));
				Point rotatedRectangleCoords = ControlHelpers.GetRotatedRectangleCoords(1, angleDegrees, point, num4, num5);
				Point rotatedRectangleCoords2 = ControlHelpers.GetRotatedRectangleCoords(2, angleDegrees, point, num4, num5);
				Point rotatedRectangleCoords3 = ControlHelpers.GetRotatedRectangleCoords(3, angleDegrees, point, num4, num5);
				Point rotatedRectangleCoords4 = ControlHelpers.GetRotatedRectangleCoords(4, angleDegrees, point, num4, num5);
				if (ControlHelpers.IsPointInPolygon4(new PointF[4] { rotatedRectangleCoords, rotatedRectangleCoords2, rotatedRectangleCoords3, rotatedRectangleCoords4 }, testPoint))
				{
					method_10(item, point, num);
					Selector.Visible = true;
					btnRemoveTable.Enabled = true;
					btnEditTable.Enabled = false;
					return;
				}
				continue;
			}
			if (item.Rotation != 'H' && item.Rotation != 'V')
			{
				if (item.Rotation != 'O')
				{
					continue;
				}
				if (item.TableName.Contains(TransparentLabelType.Plant))
				{
					int int_ = 72;
					int int_2 = 74;
					Point point2 = new Point((int)((double)item.X.Value * num), (int)((double)item.Y.Value * num));
					Point point3 = new Point((int)((double)(item.X.Value + 72) * num), (int)((double)item.Y.Value * num));
					Point point4 = new Point((int)((double)(item.X.Value + 72) * num), (int)((double)(item.Y.Value + 74) * num));
					Point point5 = new Point((int)((double)item.X.Value * num), (int)((double)(item.Y.Value + 74) * num));
					if (ControlHelpers.IsPointInPolygon4(new PointF[4] { point2, point3, point4, point5 }, testPoint))
					{
						method_9(item, int_, int_2, 3, num);
						btnRemoveTable.Enabled = true;
						btnEditTable.Enabled = false;
						Selector.Visible = true;
						return;
					}
				}
				else if (item.TableName.Contains(TransparentLabelType.Bench))
				{
					int int_3 = 92;
					int int_4 = 64;
					Point point6 = new Point((int)((double)item.X.Value * num), (int)((double)item.Y.Value * num));
					Point point7 = new Point((int)((double)(item.X.Value + 92) * num), (int)((double)item.Y.Value * num));
					Point point8 = new Point((int)((double)(item.X.Value + 92) * num), (int)((double)(item.Y.Value + 64) * num));
					Point point9 = new Point((int)((double)item.X.Value * num), (int)((double)(item.Y.Value + 64) * num));
					if (ControlHelpers.IsPointInPolygon4(new PointF[4] { point6, point7, point8, point9 }, testPoint))
					{
						method_9(item, int_3, int_4, 4, num);
						btnRemoveTable.Enabled = true;
						btnEditTable.Enabled = false;
						Selector.Visible = true;
						return;
					}
				}
				else if (item.TableName.Contains(TransparentLabelType.Chair))
				{
					int int_5 = 68;
					int int_6 = 70;
					Point point10 = new Point((int)((double)item.X.Value * num), (int)((double)item.Y.Value * num));
					Point point11 = new Point((int)((double)(item.X.Value + 68) * num), (int)((double)item.Y.Value * num));
					Point point12 = new Point((int)((double)(item.X.Value + 68) * num), (int)((double)(item.Y.Value + 70) * num));
					Point point13 = new Point((int)((double)item.X.Value * num), (int)((double)(item.Y.Value + 70) * num));
					if (ControlHelpers.IsPointInPolygon4(new PointF[4] { point10, point11, point12, point13 }, testPoint))
					{
						method_9(item, int_5, int_6, 5, num);
						btnRemoveTable.Enabled = true;
						btnEditTable.Enabled = false;
						Selector.Visible = true;
						return;
					}
				}
				continue;
			}
			if (!item.Round)
			{
				int num6 = item.NumOfSeats.Value;
				if (num6 <= 2)
				{
					num6++;
				}
				int num7 = (int)(40.0 * num);
				int num8 = (int)((double)(15 * num6) * num);
				int angleOfRotation = item.AngleOfRotation;
				int num9 = Math.Max(num7, num8);
				Size size_ = new Size(num9 * 2 + num9 / 2, num9 * 2 + num9 / 2);
				int num10 = (int)((double)(size_.Width / 2) + (double)item.X.Value * num);
				int num11 = (int)((double)(size_.Height / 2) + (double)item.Y.Value * num);
				Point center = new Point(num10, num11);
				Point rotatedRectangleCoords5 = ControlHelpers.GetRotatedRectangleCoords(1, angleOfRotation, center, num8, num7);
				Point rotatedRectangleCoords6 = ControlHelpers.GetRotatedRectangleCoords(2, angleOfRotation, center, num8, num7);
				Point rotatedRectangleCoords7 = ControlHelpers.GetRotatedRectangleCoords(3, angleOfRotation, center, num8, num7);
				Point rotatedRectangleCoords8 = ControlHelpers.GetRotatedRectangleCoords(4, angleOfRotation, center, num8, num7);
				if (ControlHelpers.IsPointInPolygon4(new PointF[4] { rotatedRectangleCoords5, rotatedRectangleCoords6, rotatedRectangleCoords7, rotatedRectangleCoords8 }, testPoint))
				{
					if (this.int_2 != 0)
					{
						method_17(item);
						return;
					}
					method_11(item, size_, num7, num8, bool_1: false, num);
					btnRemoveTable.Enabled = true;
					btnEditTable.Enabled = true;
					Selector.Visible = true;
					return;
				}
				continue;
			}
			int value = item.NumOfSeats.Value;
			int num12 = (int)((double)(60 + value * 4) * num);
			Size size_2 = new Size(num12, num12);
			Point point14 = new Point((int)((double)item.X.Value * num), (int)((double)item.Y.Value * num));
			Point point15 = new Point(point14.X, point14.Y);
			Point point16 = new Point(point14.X + num12, point14.Y);
			Point point17 = new Point(point14.X + num12, point14.Y + num12);
			Point point18 = new Point(point14.X, point14.Y + num12);
			if (ControlHelpers.IsPointInPolygon4(new PointF[4] { point15, point16, point17, point18 }, testPoint))
			{
				if (this.int_2 != 0)
				{
					method_17(item);
					return;
				}
				method_11(item, size_2, num12, num12, bool_1: true, num);
				btnRemoveTable.Enabled = true;
				btnEditTable.Enabled = true;
				Selector.Visible = true;
				return;
			}
		}
		Selector.Visible = false;
	}

	private IEnumerable<Control> method_21(Control control_1)
	{
		foreach (Control child in control_1.Controls)
		{
			yield return child;
			foreach (Control item in method_21(child))
			{
				yield return item;
			}
		}
	}

	private void pbZoomIn_Click(object sender, EventArgs e)
	{
		if (int_5 < 9)
		{
			int_5++;
			method_5();
		}
	}

	private void pbZoomOut_Click(object sender, EventArgs e)
	{
		if (int_5 > 1)
		{
			int_5--;
			method_5();
		}
	}

	private void iSvAtFahAx_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Edit Layout Name", 0, 256, lblSectionName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			GClass6 gClass = new GClass6();
			gClass.Layouts.Where((Layout a) => a.Section == lblSectionName.Text).ToList().ForEach(delegate(Layout a)
			{
				a.Section = MemoryLoadedObjects.Keyboard.textEntered;
			});
			gClass.SubmitChanges();
			list_3 = gClass.Layouts.ToList();
			method_4();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditLayout));
		pnlLayoutArea = new BufferedPanel();
		pbZoomOut = new PictureBox();
		pbZoomIn = new PictureBox();
		pictureBox_0 = new PictureBox();
		pictureBoxGuest = new PictureBox();
		btnCancel = new Button();
		btnAddTable = new Button();
		btnRemoveTable = new Button();
		btnEditTable = new Button();
		button_0 = new Button();
		btnRight = new Button();
		btnLeft = new Button();
		lblSectionName = new Label();
		label10 = new Label();
		btnSave = new Button();
		btnSetAsDefault = new Button();
		pictureBoxRotate = new PictureBox();
		btnAddPlant = new Button();
		btnAddChair = new Button();
		btnAddBench = new Button();
		btnGrid = new Button();
		plantImage = new PictureBox();
		benchImage = new PictureBox();
		chairImage = new PictureBox();
		lblTraining = new Label();
		iSvAtFahAx = new Button();
		((ISupportInitialize)pbZoomOut).BeginInit();
		((ISupportInitialize)pbZoomIn).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)pictureBoxGuest).BeginInit();
		((ISupportInitialize)pictureBoxRotate).BeginInit();
		((ISupportInitialize)plantImage).BeginInit();
		((ISupportInitialize)benchImage).BeginInit();
		((ISupportInitialize)chairImage).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlLayoutArea, "pnlLayoutArea");
		pnlLayoutArea.BackColor = Color.Transparent;
		pnlLayoutArea.BorderStyle = BorderStyle.FixedSingle;
		pnlLayoutArea.Name = "pnlLayoutArea";
		pnlLayoutArea.Paint += pnlLayoutArea_Paint;
		pnlLayoutArea.MouseClick += pnlLayoutArea_MouseClick;
		componentResourceManager.ApplyResources(pbZoomOut, "pbZoomOut");
		pbZoomOut.BackColor = Color.Transparent;
		pbZoomOut.Name = "pbZoomOut";
		pbZoomOut.TabStop = false;
		pbZoomOut.Click += pbZoomOut_Click;
		componentResourceManager.ApplyResources(pbZoomIn, "pbZoomIn");
		pbZoomIn.BackColor = Color.Transparent;
		pbZoomIn.Name = "pbZoomIn";
		pbZoomIn.TabStop = false;
		pbZoomIn.Click += pbZoomIn_Click;
		pictureBox_0.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(pictureBox_0, "Grid50x50");
		pictureBox_0.Name = "Grid50x50";
		pictureBox_0.TabStop = false;
		pictureBoxGuest.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(pictureBoxGuest, "pictureBoxGuest");
		pictureBoxGuest.Name = "pictureBoxGuest";
		pictureBoxGuest.TabStop = false;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(btnAddTable, "btnAddTable");
		btnAddTable.BackColor = Color.FromArgb(77, 174, 225);
		btnAddTable.FlatAppearance.BorderColor = Color.White;
		btnAddTable.FlatAppearance.BorderSize = 0;
		btnAddTable.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddTable.ForeColor = Color.White;
		btnAddTable.Name = "btnAddTable";
		btnAddTable.Tag = "";
		btnAddTable.UseVisualStyleBackColor = false;
		btnAddTable.Click += btnAddTable_Click;
		componentResourceManager.ApplyResources(btnRemoveTable, "btnRemoveTable");
		btnRemoveTable.BackColor = Color.SandyBrown;
		btnRemoveTable.FlatAppearance.BorderColor = Color.White;
		btnRemoveTable.FlatAppearance.BorderSize = 0;
		btnRemoveTable.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnRemoveTable.ForeColor = Color.White;
		btnRemoveTable.Name = "btnRemoveTable";
		btnRemoveTable.UseVisualStyleBackColor = false;
		btnRemoveTable.EnabledChanged += btnSave_EnabledChanged;
		btnRemoveTable.Click += btnRemoveTable_Click;
		componentResourceManager.ApplyResources(btnEditTable, "btnEditTable");
		btnEditTable.BackColor = Color.FromArgb(65, 168, 95);
		btnEditTable.FlatAppearance.BorderColor = Color.White;
		btnEditTable.FlatAppearance.BorderSize = 0;
		btnEditTable.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnEditTable.ForeColor = Color.White;
		btnEditTable.Name = "btnEditTable";
		btnEditTable.UseVisualStyleBackColor = false;
		btnEditTable.EnabledChanged += btnSave_EnabledChanged;
		btnEditTable.Click += btnEditTable_Click;
		componentResourceManager.ApplyResources(button_0, "btnAddHWall");
		button_0.BackColor = Color.FromArgb(50, 119, 155);
		button_0.FlatAppearance.BorderColor = Color.White;
		button_0.FlatAppearance.BorderSize = 0;
		button_0.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button_0.ForeColor = Color.White;
		button_0.Name = "btnAddHWall";
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		componentResourceManager.ApplyResources(btnRight, "btnRight");
		btnRight.BackColor = Color.Gray;
		btnRight.FlatAppearance.BorderColor = Color.Black;
		btnRight.FlatAppearance.BorderSize = 0;
		btnRight.FlatAppearance.MouseDownBackColor = Color.White;
		btnRight.ForeColor = Color.White;
		btnRight.Name = "btnRight";
		btnRight.UseVisualStyleBackColor = false;
		btnRight.EnabledChanged += btnLeft_EnabledChanged;
		btnRight.Click += btnRight_Click;
		componentResourceManager.ApplyResources(btnLeft, "btnLeft");
		btnLeft.BackColor = Color.Gray;
		btnLeft.FlatAppearance.BorderColor = Color.Black;
		btnLeft.FlatAppearance.BorderSize = 0;
		btnLeft.FlatAppearance.MouseDownBackColor = Color.White;
		btnLeft.ForeColor = Color.White;
		btnLeft.Name = "btnLeft";
		btnLeft.UseVisualStyleBackColor = false;
		btnLeft.EnabledChanged += btnLeft_EnabledChanged;
		btnLeft.Click += btnLeft_Click;
		componentResourceManager.ApplyResources(lblSectionName, "lblSectionName");
		lblSectionName.BackColor = Color.Gray;
		lblSectionName.FlatStyle = FlatStyle.Flat;
		lblSectionName.ForeColor = Color.Black;
		lblSectionName.Name = "lblSectionName";
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.EnabledChanged += btnSave_EnabledChanged;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(btnSetAsDefault, "btnSetAsDefault");
		btnSetAsDefault.BackColor = Color.FromArgb(61, 142, 185);
		btnSetAsDefault.FlatAppearance.BorderColor = Color.White;
		btnSetAsDefault.FlatAppearance.BorderSize = 0;
		btnSetAsDefault.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSetAsDefault.ForeColor = Color.White;
		btnSetAsDefault.Name = "btnSetAsDefault";
		btnSetAsDefault.UseVisualStyleBackColor = false;
		btnSetAsDefault.Click += btnSetAsDefault_Click;
		pictureBoxRotate.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(pictureBoxRotate, "pictureBoxRotate");
		pictureBoxRotate.Name = "pictureBoxRotate";
		pictureBoxRotate.TabStop = false;
		componentResourceManager.ApplyResources(btnAddPlant, "btnAddPlant");
		btnAddPlant.BackColor = Color.SteelBlue;
		btnAddPlant.FlatAppearance.BorderColor = Color.White;
		btnAddPlant.FlatAppearance.BorderSize = 0;
		btnAddPlant.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddPlant.ForeColor = Color.White;
		btnAddPlant.Name = "btnAddPlant";
		btnAddPlant.UseVisualStyleBackColor = false;
		btnAddPlant.Click += btnAddPlant_Click;
		componentResourceManager.ApplyResources(btnAddChair, "btnAddChair");
		btnAddChair.BackColor = Color.FromArgb(50, 119, 155);
		btnAddChair.FlatAppearance.BorderColor = Color.White;
		btnAddChair.FlatAppearance.BorderSize = 0;
		btnAddChair.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddChair.ForeColor = Color.White;
		btnAddChair.Name = "btnAddChair";
		btnAddChair.UseVisualStyleBackColor = false;
		btnAddChair.Click += btnAddChair_Click;
		componentResourceManager.ApplyResources(btnAddBench, "btnAddBench");
		btnAddBench.BackColor = Color.SteelBlue;
		btnAddBench.FlatAppearance.BorderColor = Color.White;
		btnAddBench.FlatAppearance.BorderSize = 0;
		btnAddBench.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddBench.ForeColor = Color.White;
		btnAddBench.Name = "btnAddBench";
		btnAddBench.UseVisualStyleBackColor = false;
		btnAddBench.Click += btnAddBench_Click;
		componentResourceManager.ApplyResources(btnGrid, "btnGrid");
		btnGrid.BackColor = Color.FromArgb(50, 119, 155);
		btnGrid.FlatAppearance.BorderColor = Color.White;
		btnGrid.FlatAppearance.BorderSize = 0;
		btnGrid.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnGrid.ForeColor = Color.White;
		btnGrid.Name = "btnGrid";
		btnGrid.UseVisualStyleBackColor = false;
		btnGrid.Click += btnGrid_Click;
		componentResourceManager.ApplyResources(plantImage, "plantImage");
		plantImage.BackColor = Color.Transparent;
		plantImage.Name = "plantImage";
		plantImage.TabStop = false;
		componentResourceManager.ApplyResources(benchImage, "benchImage");
		benchImage.BackColor = Color.Transparent;
		benchImage.Name = "benchImage";
		benchImage.TabStop = false;
		componentResourceManager.ApplyResources(chairImage, "chairImage");
		chairImage.BackColor = Color.Transparent;
		chairImage.Name = "chairImage";
		chairImage.TabStop = false;
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(iSvAtFahAx, "btnEditLayoutName");
		iSvAtFahAx.BackColor = Color.FromArgb(50, 119, 155);
		iSvAtFahAx.FlatAppearance.BorderColor = Color.White;
		iSvAtFahAx.FlatAppearance.BorderSize = 0;
		iSvAtFahAx.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		iSvAtFahAx.ForeColor = Color.White;
		iSvAtFahAx.Name = "btnEditLayoutName";
		iSvAtFahAx.UseVisualStyleBackColor = false;
		iSvAtFahAx.Click += iSvAtFahAx_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(iSvAtFahAx);
		base.Controls.Add(pictureBox_0);
		base.Controls.Add(btnGrid);
		base.Controls.Add(benchImage);
		base.Controls.Add(chairImage);
		base.Controls.Add(plantImage);
		base.Controls.Add(btnAddBench);
		base.Controls.Add(btnAddChair);
		base.Controls.Add(btnAddPlant);
		base.Controls.Add(pictureBoxRotate);
		base.Controls.Add(btnSetAsDefault);
		base.Controls.Add(btnSave);
		base.Controls.Add(pictureBoxGuest);
		base.Controls.Add(label10);
		base.Controls.Add(btnRight);
		base.Controls.Add(btnLeft);
		base.Controls.Add(lblSectionName);
		base.Controls.Add(button_0);
		base.Controls.Add(btnEditTable);
		base.Controls.Add(btnRemoveTable);
		base.Controls.Add(btnAddTable);
		base.Controls.Add(btnCancel);
		base.Controls.Add(lblTraining);
		base.Controls.Add(pbZoomOut);
		base.Controls.Add(pbZoomIn);
		base.Controls.Add(pnlLayoutArea);
		base.MinimizeBox = false;
		base.Name = "frmEditLayout";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmEditLayout_Load;
		base.Controls.SetChildIndex(pnlLayoutArea, 0);
		base.Controls.SetChildIndex(pbZoomIn, 0);
		base.Controls.SetChildIndex(pbZoomOut, 0);
		base.Controls.SetChildIndex(lblTraining, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(btnAddTable, 0);
		base.Controls.SetChildIndex(btnRemoveTable, 0);
		base.Controls.SetChildIndex(btnEditTable, 0);
		base.Controls.SetChildIndex(button_0, 0);
		base.Controls.SetChildIndex(lblSectionName, 0);
		base.Controls.SetChildIndex(btnLeft, 0);
		base.Controls.SetChildIndex(btnRight, 0);
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(pictureBoxGuest, 0);
		base.Controls.SetChildIndex(btnSave, 0);
		base.Controls.SetChildIndex(btnSetAsDefault, 0);
		base.Controls.SetChildIndex(pictureBoxRotate, 0);
		base.Controls.SetChildIndex(btnAddPlant, 0);
		base.Controls.SetChildIndex(btnAddChair, 0);
		base.Controls.SetChildIndex(btnAddBench, 0);
		base.Controls.SetChildIndex(plantImage, 0);
		base.Controls.SetChildIndex(chairImage, 0);
		base.Controls.SetChildIndex(benchImage, 0);
		base.Controls.SetChildIndex(btnGrid, 0);
		base.Controls.SetChildIndex(pictureBox_0, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(iSvAtFahAx, 0);
		((ISupportInitialize)pbZoomOut).EndInit();
		((ISupportInitialize)pbZoomIn).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)pictureBoxGuest).EndInit();
		((ISupportInitialize)pictureBoxRotate).EndInit();
		((ISupportInitialize)plantImage).EndInit();
		((ISupportInitialize)benchImage).EndInit();
		((ISupportInitialize)chairImage).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_22(Layout layout_1)
	{
		return layout_1.TableName == control_0.Parent.Name.Replace("\n", string.Empty);
	}

	[CompilerGenerated]
	private bool method_23(Layout layout_1)
	{
		return layout_1.TableName == control_0.Name.Replace("\n", string.Empty);
	}

	[CompilerGenerated]
	private bool method_24(Layout layout_1)
	{
		return layout_1.Section == lblSectionName.Text;
	}

	[CompilerGenerated]
	private bool method_25(Layout layout_1)
	{
		return layout_1.Section == lblSectionName.Text;
	}
}
