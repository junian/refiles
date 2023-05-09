using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public static class MailHelpers
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int AppointmentId;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public int AppointmentId;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	public static void SendSmsViaAppointment(string type, int AppointmentId, string phoneNumber, string name)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.AppointmentId = AppointmentId;
		if (CS_0024_003C_003E8__locals0.AppointmentId != 0)
		{
			if (string.IsNullOrEmpty(phoneNumber))
			{
				new frmMessageBox("Please add a phone number for this customer.", "Phone Number Blank.").ShowDialog();
			}
			else
			{
				if (new frmMessageBox("Are you sure you want to send text to " + name + " - " + phoneNumber + "?", "Send SMS", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
				{
					return;
				}
				GClass6 gClass = new GClass6();
				Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == CS_0024_003C_003E8__locals0.AppointmentId).FirstOrDefault();
				if (appointment == null)
				{
					if (type == "reservation")
					{
						new frmMessageBox("Reservation does not exist, please try saving the reservation again.", "Save Reservation").ShowDialog();
					}
					else
					{
						new frmMessageBox("Wait list customer does not exist, please try saving the customer again.", "Save Customer").ShowDialog();
					}
					return;
				}
				if (appointment.SMSSent)
				{
					new frmMessageBox("Text Message was already sent to this customer.", "SMS Already Sent").ShowDialog();
					return;
				}
				CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
				if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
				{
					if (!string.IsNullOrEmpty(appointment.CustomerCell))
					{
						string token = SyncMethods.GetToken();
						if (token == string.Empty)
						{
							new frmMessageBox("Invalid API key, please add the correct cloudsync API key.", "SMS API Key Error").ShowDialog();
							return;
						}
						string empty = string.Empty;
						if (NotificationMethods.SendSMS(message: ((!(type == "reservation")) ? ("Friendly reminder from " + companySetup.Name + ", please return to the restaurant as your table is now ready. *Do not reply to this message. Please call " + companySetup.Phone + " for any changes.") : (Resources.Reminder + companySetup.Name + Resources._reservation_tomorrow_at_APPOI + companySetup.Phone + Resources._if_you_need_to_change_or_canc)).Replace("{APPOINTMENT_DATE}", appointment.StartDateTime.ToShortDateString()).Replace("{APPOINTMENT_TIME}", appointment.StartDateTime.ToShortTimeString()), token: token, recipient_number: appointment.CustomerCell))
						{
							appointment.SMSSent = true;
							new frmMessageBox("Text Message Sent!", "SMS sent").ShowDialog();
						}
						else
						{
							appointment.SMSSent = false;
							new frmMessageBox("Text Message NOT sent! Please input a valid phone number.", "SMS ERROR.").ShowDialog();
						}
						Helper.SubmitChangesWithCatch(gClass);
					}
					else
					{
						new frmMessageBox("Please save a phone number for this customer first.", "SMS Error").ShowDialog();
					}
				}
				else
				{
					new frmMessageBox("You do not have SMS subcription for this location.  Please contact Hippos if you wish to enable SMS features.", "SMS ERROR.").ShowDialog();
				}
			}
		}
		else
		{
			new frmMessageBox("Please save before sending a text message.", "Save Customer").ShowDialog();
		}
	}

	public static void SendEmailViaAppointment(string type, int AppointmentId, string email, string name)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.AppointmentId = AppointmentId;
		if (CS_0024_003C_003E8__locals0.AppointmentId != 0)
		{
			GClass6 gClass = new GClass6();
			Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == CS_0024_003C_003E8__locals0.AppointmentId).FirstOrDefault();
			if (appointment == null)
			{
				if (type == "reservation")
				{
					new frmMessageBox("Reservation does not exist, please try saving the reservation again.", "Save Reservation").ShowDialog();
				}
				else
				{
					new frmMessageBox("Wait list customer does not exist, please save again the customer.", "Save customer").ShowDialog();
				}
			}
			else if (appointment.CustomerEmail != email)
			{
				new frmMessageBox("Please save the Customer data first before sending.", "Save customer").ShowDialog();
			}
			else if (appointment.EmailSent)
			{
				new frmMessageBox("Email is already sent to this customer.", "Email already sent").ShowDialog();
			}
			else if (string.IsNullOrEmpty(appointment.CustomerEmail))
			{
				new frmMessageBox("Please add an email for this customer.", "Email Blank.").ShowDialog();
			}
			else
			{
				if (new frmMessageBox("Are you sure you want to send an email to " + appointment.CustomerName + " - " + appointment.CustomerEmail + "?", "Send EMAIL", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
				{
					return;
				}
				CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
				if (!string.IsNullOrEmpty(appointment.CustomerEmail))
				{
					string subject;
					string text;
					if (type == "reservation")
					{
						subject = Resources.Reservation_Reminder_for + companySetup.Name;
						text = Resources.This_is_a_friendly_reminder_fr + companySetup.Name + Resources._that_you_have_a_reservation_t + appointment.StartDateTime.ToShortTimeString() + Resources._br_br_Please_call + companySetup.Phone + Resources._if_you_need_to_cancel_or_chan + companySetup.Name;
					}
					else
					{
						subject = "Wait list UPDATE for " + companySetup.Name;
						text = "Friendly reminder from " + companySetup.Name + ", please return to the restaurant as your table is now ready. *Do not reply to this message. Please call " + companySetup.Phone + " for any changes.";
					}
					string text2 = NotificationMethods.sendEmail(NotificationMethods.GetSMTPSettings(), appointment.CustomerEmail, subject, text.Replace("{APPOINTMENT_DATE}", appointment.StartDateTime.ToShortDateString()).Replace("{APPOINTMENT_TIME}", appointment.StartDateTime.ToShortTimeString()));
					if (text2 == "Mail Sent.")
					{
						appointment.EmailSent = true;
						new frmMessageBox("Email Sent!", "EMAIL sent").ShowDialog();
					}
					else
					{
						appointment.EmailSent = false;
						new frmMessageBox(text2, "EMAIL error.").ShowDialog();
					}
					Helper.SubmitChangesWithCatch(gClass);
				}
				else
				{
					new frmMessageBox("Please save the Email Address for this customer first.", "Email Error").ShowDialog();
				}
			}
		}
		else
		{
			new frmMessageBox("Please save the Customer data first before sending.", "Save customer").ShowDialog();
		}
	}

	public static void SendSMSOrderNotification(string phoneNumber, string name, string OrderNumber)
	{
		if (string.IsNullOrEmpty(phoneNumber))
		{
			new frmMessageBox("Please add a phone number for this customer.", "Phone Number Blank.").ShowDialog();
		}
		else
		{
			if (new frmMessageBox("Are you sure you want to send text to " + name + " - " + phoneNumber + "?", "Send SMS", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
			if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
			{
				if (!string.IsNullOrEmpty(phoneNumber))
				{
					string token = SyncMethods.GetToken();
					if (token == string.Empty)
					{
						new frmMessageBox("Invalid API key, please add the correct cloudsync API key.", "SMS API Key Error").ShowDialog();
						return;
					}
					string message = "Friendly reminder from " + companySetup.Name + ", please return to the restaurant as your Order# " + OrderNumber + " is now ready. *Do not reply to this message. Please call " + companySetup.Phone + " for any changes.";
					if (NotificationMethods.SendSMS(token, phoneNumber, message))
					{
						new frmMessageBox("Text Message Sent!", "SMS sent").ShowDialog();
					}
					else
					{
						new frmMessageBox("Text Message NOT sent! Please input a valid phone number.", "SMS ERROR.").ShowDialog();
					}
				}
				else
				{
					new frmMessageBox("Please save a phone number for this customer first.", "SMS Error").ShowDialog();
				}
			}
			else
			{
				new frmMessageBox("You do not have SMS subcription for this location.  Please contact Hippos if you wish to enable SMS features.", "SMS ERROR.").ShowDialog();
			}
		}
	}
}
