using System.Collections.Generic;
using System.Linq;
using CorePOS.Business.Objects.ThirdPartyAPIs.Other;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class CompanyHelper
{
	public static CompanyObject CompanyData;

	public static CompanySetup CompanyDataSetup;

	public static void SetCompany()
	{
		GClass6 gClass = new GClass6();
		CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
		string text2 = (CompanyData.Address1 = (CompanyDataSetup.Address1 = companySetup.Address1));
		text2 = (CompanyData.BusinessName = (CompanyDataSetup.BusinessName = companySetup.BusinessName));
		int num2 = (CompanyData.Capacity = (CompanyDataSetup.Capacity = companySetup.Capacity));
		text2 = (CompanyData.City = (CompanyDataSetup.City = companySetup.City));
		text2 = (CompanyData.Country = (CompanyDataSetup.Country = companySetup.Country));
		text2 = (CompanyData.Fax = (CompanyDataSetup.Fax = companySetup.Fax));
		text2 = (CompanyData.Name = (CompanyDataSetup.Name = companySetup.Name));
		text2 = (CompanyData.Phone = (CompanyDataSetup.Phone = companySetup.Phone));
		text2 = (CompanyData.StateProv = (CompanyDataSetup.StateProv = companySetup.StateProv));
		text2 = (CompanyData.String_0 = (CompanyDataSetup.String_0 = companySetup.String_0));
		text2 = (CompanyData.ZIP = (CompanyDataSetup.ZIP = companySetup.ZIP));
		if (string.IsNullOrEmpty(companySetup.Long) || string.IsNullOrEmpty(companySetup.Lat))
		{
			GoogleObjects.LatLongModel latLongModel = GoogleMethods.ConvertAddressToLatLong(companySetup.Address1 + "+" + companySetup.City + "+" + companySetup.StateProv + "+" + companySetup.Country);
			companySetup.Long = latLongModel.Longitude;
			companySetup.Lat = latLongModel.Latitude;
		}
		CompanyDataSetup.Long = companySetup.Long;
		CompanyDataSetup.Lat = companySetup.Lat;
		if (string.IsNullOrEmpty(companySetup.TimeZoneName))
		{
			GoogleObjects.TimeZoneModel locationTimeZone = GoogleMethods.GetLocationTimeZone(CompanyDataSetup.Lat, CompanyDataSetup.Long);
			if (locationTimeZone != null)
			{
				companySetup.TimeZoneName = locationTimeZone.timeZoneName;
				companySetup.TimeZoneOffset = locationTimeZone.rawOffset + locationTimeZone.dstOffset;
			}
		}
		gClass.SubmitChanges();
		CompanyDataSetup.TimeZoneName = companySetup.TimeZoneName;
		CompanyDataSetup.TimeZoneOffset = companySetup.TimeZoneOffset;
		List<BusinessHoursObject> list = new List<BusinessHoursObject>();
		foreach (BusinessHour item in gClass.BusinessHours.ToList())
		{
			list.Add(new BusinessHoursObject
			{
				Day = item.DayOfTheWeek,
				OpenTime = item.LatestOpeningTime,
				CloseTime = item.LatestClosingTime
			});
		}
		CompanyData.ListOfBusinessHours = list;
		if (SettingsHelper.GetSettingValueByKey("print_tax_no") == "OFF")
		{
			text2 = (CompanyData.String_0 = (CompanyDataSetup.String_0 = ""));
		}
	}

	public static bool UpdateCompanyHasUnconfirmedOnlineOrder(bool status)
	{
		GClass6 gClass = new GClass6();
		gClass.CompanySetups.FirstOrDefault().hasUnconfirmedOnlineOrder = status;
		Helper.SubmitChangesWithCatch(gClass);
		return status;
	}

	public static bool CheckIfCompanyHasUnconfirmedOnlineOrder()
	{
		return new GClass6().CompanySetups.FirstOrDefault().hasUnconfirmedOnlineOrder;
	}

	static CompanyHelper()
	{
		Class2.oOsq41PzvTVMr();
		CompanyData = new CompanyObject();
		CompanyDataSetup = new CompanySetup();
	}
}
