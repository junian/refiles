namespace CorePOS.Business.Enums.ThirdParty;

public enum DeliverectOrderStatusTag
{
	parsed = 1,
	received = 2,
	new_received = 10,
	accepted = 20,
	rejected = 30,
	preparing = 50,
	prepared = 60,
	ready_for_pickup = 70,
	in_delivery = 80,
	finalized = 90,
	auto_finalized = 95,
	cancel = 100,
	cancelled = 110,
	failed = 120
}
