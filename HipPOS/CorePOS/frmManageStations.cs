using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CommonForms;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmManageStations : frmMasterForm
{
	private string string_0;

	private string string_1;

	private IContainer icontainer_1;

	private PictureBox pictureBox1;

	private Label lblHeaderTitle;

	private Class19 ddlStations;

	private Label label1;

	private RadTextBoxControl txtName;

	private Label label2;

	internal Button btnShowKeyboard_Name;

	internal Button btnDelete;

	internal Button btnAddNew;

	internal Button btnUpdate;

	private Label label3;

	private Class19 ddlPrintCopies;

	private Label label4;

	private RadToggleSwitch chkEnablePrint;

	internal Button btnSelectPrinter;

	private Label lblPrinterName;

	private RadToggleSwitch chkAutoPrint;

	private Label label5;

	private Label label7;

	private RadToggleSwitch chkSendStation;

	private Label label8;

	private Label label9;

	private Class19 pjuWniyana;

	private Class19 ddlPaperSize;

	private Label label10;

	private Label label11;

	private Label label12;

	private Label lblDisplayFont;

	private Label lblChitFont;

	internal Button btnSetOrderType;

	private RadToggleSwitch chkPrintForEach;

	private Label label13;

	private Class19 ddlPrintItemQtyGreater;

	private Label label14;

	private Label lblHideEachQty;

	private Label label6;

	public frmManageStations()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = string.Empty;
		string_1 = string.Join(",", OrderTypes.DineIn, OrderTypes.Delivery, OrderTypes.ToGo, OrderTypes.PickUp, OrderTypes.DeliveryOnline, OrderTypes.PickUpOnline);
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageStations_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("1", "Default Chit");
		dictionary.Add("3", "Individual Item Chit");
		dictionary.Add("2", "Individual Item Label");
		dictionary.Add("4", "Individual Item Large Label");
		dictionary.Add("5", "Order Summary Chit");
		dictionary.Add("6", "Default Chit 2");
		pjuWniyana.DisplayMember = "Value";
		pjuWniyana.ValueMember = "Key";
		pjuWniyana.DataSource = new BindingSource(dictionary, null);
		method_3();
	}

	private void method_3()
	{
		StationMethods stationMethods = new StationMethods();
		Dictionary<string, string> dictionary = new Dictionary<string, string> { { "0", "+ Add New" } };
		foreach (Station item in from a in stationMethods.GetStations(null, Thread.CurrentThread.CurrentCulture.Name)
			where !a.SystemDefinedID.HasValue
			select a)
		{
			dictionary.Add(item.StationID.ToString(), item.StationName);
		}
		ddlStations.DisplayMember = "Value";
		ddlStations.ValueMember = "Key";
		ddlStations.DataSource = new BindingSource(dictionary, null);
	}

	private void ddlStations_SelectedIndexChanged(object sender, EventArgs e)
	{
		int num = Convert.ToInt32(ddlStations.SelectedValue.ToString());
		((Control)(object)txtName).Enabled = true;
		btnDelete.Visible = true;
		if (num <= 4)
		{
			((Control)(object)txtName).Enabled = false;
			btnDelete.Visible = false;
			if (num == 0)
			{
				((Control)(object)txtName).Enabled = true;
			}
		}
		if (ddlStations.SelectedValue.ToString() != "0")
		{
			Station station = new GClass6().Stations.Where((Station a) => a.StationID == Convert.ToInt16(ddlStations.SelectedValue)).FirstOrDefault();
			((Control)(object)txtName).Text = station.StationName;
			ddlPrintCopies.Text = station.PrintCopies.ToString();
			ddlPrintItemQtyGreater.Text = station.PrintItemQtyGreater.ToString();
			chkEnablePrint.set_Value(station.EnablePrint);
			lblPrinterName.Text = station.PrinterName;
			chkAutoPrint.set_Value(station.AutoPrint);
			chkSendStation.set_Value(station.SendToStation);
			pjuWniyana.SelectedValue = station.ChitFormat.ToString();
			ddlPaperSize.Text = station.PaperSize.Trim();
			lblChitFont.Text = station.ChitFontSize.ToString();
			lblDisplayFont.Text = station.DisplayFontSize.ToString();
			string_0 = station.OrderTypes;
			chkPrintForEach.set_Value(station.PrintEachQty);
		}
		else
		{
			((Control)(object)txtName).Text = "";
			ddlPrintCopies.Text = "1";
			ddlPrintItemQtyGreater.Text = "1";
			chkEnablePrint.set_Value(false);
			lblPrinterName.Text = "";
			chkAutoPrint.set_Value(false);
			chkSendStation.set_Value(false);
			pjuWniyana.SelectedValue = "1";
			ddlPaperSize.Text = "80mm";
			lblChitFont.Text = "8";
			lblDisplayFont.Text = "8";
			string_0 = string_1;
			chkPrintForEach.set_Value(false);
		}
	}

	private void btnAddNew_Click(object sender, EventArgs e)
	{
		ddlStations.SelectedIndex = 0;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (new frmMessageBox("Are you sure you want to delete this station? Items under this station will be reassigned to a selected station.", "Delete station", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
		{
			return;
		}
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.selectedStationId = Convert.ToInt16(ddlStations.SelectedValue);
		int num = 1;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Station station2 in new StationMethods().GetStations(null, Thread.CurrentThread.CurrentCulture.Name))
		{
			if (CS_0024_003C_003E8__locals0.selectedStationId != station2.StationID)
			{
				dictionary.Add(station2.StationID.ToString(), station2.StationName);
			}
		}
		frmDDLSelector frmDDLSelector2 = new frmDDLSelector("Reassign items to Station", dictionary);
		if (frmDDLSelector2.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		num = Convert.ToInt32(frmDDLSelector2.SelectedValue);
		List<Item> list = gClass.Items.Where((Item a) => a.StationID.Contains(CS_0024_003C_003E8__locals0.selectedStationId.ToString())).ToList();
		if (list.Count > 0)
		{
			foreach (Item item in list)
			{
				item.Synced = false;
				item.StationID = StationMethods.ChangeSingleStationFromStationIds(item.StationID, CS_0024_003C_003E8__locals0.selectedStationId.ToString(), num.ToString());
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		Station station = gClass.Stations.Where((Station a) => a.StationID == CS_0024_003C_003E8__locals0.selectedStationId).FirstOrDefault();
		if (station != null)
		{
			station.IsDeleted = true;
			station.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
			new NotificationLabel(this, "Station successfully deleted.", NotificationTypes.Success).Show();
		}
		method_3();
		MemoryLoadedObjects.all_stations = new GClass6().Stations.Where((Station a) => a.IsDeleted == false).ToList();
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(((Control)(object)txtName).Text))
			{
				new NotificationLabel(this, "Please add a station name.", NotificationTypes.Warning).Show();
				return;
			}
			GClass6 gClass = new GClass6();
			if (ddlStations.SelectedIndex == 0)
			{
				if (gClass.Stations.Where((Station a) => a.StationName.ToUpper() == ((Control)(object)txtName).Text.ToUpper()).FirstOrDefault() != null)
				{
					new NotificationLabel(this, "Station Name already exist.", NotificationTypes.Warning).Show();
					return;
				}
				Station entity = new Station
				{
					StationName = ((Control)(object)txtName).Text,
					EnablePrint = chkEnablePrint.get_Value(),
					PrintCopies = Convert.ToInt32(ddlPrintCopies.Text),
					PrintItemQtyGreater = Convert.ToInt16(ddlPrintItemQtyGreater.Text),
					PrinterName = lblPrinterName.Text,
					AutoPrint = chkAutoPrint.get_Value(),
					Synced = false,
					SendToStation = chkSendStation.get_Value(),
					PaperSize = ddlPaperSize.Text.Trim(),
					ChitFormat = Convert.ToInt16(pjuWniyana.SelectedValue),
					ChitFontSize = Convert.ToInt32(lblChitFont.Text),
					DisplayFontSize = Convert.ToInt32(lblDisplayFont.Text),
					OrderTypes = string_0,
					PrintEachQty = chkPrintForEach.get_Value()
				};
				gClass.Stations.InsertOnSubmit(entity);
				Helper.SubmitChangesWithCatch(gClass);
			}
			else
			{
				Station station = gClass.Stations.Where((Station a) => a.StationID == Convert.ToInt16(ddlStations.SelectedValue)).FirstOrDefault();
				if (station != null)
				{
					station.StationName = ((Control)(object)txtName).Text;
					station.PrinterName = lblPrinterName.Text;
					station.PrintCopies = Convert.ToInt32(ddlPrintCopies.Text);
					station.PrintItemQtyGreater = Convert.ToInt16(ddlPrintItemQtyGreater.Text);
					station.EnablePrint = chkEnablePrint.get_Value();
					station.AutoPrint = chkAutoPrint.get_Value();
					station.SendToStation = chkSendStation.get_Value();
					station.ChitFormat = Convert.ToInt16(pjuWniyana.SelectedValue);
					station.PaperSize = ddlPaperSize.Text.Trim();
					station.ChitFontSize = Convert.ToInt32(lblChitFont.Text);
					station.DisplayFontSize = Convert.ToInt32(lblDisplayFont.Text);
					station.Synced = false;
					station.OrderTypes = string_0;
					station.PrintEachQty = chkPrintForEach.get_Value();
					Helper.SubmitChangesWithCatch(gClass);
				}
			}
			new NotificationLabel(this, "Station successfully saved.", NotificationTypes.Success).Show();
			MemoryLoadedObjects.all_stations = gClass.Stations.ToList();
			SettingsObject settingByKey = SettingsHelper.GetSettingByKey("layout_show_drink_icon");
			SettingsObject settingByKey2 = SettingsHelper.GetSettingByKey("layout_show_food_icon");
			if (MemoryLoadedObjects.all_stations.Where((Station x) => x.StationName.ToUpper().Contains("BAR") && x.SendToStation).Any())
			{
				settingByKey.Value = "ON";
			}
			else
			{
				settingByKey.Value = "OFF";
			}
			if (MemoryLoadedObjects.all_stations.Where((Station x) => !x.StationName.ToUpper().Contains("BAR") && x.SendToStation).Any())
			{
				settingByKey2.Value = "ON";
			}
			else
			{
				settingByKey2.Value = "OFF";
			}
			method_3();
		}
		catch (Exception ex)
		{
			if (ex.Message.Contains("Violation of PRIMARY KEY"))
			{
				btnUpdate_Click(null, null);
			}
			else
			{
				new NotificationLabel(this, "Database error. Please restart hippos app.", NotificationTypes.Warning).Show();
			}
		}
	}

	private void btnSelectPrinter_Click(object sender, EventArgs e)
	{
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog(this) != DialogResult.Cancel)
		{
			lblPrinterName.Text = printDialog.PrinterSettings.PrinterName;
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Station Name", 1, 128, ((Control)(object)txtName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtName).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void lblDisplayFont_Click(object sender, EventArgs e)
	{
		frmFontSize frmFontSize = new frmFontSize(string.IsNullOrEmpty(lblDisplayFont.Text) ? 8 : Convert.ToInt16(lblDisplayFont.Text));
		frmFontSize.ShowDialog();
		lblDisplayFont.Text = frmFontSize.FontSize.ToString();
	}

	private void lblChitFont_Click(object sender, EventArgs e)
	{
		frmFontSize frmFontSize = new frmFontSize(string.IsNullOrEmpty(lblChitFont.Text) ? 8 : Convert.ToInt16(lblChitFont.Text));
		frmFontSize.ShowDialog();
		lblChitFont.Text = frmFontSize.FontSize.ToString();
	}

	private void btnSetOrderType_Click(object sender, EventArgs e)
	{
		frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SELECT APPLICABLE ORDER TYPES", OrderTypesDictionary.OrderTypes, string_0);
		if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
		{
			string_0 = frmChecklistSelector.returnValue;
		}
	}

	private void pjuWniyana_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (pjuWniyana.Items != null && pjuWniyana.Items.Count > 0 && Convert.ToInt16(pjuWniyana.SelectedValue) == 3)
		{
			lblHideEachQty.Visible = false;
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_102e: Unknown result type (might be due to invalid IL or missing references)
		//IL_105b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1088: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1373: Unknown result type (might be due to invalid IL or missing references)
		//IL_138b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_141d: Unknown result type (might be due to invalid IL or missing references)
		//IL_144a: Unknown result type (might be due to invalid IL or missing references)
		//IL_146b: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16db: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1713: Unknown result type (might be due to invalid IL or missing references)
		//IL_1740: Unknown result type (might be due to invalid IL or missing references)
		//IL_176d: Unknown result type (might be due to invalid IL or missing references)
		//IL_179a: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2261: Unknown result type (might be due to invalid IL or missing references)
		//IL_2279: Unknown result type (might be due to invalid IL or missing references)
		//IL_2290: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22de: Unknown result type (might be due to invalid IL or missing references)
		//IL_230b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2338: Unknown result type (might be due to invalid IL or missing references)
		//IL_2359: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageStations));
		pictureBox1 = new PictureBox();
		lblHeaderTitle = new Label();
		ddlStations = new Class19();
		label1 = new Label();
		txtName = new RadTextBoxControl();
		label2 = new Label();
		btnShowKeyboard_Name = new Button();
		btnDelete = new Button();
		btnAddNew = new Button();
		btnUpdate = new Button();
		label3 = new Label();
		ddlPrintCopies = new Class19();
		label4 = new Label();
		chkEnablePrint = new RadToggleSwitch();
		btnSelectPrinter = new Button();
		lblPrinterName = new Label();
		chkAutoPrint = new RadToggleSwitch();
		label5 = new Label();
		label7 = new Label();
		chkSendStation = new RadToggleSwitch();
		label8 = new Label();
		label9 = new Label();
		pjuWniyana = new Class19();
		ddlPaperSize = new Class19();
		label10 = new Label();
		label11 = new Label();
		label12 = new Label();
		lblDisplayFont = new Label();
		lblChitFont = new Label();
		btnSetOrderType = new Button();
		chkPrintForEach = new RadToggleSwitch();
		label13 = new Label();
		ddlPrintItemQtyGreater = new Class19();
		label14 = new Label();
		lblHideEachQty = new Label();
		label6 = new Label();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)chkEnablePrint).BeginInit();
		((ISupportInitialize)chkAutoPrint).BeginInit();
		((ISupportInitialize)chkSendStation).BeginInit();
		((ISupportInitialize)chkPrintForEach).BeginInit();
		SuspendLayout();
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(611, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(44, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 238;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(2, 4);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(653, 38);
		lblHeaderTitle.TabIndex = 237;
		lblHeaderTitle.Text = "MANAGE STATIONS";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		ddlStations.BackColor = Color.White;
		ddlStations.DrawMode = DrawMode.OwnerDrawVariable;
		ddlStations.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlStations.FlatStyle = FlatStyle.Flat;
		ddlStations.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlStations.FormattingEnabled = true;
		ddlStations.ItemHeight = 28;
		ddlStations.Items.AddRange(new object[1] { "**Please Select A Field Name**" });
		ddlStations.Location = new Point(138, 43);
		ddlStations.Margin = new Padding(2);
		ddlStations.Name = "ddlStations";
		ddlStations.Size = new Size(516, 34);
		ddlStations.TabIndex = 240;
		ddlStations.SelectedIndexChanged += ddlStations_SelectedIndexChanged;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = SystemColors.ButtonFace;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(2, 43);
		label1.Margin = new Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Padding = new Padding(3, 0, 0, 0);
		label1.Size = new Size(135, 34);
		label1.TabIndex = 239;
		label1.Text = "Station List";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		((Control)(object)txtName).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		((Control)(object)txtName).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtName).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtName).Location = new Point(138, 78);
		((Control)(object)txtName).Name = "txtName";
		((RadElement)((RadControl)txtName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtName).Size = new Size(466, 35);
		((Control)(object)txtName).TabIndex = 243;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = SystemColors.ButtonFace;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(2, 78);
		label2.Margin = new Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Padding = new Padding(3, 0, 0, 0);
		label2.Size = new Size(135, 35);
		label2.TabIndex = 242;
		label2.Text = "Name";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Name.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Name.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Name.Image");
		btnShowKeyboard_Name.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Name.Location = new Point(602, 78);
		btnShowKeyboard_Name.Margin = new Padding(2);
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.Size = new Size(52, 35);
		btnShowKeyboard_Name.TabIndex = 241;
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		btnDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnDelete.FlatAppearance.BorderColor = Color.White;
		btnDelete.FlatAppearance.BorderSize = 0;
		btnDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDelete.FlatStyle = FlatStyle.Flat;
		btnDelete.Font = new Font("Microsoft Sans Serif", 9f);
		btnDelete.ForeColor = Color.White;
		btnDelete.Image = (Image)componentResourceManager.GetObject("btnDelete.Image");
		btnDelete.ImeMode = ImeMode.NoControl;
		btnDelete.Location = new Point(293, 284);
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new Size(120, 80);
		btnDelete.TabIndex = 246;
		btnDelete.Text = "DELETE";
		btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		btnAddNew.BackColor = Color.FromArgb(1, 110, 211);
		btnAddNew.DialogResult = DialogResult.OK;
		btnAddNew.FlatAppearance.BorderColor = Color.Black;
		btnAddNew.FlatAppearance.BorderSize = 0;
		btnAddNew.FlatStyle = FlatStyle.Flat;
		btnAddNew.Font = new Font("Microsoft Sans Serif", 9f);
		btnAddNew.ForeColor = Color.White;
		btnAddNew.Image = (Image)componentResourceManager.GetObject("btnAddNew.Image");
		btnAddNew.ImeMode = ImeMode.NoControl;
		btnAddNew.Location = new Point(414, 284);
		btnAddNew.Name = "btnAddNew";
		btnAddNew.Size = new Size(120, 80);
		btnAddNew.TabIndex = 245;
		btnAddNew.Text = "NEW";
		btnAddNew.TextImageRelation = TextImageRelation.ImageAboveText;
		btnAddNew.UseVisualStyleBackColor = false;
		btnAddNew.Click += btnAddNew_Click;
		btnUpdate.BackColor = Color.FromArgb(80, 203, 116);
		btnUpdate.FlatAppearance.BorderColor = Color.White;
		btnUpdate.FlatAppearance.BorderSize = 0;
		btnUpdate.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnUpdate.FlatStyle = FlatStyle.Flat;
		btnUpdate.Font = new Font("Microsoft Sans Serif", 9f);
		btnUpdate.ForeColor = Color.White;
		btnUpdate.Image = (Image)componentResourceManager.GetObject("btnUpdate.Image");
		btnUpdate.ImeMode = ImeMode.NoControl;
		btnUpdate.Location = new Point(535, 284);
		btnUpdate.Margin = new Padding(4, 5, 4, 5);
		btnUpdate.Name = "btnUpdate";
		btnUpdate.Size = new Size(120, 80);
		btnUpdate.TabIndex = 244;
		btnUpdate.Text = "SAVE";
		btnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
		btnUpdate.UseVisualStyleBackColor = false;
		btnUpdate.Click += btnUpdate_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = SystemColors.ButtonFace;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(2, 182);
		label3.Margin = new Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Padding = new Padding(3, 0, 0, 0);
		label3.Size = new Size(135, 33);
		label3.TabIndex = 248;
		label3.Text = "Print Copies";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		ddlPrintCopies.BackColor = Color.White;
		ddlPrintCopies.DisplayMember = "en-US,fr-CA";
		ddlPrintCopies.DrawMode = DrawMode.OwnerDrawVariable;
		ddlPrintCopies.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlPrintCopies.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlPrintCopies.ForeColor = Color.FromArgb(40, 40, 40);
		ddlPrintCopies.FormattingEnabled = true;
		ddlPrintCopies.ItemHeight = 28;
		ddlPrintCopies.Items.AddRange(new object[5] { "1", "2", "3", "4", "5" });
		ddlPrintCopies.Location = new Point(137, 181);
		ddlPrintCopies.Margin = new Padding(4, 5, 4, 5);
		ddlPrintCopies.MinimumSize = new Size(50, 0);
		ddlPrintCopies.Name = "ddlPrintCopies";
		ddlPrintCopies.Size = new Size(59, 34);
		ddlPrintCopies.TabIndex = 249;
		ddlPrintCopies.Tag = "print_kitchen_copy";
		ddlPrintCopies.ValueMember = "en-US,fr-CA";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = SystemColors.ButtonFace;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(196, 182);
		label4.Margin = new Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Padding = new Padding(3, 0, 0, 0);
		label4.Size = new Size(105, 33);
		label4.TabIndex = 250;
		label4.Text = "Enable Print";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		((Control)(object)chkEnablePrint).Location = new Point(301, 182);
		((Control)(object)chkEnablePrint).Name = "chkEnablePrint";
		chkEnablePrint.set_OffText("NO");
		chkEnablePrint.set_OnText("YES");
		((Control)(object)chkEnablePrint).Size = new Size(66, 33);
		((Control)(object)chkEnablePrint).TabIndex = 251;
		((Control)(object)chkEnablePrint).Tag = "";
		chkEnablePrint.set_ToggleStateMode((ToggleStateMode)1);
		chkEnablePrint.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkEnablePrint).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkEnablePrint).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkEnablePrint).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEnablePrint).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEnablePrint).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEnablePrint).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkEnablePrint).GetChildAt(0).GetChildAt(0)).set_Text("YES");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkEnablePrint).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		btnSelectPrinter.BackColor = Color.FromArgb(77, 174, 225);
		btnSelectPrinter.DialogResult = DialogResult.OK;
		btnSelectPrinter.FlatAppearance.BorderColor = Color.Black;
		btnSelectPrinter.FlatAppearance.BorderSize = 0;
		btnSelectPrinter.FlatStyle = FlatStyle.Flat;
		btnSelectPrinter.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnSelectPrinter.ForeColor = Color.White;
		btnSelectPrinter.ImeMode = ImeMode.NoControl;
		btnSelectPrinter.Location = new Point(368, 182);
		btnSelectPrinter.Margin = new Padding(2);
		btnSelectPrinter.Name = "btnSelectPrinter";
		btnSelectPrinter.Size = new Size(116, 33);
		btnSelectPrinter.TabIndex = 252;
		btnSelectPrinter.Text = "Select Printer";
		btnSelectPrinter.UseVisualStyleBackColor = false;
		btnSelectPrinter.Click += btnSelectPrinter_Click;
		lblPrinterName.BackColor = Color.Gray;
		lblPrinterName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblPrinterName.ForeColor = Color.White;
		lblPrinterName.ImeMode = ImeMode.NoControl;
		lblPrinterName.Location = new Point(485, 182);
		lblPrinterName.Name = "lblPrinterName";
		lblPrinterName.Padding = new Padding(5, 0, 0, 0);
		lblPrinterName.Size = new Size(169, 33);
		lblPrinterName.TabIndex = 253;
		lblPrinterName.TextAlign = ContentAlignment.MiddleLeft;
		((Control)(object)chkAutoPrint).Location = new Point(138, 147);
		((Control)(object)chkAutoPrint).Name = "chkAutoPrint";
		chkAutoPrint.set_OffText("NO");
		chkAutoPrint.set_OnText("YES");
		((Control)(object)chkAutoPrint).Size = new Size(58, 34);
		((Control)(object)chkAutoPrint).TabIndex = 255;
		((Control)(object)chkAutoPrint).Tag = "";
		chkAutoPrint.set_ToggleStateMode((ToggleStateMode)1);
		chkAutoPrint.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkAutoPrint).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkAutoPrint).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkAutoPrint).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPrint).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPrint).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPrint).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkAutoPrint).GetChildAt(0).GetChildAt(0)).set_Text("YES");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkAutoPrint).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = SystemColors.ButtonFace;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(2, 148);
		label5.Margin = new Padding(2, 0, 2, 0);
		label5.Name = "label5";
		label5.Padding = new Padding(3, 0, 0, 0);
		label5.Size = new Size(135, 33);
		label5.TabIndex = 254;
		label5.Text = "Auto Print Bill";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		label7.BackColor = Color.LemonChiffon;
		label7.Cursor = Cursors.Default;
		label7.Font = new Font("Microsoft Sans Serif", 9f);
		label7.ImeMode = ImeMode.NoControl;
		label7.Location = new Point(3, 284);
		label7.Name = "label7";
		label7.Padding = new Padding(5);
		label7.Size = new Size(289, 80);
		label7.TabIndex = 257;
		label7.Text = "Enable Print: Enable print to station feature.\r\nAuto Print: Enable to print a receipt when order/item is made on station. (Not applicable to Dine In orders)";
		((Control)(object)chkSendStation).Location = new Point(485, 216);
		((Control)(object)chkSendStation).Name = "chkSendStation";
		chkSendStation.set_OffText("NO");
		chkSendStation.set_OnText("YES");
		((Control)(object)chkSendStation).Size = new Size(66, 33);
		((Control)(object)chkSendStation).TabIndex = 259;
		((Control)(object)chkSendStation).Tag = "";
		chkSendStation.set_ToggleStateMode((ToggleStateMode)1);
		chkSendStation.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSendStation).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSendStation).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSendStation).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSendStation).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSendStation).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSendStation).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSendStation).GetChildAt(0).GetChildAt(0)).set_Text("YES");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSendStation).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = SystemColors.ButtonFace;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(251, 216);
		label8.Margin = new Padding(2, 0, 2, 0);
		label8.Name = "label8";
		label8.Padding = new Padding(3, 0, 0, 0);
		label8.Size = new Size(233, 33);
		label8.TabIndex = 258;
		label8.Text = "Send To Station Screen";
		label8.TextAlign = ContentAlignment.MiddleLeft;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		label9.Font = new Font("Microsoft Sans Serif", 12f);
		label9.ForeColor = SystemColors.ButtonFace;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(2, 114);
		label9.Margin = new Padding(2, 0, 2, 0);
		label9.Name = "label9";
		label9.Padding = new Padding(3, 0, 0, 0);
		label9.Size = new Size(135, 33);
		label9.TabIndex = 260;
		label9.Text = "Chit Format";
		label9.TextAlign = ContentAlignment.MiddleLeft;
		pjuWniyana.BackColor = Color.White;
		pjuWniyana.DisplayMember = "en-US,fr-CA";
		pjuWniyana.DrawMode = DrawMode.OwnerDrawVariable;
		pjuWniyana.DropDownStyle = ComboBoxStyle.DropDownList;
		pjuWniyana.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		pjuWniyana.ForeColor = Color.FromArgb(40, 40, 40);
		pjuWniyana.FormattingEnabled = true;
		pjuWniyana.ItemHeight = 28;
		pjuWniyana.Items.AddRange(new object[2] { "Default Chit", "Individual Item Label" });
		pjuWniyana.Location = new Point(137, 113);
		pjuWniyana.Margin = new Padding(4, 5, 4, 5);
		pjuWniyana.MinimumSize = new Size(50, 0);
		pjuWniyana.Name = "ddlChitFormat";
		pjuWniyana.Size = new Size(315, 34);
		pjuWniyana.TabIndex = 261;
		pjuWniyana.Tag = "print_kitchen_copy";
		pjuWniyana.ValueMember = "en-US,fr-CA";
		pjuWniyana.SelectedIndexChanged += pjuWniyana_SelectedIndexChanged;
		ddlPaperSize.BackColor = Color.White;
		ddlPaperSize.DrawMode = DrawMode.OwnerDrawVariable;
		ddlPaperSize.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlPaperSize.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlPaperSize.ForeColor = Color.FromArgb(40, 40, 40);
		ddlPaperSize.FormattingEnabled = true;
		ddlPaperSize.ItemHeight = 28;
		ddlPaperSize.Items.AddRange(new object[4] { "102mm", "80mm", "72mm", "58mm" });
		ddlPaperSize.Location = new Point(137, 216);
		ddlPaperSize.Margin = new Padding(4, 5, 4, 5);
		ddlPaperSize.MinimumSize = new Size(50, 0);
		ddlPaperSize.Name = "ddlPaperSize";
		ddlPaperSize.Size = new Size(114, 34);
		ddlPaperSize.TabIndex = 262;
		ddlPaperSize.Tag = "receipt_size";
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.Font = new Font("Microsoft Sans Serif", 12f);
		label10.ForeColor = SystemColors.ButtonFace;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(2, 216);
		label10.Margin = new Padding(2, 0, 2, 0);
		label10.Name = "label10";
		label10.Padding = new Padding(3, 0, 0, 0);
		label10.Size = new Size(135, 33);
		label10.TabIndex = 263;
		label10.Text = "Paper Size";
		label10.TextAlign = ContentAlignment.MiddleLeft;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		label11.Font = new Font("Microsoft Sans Serif", 12f);
		label11.ForeColor = SystemColors.ButtonFace;
		label11.ImeMode = ImeMode.NoControl;
		label11.Location = new Point(2, 250);
		label11.Margin = new Padding(2, 0, 2, 0);
		label11.Name = "label11";
		label11.Padding = new Padding(3, 0, 0, 0);
		label11.Size = new Size(135, 33);
		label11.TabIndex = 264;
		label11.Text = "Display Font Size";
		label11.TextAlign = ContentAlignment.MiddleLeft;
		label12.BackColor = Color.FromArgb(132, 146, 146);
		label12.Font = new Font("Microsoft Sans Serif", 12f);
		label12.ForeColor = SystemColors.ButtonFace;
		label12.ImeMode = ImeMode.NoControl;
		label12.Location = new Point(251, 250);
		label12.Margin = new Padding(2, 0, 2, 0);
		label12.Name = "label12";
		label12.Padding = new Padding(3, 0, 0, 0);
		label12.Size = new Size(135, 33);
		label12.TabIndex = 266;
		label12.Text = "Chit Font Size";
		label12.TextAlign = ContentAlignment.MiddleLeft;
		lblDisplayFont.BackColor = Color.White;
		lblDisplayFont.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblDisplayFont.ForeColor = SystemColors.ActiveCaptionText;
		lblDisplayFont.ImeMode = ImeMode.NoControl;
		lblDisplayFont.Location = new Point(138, 250);
		lblDisplayFont.Margin = new Padding(2, 0, 2, 0);
		lblDisplayFont.Name = "lblDisplayFont";
		lblDisplayFont.Padding = new Padding(3, 0, 0, 0);
		lblDisplayFont.Size = new Size(112, 33);
		lblDisplayFont.TabIndex = 267;
		lblDisplayFont.TextAlign = ContentAlignment.MiddleLeft;
		lblDisplayFont.Click += lblDisplayFont_Click;
		lblChitFont.BackColor = Color.White;
		lblChitFont.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblChitFont.ForeColor = SystemColors.ActiveCaptionText;
		lblChitFont.ImeMode = ImeMode.NoControl;
		lblChitFont.Location = new Point(387, 250);
		lblChitFont.Margin = new Padding(2, 0, 2, 0);
		lblChitFont.Name = "lblChitFont";
		lblChitFont.Padding = new Padding(3, 0, 0, 0);
		lblChitFont.Size = new Size(164, 33);
		lblChitFont.TabIndex = 269;
		lblChitFont.TextAlign = ContentAlignment.MiddleLeft;
		lblChitFont.Click += lblChitFont_Click;
		btnSetOrderType.BackColor = Color.FromArgb(77, 174, 225);
		btnSetOrderType.FlatAppearance.BorderColor = Color.White;
		btnSetOrderType.FlatAppearance.BorderSize = 0;
		btnSetOrderType.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSetOrderType.FlatStyle = FlatStyle.Flat;
		btnSetOrderType.Font = new Font("Microsoft Sans Serif", 10f);
		btnSetOrderType.ForeColor = Color.White;
		btnSetOrderType.ImeMode = ImeMode.NoControl;
		btnSetOrderType.Location = new Point(552, 216);
		btnSetOrderType.Name = "btnSetOrderType";
		btnSetOrderType.Size = new Size(102, 67);
		btnSetOrderType.TabIndex = 270;
		btnSetOrderType.Text = "SET ORDER TYPES";
		btnSetOrderType.UseVisualStyleBackColor = false;
		btnSetOrderType.Click += btnSetOrderType_Click;
		((Control)(object)chkPrintForEach).Location = new Point(596, 114);
		((Control)(object)chkPrintForEach).Name = "chkPrintForEach";
		chkPrintForEach.set_OffText("NO");
		chkPrintForEach.set_OnText("YES");
		((Control)(object)chkPrintForEach).Size = new Size(58, 32);
		((Control)(object)chkPrintForEach).TabIndex = 273;
		((Control)(object)chkPrintForEach).Tag = "";
		chkPrintForEach.set_ToggleStateMode((ToggleStateMode)1);
		chkPrintForEach.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkPrintForEach).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkPrintForEach).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkPrintForEach).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintForEach).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintForEach).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintForEach).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkPrintForEach).GetChildAt(0).GetChildAt(0)).set_Text("YES");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkPrintForEach).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label13.BackColor = Color.FromArgb(132, 146, 146);
		label13.Font = new Font("Microsoft Sans Serif", 12f);
		label13.ForeColor = SystemColors.ButtonFace;
		label13.ImeMode = ImeMode.NoControl;
		label13.Location = new Point(453, 114);
		label13.Margin = new Padding(2, 0, 2, 0);
		label13.Name = "label13";
		label13.Padding = new Padding(3, 0, 0, 0);
		label13.Size = new Size(142, 33);
		label13.TabIndex = 272;
		label13.Text = "Print For Each Qty";
		label13.TextAlign = ContentAlignment.MiddleLeft;
		ddlPrintItemQtyGreater.BackColor = Color.White;
		ddlPrintItemQtyGreater.DisplayMember = "en-US,fr-CA";
		ddlPrintItemQtyGreater.DrawMode = DrawMode.OwnerDrawVariable;
		ddlPrintItemQtyGreater.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlPrintItemQtyGreater.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlPrintItemQtyGreater.ForeColor = Color.FromArgb(40, 40, 40);
		ddlPrintItemQtyGreater.FormattingEnabled = true;
		ddlPrintItemQtyGreater.ItemHeight = 28;
		ddlPrintItemQtyGreater.Items.AddRange(new object[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
		ddlPrintItemQtyGreater.Location = new Point(452, 147);
		ddlPrintItemQtyGreater.Margin = new Padding(4, 5, 4, 5);
		ddlPrintItemQtyGreater.MinimumSize = new Size(50, 0);
		ddlPrintItemQtyGreater.Name = "ddlPrintItemQtyGreater";
		ddlPrintItemQtyGreater.Size = new Size(59, 34);
		ddlPrintItemQtyGreater.TabIndex = 276;
		ddlPrintItemQtyGreater.Tag = "print_kitchen_copy";
		ddlPrintItemQtyGreater.ValueMember = "en-US,fr-CA";
		label14.BackColor = Color.FromArgb(132, 146, 146);
		label14.Font = new Font("Microsoft Sans Serif", 12f);
		label14.ForeColor = SystemColors.ButtonFace;
		label14.ImeMode = ImeMode.NoControl;
		label14.Location = new Point(197, 148);
		label14.Margin = new Padding(2, 0, 2, 0);
		label14.Name = "label14";
		label14.Padding = new Padding(3, 0, 0, 0);
		label14.Size = new Size(255, 33);
		label14.TabIndex = 275;
		label14.Text = "Print if Item Qty Greater or Equal";
		label14.TextAlign = ContentAlignment.MiddleLeft;
		lblHideEachQty.BackColor = Color.Gray;
		lblHideEachQty.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblHideEachQty.ForeColor = Color.White;
		lblHideEachQty.ImeMode = ImeMode.NoControl;
		lblHideEachQty.Location = new Point(453, 114);
		lblHideEachQty.Name = "lblHideEachQty";
		lblHideEachQty.Padding = new Padding(5, 0, 0, 0);
		lblHideEachQty.Size = new Size(202, 33);
		lblHideEachQty.TabIndex = 271;
		lblHideEachQty.TextAlign = ContentAlignment.MiddleLeft;
		label6.BackColor = Color.Gray;
		label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		label6.ForeColor = Color.White;
		label6.ImeMode = ImeMode.NoControl;
		label6.Location = new Point(512, 148);
		label6.Name = "label6";
		label6.Padding = new Padding(5, 0, 0, 0);
		label6.Size = new Size(143, 33);
		label6.TabIndex = 277;
		label6.TextAlign = ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(656, 369);
		base.Controls.Add(label6);
		base.Controls.Add(ddlPrintItemQtyGreater);
		base.Controls.Add(label14);
		base.Controls.Add(lblHideEachQty);
		base.Controls.Add((Control)(object)chkPrintForEach);
		base.Controls.Add(label13);
		base.Controls.Add(btnSetOrderType);
		base.Controls.Add(lblChitFont);
		base.Controls.Add(lblDisplayFont);
		base.Controls.Add(label12);
		base.Controls.Add(label11);
		base.Controls.Add(label10);
		base.Controls.Add(ddlPaperSize);
		base.Controls.Add(pjuWniyana);
		base.Controls.Add(label9);
		base.Controls.Add((Control)(object)chkSendStation);
		base.Controls.Add(label8);
		base.Controls.Add(label7);
		base.Controls.Add((Control)(object)chkAutoPrint);
		base.Controls.Add(label5);
		base.Controls.Add(lblPrinterName);
		base.Controls.Add(btnSelectPrinter);
		base.Controls.Add((Control)(object)chkEnablePrint);
		base.Controls.Add(label4);
		base.Controls.Add(ddlPrintCopies);
		base.Controls.Add(label3);
		base.Controls.Add(btnDelete);
		base.Controls.Add(btnAddNew);
		base.Controls.Add(btnUpdate);
		base.Controls.Add((Control)(object)txtName);
		base.Controls.Add(label2);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(ddlStations);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmManageStations";
		base.Opacity = 1.0;
		Text = "frmManageStations";
		base.Load += frmManageStations_Load;
		base.Controls.SetChildIndex(lblHeaderTitle, 0);
		base.Controls.SetChildIndex(pictureBox1, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(ddlStations, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Name, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex((Control)(object)txtName, 0);
		base.Controls.SetChildIndex(btnUpdate, 0);
		base.Controls.SetChildIndex(btnAddNew, 0);
		base.Controls.SetChildIndex(btnDelete, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(ddlPrintCopies, 0);
		base.Controls.SetChildIndex(label4, 0);
		base.Controls.SetChildIndex((Control)(object)chkEnablePrint, 0);
		base.Controls.SetChildIndex(btnSelectPrinter, 0);
		base.Controls.SetChildIndex(lblPrinterName, 0);
		base.Controls.SetChildIndex(label5, 0);
		base.Controls.SetChildIndex((Control)(object)chkAutoPrint, 0);
		base.Controls.SetChildIndex(label7, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex((Control)(object)chkSendStation, 0);
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(pjuWniyana, 0);
		base.Controls.SetChildIndex(ddlPaperSize, 0);
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(label11, 0);
		base.Controls.SetChildIndex(label12, 0);
		base.Controls.SetChildIndex(lblDisplayFont, 0);
		base.Controls.SetChildIndex(lblChitFont, 0);
		base.Controls.SetChildIndex(btnSetOrderType, 0);
		base.Controls.SetChildIndex(label13, 0);
		base.Controls.SetChildIndex((Control)(object)chkPrintForEach, 0);
		base.Controls.SetChildIndex(lblHideEachQty, 0);
		base.Controls.SetChildIndex(label14, 0);
		base.Controls.SetChildIndex(ddlPrintItemQtyGreater, 0);
		base.Controls.SetChildIndex(label6, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)chkEnablePrint).EndInit();
		((ISupportInitialize)chkAutoPrint).EndInit();
		((ISupportInitialize)chkSendStation).EndInit();
		((ISupportInitialize)chkPrintForEach).EndInit();
		ResumeLayout(performLayout: false);
	}
}
