using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;

namespace CorePOS;

public class frmSelectLanguage : frmMasterForm
{
	public string LanguageSelected;

	private IContainer icontainer_1;

	private Label label9;

	private FlowLayoutPanel flowLayoutPanel1;

	public frmSelectLanguage()
	{
		Class26.Ggkj0JxzN9YmC();
		LanguageSelected = "en-US";
		// base._002Ector();
		wiCoalqOlA();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("primary_language");
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("secondary_language");
		string text = "English";
		text = ((settingValueByKey == "fr-CA") ? "French" : ((!(settingValueByKey == "es-US")) ? "English" : "Spanish"));
		Button button = new Button();
		button.Name = settingValueByKey;
		button.Text = text;
		button.Size = new Size(251, 82);
		button.Margin = new Padding(0, 1, 0, 0);
		button.BackColor = Color.FromArgb(50, 119, 155);
		button.ForeColor = Color.White;
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderSize = 0;
		button.Click += method_3;
		flowLayoutPanel1.Controls.Add(button);
		string text2 = "English";
		text2 = ((settingValueByKey2 == "fr-CA") ? "French" : ((!(settingValueByKey2 == "es-US")) ? "English" : "Spanish"));
		Button button2 = new Button();
		button2.Name = settingValueByKey2;
		button2.Text = text2;
		button2.Size = new Size(251, 82);
		button2.Margin = new Padding(0, 1, 0, 0);
		button2.BackColor = Color.FromArgb(50, 119, 155);
		button2.ForeColor = Color.White;
		button2.FlatStyle = FlatStyle.Flat;
		button2.FlatAppearance.BorderSize = 0;
		button2.Click += method_3;
		flowLayoutPanel1.Controls.Add(button2);
	}

	private void method_3(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		LanguageSelected = button.Name;
		BploYwlqKQ();
		base.DialogResult = DialogResult.OK;
	}

	private void BploYwlqKQ()
	{
		CultureInfo cultureInfo = new CultureInfo(LanguageSelected);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void wiCoalqOlA()
	{
		label9 = new Label();
		flowLayoutPanel1 = new FlowLayoutPanel();
		SuspendLayout();
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(1, 3);
		label9.Name = "label9";
		label9.Size = new Size(428, 46);
		label9.TabIndex = 102;
		label9.Text = "SELECT LANGUAGE";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		flowLayoutPanel1.Location = new Point(88, 107);
		flowLayoutPanel1.Margin = new Padding(0);
		flowLayoutPanel1.Name = "flowLayoutPanel1";
		flowLayoutPanel1.Size = new Size(251, 181);
		flowLayoutPanel1.TabIndex = 103;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(429, 433);
		base.Controls.Add(flowLayoutPanel1);
		base.Controls.Add(label9);
		base.Name = "frmSelectLanguage";
		base.Opacity = 1.0;
		Text = "frmSelectLanguage";
		ResumeLayout(performLayout: false);
	}
}
