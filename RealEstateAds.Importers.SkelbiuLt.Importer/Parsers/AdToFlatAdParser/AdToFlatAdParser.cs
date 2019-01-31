using RealEstateAds.Dal.Models.RealEstateObjects;
using RealEstateAds.Importers.SkelbiuLt.Importer.Models.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Converters.AdToFlatConverters
{
	internal static partial class AdToFlatAdParser
	{
		public const string PlaceText = "Gyvenvietė";
		public const string NeighborhoodText = "Mikrorajonas";
		public const string StreetText = "Gatvė";
		public const string HouseNumText = "Namo numeris";
		public const string AreaText = "Plotas, m²";
		public const string RoomsText = "Kamb. sk.";
		public const string InstallationText = "Įrengimas";
		public const string TypeText = "Tipas";
		public const string FloorText = "Aukštas";
		public const string FloorsText = "Aukštų skaičius";
		public const string YearText = "Metai";
		public const string HeatingText = "Šildymas";

		public static string GetPlace(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == PlaceText)?.Value;
		public static string GetNeighborhood(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == NeighborhoodText)?.Value;
		public static string GetStreet(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == StreetText)?.Value;
		public static string GetHouseNum(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == HouseNumText)?.Value;
		public static string GetInstallation(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == InstallationText)?.Value;
		public static string GetHeating(IEnumerable<AdFieldGroup> infos) => infos.SingleOrDefault(x => x.Text == HeatingText)?.Value;

		public static int? GetArea(IEnumerable<AdFieldGroup> infos)
		{
			var area = infos.SingleOrDefault(x => x.Text == AreaText)?.Value;
			if (area == null)
				return null;

			return int.Parse(new Regex("[0-9]+").Match(area).Value);
		}

		public static int? GetRooms(IEnumerable<AdFieldGroup> infos)
		{
			var value = infos.SingleOrDefault(x => x.Text == RoomsText)?.Value;
			if (value == null)
				return null;

			return int.Parse(value);
		}

		public static int? GetFloor(IEnumerable<AdFieldGroup> infos)
		{
			var value = infos.SingleOrDefault(x => x.Text == FloorText)?.Value;
			if (value == null)
				return null;

			return int.Parse(value);
		}
		public static int? GetFloors(IEnumerable<AdFieldGroup> infos)
		{
			var value = infos.SingleOrDefault(x => x.Text == FloorsText)?.Value;
			if (value == null)
				return null;

			return int.Parse(value);
		}
		public static string GetYear(IEnumerable<AdFieldGroup> infos) => infos.Single(x => x.Text == YearText).Value; //1998, 2010 renovuotas?? how to parse
	}
}
