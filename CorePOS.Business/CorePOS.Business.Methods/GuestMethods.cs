using System;
using System.Collections.Generic;
using System.Linq;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class GuestMethods
{
	public static void AssignEmployeeTable(string tableName, int? EmployeeId)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		GClass6 gClass = new GClass6();
		Layout layout = gClass.Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault();
		if (layout != null)
		{
			layout.EmployeeID = EmployeeId;
		}
		if (EmployeeId.HasValue && EmployeeId.Value != 0)
		{
			foreach (Order item in (from x in new OrderMethods(gClass).UnPaidOpenOrders(OrderTypes.DineIn, "Table " + CS_0024_003C_003E8__locals0.tableName)
				where x.DateCreated >= DateTime.Now.AddDays(-1.0)
				select x).ToList())
			{
				if (!(SettingsHelper.GetSettingValueByKey("delivery_management") == "ON") || !(item.OrderType == OrderTypes.Delivery) || !MemoryLoadedData.IsDeliveryManagement)
				{
					item.UserServed = (short)EmployeeId.Value;
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static int? GetEmployeeTable(string tableName)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		return new GClass6().Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault()?.EmployeeID;
	}

	public static DateTime? GetDateTimeSeatedTable(string tableName)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		return new GClass6().Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault()?.DateTimeSeated;
	}

	public static void UpdateDateTimeSeatedOrder(string OrderNumber, DateTime DateTimeSeated)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.OrderNumber = OrderNumber;
		GClass6 gClass = new GClass6();
		foreach (Order item in gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.OrderNumber).ToList())
		{
			item.DateTimeSeated = DateTimeSeated;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void UpdateTableGuestCapacity(string tableName, int numberOfGuests, int empID, bool updateDateSeated = false)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		GClass6 gClass = new GClass6();
		Layout layout = gClass.Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault();
		if (layout == null)
		{
			return;
		}
		layout.CurrentGuests = numberOfGuests;
		int? employeeID = layout.EmployeeID;
		if (!((employeeID.GetValueOrDefault() == 0) & employeeID.HasValue) && empID != 0)
		{
			Employee employeeByID = EmployeeMethods.getEmployeeByID(empID);
			if (employeeByID != null)
			{
				if (employeeByID.Users.FirstOrDefault().Role.RoleName == "Staff")
				{
					layout.EmployeeID = empID;
				}
			}
			else
			{
				layout.EmployeeID = 0;
			}
		}
		else
		{
			layout.EmployeeID = empID;
		}
		if (updateDateSeated)
		{
			layout.DateTimeSeated = DateTime.Now;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void UpdateTableGuestCapacityByOrderGuestCount(string tableName)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		GClass6 gClass = new GClass6();
		Layout layout = gClass.Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault();
		if (layout != null)
		{
			List<OrderResult> source = (from o in new OrderMethods().GetMultipleBills("Table " + CS_0024_003C_003E8__locals0.tableName, OrderTypes.DineIn)
				where o.DateCreated.AddHours(24.0) > DateTime.Now
				select o into a
				group a by a.OrderNumber into a
				select a.FirstOrDefault()).ToList();
			int num2 = (layout.CurrentGuests = ((source.Count() <= 1) ? 1 : source.Sum((OrderResult a) => a.GuestCount)));
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static short GetCurrentTableGuestCapacity(string tableName)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		Layout layout = new GClass6().Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault();
		if (layout != null)
		{
			return (short)layout.CurrentGuests;
		}
		return 1;
	}

	public static short GetCurrentTableGuestCapacity(string tableName, string orderNumber)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		Order order = new GClass6().Orders.Where((Order l) => l.Customer.ToLower() == CS_0024_003C_003E8__locals0.tableName.ToLower() && l.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
		if (order != null)
		{
			return (short)order.GuestCount;
		}
		return -1;
	}

	public static short GetTotalTableGuestCapacity(string tableName)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		Layout layout = new GClass6().Layouts.Where((Layout l) => l.TableName.Trim().ToLower() == CS_0024_003C_003E8__locals0.tableName.Trim().ToLower()).FirstOrDefault();
		if (layout != null)
		{
			return (short)(layout.NumOfSeats.HasValue ? layout.NumOfSeats.Value : 0);
		}
		return -1;
	}

	public static short GetCurrentGuestCapacity()
	{
		List<Layout> list = new GClass6().Layouts.ToList();
		if (list.Count >= 0)
		{
			return (short)list.Sum((Layout a) => a.CurrentGuests);
		}
		return -1;
	}

	public static short GetTotalGuestCapacity()
	{
		CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
		if (companySetup != null)
		{
			return (short)companySetup.Capacity;
		}
		return -1;
	}

	public static void AssignEmployeeServedOrder(string OrderNumber, short? EmployeeId)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.OrderNumber = OrderNumber;
		GClass6 gClass = new GClass6();
		foreach (Order item in gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.OrderNumber).ToList())
		{
			if (!(SettingsHelper.GetSettingValueByKey("delivery_management") == "ON") || !(item.OrderType == OrderTypes.Delivery) || !MemoryLoadedData.IsDeliveryManagement)
			{
				item.UserServed = EmployeeId;
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void setGuestPerBill(List<Order> orders, short table_guest_count = 0, GClass6 context = null)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.orders = orders;
		if (context == null)
		{
			context = new GClass6();
		}
		if (table_guest_count == 0 && CS_0024_003C_003E8__locals0.orders.Any() && CS_0024_003C_003E8__locals0.orders.FirstOrDefault().Customer != null)
		{
			if (MemoryLoadedData.all_layouts.Count() == 0)
			{
				MemoryLoadedData.all_layouts = context.Layouts.Where((Layout x) => x.Active == true).ToList();
			}
			Layout layout = MemoryLoadedData.all_layouts.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.orders.FirstOrDefault().Customer.Replace("Table", string.Empty).Trim()).FirstOrDefault();
			if (layout != null)
			{
				table_guest_count = (short)layout.CurrentGuests;
			}
		}
		List<string> list = CS_0024_003C_003E8__locals0.orders.Select((Order x) => x.OrderNumber).Distinct().ToList();
		short num = (short)list.Count();
		if (table_guest_count == 0)
		{
			table_guest_count = num;
		}
		if (table_guest_count == 0)
		{
			table_guest_count = 1;
		}
		short num2 = (short)(num / table_guest_count);
		short num3 = 0;
		short num4 = 0;
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
				CS_0024_003C_003E8__locals1.ordernum = enumerator.Current;
				num4 = (short)(num4 + 1);
				foreach (Order item in CS_0024_003C_003E8__locals0.orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals1.ordernum).ToList())
				{
					item.DateCleared = DateTime.Now;
					item.TipRecorded = true;
					if (num4 >= list.Count)
					{
						item.GuestCount = table_guest_count - num3;
					}
					else
					{
						item.GuestCount = num2;
					}
				}
				num3 = (short)(num3 + num2);
			}
		}
		Helper.SubmitChangesWithCatch(context);
	}

	public static void AssignEmployeeCashoutOrder(string OrderNumber, short? EmployeeId)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.OrderNumber = OrderNumber;
		GClass6 gClass = new GClass6();
		foreach (Order item in gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.OrderNumber))
		{
			item.UserCashout = EmployeeId;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static string GetEmployeeBytable(string tableStatus, int? employeeId)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.employeeId = employeeId;
		string result = "";
		if (SettingsHelper.GetSettingValueByKey("show_employee_table") == "ON" && (tableStatus == TableStatus.Seated || tableStatus == TableStatus.Ordered) && CS_0024_003C_003E8__locals0.employeeId.HasValue)
		{
			Employee employee = new GClass6().Employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals0.employeeId.Value).FirstOrDefault();
			if (employee != null)
			{
				string obj = ((employee.FirstName.Length >= 5) ? employee.FirstName.Substring(0, 5) : employee.FirstName);
				string text = ((employee.LastName.Length >= 1) ? employee.LastName.Substring(0, 1) : employee.LastName);
				result = obj + " " + text;
			}
		}
		return result;
	}
}
