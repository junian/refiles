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
		CompanyObject companyData = CompanyData;
		string address2 = (CompanyDataSetup.Address1 = companySetup.Address1);
		companyData.Address1 = address2;
		CompanyObject companyData2 = CompanyData;
		address2 = (CompanyDataSetup.BusinessName = companySetup.BusinessName);
		companyData2.BusinessName = address2;
		CompanyObject companyData3 = CompanyData;
		int capacity2 = (CompanyDataSetup.Capacity = companySetup.Capacity);
		companyData3.Capacity = capacity2;
		CompanyObject companyData4 = CompanyData;
		address2 = (CompanyDataSetup.City = companySetup.City);
		companyData4.City = address2;
		CompanyObject companyData5 = CompanyData;
		address2 = (CompanyDataSetup.Country = companySetup.Country);
		companyData5.Country = address2;
		CompanyObject companyData6 = CompanyData;
		address2 = (CompanyDataSetup.Fax = companySetup.Fax);
		companyData6.Fax = address2;
		CompanyObject companyData7 = CompanyData;
		address2 = (CompanyDataSetup.Name = companySetup.Name);
		companyData7.Name = address2;
		CompanyObject companyData8 = CompanyData;
		address2 = (CompanyDataSetup.Phone = companySetup.Phone);
		companyData8.Phone = address2;
		CompanyObject companyData9 = CompanyData;
		address2 = (CompanyDataSetup.StateProv = companySetup.StateProv);
		companyData9.StateProv = address2;
		CompanyObject companyData10 = CompanyData;
		address2 = (CompanyDataSetup.String_0 = companySetup.String_0);
		companyData10.String_0 = address2;
		CompanyObject companyData11 = CompanyData;
		address2 = (CompanyDataSetup.ZIP = companySetup.ZIP);
		companyData11.ZIP = address2;
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
			CompanyObject companyData12 = CompanyData;
			address2 = (CompanyDataSetup.String_0 = "");
			companyData12.String_0 = address2;
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
