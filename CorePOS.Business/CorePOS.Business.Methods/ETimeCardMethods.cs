using System;
using System.IO;
using System.Linq;
using System.Net;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public class ETimeCardMethods
{
	public static StatusCodeResponseLocation GetLocationData(object token)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/location/GetLocationData");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject(token, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<StatusCodeResponseLocation>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new StatusCodeResponseLocation
			{
				code = 400,
				LocationID = string.Empty,
				AccountID = string.Empty,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static AccessTokenReponseObject PinAuthentication(AccessTokenRequestObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=login");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AccessTokenReponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new AccessTokenReponseObject
			{
				code = 400,
				access_token = string.Empty,
				empId = string.Empty,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static ClocksInOutReponseObject EmployeePunchInOut(HipposClockInOutRequestObject data, string type)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:24286/" + "/API/Default.aspx?type=" + type);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<ClocksInOutReponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new ClocksInOutReponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static ClocksInOutReponseObject SyncPunchInOut(HipposClockInOutListPostObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=sync_clock_in_out");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<ClocksInOutReponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			return new ClocksInOutReponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static HipposClockInOutListPostObject SyncPunchInOutFromHipposTime(HipposClockInOutRequestObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=sync_clock_in_out_hippos_time");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<HipposClockInOutListPostObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			return new HipposClockInOutListPostObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static ClocksInOutReponseObject ConfirmPunchInOut(HipposClockInOutListPostObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=confirm_clock_in_out");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<ClocksInOutReponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			return new ClocksInOutReponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static EmployeeAccountPinResponseObject UpdateEmployeeAccountPin(EmployeeAccountPinRequestObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=update_employee_pin");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<EmployeeAccountPinResponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new EmployeeAccountPinResponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static EmployeeAccountPinResponseObject CreateEmployee(CreateEmployeeAccountObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=hippos_create_employee");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<EmployeeAccountPinResponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new EmployeeAccountPinResponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static EmployeeAccountPinResponseObject CheckEmployeeExist(CreateEmployeeAccountObject data)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.etime_card_server + "/API/Default.aspx?type=check_employee_exist");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<EmployeeAccountPinResponseObject>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new EmployeeAccountPinResponseObject
			{
				code = 400,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static void AddEmployeePunchInOutQueue(HipposClockInOutRequestObject data)
	{
		GClass6 gClass = new GClass6();
		EmployeeClockInOutQueue entity = new EmployeeClockInOutQueue
		{
			EmployeePin = data.employee_pin,
			Timestamp = data.timestamp,
			Action = data.action,
			EmployeeId = data.employee_id,
			Synced = false
		};
		gClass.EmployeeClockInOutQueues.InsertOnSubmit(entity);
		gClass.SubmitChanges();
	}

	public static string CheckPunchInOut(HipposClockInOutRequestObject data)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.data = data;
		EmployeeClockInOutQueue employeeClockInOutQueue = (from a in new GClass6().EmployeeClockInOutQueues
			where a.EmployeePin == CS_0024_003C_003E8__locals0.data.employee_pin && (a.Action == "hippos-clockin" || a.Action == "hippos-clockout")
			orderby a.Id descending
			select a).FirstOrDefault();
		if (employeeClockInOutQueue != null)
		{
			DateTime serverTime = HelperMethods.getServerTime(toUTC: false);
			if (DateTime.Parse(employeeClockInOutQueue.Timestamp).AddMinutes(1.0) > serverTime)
			{
				return "You have already clocked not too long ago.  Please try again in 1 minute.";
			}
		}
		return "true";
	}

	public ETimeCardMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
