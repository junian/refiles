using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS.CommonForms;

public class frmFont : frmMasterForm
{
	private string string_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Class20 ddlColors;

	private Label label6;

	private Class20 ddlStyle;

	private Label label1;

	private Class20 ddlSize;

	private Label label2;

	internal Button btnSample;

	internal Button btnOK;

	internal Button button1;

	public frmFont(string type)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		string_0 = type;
	}

	private void frmFont_Load(object sender, EventArgs e)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add("Regular", 0);
		dictionary.Add("Bold", 1);
		dictionary.Add("Italic", 2);
		((RadDropDownList)ddlStyle).set_DisplayMember("Key");
		((RadDropDownList)ddlStyle).set_ValueMember("Value");
		((RadDropDownList)ddlStyle).set_DataSource((object)new BindingSource(dictionary, null));
		Dictionary<object, string> dictionary2 = HelperMethods.FontColors(Thread.CurrentThread.CurrentCulture.Name);
		((RadDropDownList)ddlColors).set_DisplayMember("Key");
		((RadDropDownList)ddlColors).set_ValueMember("Value");
		((RadDropDownList)ddlColors).set_DataSource((object)new BindingSource(dictionary2, null));
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		for (int i = 8; i <= 16; i++)
		{
			dictionary3.Add(i.ToString(), i.ToString());
		}
		((RadDropDownList)ddlSize).set_DisplayMember("Key");
		((RadDropDownList)ddlSize).set_ValueMember("Value");
		((RadDropDownList)ddlSize).set_DataSource((object)new BindingSource(dictionary3, null));
		if (string_0 == "items")
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals0.fontSetting = SettingsHelper.GetSettingFontStyleValues("font_size_item_groups_oe");
			((RadDropDownList)ddlStyle).set_SelectedValue((object)dictionary.FirstOrDefault((KeyValuePair<string, int> x) => x.Value == Convert.ToInt32(CS_0024_003C_003E8__locals0.fontSetting.Style)).Value);
			((RadDropDownList)ddlColors).set_SelectedValue((object)dictionary2.FirstOrDefault((KeyValuePair<object, string> x) => x.Value == CS_0024_003C_003E8__locals0.fontSetting.Color).Value);
			((RadDropDownList)ddlSize).set_SelectedValue((object)dictionary3.FirstOrDefault((KeyValuePair<string, string> x) => x.Value == CS_0024_003C_003E8__locals0.fontSetting.Size.ToString()).Value);
		}
	}

	private void method_3()
	{
		if (((RadDropDownList)ddlStyle).get_SelectedValue() != null && ((RadDropDownList)ddlSize).get_SelectedValue() != null && ((RadDropDownList)ddlColors).get_SelectedValue() != null)
		{
			FontStyle style = (FontStyle)Convert.ToInt32(((RadDropDownList)ddlStyle).get_SelectedValue());
			double num = Convert.ToDouble(((RadDropDownList)ddlSize).get_SelectedValue());
			btnSample.Font = new Font(btnSample.Font.FontFamily, (float)num, style);
			Color color = HelperMethods.GetColor(((RadDropDownList)ddlColors).get_SelectedValue().ToString());
			btnSample.ForeColor = color;
		}
	}

	private void ddlStyle_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_3();
	}

	private void ddlColors_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_3();
	}

	private void ddlSize_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_3();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnOK_Click(object sender, EventArgs e)
	{
		if (string_0 == "items")
		{
			SettingsHelper.SetSettingsFontStyleValues("font_size_item_groups_oe", ((RadDropDownList)ddlStyle).get_SelectedValue().ToString(), Convert.ToInt32(((RadDropDownList)ddlSize).get_SelectedValue()), ((RadDropDownList)ddlColors).get_SelectedValue().ToString());
			new NotificationLabel(this, "Saved", NotificationTypes.Success).Show();
		}
		base.DialogResult = DialogResult.None;
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
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmFont));
		lblTitle = new Label();
		ddlColors = new Class20();
		label6 = new Label();
		ddlStyle = new Class20();
		label1 = new Label();
		ddlSize = new Class20();
		label2 = new Label();
		btnSample = new Button();
		btnOK = new Button();
		button1 = new Button();
		((ISupportInitialize)ddlColors).BeginInit();
		((ISupportInitialize)ddlStyle).BeginInit();
		((ISupportInitialize)ddlSize).BeginInit();
		SuspendLayout();
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(ddlColors, "ddlColors");
		((Control)(object)ddlColors).BackColor = Color.White;
		((RadDropDownList)ddlColors).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlColors).set_EnableKineticScrolling(true);
		((Control)(object)ddlColors).Name = "ddlColors";
		((RadControl)ddlColors).set_ThemeName("Windows8");
		((RadDropDownList)ddlColors).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlColors_SelectedIndexChanged));
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(ddlStyle, "ddlStyle");
		((Control)(object)ddlStyle).BackColor = Color.White;
		((RadDropDownList)ddlStyle).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlStyle).set_EnableKineticScrolling(true);
		((Control)(object)ddlStyle).Name = "ddlStyle";
		((RadControl)ddlStyle).set_ThemeName("Windows8");
		((RadDropDownList)ddlStyle).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlStyle_SelectedIndexChanged));
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(ddlSize, "ddlSize");
		((Control)(object)ddlSize).BackColor = Color.White;
		((RadDropDownList)ddlSize).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlSize).set_EnableKineticScrolling(true);
		((Control)(object)ddlSize).Name = "ddlSize";
		((RadControl)ddlSize).set_ThemeName("Windows8");
		((RadDropDownList)ddlSize).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlSize_SelectedIndexChanged));
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(btnSample, "btnSample");
		btnSample.BackColor = Color.FromArgb(150, 166, 166);
		btnSample.FlatAppearance.BorderColor = Color.White;
		btnSample.FlatAppearance.BorderSize = 0;
		btnSample.FlatAppearance.MouseDownBackColor = Color.White;
		btnSample.ForeColor = Color.White;
		btnSample.Name = "btnSample";
		btnSample.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(btnOK, "btnOK");
		btnOK.BackColor = Color.FromArgb(80, 203, 116);
		btnOK.DialogResult = DialogResult.OK;
		btnOK.FlatAppearance.BorderColor = Color.White;
		btnOK.FlatAppearance.BorderSize = 0;
		btnOK.FlatAppearance.MouseDownBackColor = Color.White;
		btnOK.ForeColor = Color.White;
		btnOK.Name = "btnOK";
		btnOK.UseVisualStyleBackColor = false;
		btnOK.Click += btnOK_Click;
		componentResourceManager.ApplyResources(button1, "button1");
		button1.BackColor = Color.FromArgb(235, 107, 86);
		button1.DialogResult = DialogResult.OK;
		button1.FlatAppearance.BorderColor = Color.White;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = Color.White;
		button1.ForeColor = Color.White;
		button1.Name = "button1";
		button1.UseVisualStyleBackColor = false;
		button1.Click += button1_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(button1);
		base.Controls.Add(btnOK);
		base.Controls.Add(btnSample);
		base.Controls.Add((Control)(object)ddlSize);
		base.Controls.Add(label2);
		base.Controls.Add((Control)(object)ddlStyle);
		base.Controls.Add(label1);
		base.Controls.Add((Control)(object)ddlColors);
		base.Controls.Add(label6);
		base.Controls.Add(lblTitle);
		base.Name = "frmFont";
		base.Opacity = 1.0;
		base.Load += frmFont_Load;
		((ISupportInitialize)ddlColors).EndInit();
		((ISupportInitialize)ddlStyle).EndInit();
		((ISupportInitialize)ddlSize).EndInit();
		ResumeLayout(performLayout: false);
	}
}
