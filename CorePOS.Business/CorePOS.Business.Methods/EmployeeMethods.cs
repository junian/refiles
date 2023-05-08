using System.Collections.Generic;
using System.Linq;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class EmployeeMethods
{
	public static Dictionary<string, string> getEmployees()
	{
		IQueryable<Employee> queryable = new DataManager().DataContext.Employees.Where((Employee e) => e.isActive == true);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Employee item in queryable)
		{
			dictionary.Add(item.EmployeeID.ToString(), item.FirstName + " " + item.LastName);
		}
		return dictionary;
	}

	public static Employee getEmployeeByID(int employeeID)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.employeeID = employeeID;
		return new DataManager().DataContext.Employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.employeeID).FirstOrDefault();
	}

	public static Employee getEmployeeByPIN(string PIN)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.PIN = PIN;
		return new DataManager().DataContext.Employees.Where((Employee e) => e.Users.Where((User y) => y.PIN == CS_0024_003C_003E8__locals0.PIN).Count() > 0).FirstOrDefault();
	}

	public static string getEmployeeNameString(Employee emp, short pref = 0)
	{
		return pref switch
		{
			0 => emp.FirstName, 
			1 => (emp.FirstName + " " + ((emp.LastName.Length >= 1) ? emp.LastName.Substring(0, 1) : string.Empty)).Trim(), 
			_ => (emp.FirstName + " " + emp.LastName).Trim(), 
		};
	}

	public EmployeeMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
