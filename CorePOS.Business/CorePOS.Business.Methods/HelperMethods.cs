using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CorePOS.Business.Methods;

public static class HelperMethods
{
	public class IgnoreContractResolver : DefaultContractResolver
	{
		private readonly string string_0;

		public IgnoreContractResolver(string objectToIgnore)
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
			string_0 = objectToIgnore;
		}

		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			return (from jsonProperty_0 in base.CreateProperties(type, memberSerialization)
				where jsonProperty_0.PropertyName != string_0
				select jsonProperty_0).ToList();
		}

		[CompilerGenerated]
		private bool method_0(JsonProperty jsonProperty_0)
		{
			return jsonProperty_0.PropertyName != string_0;
		}
	}

	public static bool IsDigitsOnly(string str)
	{
		int num = 0;
		while (true)
		{
			if (num < str.Length)
			{
				char c = str[num];
				if (c < '0' || c > '9')
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static Color GetColor(string colorname)
	{
		Color result = Color.FromArgb(128, 139, 141);
		if (!string.IsNullOrEmpty(colorname))
		{
			if (!colorname.Contains(","))
			{
				result = Color.FromName(colorname);
			}
			else
			{
				string[] array = colorname.Split(Convert.ToChar(","));
				int red = Convert.ToInt32(array[0].Trim());
				int green = Convert.ToInt32(array[1].Trim());
				int blue = Convert.ToInt32(array[2].Trim());
				result = Color.FromArgb(red, green, blue);
			}
		}
		return result;
	}

	public static Dictionary<string, string> ButtonColors(string lang = "en-US")
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		string key = "Ash";
		string key2 = "Asphalt";
		string key3 = "Blue";
		string key4 = "Brown";
		string key5 = "Charcoal";
		string key6 = "Fushia";
		string key7 = "Gray";
		string key8 = "Green";
		string key9 = "Orange";
		string key10 = "Pink";
		string key11 = "Purple";
		string key12 = "Navy";
		string key13 = "Light-Blue";
		string key14 = "Salmon";
		string key15 = "Turquoise";
		string key16 = "Yellow";
		string key17 = "Red";
		string key18 = "Gold";
		string key19 = "Mint";
		string key20 = "White";
		if (lang == "fr-CA")
		{
			key = "Cendre";
			key2 = "Asphalte";
			key3 = "Bleu";
			key4 = "Marron";
			key13 = "Bleu clair";
			key7 = "Gris";
			key8 = "Vert";
			key9 = "Orange";
			key10 = "Rose";
			key11 = "Violet";
			key15 = "Turquoise";
			key14 = "Saumon";
			key16 = "Jaune";
			key17 = "Rouge";
			key18 = "Or";
			key20 = "Blanc";
		}
		else if (lang == "es-US")
		{
			key = "Ceniza";
			key2 = "Asfalto";
			key3 = "Azul";
			key4 = "Marrón";
			key13 = "Azul claro";
			key7 = "Gris";
			key8 = "Verde";
			key9 = "Naranja";
			key10 = "Rosado";
			key11 = "Púrpura";
			key15 = "Turquesa";
			key14 = "Salmón";
			key16 = "Amarillo";
			key17 = "Rojo";
			key18 = "Oro";
			key20 = "Blanco";
		}
		dictionary.Add(key, "85,75,74");
		dictionary.Add(key2, "52,73,94");
		dictionary.Add(key3, "1, 110, 211");
		dictionary.Add(key4, "198, 129, 71");
		dictionary.Add(key13, "53,152,220");
		dictionary.Add(key5, "34, 32, 33");
		dictionary.Add(key6, "255, 0, 254");
		dictionary.Add(key18, "244, 156, 20");
		dictionary.Add(key7, "150,166,166");
		dictionary.Add(key8, "47,204,113");
		dictionary.Add(key19, "151,251,152");
		dictionary.Add(key12, "1,0,128");
		dictionary.Add(key9, "244,156,20");
		dictionary.Add(key10, "251, 164, 150");
		dictionary.Add(key11, "156,89,184");
		dictionary.Add(key17, "193, 57, 43");
		dictionary.Add(key14, "235, 107, 86");
		dictionary.Add(key15, "27,188,157");
		dictionary.Add(key20, "245,245,245");
		dictionary.Add(key16, "241,196,15");
		return dictionary;
	}

	public static Dictionary<object, string> LightButtonColors(string lang = "en-US")
	{
		Dictionary<object, string> dictionary = new Dictionary<object, string>();
		string key = "Gray";
		string key2 = "Green";
		string key3 = "Orange";
		string key4 = "Pink";
		string key5 = "Light-Blue";
		string key6 = "Salmon";
		string key7 = "Turquoise";
		string key8 = "Yellow";
		string key9 = "Gold";
		string key10 = "Mint";
		string key11 = "White";
		if (lang == "fr-CA")
		{
			key5 = "Bleu clair";
			key = "Gris";
			key2 = "Vert";
			key3 = "Orange";
			key4 = "Rose";
			key7 = "Turquoise";
			key6 = "Saumon";
			key8 = "Jaune";
			key9 = "Or";
			key11 = "Blanc";
		}
		else if (lang == "es-US")
		{
			key5 = "Azul claro";
			key = "Gris";
			key2 = "Verde";
			key3 = "Naranja";
			key4 = "Rosado";
			key7 = "Turquesa";
			key6 = "Salmón";
			key8 = "Amarillo";
			key9 = "Oro";
			key11 = "Blanco";
		}
		dictionary.Add(key5, "53,152,220");
		dictionary.Add(key9, "244, 156, 20");
		dictionary.Add(key, "150,166,166");
		dictionary.Add(key2, "47,204,113");
		dictionary.Add(key10, "151,251,152");
		dictionary.Add(key3, "244,156,20");
		dictionary.Add(key4, "251, 164, 150");
		dictionary.Add(key6, "235, 107, 86");
		dictionary.Add(key7, "27,188,157");
		dictionary.Add(key11, "245,245,245");
		dictionary.Add(key8, "241,196,15");
		return dictionary;
	}

	public static Dictionary<object, string> FontColors(string lang = "en-US")
	{
		Dictionary<object, string> dictionary = new Dictionary<object, string>();
		string key = "Asphalt";
		string key2 = "Black";
		string key3 = "Blue";
		string key4 = "Light-Blue";
		string key5 = "Green";
		string key6 = "Orange";
		string key7 = "Purple";
		string key8 = "Red";
		string key9 = "Yellow";
		string key10 = "White";
		if (lang == "fr-CA")
		{
			key = "Asphalte";
			key3 = "Bleu";
			key4 = "Bleu clair";
			key2 = "Noir";
			key5 = "Vert";
			key6 = "Orange";
			key7 = "Violet";
			key8 = "Rouge";
			key9 = "Jaune";
			key10 = "Blanc";
		}
		else if (lang == "es-US")
		{
			key = "Asfalto";
			key3 = "Azul";
			key4 = "Azul claro";
			key2 = "Negro";
			key5 = "Verde";
			key6 = "Naranja";
			key7 = "Púrpura";
			key8 = "Rojo";
			key9 = "Amarillo";
			key10 = "Blanco";
		}
		dictionary.Add(key, "52,73,94");
		dictionary.Add(key3, "1, 110, 211");
		dictionary.Add(key4, "53,152,220");
		dictionary.Add(key2, "0,0,0");
		dictionary.Add(key5, "47,204,113");
		dictionary.Add(key6, "244,156,20");
		dictionary.Add(key7, "156,89,184");
		dictionary.Add(key9, "241,196,15");
		dictionary.Add(key8, "193, 57, 43");
		dictionary.Add(key10, "255, 255, 255");
		return dictionary;
	}

	public static int GetCurrentTerminalID()
	{
		int? num = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["CurrentTerminalID"].ToString());
		if (num.HasValue)
		{
			int? num2 = num;
			if (!((num2.GetValueOrDefault() == 0) & num2.HasValue))
			{
				goto IL_00f2;
			}
		}
		Terminal terminal = new GClass6().Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			CorePOS.Data.Properties.Settings @default = CorePOS.Data.Properties.Settings.Default;
			num = terminal.TerminalID;
			@default["CurrentTerminalID"] = num;
		}
		else
		{
			num = 0;
		}
		goto IL_00f2;
		IL_00f2:
		return num.Value;
	}

	public static DateTime getServerTime(bool toUTC = true)
	{
		DateTime now = DateTime.Now;
		using SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		SqlCommand sqlCommand = new SqlCommand("SELECT FORMAT(GetDate(), 'MMM dd yyyy hh:mm:ss tt')", sqlConnection);
		sqlConnection.Open();
		DateTime dateTime = DateTime.ParseExact(sqlCommand.ExecuteScalar().ToString(), "MMM dd yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
		sqlConnection.Close();
		if (toUTC)
		{
			return dateTime.ToUniversalTime();
		}
		return now;
	}

	public static string GetServerTimeZoneRegistryValue(string RegistryName, string type)
	{
		string text = "";
		using SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		SqlCommand sqlCommand = new SqlCommand("DECLARE @TimeZone " + type + " EXEC MASTER.dbo.xp_regread 'HKEY_LOCAL_MACHINE', 'SYSTEM\\CurrentControlSet\\Control\\TimeZoneInformation', '" + RegistryName + "', @TimeZone OUT SELECT @TimeZone ", sqlConnection);
		sqlConnection.Open();
		text = sqlCommand.ExecuteScalar().ToString();
		sqlConnection.Close();
		return text;
	}

	public static void SetSystemTime()
	{
		new Thread((ThreadStart)delegate
		{
			DateTime dateTime = smethod_0();
			SYSTEMTIME systemtime_ = default(SYSTEMTIME);
			systemtime_.wYear = (short)dateTime.Year;
			systemtime_.wMonth = (short)dateTime.Month;
			systemtime_.wDay = (short)dateTime.Day;
			systemtime_.wHour = (short)dateTime.Hour;
			systemtime_.wMinute = (short)dateTime.Minute;
			systemtime_.wSecond = (short)dateTime.Second;
			SetSystemTime_1(ref systemtime_);
			SetSystemTimeZone(GetServerTimeZoneRegistryValue("TimeZoneKeyName", "VARCHAR(50)"));
		}).Start();
	}

	private static DateTime smethod_0()
	{
		DateTime now = DateTime.Now;
		try
		{
			byte[] array = new byte[48];
			array[0] = 27;
			IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry("pool.ntp.org").AddressList[0], 123);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			socket.Connect(remoteEP);
			socket.Send(array);
			socket.Receive(array);
			socket.Close();
			ulong num = ((ulong)array[40] << 24) | ((ulong)array[41] << 16) | ((ulong)array[42] << 8) | array[43];
			ulong num2 = ((ulong)array[44] << 24) | ((ulong)array[45] << 16) | ((ulong)array[46] << 8) | array[47];
			ulong num3 = num * 1000L + num2 * 1000L / 4294967296uL;
			return new DateTime(1900, 1, 1).AddMilliseconds((long)num3);
		}
		catch
		{
			try
			{
				return getServerTime();
			}
			catch
			{
				return DateTime.Now;
			}
		}
	}

	[DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
	private static extern bool SetSystemTime_1(ref SYSTEMTIME systemtime_0);

	public static void SetSystemTimeZone(string timeZoneId)
	{
		Process process = Process.Start(new ProcessStartInfo
		{
			FileName = "tzutil.exe",
			Arguments = "/s \"" + timeZoneId + "\"",
			UseShellExecute = false,
			CreateNoWindow = true
		});
		if (process != null)
		{
			process.WaitForExit();
			TimeZoneInfo.ClearCachedData();
		}
	}

	public static string ToOrdinal(int value)
	{
		string result = "th";
		int num = value % 100;
		if (num < 11 || num > 13)
		{
			switch (num % 10)
			{
			case 1:
				result = "st";
				break;
			case 2:
				result = "nd";
				break;
			case 3:
				result = "rd";
				break;
			}
		}
		return result;
	}

	public static IOrderedEnumerable<Order> OrderByItemCourse(this List<Order> orders)
	{
		return from a in orders
			orderby (!a.ItemCourse.ToUpper().Contains(ItemCourses.Beverage.ToUpper())) ? 1 : 0, (!a.ItemCourse.ToUpper().Contains(ItemCourses.Appetizer.ToUpper())) ? 1 : 0, (!a.ItemCourse.ToUpper().Contains(ItemCourses.Side.ToUpper())) ? 1 : 0, (!a.ItemCourse.ToUpper().Contains(ItemCourses.Entree.ToUpper())) ? 1 : 0, (!a.ItemCourse.ToUpper().Contains(ItemCourses.Dessert.ToUpper())) ? 1 : 0
			select a;
	}
}
