using System.Collections.Generic;
using System.Linq;
using CorePOS.Business.Objects;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public static class HipposOnlineOrderingMethods
{
	public static List<OrderPostDataModel> GetOrdersFromRawData(List<OnlineOrderSyncQueue> orders)
	{
		List<OrderPostDataModel> list = new List<OrderPostDataModel>();
		foreach (OnlineOrderSyncQueue order in orders)
		{
			List<OrderPostDataModel> collection = JsonConvert.DeserializeObject<List<OrderPostDataModel>>(order.RawData);
			list.AddRange(collection);
		}
		if (list.Count > 0)
		{
			list = (from a in list
				group a by a.customer_order_id into a
				select a.First()).ToList();
		}
		return list;
	}
}
