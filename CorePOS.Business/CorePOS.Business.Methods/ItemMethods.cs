using System.Linq;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class ItemMethods
{
	protected GClass6 _dataContext;

	public ItemMethods(GClass6 dataContext = null)
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
		if (dataContext == null)
		{
			_dataContext = new GClass6();
		}
		else
		{
			_dataContext = dataContext;
		}
	}

	public IQueryable<Item> GetItems()
	{
		return _dataContext.Items;
	}
}
