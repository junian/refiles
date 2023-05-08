namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public enum DeliverectOrderStatusTag
{
	parsed = 1,
	received = 2,
	new_received = 10,
	accepted = 20,
	rejected = 30,
	printed = 40,
	preparing = 50,
	prepared = 60,
	ready_for_pickup = 70,
	in_delivery = 80,
	finalized = 90,
	auto_finalized = 95,
	cancel = 100,
	cancelled = 110,
	failed = 120,
	pos_failed_received = 121,
	parse_failed = 124
}
