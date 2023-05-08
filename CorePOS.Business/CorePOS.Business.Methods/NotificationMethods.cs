using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CrashGrabLib;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public class NotificationMethods
{
	public static bool SendSMS(string token, string recipient_number, string message)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/sms/sms");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				SMSQueueMsgModel obj = new SMSQueueMsgModel
				{
					token = token,
					message = message,
					recipient_number = recipient_number
				};
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)obj, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			if (streamReader.ReadToEnd().ToString().Contains("Success"))
			{
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static string sendEmail(SMTPSettings settings, string to, string subject, string message, List<string> attachments = null)
	{
		string string_ = "<html><body><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" height=\"100%\" width=\"100%\"><tbody><tr><td align=\"center\" valign=\"top\"><div id=\"template_header_image\"><p style=\"margin-top: 0;\"></p></div><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" id=\"template_container\" style=\"box-shadow: 0 1px 4px rgba(0,0,0,0.1) !important; background-color: #fdfdfd; border: 0 #fdfdfd; border-radius: 3px !important;\"><tbody><tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" id=\"template_body\"><tbody><tr><td valign=\"top\" id=\"body_content\" style=\"background-color: #fdfdfd;\"><table border=\"0\" cellpadding=\"20\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td valign=\"top\" style=\"padding: 48px;\"><div id=\"body_content_inner\" style=\"color: #737373; font-family: &quot;Helvetica Neue&quot;, Helvetica, Roboto, Arial, sans-serif; font-size: 14px; line-height: 150%; text-align: left;\"><p style=\"margin: 0 0 16px;\"> " + message + "</p></div></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" width=\"600\" id=\"template_footer\"><tbody><tr><td valign=\"top\" style=\"padding: 0; -webkit-border-radius: 6px;\"><table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td colspan=\"2\" valign=\"middle\" id=\"credit\" style=\"padding: 20px 20px 20px 20px; -webkit-border-radius: 6px; border: 0; color: #737373; font-family: Arial; font-size: 12px; line-height: 100%; text-align: center;\"><br/><p>Powered by Hippos Software Inc. - https://www.hipposhq.com</p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
		new GClass6();
		if (!string.IsNullOrEmpty(settings.server) && !string.IsNullOrEmpty(settings.username))
		{
			return smethod_0(settings.server, settings.port, settings.username, settings.password, settings.sslEnable, settings.username, to, null, null, subject, string_, bool_1: true, attachments);
		}
		return "SMTP info invalid.  Please check SMTP settings in the Settings table.";
	}

	public static void sendError_old(string message)
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

	public static void sendCrash(string version, string systemInfo, Exception error, bool isSilent = true)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.error = error;
		CS_0024_003C_003E8__locals0.version = version;
		CS_0024_003C_003E8__locals0.systemInfo = systemInfo;
		CS_0024_003C_003E8__locals0.isSilent = isSilent;
		try
		{
			DebugMethods.ShowExceptionTextFile(CS_0024_003C_003E8__locals0.error);
		}
		catch
		{
		}
		new Thread((ThreadStart)delegate
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			try
			{
				CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
				string text = string.Empty;
				if (companySetup != null)
				{
					text = companySetup.Name;
				}
				Crash val = new Crash();
				val.set_InnerException((CS_0024_003C_003E8__locals0.error.InnerException == null) ? string.Empty : CS_0024_003C_003E8__locals0.error.InnerException.Message);
				val.set_Source((CS_0024_003C_003E8__locals0.error.Source != null) ? CS_0024_003C_003E8__locals0.error.Source : string.Empty);
				val.set_StackTrace((CS_0024_003C_003E8__locals0.error.StackTrace != null) ? CS_0024_003C_003E8__locals0.error.StackTrace.Replace("\\", "/") : string.Empty);
				val.set_TargetSite((CS_0024_003C_003E8__locals0.error.TargetSite != null) ? CS_0024_003C_003E8__locals0.error.TargetSite.Name : string.Empty);
				if (CS_0024_003C_003E8__locals0.error == null)
				{
					throw new Exception("Error Exception was NULL");
				}
				string path = AppDomain.CurrentDomain.BaseDirectory + "\\DebugMode.txt";
				AddCrash.AddCrashFunction("rmEUNuAw0tEBRYQLnPcC", string.IsNullOrEmpty(text) ? BrandingTerms.SoftwareName : (BrandingTerms.SoftwareName + " - " + text), string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.version) ? CorePOS.Data.Properties.Settings.Default["AppVersion"].ToString() : CS_0024_003C_003E8__locals0.version, CS_0024_003C_003E8__locals0.systemInfo, File.Exists(path) ? ("[*** DEBUG MODE ***] " + CS_0024_003C_003E8__locals0.error.Message.Replace("\\", "/")) : ((CS_0024_003C_003E8__locals0.isSilent ? "[***SILENT LOG***] " : string.Empty) + CS_0024_003C_003E8__locals0.error.Message.Replace("\\", "/")), val);
			}
			catch (Exception ex)
			{
				sendError_old(ex.Message + "\r[TRACE:]" + ex.StackTrace);
			}
		}).Start();
	}

	public static void sendCrashStringOnly(string version, string systemInfo, string error)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.error = error;
		_003C_003Ec__DisplayClass4_.version = version;
		_003C_003Ec__DisplayClass4_.systemInfo = systemInfo;
		new Thread((ThreadStart)delegate
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			try
			{
				CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
				string text = string.Empty;
				if (companySetup != null)
				{
					text = companySetup.Name;
				}
				Crash val = new Crash();
				val.set_InnerException(_003C_003Ec__DisplayClass4_.error);
				val.set_Source(_003C_003Ec__DisplayClass4_.error);
				val.set_StackTrace("");
				val.set_TargetSite("");
				if (_003C_003Ec__DisplayClass4_.error == null)
				{
					throw new Exception("Error Exception was NULL");
				}
				string path = AppDomain.CurrentDomain.BaseDirectory + "\\DebugMode.txt";
				AddCrash.AddCrashFunction("rmEUNuAw0tEBRYQLnPcC", string.IsNullOrEmpty(text) ? BrandingTerms.SoftwareName : (BrandingTerms.SoftwareName + " - " + text), string.IsNullOrEmpty(_003C_003Ec__DisplayClass4_.version) ? CorePOS.Data.Properties.Settings.Default["AppVersion"].ToString() : _003C_003Ec__DisplayClass4_.version, _003C_003Ec__DisplayClass4_.systemInfo, File.Exists(path) ? ("[*** DEBUG MODE ***] " + _003C_003Ec__DisplayClass4_.error) : _003C_003Ec__DisplayClass4_.error, val);
			}
			catch (Exception ex)
			{
				sendError_old(ex.Message + "\r[TRACE:]" + ex.StackTrace);
			}
		}).Start();
	}

	private static string smethod_0(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3, string string_4, string string_5, string string_6, string string_7, string string_8, bool bool_1, List<string> list_0 = null)
	{
		try
		{
			if (string_4 != null && string_4 != string.Empty && string_3 != null && string_3 != string.Empty)
			{
				MailMessage mailMessage = new MailMessage();
				MailAddress mailAddress2 = (mailMessage.From = new MailAddress(string_3));
				if (list_0 != null)
				{
					foreach (string item4 in list_0)
					{
						Attachment attachment = new Attachment(item4, "application/octet-stream");
						ContentDisposition contentDisposition = attachment.ContentDisposition;
						contentDisposition.CreationDate = File.GetCreationTime(item4);
						contentDisposition.ModificationDate = File.GetLastWriteTime(item4);
						contentDisposition.ReadDate = File.GetLastAccessTime(item4);
						mailMessage.Attachments.Add(attachment);
					}
				}
				string[] array = SplitSemiCloneChar(string_4);
				for (int i = 0; i < array.Length; i++)
				{
					MailAddress item = new MailAddress(array[i]);
					mailMessage.To.Add(item);
				}
				if (string_5 != null && string_5 != string.Empty)
				{
					array = SplitSemiCloneChar(string_5);
					for (int i = 0; i < array.Length; i++)
					{
						MailAddress item2 = new MailAddress(array[i]);
						mailMessage.CC.Add(item2);
					}
				}
				if (string_6 != null && string_6 != string.Empty)
				{
					array = SplitSemiCloneChar(string_6);
					for (int i = 0; i < array.Length; i++)
					{
						MailAddress item3 = new MailAddress(array[i]);
						mailMessage.Bcc.Add(item3);
					}
				}
				mailMessage.IsBodyHtml = bool_1;
				mailMessage.Subject = string_7;
				mailMessage.Body = string_8;
				if (string_0 != null && string_0 != string.Empty)
				{
					SmtpClient smtpClient = new SmtpClient(string_0, int_0);
					smtpClient.UseDefaultCredentials = false;
					smtpClient.Credentials = new NetworkCredential(string_1, string_2);
					smtpClient.EnableSsl = bool_0;
					smtpClient.Timeout = 10000;
					smtpClient.Send(mailMessage);
					return "Mail Sent.";
				}
				return Resources.Mail_Smtpserver_can_t_be_empty;
			}
			return Resources.Mail_address_from_and_to_can_t;
		}
		catch (Exception ex)
		{
			return "Error: " + ex.Message;
		}
	}

	public static string[] SplitSemiCloneChar(string text)
	{
		if (text == null && !(text != string.Empty))
		{
			return null;
		}
		return text.Split(';');
	}

	public static SMTPSettings GetSMTPSettings()
	{
		GClass6 gClass = new GClass6();
		SMTPSettings sMTPSettings = new SMTPSettings();
		IQueryable<Setting> source = gClass.Settings.Where((Setting s) => s.Key.Contains("smtp"));
		sMTPSettings.server = source.Where((Setting s) => s.Key.Equals("smtp_server")).FirstOrDefault().Value;
		sMTPSettings.port = Convert.ToInt32(source.Where((Setting s) => s.Key.Equals("smtp_port")).FirstOrDefault().Value);
		sMTPSettings.username = source.Where((Setting s) => s.Key.Equals("smtp_username")).FirstOrDefault().Value;
		string text = StringCipher.Decrypt(source.Where((Setting s) => s.Key.Equals("smtp_password")).FirstOrDefault().Value, "DigitalCraftHipPOS");
		if (text == "false")
		{
			sMTPSettings.password = source.Where((Setting s) => s.Key.Equals("smtp_password")).FirstOrDefault().Value;
			string value = StringCipher.Encrypt(sMTPSettings.password, "DigitalCraftHipPOS");
			source.Where((Setting s) => s.Key.Equals("smtp_password")).FirstOrDefault().Value = value;
			try
			{
				Helper.SubmitChangesWithCatch(gClass);
			}
			catch (Exception ex)
			{
				sendError_old(ex.Message);
				sMTPSettings.password = "";
			}
		}
		else
		{
			sMTPSettings.password = text;
		}
		sMTPSettings.sslEnable = Convert.ToBoolean(source.Where((Setting s) => s.Key.Equals("smtp_use_ssl")).FirstOrDefault().Value);
		return sMTPSettings;
	}

	public NotificationMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
