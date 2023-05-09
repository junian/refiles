using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.InAppAPI;
using CorePOS.Data;
using Newtonsoft.Json;
using Telerik.WinControls.UI;

namespace CorePOS.Helpers;

public class HTTPHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public HttpListener listener;

		public HTTPHelper _003C_003E4__this;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CTCPListener_003Eb__2()
		{
			while (true)
			{
				try
				{
					HttpListenerContext context = listener.GetContext();
					_003C_003E4__this.method_1(context);
				}
				catch
				{
					break;
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Layout layout;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetLayout_003Eb__2(OccupiedTable a)
		{
			return a.TableName == layout.TableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public Employee emp;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetStaffTables_003Eb__2(OccupiedTable x)
		{
			return x.EmployeeID == emp.EmployeeID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public Layout layout;

		public _003C_003Ec__DisplayClass10_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetStaffTables_003Eb__4(OccupiedTable a)
		{
			return a.TableName == layout.TableName;
		}

		internal bool _003CGetStaffTables_003Eb__5(OccupiedTable a)
		{
			return a.TableName == layout.TableName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public short groupId;

		public Func<ItemsInGroup, bool> _003C_003E9__0;

		public _003C_003Ec__DisplayClass13_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetItems_003Eb__0(ItemsInGroup x)
		{
			if (x.Item.ItemClassification == ItemClassifications.Product && x.Item.Active)
			{
				return x.GroupID.Value == groupId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public ItemsInGroup iig;

		public _003C_003Ec__DisplayClass13_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetItems_003Eb__2(usp_ItemOptionsResult i)
		{
			if (i.ItemID == iig.ItemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CGetItems_003Eb__3(ItemsInItem a)
		{
			return a.ParentItemID == iig.ItemID;
		}

		internal bool _003CGetItems_003Eb__5(GroupsInItem a)
		{
			return a.ItemID == iig.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_2
	{
		public ItemsInItem a;

		public _003C_003Ec__DisplayClass13_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetItems_003Eb__7(Item b)
		{
			return b.ItemID == a.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int itemID;

		public List<string> tabs;

		public List<Reason> reasons;

		public HTTPHelper _003C_003E4__this;

		public _003C_003Ec__DisplayClass15_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetOptions_003Eb__0(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CGetOptions_003Eb__2(Reason x)
		{
			return tabs.Contains(x.Value.ToUpper());
		}

		internal bool _003CGetOptions_003Eb__6(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}

		internal OptionObject _003CGetOptions_003Eb__9(usp_ItemOptionsResult a)
		{
			_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_1
			{
				a = a
			};
			return new OptionObject
			{
				ItemWithOptionID = CS_0024_003C_003E8__locals0.a.ItemWithOptionID,
				ItemID = CS_0024_003C_003E8__locals0.a.ItemID,
				Option_ItemID = CS_0024_003C_003E8__locals0.a.Option_ItemID,
				ItemName = CS_0024_003C_003E8__locals0.a.ItemName,
				SortOrder = CS_0024_003C_003E8__locals0.a.SortOrder,
				OptionSortOrder = CS_0024_003C_003E8__locals0.a.OptionSortOrder,
				SpecialPrice = CS_0024_003C_003E8__locals0.a.SpecialPrice,
				AllowAdditional = CS_0024_003C_003E8__locals0.a.AllowAdditional,
				MaxGroupOptions = CS_0024_003C_003E8__locals0.a.MaxGroupOptions,
				MinGroupOptions = CS_0024_003C_003E8__locals0.a.MinGroupOptions,
				Color = CS_0024_003C_003E8__locals0.a.Color,
				Preselect = CS_0024_003C_003E8__locals0.a.Preselect,
				ToBeDeleted = CS_0024_003C_003E8__locals0.a.ToBeDeleted,
				GroupID = CS_0024_003C_003E8__locals0.a.GroupID,
				GroupDependency = CS_0024_003C_003E8__locals0.a.GroupDependency,
				OptionDependency = CS_0024_003C_003E8__locals0.a.OptionDependency,
				Qty = CS_0024_003C_003E8__locals0.a.Qty,
				Tab = CS_0024_003C_003E8__locals0.a.Tab,
				TabSortOrder = (short)((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.a.Tab) && reasons.Where((Reason b) => b.Value == CS_0024_003C_003E8__locals0.a.Tab).FirstOrDefault() != null) ? reasons.Where((Reason b) => b.Value == CS_0024_003C_003E8__locals0.a.Tab).FirstOrDefault().SortOrder : 0),
				GroupName = ((CS_0024_003C_003E8__locals0.a.GroupID <= 0 || _003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault() == null) ? "** No Option Group **" : _003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault().GroupName),
				GroupSortOrder = (short)((CS_0024_003C_003E8__locals0.a.GroupID > 0 && _003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault() != null) ? _003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault().SortOrder : 0)
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public usp_ItemOptionsResult a;

		public _003C_003Ec__DisplayClass15_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetOptions_003Eb__10(Reason b)
		{
			return b.Value == a.Tab;
		}

		internal bool _003CGetOptions_003Eb__11(Reason b)
		{
			return b.Value == a.Tab;
		}

		internal bool _003CGetOptions_003Eb__12(Group b)
		{
			return b.GroupID == a.GroupID;
		}

		internal bool _003CGetOptions_003Eb__13(Group b)
		{
			return b.GroupID == a.GroupID;
		}

		internal bool _003CGetOptions_003Eb__14(Group b)
		{
			return b.GroupID == a.GroupID;
		}

		internal bool _003CGetOptions_003Eb__15(Group b)
		{
			return b.GroupID == a.GroupID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public List<int> intList;

		public string orderNumber;

		public _003C_003Ec__DisplayClass17_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public OrderedItem orItem;

		public _003C_003Ec__DisplayClass17_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CSaveOrders_003Eb__5(Item x)
		{
			return x.ItemID.Equals(orItem.itemID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_2
	{
		public Item itemFromDB;

		public _003C_003Ec__DisplayClass17_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CSaveOrders_003Eb__6(ItemsInGroup x)
		{
			return x.ItemID.Value == itemFromDB.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_3
	{
		public string stationId;

		public _003C_003Ec__DisplayClass17_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CSaveOrders_003Eb__7(Station a)
		{
			return a.StationID == Convert.ToInt32(stationId);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public List<int> intList;

		public _003C_003Ec__DisplayClass18_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCalculateOrderTax_003Eb__1(Item x)
		{
			return intList.Contains(x.ItemID);
		}

		internal bool _003CCalculateOrderTax_003Eb__2(ItemsInGroup x)
		{
			return intList.Contains(x.ItemID.Value);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public OrderedItem orItem;

		public _003C_003Ec__DisplayClass18_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCalculateOrderTax_003Eb__4(Item x)
		{
			return x.ItemID.Equals(orItem.itemID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_2
	{
		public Item itemFromDB;

		public _003C_003Ec__DisplayClass18_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCalculateOrderTax_003Eb__5(ItemsInGroup x)
		{
			return x.ItemID.Value == itemFromDB.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public List<int> intList;

		public int selectedTag;

		public Func<Item, bool> _003C_003E9__6;

		public _003C_003Ec__DisplayClass19_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculateItemsAndTotals_003Eb__1(Item x)
		{
			return intList.Contains(x.ItemID);
		}

		internal bool _003CRecalculateItemsAndTotals_003Eb__6(Item x)
		{
			return x.ItemID == selectedTag;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public int itemID;

		public _003C_003Ec__DisplayClass19_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculateItemsAndTotals_003Eb__5(Item x)
		{
			return x.ItemID.Equals(itemID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_2
	{
		public Item taxIncludedItems;

		public _003C_003Ec__DisplayClass19_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculateItemsAndTotals_003Eb__8(Item x)
		{
			return x.ItemID == taxIncludedItems.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public string tablename;

		public _003C_003Ec__DisplayClass22_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public APIRequestObj data;

		public _003C_003Ec__DisplayClass23_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetOrders_003Eb__6(Order x)
		{
			return x.Customer.ToUpper() == data.orderHeader.customer;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public string param;

		public _003C_003Ec__DisplayClass29_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetReasons_003Eb__0(Reason x)
		{
			return x.ReasonType == param;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public string param2;

		public _003C_003Ec__DisplayClass30_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintReceipt_003Eb__0(Terminal x)
		{
			return x.SystemName == param2.ToUpper();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public string param2;

		public string orderNumber;

		public _003C_003Ec__DisplayClass31_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CSendToPaymentTerminal_003Eb__0(Terminal x)
		{
			return x.SystemName == param2.ToUpper();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public string ordernumber;

		public _003C_003Ec__DisplayClass34_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessBillPayment_003Eb__0(Order x)
		{
			if (x.OrderNumber == ordernumber && !x.Paid)
			{
				return !x.Void;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public string table;

		public _003C_003Ec__DisplayClass34_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	private List<Group> list_0;

	private List<ItemsInItem> list_1;

	private List<GroupsInItem> list_2;

	public void method_0(HttpListener listener)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.listener = listener;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		int num = 8880;
		int num2 = 8887;
		Setting setting = gclass6_0.Settings.Where((Setting a) => a.Key == "http_port_range").FirstOrDefault();
		if (setting != null)
		{
			try
			{
				string[] array = setting.Value.Split('-');
				num = Convert.ToInt32(array[0]);
				num2 = Convert.ToInt32(array[1]);
			}
			catch
			{
			}
		}
		for (int i = num; i < num2; i++)
		{
			CS_0024_003C_003E8__locals0.listener.Prefixes.Add("http://127.0.0.1:" + i + "/");
		}
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				for (int k = 8880; k < 8887; k++)
				{
					CS_0024_003C_003E8__locals0.listener.Prefixes.Add("http://" + iPAddress.ToString() + ":" + k + "/");
				}
			}
		}
		list_0 = new GClass6().Groups.Where((Group x) => x.Active == true && x.Archived == false).ToList();
		list_1 = gclass6_0.ItemsInItems.ToList();
		list_2 = gclass6_0.GroupsInItems.ToList();
		CS_0024_003C_003E8__locals0.listener.Start();
		Console.WriteLine("Listening...");
		new Thread((ThreadStart)delegate
		{
			while (true)
			{
				try
				{
					HttpListenerContext context = CS_0024_003C_003E8__locals0.listener.GetContext();
					CS_0024_003C_003E8__locals0._003C_003E4__this.method_1(context);
				}
				catch
				{
					break;
				}
			}
		}).Start();
	}

	private void method_1(HttpListenerContext httpListenerContext_0)
	{
		Encoding.UTF8.GetBytes("ACK");
		httpListenerContext_0.Response.StatusCode = 200;
		httpListenerContext_0.Response.KeepAlive = true;
		httpListenerContext_0.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
		httpListenerContext_0.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
		httpListenerContext_0.Response.AddHeader("Access-Control-Max-Age", "1728000");
		httpListenerContext_0.Response.AppendHeader("Access-Control-Allow-Origin", "*");
		try
		{
			string value;
			using (Stream stream = httpListenerContext_0.Request.InputStream)
			{
				using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
				value = streamReader.ReadToEnd();
			}
			APIRequestObj aPIRequestObj = JsonConvert.DeserializeObject<APIRequestObj>(value, new JsonSerializerSettings
			{
				MaxDepth = 10,
				ContractResolver = new HelperMethods.IgnoreContractResolver("Signature")
			});
			if (aPIRequestObj == null)
			{
				return;
			}
			if (!method_2(aPIRequestObj.api_token))
			{
				APIResponseObj aPIResponseObj = new APIResponseObj();
				aPIResponseObj.code = 401;
				aPIResponseObj.message = "Invalid Access Token";
				method_4(httpListenerContext_0, aPIResponseObj);
				return;
			}
			switch (aPIRequestObj.call_type)
			{
			case "set_productkey":
				method_22(httpListenerContext_0, aPIRequestObj);
				break;
			case "is_order_paid":
				method_12(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "is_pin_needed":
				method_20(httpListenerContext_0, aPIRequestObj);
				break;
			case "orders":
				method_19(httpListenerContext_0, aPIRequestObj);
				break;
			case "staff_tables":
				method_6(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "auth_productkey":
				method_23(httpListenerContext_0, aPIRequestObj);
				break;
			case "save_order":
				method_13(httpListenerContext_0, aPIRequestObj);
				break;
			case "set_table":
				method_17(httpListenerContext_0, aPIRequestObj);
				break;
			case "items":
				method_9(httpListenerContext_0, aPIRequestObj.call_param, aPIRequestObj.call_param2);
				break;
			case "clear_table":
				method_18(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "settings":
				method_24(httpListenerContext_0);
				break;
			case "instructions":
				method_10(httpListenerContext_0);
				break;
			case "recalculate_totals":
				method_15(httpListenerContext_0, aPIRequestObj);
				break;
			case "calculate_gratuity":
				method_16(httpListenerContext_0, aPIRequestObj);
				break;
			case "record_clover_payment":
				method_28(httpListenerContext_0, aPIRequestObj);
				break;
			case "groups":
				method_8(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "print_receipt":
				method_26(httpListenerContext_0, aPIRequestObj.call_param, aPIRequestObj.call_param2);
				break;
			case "pin_authentication":
				method_21(httpListenerContext_0, aPIRequestObj);
				break;
			case "reasons":
				method_25(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "unoccupied_tables":
				method_7(httpListenerContext_0);
				break;
			case "layout":
				method_5(httpListenerContext_0);
				break;
			case "sendto_payment_terminal":
				method_27(httpListenerContext_0, aPIRequestObj.call_param, aPIRequestObj.call_param2);
				break;
			case "options":
				method_11(httpListenerContext_0, aPIRequestObj.call_param);
				break;
			case "calculate_tax":
				method_14(httpListenerContext_0, aPIRequestObj);
				break;
			}
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			method_3(httpListenerContext_0, 201, ex.Message);
		}
	}

	private bool method_2(string string_0)
	{
		Setting setting = new GClass6().Settings.Where((Setting a) => a.Key == "http_listener_access_token").FirstOrDefault();
		if (string.IsNullOrEmpty(setting.Value))
		{
			return true;
		}
		if (string_0 == setting.Value)
		{
			return true;
		}
		return false;
	}

	private void method_3(HttpListenerContext httpListenerContext_0, int int_0, string string_0)
	{
		try
		{
			APIResponseObj value = new APIResponseObj
			{
				code = int_0,
				message = string_0
			};
			HttpListenerResponse response = httpListenerContext_0.Response;
			string s = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				MaxDepth = 2000
			});
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			response.ContentLength64 = bytes.Length;
			response.OutputStream.Write(bytes, 0, bytes.Length);
		}
		catch
		{
		}
	}

	private void method_4(HttpListenerContext httpListenerContext_0, object object_0)
	{
		HttpListenerResponse response = httpListenerContext_0.Response;
		string s = JsonConvert.SerializeObject(object_0, Formatting.Indented, new JsonSerializerSettings
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			MaxDepth = 1
		});
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		response.ContentLength64 = bytes.Length;
		response.OutputStream.Write(bytes, 0, bytes.Length);
	}

	private void method_5(HttpListenerContext httpListenerContext_0)
	{
		GClass6 gClass = new GClass6();
		List<Layout> list = gClass.Layouts.Where((Layout x) => x.Active == true).ToList();
		List<OccupiedTable> source = new OrderMethods().OccupiedTables().ToList();
		List<TableModel> list2 = new List<TableModel>();
		List<Layout> list3 = new List<Layout>();
		using (List<Layout>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
				CS_0024_003C_003E8__locals0.layout = enumerator.Current;
				if (CS_0024_003C_003E8__locals0.layout.Rotation != 'V' && CS_0024_003C_003E8__locals0.layout.Rotation != 'H')
				{
					list3.Add(CS_0024_003C_003E8__locals0.layout);
					continue;
				}
				OccupiedTable occupiedTable = source.Where((OccupiedTable a) => a.TableName == CS_0024_003C_003E8__locals0.layout.TableName).FirstOrDefault();
				int currentGuests = occupiedTable?.GuestCount ?? CS_0024_003C_003E8__locals0.layout.CurrentGuests;
				string orderNumber = ((occupiedTable == null) ? "" : occupiedTable.OrderNumber);
				string status = TableStatus.Open;
				string color = "#fff";
				if (occupiedTable != null)
				{
					if (occupiedTable.Customer == null)
					{
						status = TableStatus.Open;
					}
					else if (occupiedTable.Customer != null)
					{
						if (!occupiedTable.Cleared && occupiedTable.Paid)
						{
							status = TableStatus.Paid;
							color = "#61bd6d";
						}
						else
						{
							status = TableStatus.Ordered;
							color = "#54acd2";
						}
					}
					else
					{
						status = TableStatus.Ordered;
						color = "#54acd2";
					}
				}
				else if (CS_0024_003C_003E8__locals0.layout.AppointmentID.HasValue)
				{
					status = TableStatus.Reserved;
					color = "#eb6b56";
				}
				else if (CS_0024_003C_003E8__locals0.layout.CurrentGuests > 0)
				{
					status = TableStatus.Seated;
					color = "#ffc080";
				}
				CS_0024_003C_003E8__locals0.layout.Appointment = null;
				TableModel item = new TableModel
				{
					TableName = CS_0024_003C_003E8__locals0.layout.TableName,
					isRound = CS_0024_003C_003E8__locals0.layout.Round,
					currentGuests = currentGuests,
					angleOfRotation = CS_0024_003C_003E8__locals0.layout.AngleOfRotation,
					Location = new Point(CS_0024_003C_003E8__locals0.layout.X.Value, CS_0024_003C_003E8__locals0.layout.Y.Value),
					Section = CS_0024_003C_003E8__locals0.layout.Section,
					TotalCapacity = CS_0024_003C_003E8__locals0.layout.NumOfSeats.Value,
					Status = status,
					Color = color,
					OrderNumber = orderNumber,
					layout = CS_0024_003C_003E8__locals0.layout
				};
				list2.Add(item);
			}
		}
		string default_layout = "";
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			default_layout = terminal.DefaultLayoutSectionName;
		}
		LayoutResponseObject layoutResponseObject = new LayoutResponseObject();
		layoutResponseObject.code = 200;
		layoutResponseObject.message = string.Empty;
		layoutResponseObject.tables = list2;
		layoutResponseObject.layout_objects = list3;
		layoutResponseObject.default_layout = default_layout;
		method_4(httpListenerContext_0, layoutResponseObject);
	}

	private void method_6(HttpListenerContext httpListenerContext_0, string string_0)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		if (string.IsNullOrEmpty(string_0))
		{
			throw new Exception("Employee ID required.");
		}
		GClass6 gClass = new GClass6();
		List<TableModel> list = new List<TableModel>();
		List<Layout> list2 = new List<Layout>();
		CS_0024_003C_003E8__locals0.emp = EmployeeMethods.getEmployeeByID(Convert.ToInt32(string_0));
		string roleName = gClass.Roles.Where((Role x) => x.RoleID == CS_0024_003C_003E8__locals0.emp.Users.FirstOrDefault().RoleID).FirstOrDefault().RoleName;
		List<OccupiedTable> source;
		List<Layout> list3;
		if ("admin,manager,supervisor".Contains(roleName.ToLower()))
		{
			source = new OrderMethods().OccupiedTables().ToList();
			list3 = gClass.Layouts.Where((Layout x) => x.Active == true && ((int?)x.Rotation == (int?)86 || (int?)x.Rotation == (int?)72)).ToList();
		}
		else
		{
			source = (from x in new OrderMethods().OccupiedTables()
				where x.EmployeeID == CS_0024_003C_003E8__locals0.emp.EmployeeID
				select x).ToList();
			list3 = gClass.Layouts.Where((Layout x) => x.Active == true && ((int?)x.Rotation == (int?)86 || (int?)x.Rotation == (int?)72) && x.EmployeeID == (int?)CS_0024_003C_003E8__locals0.emp.EmployeeID).ToList();
		}
		using (List<Layout>.Enumerator enumerator = list3.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_1();
				CS_0024_003C_003E8__locals1.layout = enumerator.Current;
				if (CS_0024_003C_003E8__locals1.layout.Rotation != 'V' && CS_0024_003C_003E8__locals1.layout.Rotation != 'H')
				{
					list2.Add(CS_0024_003C_003E8__locals1.layout);
					continue;
				}
				OccupiedTable occupiedTable = source.Where((OccupiedTable a) => a.TableName == CS_0024_003C_003E8__locals1.layout.TableName).FirstOrDefault();
				int currentGuests = occupiedTable?.GuestCount ?? CS_0024_003C_003E8__locals1.layout.CurrentGuests;
				List<TableSeatOrderNumbers> list4 = (from a in source
					where a.TableName == CS_0024_003C_003E8__locals1.layout.TableName
					select a into x
					select new TableSeatOrderNumbers
					{
						OrderNumber = x.OrderNumber,
						SeatNumber = x.SeatNum,
						isPaid = x.Paid
					}).ToList();
				if (list4.Count > 1)
				{
					list4 = list4.Where((TableSeatOrderNumbers x) => !x.isPaid).ToList();
				}
				string status = TableStatus.Open;
				string color = "#fff";
				if (occupiedTable != null)
				{
					if (occupiedTable.Customer == null)
					{
						status = TableStatus.Open;
					}
					else if (occupiedTable.Customer != null)
					{
						if (!occupiedTable.Cleared && occupiedTable.Paid)
						{
							status = TableStatus.Paid;
							color = "#61bd6d";
						}
						else
						{
							status = TableStatus.Ordered;
							color = "#54acd2";
						}
					}
					else
					{
						status = TableStatus.Ordered;
						color = "#54acd2";
					}
				}
				else if (CS_0024_003C_003E8__locals1.layout.AppointmentID.HasValue)
				{
					status = TableStatus.Reserved;
					color = "#eb6b56";
				}
				else if (CS_0024_003C_003E8__locals1.layout.CurrentGuests > 0)
				{
					status = TableStatus.Seated;
					color = "#ffc080";
				}
				CS_0024_003C_003E8__locals1.layout.Appointment = null;
				list4.FirstOrDefault();
				Employee employee = null;
				if (CS_0024_003C_003E8__locals1.layout.EmployeeID.HasValue)
				{
					employee = EmployeeMethods.getEmployeeByID(Convert.ToInt32(CS_0024_003C_003E8__locals1.layout.EmployeeID));
				}
				TableModel item = new TableModel
				{
					TableName = CS_0024_003C_003E8__locals1.layout.TableName,
					EmployeeAssigned = ((employee == null) ? string.Empty : ((CS_0024_003C_003E8__locals0.emp.EmployeeID == employee.EmployeeID) ? "Me" : EmployeeMethods.getEmployeeNameString(employee, 1))),
					isRound = CS_0024_003C_003E8__locals1.layout.Round,
					currentGuests = currentGuests,
					angleOfRotation = CS_0024_003C_003E8__locals1.layout.AngleOfRotation,
					Location = new Point(CS_0024_003C_003E8__locals1.layout.X.Value, CS_0024_003C_003E8__locals1.layout.Y.Value),
					Section = CS_0024_003C_003E8__locals1.layout.Section,
					TotalCapacity = CS_0024_003C_003E8__locals1.layout.NumOfSeats.Value,
					Status = status,
					Color = color,
					OrderNumber = ((list4.FirstOrDefault() != null) ? list4.FirstOrDefault().OrderNumber : string.Empty),
					TableSeatOrderNumbers = list4,
					layout = CS_0024_003C_003E8__locals1.layout
				};
				list.Add(item);
			}
		}
		LayoutResponseObject layoutResponseObject = new LayoutResponseObject();
		layoutResponseObject.code = 200;
		layoutResponseObject.message = string.Empty;
		layoutResponseObject.tables = list;
		layoutResponseObject.layout_objects = list2;
		method_4(httpListenerContext_0, layoutResponseObject);
	}

	private void method_7(HttpListenerContext httpListenerContext_0)
	{
		GClass6 gClass = new GClass6();
		List<TableModel> list = new List<TableModel>();
		foreach (Layout item2 in gClass.Layouts.Where((Layout x) => x.Active == true && ((int?)x.Rotation == (int?)86 || (int?)x.Rotation == (int?)72) && x.EmployeeID == (int?)0 && x.CurrentGuests == 0).ToList())
		{
			item2.Appointment = null;
			TableModel item = new TableModel
			{
				TableName = item2.TableName,
				isRound = item2.Round,
				currentGuests = 0,
				angleOfRotation = item2.AngleOfRotation,
				Location = new Point(item2.X.Value, item2.Y.Value),
				Section = item2.Section,
				TotalCapacity = item2.NumOfSeats.Value,
				Status = TableStatus.Open,
				Color = "#fff",
				OrderNumber = string.Empty,
				layout = item2
			};
			list.Add(item);
		}
		LayoutResponseObject layoutResponseObject = new LayoutResponseObject();
		layoutResponseObject.code = 200;
		layoutResponseObject.message = string.Empty;
		layoutResponseObject.tables = list;
		layoutResponseObject.layout_objects = null;
		method_4(httpListenerContext_0, layoutResponseObject);
	}

	private void method_8(HttpListenerContext httpListenerContext_0, string string_0)
	{
		List<Group> list = ((string.IsNullOrEmpty(string_0) || !string_0.ToLower().Equals("staff")) ? (from x in list_0
			where x.GroupClassification == ItemClassifications.Product && x.Active && x.OrderEntryShow && x.ShowInPatronKiosk
			select x into a
			orderby a.SortOrder
			select a).ThenBy((Group b) => b.GroupName).ToList() : (from x in list_0
			where x.GroupClassification == ItemClassifications.Product && x.Active && x.OrderEntryShow
			select x into a
			orderby a.SortOrder
			select a).ThenBy((Group b) => b.GroupName).ToList());
		List<Group> list2 = new List<Group>();
		foreach (Group item in list)
		{
			item.ItemsInGroups = null;
			item.GroupsInItems = null;
			list2.Add(item);
		}
		GroupsResponseObject groupsResponseObject = new GroupsResponseObject();
		groupsResponseObject.code = 200;
		groupsResponseObject.message = string.Empty;
		groupsResponseObject.groups = list2;
		method_4(httpListenerContext_0, groupsResponseObject);
		groupsResponseObject = null;
	}

	private void method_9(HttpListenerContext httpListenerContext_0, string string_0, string string_1)
	{
		_003C_003Ec__DisplayClass13_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		bool flag = true;
		if (string_1 != null && string_1.ToLower() == "false")
		{
			flag = false;
		}
		CS_0024_003C_003E8__locals0.groupId = Convert.ToInt16(string_0);
		List<ItemObject> list = new List<ItemObject>();
		using (List<ItemsInGroup>.Enumerator enumerator = (from x in MemoryLoadedData.ListOfItemsInGroupMemory
			where x.Item.ItemClassification == ItemClassifications.Product && x.Item.Active && x.GroupID.Value == CS_0024_003C_003E8__locals0.groupId
			orderby x.SortOrder
			select x).ToList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass13_1();
				CS_0024_003C_003E8__locals1.iig = enumerator.Current;
				ItemImage itemImage = CS_0024_003C_003E8__locals1.iig.Item.ItemImages.FirstOrDefault();
				try
				{
					list.Add(new ItemObject
					{
						ItemID = CS_0024_003C_003E8__locals1.iig.Item.ItemID,
						ItemBarcode = CS_0024_003C_003E8__locals1.iig.Item.Barcode,
						ItemName = CS_0024_003C_003E8__locals1.iig.Item.ItemName,
						ItemCourse = CS_0024_003C_003E8__locals1.iig.Item.ItemCourse,
						Description = CS_0024_003C_003E8__locals1.iig.Item.Description,
						Price = CS_0024_003C_003E8__locals1.iig.Item.ItemPrice,
						StationID = CS_0024_003C_003E8__locals1.iig.Item.StationID,
						GroupId = CS_0024_003C_003E8__locals1.iig.GroupID.Value,
						GroupName = CS_0024_003C_003E8__locals1.iig.Group.GroupName,
						MaxFreeOption = CS_0024_003C_003E8__locals1.iig.Item.MaxFreeOptions,
						MinFreeOption = CS_0024_003C_003E8__locals1.iig.Item.MinFreeOptions,
						Image = ((!flag || itemImage == null) ? null : itemImage.ImageAsText),
						ImageUrl = itemImage?.BlobThumbnailName,
						ImageHighRes = ((!flag || itemImage == null) ? null : itemImage.ImageAsTextHighRes),
						ImageHighResUrl = itemImage?.BlobName,
						hasOption = (MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult i) => i.ItemID == CS_0024_003C_003E8__locals1.iig.ItemID && !i.ToBeDeleted).Count() > 0),
						itemsInItems = list_1.Where((ItemsInItem a) => a.ParentItemID == CS_0024_003C_003E8__locals1.iig.ItemID).Select(delegate(ItemsInItem a)
						{
							CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_2();
							CS_0024_003C_003E8__locals0.a = a;
							return new ItemsInItemsField
							{
								ItemID = CS_0024_003C_003E8__locals0.a.ItemID.Value,
								ItemName = MemoryLoadedData.all_items.Where((Item b) => b.ItemID == CS_0024_003C_003E8__locals0.a.ItemID).First().ItemName,
								qty = CS_0024_003C_003E8__locals0.a.Quantity.Value,
								useItemSettings = CS_0024_003C_003E8__locals0.a.UseChildItemPriceAndTax
							};
						}).ToList(),
						groupsInItems = (from a in list_2
							where a.ItemID == CS_0024_003C_003E8__locals1.iig.ItemID
							select new GroupsInItemsField
							{
								GroupId = a.GroupID,
								GroupName = a.Group.GroupName,
								qty = a.Quantity,
								SortOrder = a.SortOrder
							}).ToList()
					});
				}
				catch
				{
				}
			}
		}
		ItemsResponseObject itemsResponseObject = new ItemsResponseObject();
		itemsResponseObject.code = 200;
		itemsResponseObject.message = string.Empty;
		itemsResponseObject.items = list;
		method_4(httpListenerContext_0, itemsResponseObject);
	}

	private void method_10(HttpListenerContext httpListenerContext_0)
	{
		GClass6 gClass = new GClass6();
		List<SpecialInstruction> list = new List<SpecialInstruction>();
		foreach (SpecialInstruction item in gClass.SpecialInstructions.OrderBy((SpecialInstruction x) => x.Instruction).ToList())
		{
			list.Add(new SpecialInstruction
			{
				SpecialInstructionID = item.SpecialInstructionID,
				StationID = item.StationID,
				Color = item.Color,
				Instruction = item.Instruction
			});
		}
		InstructionsResponseObject instructionsResponseObject = new InstructionsResponseObject();
		instructionsResponseObject.code = 200;
		instructionsResponseObject.message = string.Empty;
		instructionsResponseObject.instructions = list;
		method_4(httpListenerContext_0, instructionsResponseObject);
	}

	private void method_11(HttpListenerContext httpListenerContext_0, string string_0)
	{
		_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.itemID = Convert.ToInt32(string_0);
		CS_0024_003C_003E8__locals0.tabs = (from i in MemoryLoadedObjects.all_item_options
			where i.ItemID == CS_0024_003C_003E8__locals0.itemID && !i.ToBeDeleted
			select i into y
			select y.Tab.ToUpper()).Distinct().ToList();
		CS_0024_003C_003E8__locals0.reasons = (from x in MemoryLoadedObjects.all_reasons
			where CS_0024_003C_003E8__locals0.tabs.Contains(x.Value.ToUpper())
			select x into a
			orderby a.isDefault descending, (a.SortOrder != 0) ? a.SortOrder : short.MaxValue, a.Value
			select a).ToList();
		List<OptionObject> options = (from i in MemoryLoadedObjects.all_item_options
			where i.ItemID == CS_0024_003C_003E8__locals0.itemID && !i.ToBeDeleted
			orderby i.OptionSortOrder, i.ItemName
			select i).Select(delegate(usp_ItemOptionsResult a)
		{
			CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_1();
			CS_0024_003C_003E8__locals0.a = a;
			return new OptionObject
			{
				ItemWithOptionID = CS_0024_003C_003E8__locals0.a.ItemWithOptionID,
				ItemID = CS_0024_003C_003E8__locals0.a.ItemID,
				Option_ItemID = CS_0024_003C_003E8__locals0.a.Option_ItemID,
				ItemName = CS_0024_003C_003E8__locals0.a.ItemName,
				SortOrder = CS_0024_003C_003E8__locals0.a.SortOrder,
				OptionSortOrder = CS_0024_003C_003E8__locals0.a.OptionSortOrder,
				SpecialPrice = CS_0024_003C_003E8__locals0.a.SpecialPrice,
				AllowAdditional = CS_0024_003C_003E8__locals0.a.AllowAdditional,
				MaxGroupOptions = CS_0024_003C_003E8__locals0.a.MaxGroupOptions,
				MinGroupOptions = CS_0024_003C_003E8__locals0.a.MinGroupOptions,
				Color = CS_0024_003C_003E8__locals0.a.Color,
				Preselect = CS_0024_003C_003E8__locals0.a.Preselect,
				ToBeDeleted = CS_0024_003C_003E8__locals0.a.ToBeDeleted,
				GroupID = CS_0024_003C_003E8__locals0.a.GroupID,
				GroupDependency = CS_0024_003C_003E8__locals0.a.GroupDependency,
				OptionDependency = CS_0024_003C_003E8__locals0.a.OptionDependency,
				Qty = CS_0024_003C_003E8__locals0.a.Qty,
				Tab = CS_0024_003C_003E8__locals0.a.Tab,
				TabSortOrder = (short)((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.a.Tab) && CS_0024_003C_003E8__locals0.reasons.Where((Reason b) => b.Value == CS_0024_003C_003E8__locals0.a.Tab).FirstOrDefault() != null) ? CS_0024_003C_003E8__locals0.reasons.Where((Reason b) => b.Value == CS_0024_003C_003E8__locals0.a.Tab).FirstOrDefault().SortOrder : 0),
				GroupName = ((CS_0024_003C_003E8__locals0.a.GroupID <= 0 || CS_0024_003C_003E8__locals0._003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault() == null) ? "** No Option Group **" : CS_0024_003C_003E8__locals0._003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault().GroupName),
				GroupSortOrder = (short)((CS_0024_003C_003E8__locals0.a.GroupID > 0 && CS_0024_003C_003E8__locals0._003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault() != null) ? CS_0024_003C_003E8__locals0._003C_003E4__this.list_0.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals0.a.GroupID).FirstOrDefault().SortOrder : 0)
			};
		}).ToList();
		OptionsResponseObject optionsResponseObject = new OptionsResponseObject();
		optionsResponseObject.code = 200;
		optionsResponseObject.message = string.Empty;
		optionsResponseObject.options = options;
		method_4(httpListenerContext_0, optionsResponseObject);
	}

	private void method_12(HttpListenerContext httpListenerContext_0, string string_0)
	{
		APIResponseObj aPIResponseObj = new APIResponseObj();
		aPIResponseObj.code = 200;
		aPIResponseObj.message = "success";
		aPIResponseObj.data = (OrderMethods.GetIsOrderPaid(string_0) ? "true" : "false");
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_13(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		string text = "SAVED ORDER";
		string customer = apirequestObj_0.orderHeader.customer;
		List<string> list = new List<string>();
		string text2 = "";
		bool flag = false;
		Employee employeeByID = UserMethods.GetEmployeeByID(apirequestObj_0.orderHeader.employeeID);
		if (employeeByID == null)
		{
			throw new Exception("Permission error.  EmpID does not exist.");
		}
		if (GuestMethods.GetCurrentTableGuestCapacity(customer.ToUpper().Replace("TABLE", string.Empty).Trim()) == 0)
		{
			GuestMethods.UpdateTableGuestCapacity(customer.ToUpper().Replace("TABLE", string.Empty).Trim(), apirequestObj_0.orderHeader.guestCount, apirequestObj_0.orderHeader.employeeID);
		}
		if (apirequestObj_0.order_items.Count == 0)
		{
			throw new Exception("Nothing to add.");
		}
		List<Item> list2 = new List<Item>();
		CS_0024_003C_003E8__locals0.intList = apirequestObj_0.order_items.Select((OrderedItem x) => x.itemID).Distinct().ToList();
		GClass6 gClass = new GClass6();
		List<Item> source = gClass.Items.Where((Item x) => CS_0024_003C_003E8__locals0.intList.Contains(x.ItemID)).ToList();
		List<ItemsInGroup> source2 = gClass.ItemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals0.intList.Contains(x.ItemID.Value)).ToList();
		CS_0024_003C_003E8__locals0.orderNumber = apirequestObj_0.orderHeader.orderNumber;
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.orderNumber))
		{
			CS_0024_003C_003E8__locals0.orderNumber = OrderMethods.GetNewOrderNumber();
		}
		gclass6_0 = new GClass6();
		using (IEnumerator<OrderedItem> enumerator = apirequestObj_0.order_items.OrderBy((OrderedItem x) => x.sortOrder).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass17_1();
				CS_0024_003C_003E8__locals1.orItem = enumerator.Current;
				_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass17_2();
				Item item = new Item();
				CS_0024_003C_003E8__locals2.itemFromDB = source.Where((Item x) => x.ItemID.Equals(CS_0024_003C_003E8__locals1.orItem.itemID)).FirstOrDefault();
				if (CS_0024_003C_003E8__locals2.itemFromDB == null)
				{
					continue;
				}
				item.ItemID = CS_0024_003C_003E8__locals2.itemFromDB.ItemID;
				if (!CS_0024_003C_003E8__locals2.itemFromDB.ItemsInGroups.Any())
				{
					ItemsInGroup itemsInGroup = source2.Where((ItemsInGroup x) => x.ItemID.Value == CS_0024_003C_003E8__locals2.itemFromDB.ItemID).FirstOrDefault();
					if (itemsInGroup != null)
					{
						item.ItemsInGroups.Add(itemsInGroup);
					}
				}
				else
				{
					item.ItemsInGroups = CS_0024_003C_003E8__locals2.itemFromDB.ItemsInGroups;
				}
				item.InventoryCount = CS_0024_003C_003E8__locals2.itemFromDB.InventoryCount;
				item.ItemSalePrice = CS_0024_003C_003E8__locals2.itemFromDB.ItemSalePrice;
				item.ItemType = CS_0024_003C_003E8__locals2.itemFromDB.ItemType;
				item.ItemTypeID = CS_0024_003C_003E8__locals2.itemFromDB.ItemTypeID;
				item.OnSale = CS_0024_003C_003E8__locals2.itemFromDB.OnSale;
				item.TaxRule = CS_0024_003C_003E8__locals2.itemFromDB.TaxRule;
				item.TaxRuleID = CS_0024_003C_003E8__locals2.itemFromDB.TaxRuleID;
				string text3 = (CS_0024_003C_003E8__locals1.orItem.itemName.Contains(" => INSTR: ") ? CS_0024_003C_003E8__locals1.orItem.itemName.ToString().Substring(CS_0024_003C_003E8__locals1.orItem.itemName.ToString().IndexOf(" => INSTR: ")) : "");
				string itemName = ((!string.IsNullOrEmpty(text3)) ? CS_0024_003C_003E8__locals1.orItem.itemName.ToString().Replace(text3, "") : CS_0024_003C_003E8__locals1.orItem.itemName.ToString());
				item.ItemName = itemName;
				item.ItemCost = CS_0024_003C_003E8__locals2.itemFromDB.ItemPrice;
				decimal num = ((CS_0024_003C_003E8__locals1.orItem.itemQty > 0m) ? (CS_0024_003C_003E8__locals1.orItem.itemPrice / CS_0024_003C_003E8__locals1.orItem.itemQty) : CS_0024_003C_003E8__locals1.orItem.itemPrice);
				item.ItemPrice = Convert.ToDecimal(num.ToString(), Thread.CurrentThread.CurrentCulture);
				item.InventoryCount = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.orItem.itemQty.ToString().Replace(",", "."));
				item.CloudItemID = apirequestObj_0.orderHeader.guestCount;
				item.ItemCourse = CS_0024_003C_003E8__locals2.itemFromDB.ItemCourse;
				item.SortOrder = CS_0024_003C_003E8__locals1.orItem.comboID;
				item.Temp = CS_0024_003C_003E8__locals1.orItem.orderID;
				item.Description = CS_0024_003C_003E8__locals1.orItem.instructions.ToUpper();
				if (item.Description.Length <= 250)
				{
					if (!item.ItemName.Contains("SUB:") && !item.ItemName.Contains("ADD:") && !item.ItemName.Contains("OPT:") && !(CS_0024_003C_003E8__locals1.orItem.itemOrderIdentifier != "MainItem"))
					{
						item.ItemCost = CS_0024_003C_003E8__locals2.itemFromDB.ItemCost;
					}
					else
					{
						item.ItemCost = Convert.ToDecimal(num.ToString(), Thread.CurrentThread.CurrentCulture);
					}
					if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orItem.itemOrderIdentifier))
					{
						if (!CS_0024_003C_003E8__locals1.orItem.itemName.Contains("OPT:") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("ADD:"))
						{
							if (CS_0024_003C_003E8__locals1.orItem.itemName.Contains("---") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("OPT:") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("ADD:"))
							{
								item.ItemClassification = "ChildItem";
							}
							else
							{
								item.ItemClassification = "MainItem";
							}
						}
						else
						{
							item.ItemClassification = "OptionItem";
						}
					}
					else
					{
						item.ItemClassification = CS_0024_003C_003E8__locals1.orItem.itemOrderIdentifier;
						if (!CS_0024_003C_003E8__locals1.orItem.itemName.Contains("OPT:") && item.ItemClassification == "OptionItem")
						{
							item.ItemName = " OPT:" + CS_0024_003C_003E8__locals1.orItem.itemName;
						}
						else if (!CS_0024_003C_003E8__locals1.orItem.itemName.Contains("ADD:") && item.ItemClassification == "ChildItem")
						{
							item.ItemName = " ADD:" + CS_0024_003C_003E8__locals1.orItem.itemName;
						}
					}
					item.ItemName = item.ItemName.ToUpper();
					item.Active = !CS_0024_003C_003E8__locals1.orItem.Void;
					if (CS_0024_003C_003E8__locals1.orItem.Void)
					{
						item.ItemColor = CS_0024_003C_003E8__locals1.orItem.voidReason;
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.itemFromDB.StationID) && string.IsNullOrEmpty(item.Temp))
					{
						string[] array = CS_0024_003C_003E8__locals2.itemFromDB.StationID.Split(',');
						for (int i = 0; i < array.Length; i++)
						{
							_003C_003Ec__DisplayClass17_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass17_3();
							CS_0024_003C_003E8__locals3.stationId = array[i];
							Station station = MemoryLoadedObjects.all_stations.Where((Station a) => a.StationID == Convert.ToInt32(CS_0024_003C_003E8__locals3.stationId)).FirstOrDefault();
							if (station != null && !list.Contains(station.StationName))
							{
								list.Add(station.StationName);
							}
						}
					}
					else if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.itemFromDB.StationID) && string.IsNullOrEmpty(item.Temp))
					{
						flag = true;
					}
					item.StationID = "0";
					item.Barcode = CS_0024_003C_003E8__locals1.orItem.DiscountDesc;
					item.ResetQty = CS_0024_003C_003E8__locals1.orItem.itemOptionID;
					list2.Add(item);
					continue;
				}
				throw new Exception("Instruction is too long.");
			}
		}
		short seatNum = (short)((apirequestObj_0.orderHeader.seatNum == 0) ? 1 : apirequestObj_0.orderHeader.seatNum);
		new OrderMethods(gclass6_0).SaveOrder(list2, CS_0024_003C_003E8__locals0.orderNumber.ToUpper(), customer, apirequestObj_0.orderHeader.orderType, 0, text, 0m, 0m, isPaid: false, string.Empty, string.Empty, string.Empty, string.Empty, apirequestObj_0.orderHeader.guestCount, isDiscount: false, string.Empty, seatNum, null, null, (short)employeeByID.EmployeeID, null, "", GratuityRemoved: false, 0);
		new OrderHelper().OrderPrintMadeCheck(text, CS_0024_003C_003E8__locals0.orderNumber, apirequestObj_0.orderHeader.orderType, "", customer, employeeByID.FirstName + " " + employeeByID.LastName, list2.Count());
		if (employeeByID.Users.FirstOrDefault().Role.RoleName == "Staff")
		{
			GuestMethods.AssignEmployeeTable(customer.Replace("Table", string.Empty).Trim(), employeeByID.EmployeeID);
		}
		text2 = string.Join(", ", list);
		string message = ((!string.IsNullOrEmpty(text2)) ? (text2 + " has been notified.") : ((!flag) ? "Your order has been sent into the abyss!" : "Order has been sent."));
		APIResponseObj aPIResponseObj = new APIResponseObj();
		aPIResponseObj.code = 200;
		aPIResponseObj.message = message;
		aPIResponseObj.data = CS_0024_003C_003E8__locals0.orderNumber;
		aPIResponseObj.data2 = OrderHelper.formatTicket(gclass6_0.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault().OrderTicketNumber);
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_14(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		new DataManager();
		APIResponseObj aPIResponseObj = new APIResponseObj();
		if (apirequestObj_0.order_items.Count == 0)
		{
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "success";
			aPIResponseObj.data = "0";
			method_4(httpListenerContext_0, aPIResponseObj);
			return;
		}
		List<Item> list = new List<Item>();
		CS_0024_003C_003E8__locals0.intList = apirequestObj_0.order_items.Select((OrderedItem x) => x.itemID).Distinct().ToList();
		List<Item> source = MemoryLoadedData.all_active_items.Where((Item x) => CS_0024_003C_003E8__locals0.intList.Contains(x.ItemID)).ToList();
		List<ItemsInGroup> source2 = MemoryLoadedObjects.all_itemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals0.intList.Contains(x.ItemID.Value)).ToList();
		using (IEnumerator<OrderedItem> enumerator = apirequestObj_0.order_items.OrderBy((OrderedItem x) => x.sortOrder).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_1();
				CS_0024_003C_003E8__locals1.orItem = enumerator.Current;
				_003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass18_2();
				Item item = new Item();
				CS_0024_003C_003E8__locals2.itemFromDB = source.Where((Item x) => x.ItemID.Equals(CS_0024_003C_003E8__locals1.orItem.itemID)).FirstOrDefault();
				if (CS_0024_003C_003E8__locals2.itemFromDB == null)
				{
					continue;
				}
				item.ItemID = CS_0024_003C_003E8__locals2.itemFromDB.ItemID;
				if (!CS_0024_003C_003E8__locals2.itemFromDB.ItemsInGroups.Any())
				{
					ItemsInGroup itemsInGroup = source2.Where((ItemsInGroup x) => x.ItemID.Value == CS_0024_003C_003E8__locals2.itemFromDB.ItemID).FirstOrDefault();
					if (itemsInGroup != null)
					{
						item.ItemsInGroups.Add(itemsInGroup);
					}
				}
				else
				{
					item.ItemsInGroups = CS_0024_003C_003E8__locals2.itemFromDB.ItemsInGroups;
				}
				item.InventoryCount = CS_0024_003C_003E8__locals2.itemFromDB.InventoryCount;
				item.ItemSalePrice = CS_0024_003C_003E8__locals2.itemFromDB.ItemSalePrice;
				item.ItemType = CS_0024_003C_003E8__locals2.itemFromDB.ItemType;
				item.ItemTypeID = CS_0024_003C_003E8__locals2.itemFromDB.ItemTypeID;
				item.OnSale = CS_0024_003C_003E8__locals2.itemFromDB.OnSale;
				item.TaxRule = CS_0024_003C_003E8__locals2.itemFromDB.TaxRule;
				item.TaxRuleID = CS_0024_003C_003E8__locals2.itemFromDB.TaxRuleID;
				item.ItemName = CS_0024_003C_003E8__locals1.orItem.itemName;
				item.ItemCost = CS_0024_003C_003E8__locals2.itemFromDB.ItemPrice;
				item.ItemPrice = Convert.ToDecimal(CS_0024_003C_003E8__locals1.orItem.itemPrice.ToString(), Thread.CurrentThread.CurrentCulture);
				item.InventoryCount = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.orItem.itemQty.ToString().Replace(",", "."));
				item.CloudItemID = apirequestObj_0.orderHeader.guestCount;
				item.SortOrder = CS_0024_003C_003E8__locals1.orItem.comboID;
				item.Temp = CS_0024_003C_003E8__locals1.orItem.orderID;
				item.Description = CS_0024_003C_003E8__locals1.orItem.instructions;
				if (item.Description.Length <= 250)
				{
					if (!item.ItemName.Contains("SUB:") && !item.ItemName.Contains("ADD:") && !item.ItemName.Contains("OPT:"))
					{
						item.ItemCost = CS_0024_003C_003E8__locals2.itemFromDB.ItemPrice;
					}
					else
					{
						item.ItemCost = Convert.ToDecimal(CS_0024_003C_003E8__locals1.orItem.itemPrice.ToString(), Thread.CurrentThread.CurrentCulture);
					}
					if (!CS_0024_003C_003E8__locals1.orItem.itemName.Contains("OPT:") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("ADD:"))
					{
						if (CS_0024_003C_003E8__locals1.orItem.itemName.Contains("---") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("OPT:") && !CS_0024_003C_003E8__locals1.orItem.itemName.Contains("ADD:"))
						{
							item.ItemClassification = "ChildItem";
						}
						else
						{
							item.ItemClassification = "MainItem";
						}
					}
					else
					{
						item.ItemClassification = "OptionItem";
					}
					item.Active = !CS_0024_003C_003E8__locals1.orItem.Void;
					if (CS_0024_003C_003E8__locals1.orItem.Void)
					{
						item.ItemColor = CS_0024_003C_003E8__locals1.orItem.voidReason;
					}
					list.Add(item);
					continue;
				}
				throw new Exception("Instruction is too long.");
			}
		}
		aPIResponseObj.code = 200;
		aPIResponseObj.message = "success";
		aPIResponseObj.data = Math.Round(TaxMethods.GetTaxWithRounding(list), 2, MidpointRounding.AwayFromZero).ToString();
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_15(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		DataManager dataManager = new DataManager();
		APIResponseObj aPIResponseObj = new APIResponseObj();
		OrderResponseObject orderResponseObject = new OrderResponseObject();
		orderResponseObject.order_items = new List<OrderedItem>();
		if (apirequestObj_0.order_items.Count == 0)
		{
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "success";
			aPIResponseObj.data = JsonConvert.SerializeObject(orderResponseObject);
			method_4(httpListenerContext_0, aPIResponseObj);
			return;
		}
		List<Item> source = new List<Item>();
		CS_0024_003C_003E8__locals0.intList = apirequestObj_0.order_items.Select((OrderedItem x) => x.itemID).Distinct().ToList();
		List<Item> source2 = MemoryLoadedData.all_active_items.Where((Item x) => CS_0024_003C_003E8__locals0.intList.Contains(x.ItemID)).ToList();
		CustomListViewTelerik customListViewTelerik = new CustomListViewTelerik();
		customListViewTelerik.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
		customListViewTelerik.Columns.Add(new ListViewDetailColumn("Qty"));
		customListViewTelerik.Columns.Add(new ListViewDetailColumn("ItemName"));
		customListViewTelerik.Columns.Add(new ListViewDetailColumn("Price"));
		customListViewTelerik.Columns.Add(new ListViewDetailColumn("Ext. Price"));
		short OeComboId = apirequestObj_0.order_items.Max((OrderedItem a) => a.comboID);
		foreach (OrderedItem item2 in apirequestObj_0.order_items.OrderBy((OrderedItem x) => x.sortOrder))
		{
			string[] values = new string[23]
			{
				item2.itemQty.ToString(),
				item2.itemName,
				item2.itemPrice.ToString(),
				(item2.itemPrice * item2.itemQty).ToString("0.00", Thread.CurrentThread.CurrentCulture),
				item2.itemID.ToString(),
				item2.comboID.ToString(),
				item2.orderID,
				item2.instructions,
				"-1",
				"0",
				"0",
				"0",
				false.ToString(),
				"",
				"0",
				item2.DiscountDesc,
				item2.itemOrderIdentifier,
				"0",
				0.ToString(),
				"",
				"",
				false.ToString(),
				""
			};
			ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
			listViewDataItem.Font = customListViewTelerik.Font;
			customListViewTelerik.Items.Add(listViewDataItem);
		}
		foreach (ListViewDataItem item3 in customListViewTelerik.Items)
		{
			_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
			CS_0024_003C_003E8__locals1.itemID = Convert.ToInt32(item3.SubItems[4].ToString());
			Item itemToAdd = source2.Where((Item x) => x.ItemID.Equals(CS_0024_003C_003E8__locals1.itemID)).FirstOrDefault();
			PromotionCheck promotion = PromotionMethods.GetPromotion(customListViewTelerik, itemToAdd, apirequestObj_0.orderHeader.orderType, DateTime.Now);
			if (promotion != null && promotion.IsPromotion)
			{
				item3.SubItems[18] = promotion.PromotionId.ToString();
			}
		}
		PromotionMethods.RecalculatePromotion(customListViewTelerik, apirequestObj_0.orderHeader.orderType, DateTime.Now, ref OeComboId);
		List<Item> list = new List<Item>();
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		CS_0024_003C_003E8__locals0.selectedTag = 0;
		decimal num3 = default(decimal);
		foreach (ListViewDataItem item4 in customListViewTelerik.Items)
		{
			if (!item4.Font.Strikeout)
			{
				num = MathHelper.FractionToDecimal((string.IsNullOrEmpty(item4[0].ToString()) ? "1" : item4[0].ToString()).Replace(",", "."));
				num2 = Convert.ToDecimal(string.IsNullOrEmpty(item4[2].ToString()) ? "0.00" : item4[2].ToString(), Thread.CurrentThread.CurrentCulture);
				CS_0024_003C_003E8__locals0.selectedTag = Convert.ToInt32(item4.SubItems[4].ToString());
				num3 = ((num == 0m) ? 0m : (OrderHelper.GetDiscountFromDiscountDescription(item4.SubItems[15].ToString(), DiscountTypes.Item) / num));
				Item item = ((CS_0024_003C_003E8__locals0.selectedTag == -999) ? dataManager.getDeliveryItem() : MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.selectedTag).FirstOrDefault());
				string temp = item4.SubItems[6].ToString();
				string notes = item4.SubItems[7].ToString();
				if (item != null)
				{
					short num4 = (short)((item.ItemsInGroups.Count() > 0) ? item.ItemsInGroups.FirstOrDefault().GroupID.Value : 0);
					list.Add(new Item
					{
						InventoryCount = num,
						ItemPrice = num2,
						ItemSalePrice = ((num2 >= num3) ? num3 : 0m),
						ItemID = item.ItemID,
						ItemName = item.ItemName,
						ItemLongName = item.ItemLongName,
						TaxRule = item.TaxRule,
						TaxRuleID = item.TaxRuleID,
						ItemTypeID = item.ItemTypeID,
						SortOrder = Convert.ToInt16(item4.SubItems[5].ToString()),
						Barcode = item4.SubItems[15].ToString(),
						ItemCost = ((item4.SubItems[8].ToString() == "-1") ? item.ItemPrice : Convert.ToDecimal(item4.SubItems[8].ToString())),
						Description = item4.SubItems[16].ToString(),
						Active = true,
						TaxesIncluded = item.TaxesIncluded,
						Temp = temp,
						Notes = notes,
						CloudItemID = num4
					});
				}
			}
		}
		decimal num5 = default(decimal);
		decimal num6 = default(decimal);
		foreach (Item item5 in list)
		{
			if (OrderHelper.GetDiscountFromDiscountDescription(item5.Barcode, DiscountTypes.Order) > 0m && item5.ItemPrice == 0m && item5.ItemCost > 0m)
			{
				item5.Barcode = OrderHelper.UpdateDiscountFromDiscountDescription(item5.Barcode, DiscountTypes.Order, 0m);
			}
			num6 += OrderHelper.GetDiscountFromDiscountDescription(item5.Barcode, DiscountTypes.Order);
			item5.ItemCost = item5.ItemPrice;
			num5 += Math.Round(item5.InventoryCount * item5.ItemPrice, 2, MidpointRounding.AwayFromZero);
		}
		decimal discountPercent = default(decimal);
		if (num5 > 0m && num6 > 0m)
		{
			discountPercent = Math.Round(num6 / num5, 10);
		}
		decimal totalDiscount = Math.Round(dataManager.CalculateOrderDiscount(list, num5, discountPercent), 2, MidpointRounding.AwayFromZero);
		using (List<Item>.Enumerator enumerator3 = source.Where((Item a) => a.TaxesIncluded).ToList().GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				_003C_003Ec__DisplayClass19_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass19_2();
				CS_0024_003C_003E8__locals2.taxIncludedItems = enumerator3.Current;
				CS_0024_003C_003E8__locals2.taxIncludedItems.ItemPrice = MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals2.taxIncludedItems.ItemID).First().ItemPrice;
			}
		}
		decimal taxWithRounding = TaxMethods.GetTaxWithRounding(list);
		taxWithRounding = Math.Round(taxWithRounding, 2, MidpointRounding.AwayFromZero);
		orderResponseObject.totalDiscount = totalDiscount;
		orderResponseObject.totalTax = taxWithRounding;
		orderResponseObject.order_items = list.Select((Item a) => new OrderedItem
		{
			instructions = a.Notes,
			orderID = a.Temp,
			itemName = a.ItemName,
			itemID = a.ItemID,
			itemQty = a.InventoryCount,
			comboID = a.SortOrder,
			itemPrice = a.ItemPrice,
			itemOrderIdentifier = a.Description,
			originalPrice = a.ItemCost,
			DiscountDesc = a.Barcode,
			GroupId = (short)a.CloudItemID
		}).ToList();
		aPIResponseObj.code = 200;
		aPIResponseObj.message = "success";
		aPIResponseObj.data = JsonConvert.SerializeObject(orderResponseObject);
		method_4(httpListenerContext_0, aPIResponseObj);
		source = null;
		CS_0024_003C_003E8__locals0.intList = null;
		source2 = null;
	}

	private void method_16(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		APIResponseObj aPIResponseObj = new APIResponseObj();
		decimal d = default(decimal);
		if (SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON")
		{
			new GClass6();
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
			if (GuestMethods.GetCurrentTableGuestCapacity(apirequestObj_0.orderHeader.customer.ToUpper().Replace("TABLE ", "")) >= Convert.ToInt32(settingValueByKey))
			{
				d = OrderMethods.ComputeAutoGratuity(apirequestObj_0.orderHeader.orderNumber, Thread.CurrentThread.CurrentCulture.Name);
			}
		}
		aPIResponseObj.code = 200;
		aPIResponseObj.message = "success";
		aPIResponseObj.data = Math.Round(d, 2, MidpointRounding.AwayFromZero).ToString();
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_17(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		GuestMethods.UpdateTableGuestCapacity(apirequestObj_0.orderHeader.customer.ToUpper().Replace("TABLE ", ""), apirequestObj_0.orderHeader.guestCount, apirequestObj_0.orderHeader.employeeID);
		APIResponseObj aPIResponseObj = new APIResponseObj();
		aPIResponseObj.code = 200;
		aPIResponseObj.message = "Success";
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_18(HttpListenerContext httpListenerContext_0, string string_0)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.tablename = string_0;
		APIResponseObj aPIResponseObj = new APIResponseObj();
		try
		{
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.tablename = CS_0024_003C_003E8__locals0.tablename.ToUpper().Replace("TABLE ", string.Empty).Trim();
			GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.tablename, 0, 0);
			GuestMethods.AssignEmployeeTable(CS_0024_003C_003E8__locals0.tablename, 0);
			gClass.Refresh(RefreshMode.OverwriteCurrentValues);
			foreach (Order item in gClass.Orders.Where((Order o) => o.Customer.ToUpper() == "TABLE " + CS_0024_003C_003E8__locals0.tablename && o.OrderType == OrderTypes.DineIn && o.Paid == true && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-14.0) && o.DateCleared == null).ToList())
			{
				item.DateCleared = DateTime.Now;
				item.TipRecorded = true;
				item.Synced = false;
			}
			Helper.SubmitChangesWithCatch(gClass);
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "Success";
		}
		catch (Exception ex)
		{
			aPIResponseObj.code = 201;
			aPIResponseObj.message = ex.Message;
		}
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_19(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0.data = apirequestObj_0;
		GClass6 gClass = new GClass6();
		List<Order> list;
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.data.orderHeader.orderNumber))
		{
			list = (from o in gClass.Orders
				where o.OrderNumber == CS_0024_003C_003E8__locals0.data.orderHeader.orderNumber && o.Paid == false && o.Void == false
				select o into x
				orderby x.ComboID
				select x).ThenBy((Order y) => y.DateCreated).ToList();
			Order order = list.FirstOrDefault();
			decimal num = list.Sum((Order x) => x.Total);
			decimal num2 = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("card_transaction_fee"));
			if (num2 > 0m)
			{
				decimal num3 = num * (num2 / 100m);
				if (num3 > 0m && list.Where((Order x) => x.ItemName == "Transaction Fee").FirstOrDefault() == null)
				{
					Order item = OrderMethods.CreateTransactionFeeOrder(num3, order.OrderNumber, order.OrderType, order.Customer, order.CustomerInfo, order.CustomerInfoName, order.PaymentMethods.Replace(',', '.'), (short)((CS_0024_003C_003E8__locals0.data.orderHeader.employeeID == 0) ? 1 : ((short)CS_0024_003C_003E8__locals0.data.orderHeader.employeeID)), order.TerminalID, order.GuestCount);
					list.Add(item);
				}
			}
		}
		else
		{
			list = ((!(CS_0024_003C_003E8__locals0.data.orderHeader.customer == "TAKEOUTS")) ? (from o in gClass.Orders
				where o.Paid == false && o.Void == false && o.OrderType == CS_0024_003C_003E8__locals0.data.orderHeader.orderType && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)
				select o into a
				orderby a.DateCreated
				select a).ThenBy((Order b) => b.ComboID).ToList() : gClass.Orders.Where((Order o) => o.Paid == false && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && (o.OrderType == OrderTypes.PickUp || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.ToGo)).ToList().OrderByItemCourse()
				.ThenBy((Order b) => b.ComboID)
				.ThenBy((Order a) => a.DateCreated)
				.ToList());
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.data.orderHeader.customer))
			{
				list = list.Where((Order x) => x.Customer.ToUpper() == CS_0024_003C_003E8__locals0.data.orderHeader.customer).ToList();
			}
		}
		foreach (Order item2 in list)
		{
			item2.TerminalID = null;
			item2.Terminal = null;
			item2.Terminal1 = null;
		}
		OrdersResponseObject ordersResponseObject = new OrdersResponseObject();
		ordersResponseObject.code = 200;
		ordersResponseObject.message = string.Empty;
		ordersResponseObject.orders = list;
		method_4(httpListenerContext_0, ordersResponseObject);
	}

	private void method_20(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		APIResponseObj aPIResponseObj = new APIResponseObj();
		if (!AuthMethods.IsPinRequired(apirequestObj_0.control_access.form_name, apirequestObj_0.control_access.control_name))
		{
			aPIResponseObj.code = 201;
			aPIResponseObj.message = "Pin Not Needed";
		}
		else
		{
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "Pin Needed";
		}
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_21(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		bool num = UserMethods.AuthenticateUser(apirequestObj_0.AuthPin.password, apirequestObj_0.AuthPin.roles);
		APIPinAuthenticationResponseObj aPIPinAuthenticationResponseObj = new APIPinAuthenticationResponseObj();
		if (num)
		{
			Employee employee = UserMethods.AuthenticateUser(apirequestObj_0.AuthPin.password);
			aPIPinAuthenticationResponseObj.code = 200;
			aPIPinAuthenticationResponseObj.message = "Success";
			if (employee != null)
			{
				aPIPinAuthenticationResponseObj.data = employee.EmployeeID.ToString();
				aPIPinAuthenticationResponseObj.name = employee.FirstName;
			}
		}
		else
		{
			aPIPinAuthenticationResponseObj.code = 401;
			aPIPinAuthenticationResponseObj.message = "Unauthorize";
		}
		method_4(httpListenerContext_0, aPIPinAuthenticationResponseObj);
	}

	private void method_22(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		ValidateProductKeyPostData key = new ValidateProductKeyPostData
		{
			product_key = apirequestObj_0.pk_object.product_key,
			system_id = apirequestObj_0.pk_object.system_id,
			OSver = apirequestObj_0.pk_object.os_ver
		};
		APIProductKeyReponseObj aPIProductKeyReponseObj = new APIProductKeyReponseObj();
		ValidateProductKeyResponse validateProductKeyResponse = SyncMethods.ValidateProductKey(key);
		if (validateProductKeyResponse.code == 200)
		{
			aPIProductKeyReponseObj.product_key = StringCipher.Encrypt(apirequestObj_0.pk_object.product_key, "HipposHQ");
			aPIProductKeyReponseObj.install_token = StringCipher.Encrypt(validateProductKeyResponse.install_token, "HipposHQ");
			aPIProductKeyReponseObj.install_id = StringCipher.Encrypt(validateProductKeyResponse.install_id, "HipposHQ");
			aPIProductKeyReponseObj.code = 200;
			aPIProductKeyReponseObj.message = "Success";
		}
		else
		{
			aPIProductKeyReponseObj.code = 401;
			aPIProductKeyReponseObj.message = validateProductKeyResponse.message;
		}
		method_4(httpListenerContext_0, aPIProductKeyReponseObj);
	}

	private void method_23(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		string product_key = StringCipher.Decrypt(apirequestObj_0.pk_object.product_key, "HipposHQ");
		string text = StringCipher.Decrypt(apirequestObj_0.pk_object.install_token, "HipposHQ");
		string iv = StringCipher.Decrypt(apirequestObj_0.pk_object.install_id, "HipposHQ");
		ValidateProductKeyResponse validateProductKeyResponse = SyncMethods.ValidateProductKey(new ValidateProductKeyPostData
		{
			product_key = product_key,
			system_id = apirequestObj_0.pk_object.system_id,
			OSver = apirequestObj_0.pk_object.os_ver
		});
		string[] array = new CryptoHelper().Decrypt(text, iv).Split(';');
		DateTime dateTime = DateTime.Now.AddDays(-1.0);
		APIResponseObj aPIResponseObj = new APIResponseObj();
		if (validateProductKeyResponse.code == 201)
		{
			try
			{
				dateTime = DateTime.ParseExact(array[2], "MM/dd/yyyy", CultureInfo.CurrentCulture);
				if (DateTime.Now.Date > dateTime)
				{
					aPIResponseObj.code = 401;
					aPIResponseObj.message = "License expired";
				}
				else
				{
					aPIResponseObj.code = 200;
					aPIResponseObj.message = "License Auth";
				}
			}
			catch
			{
				aPIResponseObj.code = 401;
				aPIResponseObj.message = "Database Error";
			}
		}
		else
		{
			aPIResponseObj.code = 401;
			aPIResponseObj.message = validateProductKeyResponse.message;
		}
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_24(HttpListenerContext httpListenerContext_0)
	{
		SettingsResponseObject settingsResponseObject = new SettingsResponseObject();
		settingsResponseObject.code = 200;
		settingsResponseObject.message = "success";
		settingsResponseObject.ListOfSettings = SettingsHelper.HipposSettings.Where((SettingsObject a) => !a.Key.Contains("cloudsync") && !a.Key.Contains("smtp") && !a.Key.Contains("sms")).ToList();
		method_4(httpListenerContext_0, settingsResponseObject);
	}

	private void method_25(HttpListenerContext httpListenerContext_0, string string_0)
	{
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals0.param = string_0;
		new GClass6();
		ReasonsResponseObject reasonsResponseObject = new ReasonsResponseObject();
		reasonsResponseObject.code = 200;
		reasonsResponseObject.message = string.Empty;
		reasonsResponseObject.reasons = MemoryLoadedObjects.all_reasons.Where((Reason x) => x.ReasonType == CS_0024_003C_003E8__locals0.param).ToList();
		method_4(httpListenerContext_0, reasonsResponseObject);
	}

	private void method_26(HttpListenerContext httpListenerContext_0, string string_0, string string_1)
	{
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals0.param2 = string_1;
		new GClass6();
		StatusCodeResponse statusCodeResponse = new StatusCodeResponse();
		statusCodeResponse.code = 400;
		statusCodeResponse.message = "Print Failed";
		try
		{
			Terminal terminal = MemoryLoadedObjects.all_terminals.Where((Terminal x) => x.SystemName == CS_0024_003C_003E8__locals0.param2.ToUpper()).FirstOrDefault();
			if (terminal != null)
			{
				PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, terminal.DefaultPrinter);
				if (PrintHelper.CheckPCPrintQueueStatus(terminal.DefaultPrinter))
				{
					statusCodeResponse.code = 200;
					statusCodeResponse.message = "Success";
				}
			}
		}
		catch
		{
		}
		method_4(httpListenerContext_0, statusCodeResponse);
	}

	private void method_27(HttpListenerContext httpListenerContext_0, string string_0, string string_1)
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals0.param2 = string_1;
		GClass6 gClass = new GClass6();
		StatusCodeResponse statusCodeResponse = new StatusCodeResponse();
		statusCodeResponse.code = 400;
		statusCodeResponse.message = "Action Failed";
		CS_0024_003C_003E8__locals0.orderNumber = string_0;
		try
		{
			Terminal terminal = MemoryLoadedObjects.all_terminals.Where((Terminal x) => x.SystemName == CS_0024_003C_003E8__locals0.param2.ToUpper()).FirstOrDefault();
			if (terminal != null)
			{
				List<PaymentTransactionObject> trans_objects = new List<PaymentTransactionObject>();
				bool flag = false;
				List<Order> list = gClass.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.Void == false && x.Paid == false).ToList();
				int total_due = (int)(list.Sum((Order x) => x.Total) * 100m);
				if (terminal.PaymentProviderName == PaymentProviderNames.FirstData)
				{
					UIPaymentHelper.ProcessFirstData(null, terminal, "sale", total_due, CS_0024_003C_003E8__locals0.orderNumber, "", null, out trans_objects, showForm: false);
				}
				else
				{
					UIPaymentHelper.ProcessIngenico(terminal.PaymentProviderName, null, terminal, "sale", total_due, CS_0024_003C_003E8__locals0.orderNumber, "", null, out trans_objects, showForm: false);
				}
				foreach (PaymentTransactionObject item in trans_objects)
				{
					flag = true;
					if (!string.IsNullOrEmpty(item.customerreceipt) && (item.customerreceipt.ToUpper().Contains("NOT COMPLETED") || item.customerreceipt.ToUpper().Contains("DECLINED") || item.customerreceipt.ToUpper().Contains("*CANCELLED*") || !item.merchantreceipt.ToUpper().Contains("APPROVED")))
					{
						flag = false;
					}
					if (flag && !string.IsNullOrEmpty(item.totalamount) && Convert.ToDecimal(item.totalamount) / 100m <= 0m)
					{
						flag = false;
					}
					if (!flag)
					{
						continue;
					}
					decimal num = Convert.ToDecimal(item.totalamount) / 100m;
					string receipt = item.customerreceipt.ToUpper();
					if (!(num > 0m))
					{
						continue;
					}
					string paymentMethods = UIPaymentHelper.GetActualPaymentMethod("DEBIT/CREDIT", receipt) + "=" + num.ToString("0.00") + "|";
					foreach (Order item2 in list)
					{
						item2.PaymentMethods = paymentMethods;
						item2.Paid = true;
						item2.DatePaid = DateTime.Now;
						item2.Synced = false;
					}
					gClass.SubmitChanges();
					PrintHelper.GenerateReceipt(CS_0024_003C_003E8__locals0.orderNumber, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, terminal.DefaultPrinter);
					statusCodeResponse.code = 200;
					statusCodeResponse.message = "Success";
				}
			}
		}
		catch
		{
		}
		method_4(httpListenerContext_0, statusCodeResponse);
	}

	private void method_28(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		new GClass6();
		APIResponseObj aPIResponseObj = new APIResponseObj();
		if (apirequestObj_0.clover_response != null)
		{
			decimal num = (decimal)apirequestObj_0.clover_response.Payment.amount / 100m;
			if (num <= 0m)
			{
				aPIResponseObj.code = 401;
				aPIResponseObj.message = "Transaction is cancelled.";
				method_4(httpListenerContext_0, aPIResponseObj);
				return;
			}
			PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
			paymentTransactionObject.approvalcode = apirequestObj_0.clover_response.Payment.cardTransaction.authCode;
			paymentTransactionObject.cardaccount = apirequestObj_0.clover_response.Payment.cardTransaction.last4;
			paymentTransactionObject.invoicenumber = apirequestObj_0.orderHeader.orderNumber;
			paymentTransactionObject.responsecode = (apirequestObj_0.clover_response.Success ? "00" : "51");
			paymentTransactionObject.totalamount = apirequestObj_0.clover_response.Payment.amount.ToString();
			paymentTransactionObject.transaction_type = "sale";
			paymentTransactionObject.rawdata = JsonConvert.SerializeObject(apirequestObj_0.clover_response, Formatting.Indented, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				MaxDepth = 2000
			});
			string text = FirstData.FormatCloverReceipt("sale", paymentTransactionObject.rawdata, apirequestObj_0.orderHeader.orderNumber);
			string customerreceipt = (paymentTransactionObject.merchantreceipt = text);
			paymentTransactionObject.customerreceipt = customerreceipt;
			PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, httpListenerContext_0.Request.RemoteEndPoint.Address.ToString(), httpListenerContext_0.Request.RemoteEndPoint.Port, "request made on clover app", "request", apirequestObj_0.orderHeader.orderNumber, "");
			PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, httpListenerContext_0.Request.RemoteEndPoint.Address.ToString(), httpListenerContext_0.Request.RemoteEndPoint.Port, paymentTransactionObject.rawdata, "response", apirequestObj_0.orderHeader.orderNumber, "");
			UIPaymentHelper.RecordPaymentTransaction(paymentTransactionObject, apirequestObj_0.orderHeader.orderNumber, null);
			string string_ = "DEBIT/CREDIT";
			if (paymentTransactionObject.customerreceipt.Contains("VISA"))
			{
				string_ = "Visa";
			}
			else if (!paymentTransactionObject.customerreceipt.Contains("INTERAC") && !paymentTransactionObject.customerreceipt.Contains("DEBIT"))
			{
				if (!paymentTransactionObject.customerreceipt.Contains("AMERICAN EXPRESS") && !paymentTransactionObject.customerreceipt.Contains("AMEX"))
				{
					if (!paymentTransactionObject.customerreceipt.Contains("MASTERCARD") && !paymentTransactionObject.customerreceipt.Contains("MC ****"))
					{
						if (paymentTransactionObject.customerreceipt.Contains("JCB"))
						{
							string_ = "JCB";
						}
						else if (paymentTransactionObject.customerreceipt.Contains("DISCOVERY CARD"))
						{
							string_ = "Discovery Card";
						}
						else if (paymentTransactionObject.customerreceipt.Contains("CREDIT"))
						{
							string_ = "CREDIT";
						}
					}
					else
					{
						string_ = "MasterCard";
					}
				}
				else
				{
					string_ = "American Express";
				}
			}
			else
			{
				string_ = "Interac";
			}
			method_30(apirequestObj_0.orderHeader.orderNumber, num, ((decimal?)apirequestObj_0.clover_response.Payment.tipAmount / (decimal?)100m).Value, string_, (short)apirequestObj_0.orderHeader.employeeID);
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "Success";
		}
		else
		{
			aPIResponseObj.code = 400;
			aPIResponseObj.message = "No data";
		}
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_29(HttpListenerContext httpListenerContext_0, APIRequestObj apirequestObj_0)
	{
		new GClass6();
		APIResponseObj aPIResponseObj = new APIResponseObj();
		if (apirequestObj_0.clover_response != null)
		{
			decimal num = (decimal)apirequestObj_0.poynt_response.amounts.transactionAmount / 100m;
			if (num <= 0m)
			{
				aPIResponseObj.code = 401;
				aPIResponseObj.message = "Transaction is cancelled.";
				method_4(httpListenerContext_0, aPIResponseObj);
				return;
			}
			PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
			paymentTransactionObject.approvalcode = apirequestObj_0.poynt_response.id;
			paymentTransactionObject.cardaccount = apirequestObj_0.poynt_response.fundingSource.card.numberLast4;
			paymentTransactionObject.invoicenumber = apirequestObj_0.orderHeader.orderNumber;
			paymentTransactionObject.responsecode = ((apirequestObj_0.poynt_response.status == "AUTHORIZED") ? "00" : "51");
			paymentTransactionObject.totalamount = apirequestObj_0.poynt_response.amounts.transactionAmount.ToString();
			paymentTransactionObject.transaction_type = "sale";
			paymentTransactionObject.rawdata = JsonConvert.SerializeObject(apirequestObj_0.poynt_response, Formatting.Indented, new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				MaxDepth = 2000
			});
			Poynt.FormatPoyntReceipt("sale", paymentTransactionObject.rawdata);
			PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, httpListenerContext_0.Request.RemoteEndPoint.Address.ToString(), httpListenerContext_0.Request.RemoteEndPoint.Port, "request made on poynt app", "request", apirequestObj_0.orderHeader.orderNumber, "");
			PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, httpListenerContext_0.Request.RemoteEndPoint.Address.ToString(), httpListenerContext_0.Request.RemoteEndPoint.Port, paymentTransactionObject.rawdata, "response", apirequestObj_0.orderHeader.orderNumber, "");
			UIPaymentHelper.RecordPaymentTransaction(paymentTransactionObject, apirequestObj_0.orderHeader.orderNumber, null);
			string string_ = "DEBIT/CREDIT";
			if (paymentTransactionObject.customerreceipt.Contains("VISA"))
			{
				string_ = "Visa";
			}
			else if (!paymentTransactionObject.customerreceipt.Contains("INTERAC") && !paymentTransactionObject.customerreceipt.Contains("DEBIT"))
			{
				if (!paymentTransactionObject.customerreceipt.Contains("AMERICAN EXPRESS") && !paymentTransactionObject.customerreceipt.Contains("AMEX"))
				{
					if (!paymentTransactionObject.customerreceipt.Contains("MASTERCARD") && !paymentTransactionObject.customerreceipt.Contains("MC ****"))
					{
						if (paymentTransactionObject.customerreceipt.Contains("JCB"))
						{
							string_ = "JCB";
						}
						else if (paymentTransactionObject.customerreceipt.Contains("DISCOVERY CARD"))
						{
							string_ = "Discovery Card";
						}
						else if (paymentTransactionObject.customerreceipt.Contains("CREDIT"))
						{
							string_ = "CREDIT";
						}
					}
					else
					{
						string_ = "MasterCard";
					}
				}
				else
				{
					string_ = "American Express";
				}
			}
			else
			{
				string_ = "Interac";
			}
			method_30(apirequestObj_0.orderHeader.orderNumber, num, (decimal)apirequestObj_0.poynt_response.amounts.tipAmount / 100m, string_, (short)apirequestObj_0.orderHeader.employeeID);
			aPIResponseObj.code = 200;
			aPIResponseObj.message = "Success";
		}
		else
		{
			aPIResponseObj.code = 400;
			aPIResponseObj.message = "No data";
		}
		method_4(httpListenerContext_0, aPIResponseObj);
	}

	private void method_30(string string_0, decimal decimal_0, decimal decimal_1, string string_1, short short_0)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.ordernumber = string_0;
		GClass6 gClass = new GClass6();
		List<Order> list = (from x in new OrderMethods(gClass).OpenOrders()
			where x.OrderNumber == CS_0024_003C_003E8__locals0.ordernumber && !x.Paid && !x.Void
			select x into y
			orderby y.DateCreated
			select y).ToList();
		decimal num = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("card_transaction_fee"));
		if (num > 0m)
		{
			decimal num2 = list.Sum((Order x) => x.Total) * (num / 100m);
			if (num2 > 0m && list.Where((Order x) => x.ItemName == "Transaction Fee").FirstOrDefault() == null)
			{
				Order order = list.FirstOrDefault();
				Order order2 = OrderMethods.CreateTransactionFeeOrder(num2, order.OrderNumber, order.OrderType, order.Customer, order.CustomerInfo, order.CustomerInfoName, order.PaymentMethods.Replace(',', '.'), short_0, order.TerminalID, order.GuestCount);
				gClass.Orders.InsertOnSubmit(order2);
				list.Add(order2);
			}
		}
		if (list.Count() <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass34_1();
		decimal num3 = list.Sum((Order x) => x.Total);
		CS_0024_003C_003E8__locals1.table = null;
		bool flag = false;
		flag = ((SettingsHelper.GetSettingValueByKey("auto_clear_table") == "ON") ? true : false);
		Order order3 = list.FirstOrDefault();
		if (order3.PaymentMethods == "SAVED ORDER")
		{
			order3.PaymentMethods = "";
		}
		string paymentMethods = order3.PaymentMethods + string_1 + "=" + (decimal_0 + decimal_1).ToString("0.00") + "|";
		decimal tenderAmount = order3.TenderAmount + (decimal_0 + decimal_1);
		decimal num4 = order3.TipAmount + decimal_1;
		bool flag2 = false;
		decimal num5 = list.Sum((Order a) => a.SubTotal);
		foreach (Order item in list)
		{
			if (decimal_0 + item.TenderAmount >= num3)
			{
				flag2 = true;
				item.Paid = true;
				item.DatePaid = DateTime.Now;
				if (flag)
				{
					item.DateCleared = DateTime.Now;
				}
			}
			item.PaymentMethods = paymentMethods;
			item.TenderAmount = tenderAmount;
			item.TipAmount = num4;
			string discountType = TipTypes.Card;
			if (item.PaymentMethods.ToUpper().Contains("CASH"))
			{
				discountType = TipTypes.Cash;
			}
			item.TipDesc = OrderHelper.UpdateDiscountFromDiscountDescription(item.TipDesc, discountType, num4);
			item.TipRecorded = ((item.TipAmount > 0m) ? true : false);
			if (item.TipAmount > 0m)
			{
				List<string> list2 = new List<string>();
				foreach (CustomTipSharing item2 in MemoryLoadedObjects.all_tip_sharing.Where((CustomTipSharing a) => a.Percentage > 0m))
				{
					decimal num6 = item.TipAmount * item2.Percentage / 100m;
					if (num6 > 0m && item2.TipShareType == 1 && item.TipAmount > 0m)
					{
						list2.Add(item2.TipName + "=" + num6.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
					else if (item2.TipShareType == 2)
					{
						num6 = num5 * item2.Percentage / 100m;
						list2.Add(item2.TipName + "=" + num6.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
				}
				if (list2 != null && list2.Count > 0)
				{
					item.TipShareDesc = string.Join("|", list2);
				}
			}
			item.UserCashout = short_0;
			item.Synced = false;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.table))
			{
				CS_0024_003C_003E8__locals1.table = item.Customer;
			}
		}
		if (flag && flag2)
		{
			CS_0024_003C_003E8__locals1.table = CS_0024_003C_003E8__locals1.table.ToUpper().Replace("TABLE", string.Empty).Trim();
			Layout layout = gClass.Layouts.Where((Layout x) => x.TableName == CS_0024_003C_003E8__locals1.table).FirstOrDefault();
			if (layout != null)
			{
				layout.CurrentGuests = 0;
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public HTTPHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		// base._002Ector();
	}
}
