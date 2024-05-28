using System;
using System.Linq;
using CorePOS.Business.Objects;

namespace CorePOS.Business.Methods;

public static class DeliveryMethods
{
	public static decimal GetDeliveryFee(string address = "")
	{
		DeliveryFeeSettingsObject deliveryFeeSettings = SettingsHelper.DeliveryFeeSettings.GetDeliveryFeeSettings();
		decimal num = default(decimal);
		if (deliveryFeeSettings.ListOfFeeCalculation.Where((DeliveryFeeFromToPerKM a) => a.ChargePerKM > 0m).Count() > 0)
		{
			int num2 = (int)Math.Ceiling(GoogleMethods.GetTotalDistanceFromDeliveryAddress(address).Distance.ConvertDistance());
			foreach (DeliveryFeeFromToPerKM item in deliveryFeeSettings.ListOfFeeCalculation)
			{
				if (item.ChargePerKM > 0m)
				{
					decimal num3 = (((decimal)num2 > item.ToDistance) ? ((item.ToDistance - item.FromDistance) * item.ChargePerKM) : (((decimal)num2 - item.FromDistance) * item.ChargePerKM));
					if (num3 > 0m)
					{
						num += num3;
					}
				}
			}
		}
		if (num == 0m)
		{
			return deliveryFeeSettings.BaseRate;
		}
		return deliveryFeeSettings.BaseRate + num;
	}

	public static decimal GetDeliveryFeeByDistance(decimal totalDistanceInKM)
	{
		DeliveryFeeSettingsObject deliveryFeeSettings = SettingsHelper.DeliveryFeeSettings.GetDeliveryFeeSettings();
		decimal num = default(decimal);
		if (deliveryFeeSettings.ListOfFeeCalculation.Where((DeliveryFeeFromToPerKM a) => a.ChargePerKM > 0m).Count() > 0)
		{
			int num2 = (int)Math.Ceiling(totalDistanceInKM.ConvertDistance());
			foreach (DeliveryFeeFromToPerKM item in deliveryFeeSettings.ListOfFeeCalculation)
			{
				if (item.ChargePerKM > 0m)
				{
					decimal num3 = (((decimal)num2 > item.ToDistance) ? ((item.ToDistance - item.FromDistance) * item.ChargePerKM) : (((decimal)num2 - item.FromDistance) * item.ChargePerKM));
					if (num3 > 0m)
					{
						num += num3;
					}
				}
			}
		}
		if (num == 0m)
		{
			return deliveryFeeSettings.BaseRate;
		}
		return deliveryFeeSettings.BaseRate + num;
	}
}
