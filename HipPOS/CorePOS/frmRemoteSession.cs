using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Properties;
using Microsoft.Win32;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmRemoteSession : frmMasterForm
{
	private IContainer icontainer_1;

	internal Button btnConnect;

	private RadTextBoxControl txtSessionID;

	private Label label1;

	internal Button btnShowKeyboard_SessionID;

	private Label label10;

	internal Button btnClose;

	public frmRemoteSession()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void txtSessionID_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowKeyboard_SessionID_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Session_ID, 0, 32, txtSessionID.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtSessionID.Text = MemoryLoadedObjects.Numpad.valueEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private string method_3()
	{
		string empty = string.Empty;
		RegistryKey registryKey = null;
		try
		{
			registryKey = Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", writable: false);
			if (registryKey == null)
			{
				registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http", writable: false);
			}
			if (registryKey != null)
			{
				empty = registryKey.GetValue(null).ToString().ToLower()
					.Replace("\"", "");
				if (!empty.EndsWith("exe"))
				{
					empty = empty.Substring(0, empty.LastIndexOf(".exe") + 4);
				}
				registryKey.Close();
				return empty;
			}
			return empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private void btnConnect_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtSessionID.Text))
		{
			new frmMessageBox(Resources.Please_input_a_session_ID).ShowDialog(this);
			return;
		}
		Process.Start("https://assist.zoho.com/assist-join?key=" + txtSessionID.Text + "&mode=manual&role=A");
		Close();
	}

	private void method_4(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRemoteSession));
		btnConnect = new Button();
		txtSessionID = new RadTextBoxControl();
		label1 = new Label();
		btnShowKeyboard_SessionID = new Button();
		label10 = new Label();
		btnClose = new Button();
		((ISupportInitialize)txtSessionID).BeginInit();
		SuspendLayout();
		btnConnect.BackColor = Color.FromArgb(77, 174, 225);
		btnConnect.FlatAppearance.BorderColor = Color.Sienna;
		btnConnect.FlatAppearance.BorderSize = 0;
		btnConnect.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnConnect, "btnConnect");
		btnConnect.ForeColor = Color.White;
		btnConnect.Name = "btnConnect";
		btnConnect.UseVisualStyleBackColor = false;
		btnConnect.Click += btnConnect_Click;
		componentResourceManager.ApplyResources(txtSessionID, "txtSessionID");
		txtSessionID.Name = "txtSessionID";
		txtSessionID.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSessionID.Click += txtSessionID_Click;
		((RadTextBoxControlElement)txtSessionID.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSessionID.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnShowKeyboard_SessionID.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SessionID.DialogResult = DialogResult.OK;
		btnShowKeyboard_SessionID.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SessionID.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SessionID, "btnShowKeyboard_SessionID");
		btnShowKeyboard_SessionID.ForeColor = Color.White;
		btnShowKeyboard_SessionID.Name = "btnShowKeyboard_SessionID";
		btnShowKeyboard_SessionID.UseVisualStyleBackColor = false;
		btnShowKeyboard_SessionID.Click += btnShowKeyboard_SessionID_Click;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnConnect);
		base.Controls.Add(txtSessionID);
		base.Controls.Add(label1);
		base.Controls.Add(btnShowKeyboard_SessionID);
		base.Controls.Add(label10);
		base.Controls.Add(btnClose);
		base.Name = "frmRemoteSession";
		base.Opacity = 1.0;
		((ISupportInitialize)txtSessionID).EndInit();
		ResumeLayout(performLayout: false);
	}
}
