using System.Linq;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class DayEndClosingMethods
{
	public static IQueryable<usp_ClosingTotalsResult> getDayEndTotals()
	{
		return new GClass6().usp_ClosingTotals().AsQueryable();
	}

	public DayEndClosingMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
