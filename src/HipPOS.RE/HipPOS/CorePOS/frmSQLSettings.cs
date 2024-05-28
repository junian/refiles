using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Properties;

namespace CorePOS;

public class frmSQLSettings : frmMasterForm
{
	private string ErqFkjeTrUK;

	private IContainer icontainer_1;

	private Label label2;

	private TextBox txtCatelog;

	private Label label12;

	private Label label3;

	private TextBox txtPassword;

	private Label BajFklrQgmw;

	private TextBox txtUsername;

	private Label label4;

	private TextBox txtSqlServer;

	internal Button btnCancel;

	internal Button btnSave;

	public frmSQLSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		ErqFkjeTrUK = AppDomain.CurrentDomain.BaseDirectory + "\\connectionstring.txt";
		// base._002Ector();
		InitializeComponent_1();
		method_3();
	}

	private void method_3()
	{
		try
		{
			string text = string.Empty;
			if (File.Exists(ErqFkjeTrUK))
			{
				using StreamReader streamReader = new StreamReader(ErqFkjeTrUK);
				while (streamReader.Peek() >= 0)
				{
					text = streamReader.ReadLine();
				}
			}
			StringCipher.Decrypt(text, "DigitalCraftHipPOS");
			if (text.Contains("{%APPLICATION_PATH%}\\"))
			{
				return;
			}
			string[] array = text.Split(';');
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].IndexOf("=") != -1)
				{
					dictionary.Add(array[i].Substring(0, array[i].IndexOf("=")), array[i].Substring(array[i].IndexOf("=") + 1, array[i].Length - array[i].IndexOf("=") - 1));
				}
			}
			txtSqlServer.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "Data Source").Value;
			txtCatelog.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "Initial Catalog").Value;
			if (string.IsNullOrEmpty(txtCatelog.Text))
			{
				txtCatelog.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "AttachDbFilename").Value;
			}
			txtCatelog.Text = txtCatelog.Text.Replace("{%MODE%}", string.Empty);
			txtUsername.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "User ID").Value;
			if (string.IsNullOrEmpty(txtUsername.Text))
			{
				txtUsername.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "Integrated Security").Value;
			}
			txtPassword.Text = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Key == "Password").Value;
		}
		catch (Exception)
		{
			txtSqlServer.Text = string.Empty;
			txtCatelog.Text = string.Empty;
			txtUsername.Text = string.Empty;
			txtPassword.Text = string.Empty;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (!(txtCatelog.Text == "") && !(txtPassword.Text == "") && !(txtSqlServer.Text == "") && !(txtUsername.Text == ""))
		{
			string text = "Data Source=" + txtSqlServer.Text.Trim();
			if (txtCatelog.Text.IndexOf(".mdf") == txtCatelog.Text.Length - 4)
			{
				string text2 = ";AttachDbFilename=" + txtCatelog.Text.Substring(0, txtCatelog.Text.Length - 4) + "{%MODE%}.mdf";
				string text3 = ";Integrated Security=" + txtUsername.Text.Trim();
				string plainText = text + text2 + text3;
				File.WriteAllText(ErqFkjeTrUK, StringCipher.Encrypt(plainText, "DigitalCraftHipPOS"));
			}
			else
			{
				string text4 = ";Initial Catalog=" + txtCatelog.Text.Trim().Replace("{%MODE%}", string.Empty) + "{%MODE%}";
				string text5 = ";Persist Security Info=True";
				string text6 = ";User ID=" + txtUsername.Text.Trim();
				string text7 = ";Password=" + txtPassword.Text.Trim();
				string plainText2 = text + text4 + text5 + text6 + text7;
				File.WriteAllText(ErqFkjeTrUK, StringCipher.Encrypt(plainText2, "DigitalCraftHipPOS"));
			}
			if (new frmMessageBox(Resources.SQL_Server_settings_saved_Plea).ShowDialog(this) == DialogResult.OK)
			{
				Application.Exit();
			}
		}
		else
		{
			new frmMessageBox("Please fill in all text fields.").ShowDialog();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Application.Exit();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSQLSettings));
		label2 = new Label();
		txtCatelog = new TextBox();
		label12 = new Label();
		label3 = new Label();
		txtPassword = new TextBox();
		BajFklrQgmw = new Label();
		txtUsername = new TextBox();
		label4 = new Label();
		txtSqlServer = new TextBox();
		btnCancel = new Button();
		btnSave = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(1, 110, 211);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		txtCatelog.BackColor = Color.White;
		txtCatelog.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(txtCatelog, "txtCatelog");
		txtCatelog.Name = "txtCatelog";
		label12.BackColor = Color.FromArgb(53, 73, 94);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(27, 188, 157);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		txtPassword.BackColor = Color.White;
		txtPassword.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(txtPassword, "txtPassword");
		txtPassword.Name = "txtPassword";
		componentResourceManager.ApplyResources(BajFklrQgmw, "label5");
		BajFklrQgmw.BackColor = Color.FromArgb(53, 152, 220);
		BajFklrQgmw.ForeColor = Color.White;
		BajFklrQgmw.Name = "label5";
		txtUsername.BackColor = Color.White;
		txtUsername.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(txtUsername, "txtUsername");
		txtUsername.Name = "txtUsername";
		componentResourceManager.ApplyResources(label4, "label4");
		label4.BackColor = Color.FromArgb(156, 89, 184);
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		txtSqlServer.BackColor = Color.White;
		txtSqlServer.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(txtSqlServer, "txtSqlServer");
		txtSqlServer.Name = "txtSqlServer";
		btnCancel.BackColor = Color.FromArgb(193, 57, 43);
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(47, 204, 113);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label2);
		base.Controls.Add(txtCatelog);
		base.Controls.Add(label12);
		base.Controls.Add(label3);
		base.Controls.Add(txtPassword);
		base.Controls.Add(BajFklrQgmw);
		base.Controls.Add(txtUsername);
		base.Controls.Add(label4);
		base.Controls.Add(txtSqlServer);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSQLSettings";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
