namespace CorePOS.Business.Enums;

public static class PaymentTerminalModels
{
	public static class Ingenico
	{
		public static string iCT250;

		public static string iPP320;

		public static string iWL220;

		public static string iWL220_PATT;

		public static string iWL250_PATT;

		public static string Desk5000;

		public static string Move5000;

		static Ingenico()
		{
			Class2.oOsq41PzvTVMr();
			iCT250 = "Ingenico iCT250";
			iPP320 = "Ingenico iPP320";
			iWL220 = "Ingenico iWL220";
			iWL220_PATT = "Ingenico iWL220 PATT";
			iWL250_PATT = "Ingenico iWL250 PATT";
			Desk5000 = "Ingenico Desk 5000";
			Move5000 = "Ingenico Move 5000";
		}
	}

	public static class Dejavoo
	{
		public static string Z9;

		public static string Z11;

		static Dejavoo()
		{
			Class2.oOsq41PzvTVMr();
			Z9 = "Dejavoo Z9";
			Z11 = "Dejavoo Z11";
		}
	}

	public static class Clover
	{
		public static string Flex;

		static Clover()
		{
			Class2.oOsq41PzvTVMr();
			Flex = "Clover Flex";
		}
	}

	public static class Verifone
	{
		public static string Vx820;

		static Verifone()
		{
			Class2.oOsq41PzvTVMr();
			Vx820 = "Verifone Vx820";
		}
	}
}
