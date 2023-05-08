using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.ThirdPartyAPIs.Other;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public class GoogleMethods
{
	private static string string_0;

	public static TravelInfo GetTotalDistanceFromDeliveryAddress(string deliveryAddress)
	{
		TravelInfo travelInfo = new TravelInfo();
		travelInfo.Distance = 0m;
		travelInfo.TravelTime = 0;
		if (string.IsNullOrEmpty(deliveryAddress))
		{
			return travelInfo;
		}
		try
		{
			deliveryAddress = deliveryAddress.Replace("#", string.Empty).Replace(" ", "+");
			string text = "";
			decimal distance = 1m;
			int num = 0;
			CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
			if (companySetup != null)
			{
				text = companySetup.Address1 + "," + companySetup.City + "," + companySetup.StateProv + "," + companySetup.ZIP + "," + companySetup.Country;
				text = text.Replace("#", string.Empty).Replace(" ", "+");
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/directions/json?origin=" + text + "&destination=" + deliveryAddress + "&key=" + string_0);
				obj.ContentType = "text/xml; encoding='utf-8'";
				obj.Method = "GET";
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
				dynamic val = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
				if (val["routes"].Count > 0)
				{
					decimal num2 = default(decimal);
					string str = "0";
					for (int i = 0; i < val["routes"].Count; i++)
					{
						decimal num3 = Convert.ToDecimal(val["routes"][i]["legs"][0]["distance"]["value"]);
						str = val["routes"][i]["legs"][0]["duration"]["value"];
						if (num2 > num3 || num2 == 0m)
						{
							num2 = num3;
						}
					}
					num = (int)str.ToDecimalWithCleanUp();
					distance = num2 / 1000m;
				}
				else
				{
					distance = 1m;
				}
			}
			travelInfo.Distance = distance;
			travelInfo.TravelTime = num / 60;
			return travelInfo;
		}
		catch (Exception)
		{
			return travelInfo;
		}
	}

	public static List<string> GetSuggestedAddress(string address)
	{
		try
		{
			new List<string>();
			address = address.Replace("#", string.Empty).Replace(" ", "+");
			if (!string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.Lat) && !string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.Long))
			{
				address = address + "&location=" + CompanyHelper.CompanyDataSetup.Lat + "," + CompanyHelper.CompanyDataSetup.Long + "&origin=" + CompanyHelper.CompanyDataSetup.Lat + "," + CompanyHelper.CompanyDataSetup.Long + "&radius=30000";
			}
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + address + "&key=" + string_0 + "&sessiontoken=1234567890");
			obj.ContentType = "text/xml; encoding='utf-8'";
			obj.Method = "GET";
			HttpWebResponse obj2 = (HttpWebResponse)obj.GetResponse();
			List<object> list = new List<object>();
			using (StreamReader streamReader = new StreamReader(obj2.GetResponseStream()))
			{
				dynamic val = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
				if (val["predictions"].Count > 0)
				{
					string text = "";
					for (int i = 0; i < val["predictions"].Count; i++)
					{
						dynamic val2 = new ExpandoObject();
						text = val["predictions"][i]["description"];
						val2.suggested_address = text;
						val2.distance = ((val["predictions"][i]["distance_meters"] != null) ? Convert.ToInt32(val["predictions"][i]["distance_meters"]) : ((object)0));
						list.Add(val2);
					}
				}
			}
			return (from x in list
				where x.distance <= 30000 && x.distance > 0
				orderby x.distance
				select x into y
				select (string)y.suggested_address).ToList();
		}
		catch
		{
			return new List<string>();
		}
	}

	public static GoogleObjects.LatLongModel ConvertAddressToLatLong(string address)
	{
		try
		{
			if (!string.IsNullOrEmpty(address))
			{
				address = address.Replace(" ", "+");
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + string_0);
				obj.ContentType = "text/xml; encoding='utf-8'";
				obj.Method = "GET";
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
				dynamic val = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
				if (val.results.Count > 0)
				{
					dynamic val2 = val.results[0].geometry.location;
					string latitude = (string)val2.lat;
					string longitude = (string)val2.lng;
					return new GoogleObjects.LatLongModel
					{
						Latitude = latitude,
						Longitude = longitude
					};
				}
				return new GoogleObjects.LatLongModel
				{
					Latitude = "",
					Longitude = ""
				};
			}
			return new GoogleObjects.LatLongModel
			{
				Latitude = "",
				Longitude = ""
			};
		}
		catch
		{
			return new GoogleObjects.LatLongModel
			{
				Latitude = "",
				Longitude = ""
			};
		}
	}

	public static GoogleObjects.TimeZoneModel GetLocationTimeZone(string lng, string lat)
	{
		try
		{
			if (!string.IsNullOrEmpty(lng) && !string.IsNullOrEmpty(lat))
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				string text = Math.Floor((DateTime.UtcNow - dateTime).TotalSeconds).ToString();
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/timezone/json?location=" + lng + "," + lat + "&timestamp=" + text + "&key=" + string_0);
				obj.ContentType = "text/xml; encoding='utf-8'";
				obj.Method = "GET";
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
				_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
				string value = streamReader.ReadToEnd();
				CS_0024_003C_003E8__locals0.response = JsonConvert.DeserializeObject<GoogleObjects.TimeZoneModel>(value);
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.response.timeZoneName))
				{
					TimeZoneInfo timeZoneInfo = (from x in TimeZoneInfo.GetSystemTimeZones()
						where x.BaseUtcOffset.TotalSeconds == (double)CS_0024_003C_003E8__locals0.response.rawOffset && (x.DaylightName == CS_0024_003C_003E8__locals0.response.timeZoneName || x.Id == CS_0024_003C_003E8__locals0.response.timeZoneName)
						select x).FirstOrDefault();
					if (timeZoneInfo != null)
					{
						CS_0024_003C_003E8__locals0.response.timeZoneName = timeZoneInfo.Id;
						return CS_0024_003C_003E8__locals0.response;
					}
					return null;
				}
				return null;
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public GoogleMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}

	static GoogleMethods()
	{
		Class2.oOsq41PzvTVMr();
		string_0 = "AIzaSyBi6vsUbjiseNTaPSbmfeQtPgeRgm7p410";
	}
}
