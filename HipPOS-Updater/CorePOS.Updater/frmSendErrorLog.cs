using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using CrashGrabLib;
using Newtonsoft.Json;

namespace CorePOS.Updater;

public class frmSendErrorLog : Form
{
	private Exception exception_0;

	private IContainer icontainer_0;

	private Label lblMessage;

	internal Button btnCancel;

	internal Button btnSave;

	private PictureBox pictureBox2;

	public frmSendErrorLog(ThreadExceptionEventArgs e)
	{
		Class13.FLcy5UmzUUEfT();
		base._002Ector();
		InitializeComponent();
		Text = "Hippos Restaurant";
		exception_0 = e.Exception;
	}

	public frmSendErrorLog(Exception e)
	{
		Class13.FLcy5UmzUUEfT();
		base._002Ector();
		InitializeComponent();
		Text = "Hippos Restaurant";
		exception_0 = e;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		sendCrash(Common.appVersion, Environment.OSVersion.VersionString, exception_0);
		MessageBox.Show("Error report has been sent. Thank you!");
		Application.Exit();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	public static void sendCrash(string version, string systemInfo, Exception error)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		try
		{
			Crash val = new Crash();
			val.set_InnerException((error.InnerException == null) ? string.Empty : error.InnerException.Message.Replace("\\", "/").Replace("\"", ""));
			val.set_Source(error.Source.Replace("\\", "/").Replace("\"", ""));
			val.set_StackTrace(error.StackTrace.Replace("\\", "/").Replace("\"", ""));
			val.set_TargetSite(error.TargetSite.Name.Replace("\\", "/").Replace("\"", ""));
			if (error == null)
			{
				throw new Exception("Error Exception was NULL");
			}
			string text = AppDomain.CurrentDomain.BaseDirectory + "\\DebugMode.txt";
			if (File.Exists(text))
			{
				string text2 = "[Source] " + error.Source + Environment.NewLine;
				text2 = text2 + "[StackTrace] " + error.StackTrace + Environment.NewLine;
				text2 = text2 + "[Message] " + error.Message;
				File.WriteAllText(text, text2);
				Process.Start(text);
			}
			string text3 = error.Message.Replace("\\", "/").Replace("\"", "");
			AddCrash.AddCrashFunction("rmEUNuAw0tEBRYQLnPcC", "Hippos Updater.", Common.appVersion, systemInfo, File.Exists(text) ? ("[*** DEBUG MODE ***] " + text3) : text3, val);
		}
		catch (Exception)
		{
			sendError(error.Message + "\r[TRACE:]" + error.StackTrace);
		}
	}

	public static void sendError(string message)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		string requestUriString = "https://digitalcraft.hipchat.com/v2/room/3018177/notification?auth_token=hyLmu0X6S3QUFReqYUOAesHvUYXv5nGTkPhFPUml";
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				HipChatMsg obj = new HipChatMsg
				{
					color = "red",
					notify = true,
					message = "[HIPPOS-RESTAURANT]\r" + message,
					message_format = "text"
				};
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)obj, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			streamReader.ReadToEnd();
		}
		catch
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.Updater.frmSendErrorLog));
		this.lblMessage = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.btnSave = new System.Windows.Forms.Button();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.lblMessage, "lblMessage");
		this.lblMessage.Name = "lblMessage";
		this.btnCancel.BackColor = System.Drawing.Color.FromArgb(193, 57, 43);
		this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		componentResourceManager.ApplyResources(this.btnCancel, "btnCancel");
		this.btnCancel.ForeColor = System.Drawing.Color.White;
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnSave.BackColor = System.Drawing.Color.FromArgb(47, 204, 113);
		this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		componentResourceManager.ApplyResources(this.btnSave, "btnSave");
		this.btnSave.ForeColor = System.Drawing.Color.White;
		this.btnSave.Name = "btnSave";
		this.btnSave.UseVisualStyleBackColor = false;
		this.btnSave.Click += new System.EventHandler(btnSave_Click);
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnSave);
		base.Controls.Add(this.lblMessage);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSendErrorLog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
	}
}
