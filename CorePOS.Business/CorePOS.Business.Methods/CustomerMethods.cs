using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class CustomerMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string phone;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string phone;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string email;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public static int GetCustomerIDByPhone(string phone)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.phone = phone;
		return (from x in new GClass6().Customers
			where x.CustomerCell == CS_0024_003C_003E8__locals0.phone || x.CustomerHome == CS_0024_003C_003E8__locals0.phone
			select x into y
			select y.CustomerID).FirstOrDefault();
	}

	public static Customer GetCustomerByPhone(string phone)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.phone = phone;
		return new GClass6().Customers.Where((Customer x) => x.CustomerCell == CS_0024_003C_003E8__locals0.phone || x.CustomerHome == CS_0024_003C_003E8__locals0.phone).FirstOrDefault();
	}

	public static int GetCustomerIDByEmail(string email)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.email = email;
		return (from x in new GClass6().Customers
			where x.CustomerEmail == CS_0024_003C_003E8__locals0.email
			select x into y
			select y.CustomerID).FirstOrDefault();
	}
}
