using System;

namespace CorePOS.Business.Enums;

public static class SubscriptionIDs
{
	public static class SubscriptionTypes
	{
		public static string Licenses;

		public static string AddOn;

		static SubscriptionTypes()
		{
			Class2.oOsq41PzvTVMr();
			Licenses = "License";
			AddOn = "Add-On";
		}
	}

	public static class Licenses
	{
		public static Guid FullService_Annual;

		public static Guid FullService_Monthly;

		public static Guid FullService_OneTimePurchase;

		public static Guid QuickService_Annual;

		public static Guid QuickService_Monthly;

		public static Guid QuickService_OneTimePurchase;

		public static Guid Hippos_Internal;

		public static Guid Kiosk_Mode_Monthly;

		public static Guid Kiosk_Mode_Annual;

		public static Guid Patron_Ordering_Monthly;

		public static Guid Patron_Ordering_Annual;

		public static Guid Kitchen_Display_System;

		public static Guid Bar_Display_System;

		static Licenses()
		{
			Class2.oOsq41PzvTVMr();
			FullService_Annual = new Guid("3350C823-F29F-4BD2-9F65-D46B0484CC31");
			FullService_Monthly = new Guid("FA0BE4D4-C8D3-4891-A04D-ED5B80933A30");
			FullService_OneTimePurchase = new Guid("89344286-3605-4338-AE3B-910C7D3873D4");
			QuickService_Annual = new Guid("967E3A66-6D81-4812-B926-1637775A1B63");
			QuickService_Monthly = new Guid("7737368D-1543-41DD-89D1-3A131C4E718B");
			QuickService_OneTimePurchase = new Guid("8FDDD37B-9F7E-4CF3-84D0-EDBAE91C69A0");
			Hippos_Internal = new Guid("ECC63C39-FBCA-481B-8937-31C2B36E7E5B");
			Kiosk_Mode_Monthly = new Guid("23FBE1B4-357F-466F-A663-880862CF93CC");
			Kiosk_Mode_Annual = new Guid("EA527D02-BE07-45F4-9413-015D7110CCF1");
			Patron_Ordering_Monthly = new Guid("580658DA-0240-4AFB-83B3-3C6C85508F4D");
			Patron_Ordering_Annual = new Guid("9823DE9C-C09C-459C-9515-CD643021E83D");
			Kitchen_Display_System = new Guid("DC9BC43E-41E4-4B78-ADB8-18B3263EDCA7");
			Bar_Display_System = new Guid("7C1252A6-3FBE-4088-89BB-9EE2D8DE72BB");
		}
	}

	public static class AddOns
	{
		public static Guid Cloudsync_Annual;

		public static Guid Cloudsync_Monthly;

		public static Guid GlobalOrderHistory;

		public static Guid OnlineOrdering_Monthly;

		public static Guid OnlineOrdering_Annual;

		public static Guid ProductionMode;

		public static Guid SkipTheDishes_Monthly;

		public static Guid SMSNotifications;

		public static Guid StaffManagement;

		public static Guid VoidOrder;

		public static Guid Delivery_Management;

		public static Guid Deliverect_Monthly;

		static AddOns()
		{
			Class2.oOsq41PzvTVMr();
			Cloudsync_Annual = new Guid("80BC4BD2-0647-4EE6-8390-25F15AAC0DF1");
			Cloudsync_Monthly = new Guid("998022C5-3D5D-4C1D-B35E-5E08DFBEA0AC");
			GlobalOrderHistory = new Guid("E3684FC3-B76E-4E9A-B101-1D4E82C5FAE3");
			OnlineOrdering_Monthly = new Guid("C61407E6-0C2F-4AAF-A49E-5C30EE2816E1");
			OnlineOrdering_Annual = new Guid("B0CED305-B6EB-4E20-A97F-F0AA877C6B61");
			ProductionMode = new Guid("82961BB1-0205-4BEA-B8E2-D71F120D1009");
			SkipTheDishes_Monthly = new Guid("9bd0bf8e-c809-471e-82a4-a9ac19fb6c37");
			SMSNotifications = new Guid("6FBDBE17-B81C-4239-B750-7E52EEF9D423");
			StaffManagement = new Guid("77E03751-4CD1-4913-8035-2B6A2A52CC6B");
			VoidOrder = new Guid("35B226D0-35E8-4A6A-93E9-0FBD44F96D59");
			Delivery_Management = new Guid("998bcbc5-df65-4bc2-a6c8-9bf4c6c3e163");
			Deliverect_Monthly = new Guid("E13490CE-D1F8-4812-809F-B77B0E324262");
		}
	}
}
