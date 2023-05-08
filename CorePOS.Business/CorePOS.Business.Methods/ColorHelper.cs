using System.Drawing;
using CorePOS.Business.Enums;

namespace CorePOS.Business.Methods;

public static class ColorHelper
{
	public static Color smethod_0(int seat)
	{
		return seat switch
		{
			1 => ColorPalette.BlueGem, 
			2 => ColorPalette.Chambray, 
			3 => ColorPalette.ChateauGreen, 
			4 => ColorPalette.IronGray, 
			5 => ColorPalette.Cinnabar, 
			6 => ColorPalette.Denim, 
			7 => ColorPalette.CuriousBlue, 
			8 => ColorPalette.Sun, 
			9 => ColorPalette.TerraCotta, 
			10 => ColorPalette.PictonBlue, 
			12 => ColorPalette.Fern, 
			13 => ColorPalette.Mariner, 
			14 => ColorPalette.MountainMeadow, 
			15 => ColorPalette.NeonCarrot, 
			16 => ColorPalette.PersianGreen, 
			_ => ColorPalette.AlmondFrost, 
		};
	}

	public static Color getOrderTypeColor(string orderType)
	{
		if (!(orderType == OrderTypes.DineIn) && !(orderType == OrderTypes.DineInOnline))
		{
			if (orderType == OrderTypes.ToGo)
			{
				return Color.FromArgb(61, 142, 185);
			}
			if (!(orderType == OrderTypes.PickUp) && !(orderType == OrderTypes.PickUpOnline) && !(orderType == OrderTypes.PickUpCurbsideOnline))
			{
				if (!(orderType == OrderTypes.Delivery) && !(orderType == OrderTypes.DeliveryOnline))
				{
					if (orderType == OrderTypes.Catering)
					{
						return Color.FromArgb(53, 143, 79);
					}
					return Color.FromArgb(1, 110, 211);
				}
				return Color.FromArgb(80, 203, 116);
			}
			return Color.FromArgb(176, 124, 219);
		}
		return Color.FromArgb(1, 110, 211);
	}
}
