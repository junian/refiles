using System.Collections.Generic;
using System.Linq;
using CorePOS.Data;

namespace CorePOS;

public class UserMethods
{
	public static bool AuthenticateUser(short userID, string password, string role)
	{
		return smethod_0(userID, password, role) == 1;
	}

	public static Employee GetUserByID(short empID)
	{
		return GetEmployeeByID(empID);
	}

	public static bool AuthenticateUser(string password, string role)
	{
		return smethod_1(password, role) >= 1;
	}

	public static Employee AuthenticateUser(string password)
	{
		return GetEmployeeByPIN(password);
	}

	public static bool AuthenticateUser(string password, List<string> roles)
	{
		foreach (string role in roles)
		{
			if (smethod_1(password, role) >= 1)
			{
				return true;
			}
		}
		return false;
	}

	private static int smethod_0(short short_0, string string_0, string string_1)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.role = string_1;
		CS_0024_003C_003E8__locals0.username = short_0;
		CS_0024_003C_003E8__locals0.password = string_0;
		return MemoryLoadedObjects.ListOfUsers.Where((User u) => u.Active && u.Role.RoleName.ToLower() == CS_0024_003C_003E8__locals0.role.ToLower() && u.EmployeeID == CS_0024_003C_003E8__locals0.username && u.PIN == CS_0024_003C_003E8__locals0.password && u.Employee.isActive).Count();
	}

	private static int smethod_1(string string_0, string string_1)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.role = string_1;
		CS_0024_003C_003E8__locals0.password = string_0;
		return MemoryLoadedObjects.ListOfUsers.Where((User u) => u.Active && u.Role.RoleName.ToLower() == CS_0024_003C_003E8__locals0.role.ToLower() && u.PIN == CS_0024_003C_003E8__locals0.password && u.Employee.isActive).Count();
	}

	public static Employee GetEmployeeByPIN(string password)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.password = password;
		return MemoryLoadedObjects.ListOfUsers.Where((User u) => u.Active && u.PIN == CS_0024_003C_003E8__locals0.password && u.Employee.isActive).FirstOrDefault()?.Employee;
	}

	public static Employee GetEmployeeByID(int id)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.id = id;
		return MemoryLoadedObjects.ListOfUsers.Where((User u) => u.Employee != null && u.Employee.isActive && u.EmployeeID == CS_0024_003C_003E8__locals0.id).FirstOrDefault()?.Employee;
	}

	public static string GetEmployeeRole(int id)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.id = id;
		return MemoryLoadedObjects.ListOfUsers.Where((User u) => u.Active && u.EmployeeID == CS_0024_003C_003E8__locals0.id).FirstOrDefault()?.Role.RoleName;
	}

	public UserMethods()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
	}
}
