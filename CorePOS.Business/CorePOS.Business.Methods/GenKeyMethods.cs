using System.Linq;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class GenKeyMethods
{
	public static void updateGenKey(string keyName, long lastKey)
	{
		new DataManager().changeKeyGens(keyName, lastKey);
	}

	public static void updateBookMark(long bookMarkKey)
	{
		DataManager dataManager = new DataManager();
		GenKey genKey = dataManager.DataContext.GenKeys.SingleOrDefault();
		if (genKey != null)
		{
			genKey.CleanUp_Bookmark = bookMarkKey;
			Helper.SubmitChangesWithCatch(dataManager.DataContext);
		}
	}

	public static GenKey getLastUpdate()
	{
		GenKey genKey = new DataManager().DataContext.GenKeys.SingleOrDefault();
		if (genKey != null)
		{
			return genKey;
		}
		return null;
	}

	public static void updateLastKey()
	{
		DataManager dataManager = new DataManager();
		GenKey genKey = dataManager.DataContext.GenKeys.SingleOrDefault();
		string text = genKey.Prefix.Trim() + $"{genKey.CleanUp_Bookmark - 1L:000000}";
		if (!((from o in dataManager.DataContext.Orders
			where !o.OrderNumber.Contains("WEB")
			orderby o.OrderNumber descending
			select o).FirstOrDefault().OrderNumber != text))
		{
			genKey.LastKey = genKey.CleanUp_Bookmark - 1L;
			Helper.SubmitChangesWithCatch(dataManager.DataContext);
		}
	}

	public GenKeyMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
