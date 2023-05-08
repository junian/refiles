using System;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CorePOS.Business.Objects;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public class SQLLogMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public Order objOrder;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public Item objItem;

		public _003C_003Ec__DisplayClass2_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_2
	{
		public OnlineOrderSyncQueue objQueue;

		public _003C_003Ec__DisplayClass2_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public static void SubmitChangesWithCatch(GClass6 context)
	{
		int num = 3;
		bool flag = false;
		while (num > 0 && !flag)
		{
			try
			{
				context.SubmitChanges(ConflictMode.ContinueOnConflict);
				flag = true;
			}
			catch (ChangeConflictException)
			{
				foreach (ObjectChangeConflict changeConflict in context.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.KeepChanges);
				}
				try
				{
					context.Refresh(RefreshMode.KeepChanges);
					context.SubmitChanges(ConflictMode.ContinueOnConflict);
					flag = true;
				}
				catch (ChangeConflictException)
				{
					foreach (ObjectChangeConflict changeConflict2 in context.ChangeConflicts)
					{
						changeConflict2.Resolve(RefreshMode.OverwriteCurrentValues);
					}
					flag = true;
				}
			}
			catch (SqlException ex3)
			{
				if (ex3.Number != 1205)
				{
					WriteLog(context);
					NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, ex3);
					throw;
				}
				Thread.Sleep(1000);
				num--;
				if (num <= 0)
				{
					WriteLog(context);
					NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, ex3);
					throw;
				}
			}
		}
	}

	public static void WriteLog(GClass6 context)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "datalogs\\";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = AppDomain.CurrentDomain.BaseDirectory + "datalogs\\processed\\";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		string path2 = text + "log_" + DateTime.Now.ToString("yyyyMMdd_hhmmssFFF") + ".txt";
		string contents = JsonConvert.SerializeObject(context.GetChangeSet());
		if (File.Exists(path2))
		{
			File.WriteAllText(path2, contents);
		}
	}

	public static string RunLog()
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "datalogs\\";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			return null;
		}
		string text2 = AppDomain.CurrentDomain.BaseDirectory + "datalogs\\processed\\";
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		FileInfo[] files = new DirectoryInfo(text).GetFiles("*.txt");
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			LinqChangeSet linqChangeSet = JsonConvert.DeserializeObject<LinqChangeSet>(File.ReadAllText(text + fileInfo.Name));
			GClass6 gClass = new GClass6();
			foreach (object insert in linqChangeSet.Inserts)
			{
				string text3 = JsonConvert.SerializeObject(insert);
				try
				{
					if (text3.Contains("OrderId") && text3.Contains("PaymentMethod"))
					{
						Order order = JsonConvert.DeserializeObject<Order>(text3);
						if (order != null)
						{
							gClass.Orders.InsertOnSubmit(order);
							num++;
						}
					}
					else if (!text3.Contains("OrderId") && !text3.Contains("PaymentMethod") && text3.Contains("ItemID"))
					{
						Item item = JsonConvert.DeserializeObject<Item>(text3);
						if (item != null)
						{
							gClass.Items.InsertOnSubmit(item);
							num2++;
						}
					}
					else if (!text3.Contains("OrderId") && !text3.Contains("PaymentMethod") && !text3.Contains("ItemID") && text3.Contains("RawData"))
					{
						OnlineOrderSyncQueue onlineOrderSyncQueue = JsonConvert.DeserializeObject<OnlineOrderSyncQueue>(text3);
						if (onlineOrderSyncQueue != null)
						{
							gClass.OnlineOrderSyncQueues.InsertOnSubmit(onlineOrderSyncQueue);
							num3++;
						}
					}
				}
				catch
				{
				}
			}
			foreach (object update in linqChangeSet.Updates)
			{
				string text4 = JsonConvert.SerializeObject(update);
				try
				{
					if (text4.Contains("OrderId") && text4.Contains("PaymentMethod"))
					{
						_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
						CS_0024_003C_003E8__locals0.objOrder = JsonConvert.DeserializeObject<Order>(text4);
						Order order2 = gClass.Orders.Where((Order x) => x.OrderId == CS_0024_003C_003E8__locals0.objOrder.OrderId).FirstOrDefault();
						if (order2 != null)
						{
							CS_0024_003C_003E8__locals0.objOrder.CopyProperties(order2);
							num++;
						}
					}
					else if (!text4.Contains("OrderId") && !text4.Contains("PaymentMethod") && text4.Contains("ItemID"))
					{
						_003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass2_1();
						CS_0024_003C_003E8__locals1.objItem = JsonConvert.DeserializeObject<Item>(text4);
						Item item2 = gClass.Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.objItem.ItemID).FirstOrDefault();
						if (item2 != null)
						{
							CS_0024_003C_003E8__locals1.objItem.CopyProperties(item2);
							num2++;
						}
					}
					else if (!text4.Contains("OrderId") && !text4.Contains("PaymentMethod") && !text4.Contains("ItemID") && text4.Contains("Provider") && text4.Contains("RawData"))
					{
						_003C_003Ec__DisplayClass2_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass2_2();
						CS_0024_003C_003E8__locals2.objQueue = JsonConvert.DeserializeObject<OnlineOrderSyncQueue>(text4);
						OnlineOrderSyncQueue onlineOrderSyncQueue2 = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue x) => x.Id == CS_0024_003C_003E8__locals2.objQueue.Id).FirstOrDefault();
						if (onlineOrderSyncQueue2 != null)
						{
							CS_0024_003C_003E8__locals2.objQueue.CopyProperties(onlineOrderSyncQueue2);
							num3++;
						}
					}
				}
				catch
				{
				}
			}
			gClass.SubmitChanges();
		}
		array = files;
		foreach (FileInfo fileInfo2 in array)
		{
			File.Copy(text + fileInfo2.Name, text2 + fileInfo2.Name);
			File.Delete(text + fileInfo2.Name);
		}
		string text5 = string.Empty;
		if (num > 0)
		{
			text5 = text5 + num + " order records were recovered.\r\n";
		}
		if (num2 > 0)
		{
			text5 = text5 + num2 + " items were recovered.\r\n";
		}
		if (num3 > 0)
		{
			text5 = text5 + num3 + " online order records were recovered.\r\n";
		}
		return text5;
	}

	protected static void smethod_0(string string_0)
	{
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		sqlConnection.Open();
		new SqlCommand(string_0, sqlConnection).ExecuteNonQuery();
		sqlConnection.Close();
	}

	public SQLLogMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
