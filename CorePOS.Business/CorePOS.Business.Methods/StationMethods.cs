using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class StationMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public short? StationID;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CGetStations_003Eb__0(Station s)
		{
			return s.StationID == StationID.Value;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public short stationId;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string PCName;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CGetStationByPCName_003Eb__0(Station s)
		{
			return s.ComputerName == PCName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public string string_0;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CGetStationByIP_003Eb__0(Station s)
		{
			return s.String_0 == string_0;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string[] stationIdsArray;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public string[] stationNamesArray;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public List<Station> GetStations(short? StationID = null, string lang = "en-US")
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.StationID = StationID;
		List<Station> list = new DataManager().GetAllStations();
		if (CS_0024_003C_003E8__locals0.StationID.HasValue)
		{
			list = list.Where((Station s) => s.StationID == CS_0024_003C_003E8__locals0.StationID.Value).ToList();
		}
		List<Station> list2 = new List<Station>();
		foreach (Station item in list)
		{
			list2.Add(new Station
			{
				StationID = item.StationID,
				StationName = method_0(item.StationName, lang),
				SystemDefinedID = item.SystemDefinedID
			});
		}
		return list2;
	}

	private string method_0(string string_0, string string_1)
	{
		if (string_0 == "Kitchen")
		{
			if (string_1 == "es-US")
			{
				return "Cocina";
			}
			if (string_1 == "fr-CA")
			{
				return "Cuisine";
			}
		}
		else if (string_0 == "No Station")
		{
			if (string_1 == "es-US")
			{
				return "Sin estacion";
			}
			if (string_1 == "fr-CA")
			{
				return "Pas de station";
			}
		}
		return string_0;
	}

	public Station GetSingleStation(short stationId)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.stationId = stationId;
		return new GClass6().Stations.Where((Station s) => s.StationID == CS_0024_003C_003E8__locals0.stationId).FirstOrDefault();
	}

	public Station GetStationByPCName(string PCName)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.PCName = PCName;
		return (from s in new DataManager().GetAllStations()
			where s.ComputerName == CS_0024_003C_003E8__locals0.PCName
			select s).FirstOrDefault();
	}

	public Station GetStationByIP(string string_0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.string_0 = string_0;
		return (from s in new DataManager().GetAllStations()
			where s.String_0 == CS_0024_003C_003E8__locals0.string_0
			select s).FirstOrDefault();
	}

	public static string GetStationNamesFromStationIds(string stationIds)
	{
		if (!string.IsNullOrEmpty(stationIds))
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.stationIdsArray = stationIds.Split(',');
			List<string> values = (from a in gClass.Stations
				where CS_0024_003C_003E8__locals0.stationIdsArray.Select((string x) => x.Trim()).Contains(a.StationID.ToString())
				select a.StationName).ToList();
			return string.Join(",", values);
		}
		return string.Empty;
	}

	public static string GetStationIdsFromStationNames(string stationNames)
	{
		if (!string.IsNullOrEmpty(stationNames))
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.stationNamesArray = stationNames.Split(',');
			List<short> values = (from a in gClass.Stations
				where CS_0024_003C_003E8__locals0.stationNamesArray.Select((string x) => x.Trim().ToLower()).Contains(a.StationName.ToLower())
				select a.StationID).ToList();
			return string.Join(",", values);
		}
		return string.Empty;
	}

	public static string ChangeSingleStationFromStationIds(string stationIds, string stationToRemove, string stationToAdd = "")
	{
		if (!string.IsNullOrEmpty(stationIds))
		{
			List<string> list = stationIds.Split(',').ToList();
			list.Remove(stationToRemove);
			if (!string.IsNullOrEmpty(stationToAdd) && !list.Contains(stationToAdd))
			{
				list.Add(stationToAdd);
			}
			return string.Join(",", list);
		}
		return string.Empty;
	}

	public static string AddStationIdFromStationIds(string stationIds, string stationToAdd)
	{
		if (!string.IsNullOrEmpty(stationIds))
		{
			List<string> list = stationIds.Split(',').ToList();
			if (!list.Contains(stationToAdd))
			{
				list.Add(stationToAdd);
			}
			return string.Join(",", list);
		}
		return stationToAdd;
	}

	public StationMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
