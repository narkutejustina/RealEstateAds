using RealEstateAds.Dal.Enums;
using RealEstateAds.Importers.SkelbiuLt.Importer.Enums;
using RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters.Values;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters
{
	public abstract class SkelbiuLtUrlFilter
	{
		//searchAddress=&district=0&quarter=0&streets=0&ignorestreets=0&cities=465%2C43&distance=0&mainCity=1&search=1&type=0&user_type=0&ad_since_min=0&ad_since_max=0&visited_page=1&orderBy=-1&detailsSearch=1
		public UrlFilterModel Category { get; set; }

		public int Page { get; set; }

		public UrlFilterModel Keywords { get; set; }
		public UrlFilterModel Submit { get; set; } // What is this for
		public UrlFilterModel AdType { get; set; }

		public MinMaxUrlFilterModel Year { get; set; }
		public MinMaxUrlFilterModel Rooms { get; set; }
		public MinMaxUrlFilterModel Price { get; set; }
		public MinMaxUrlFilterModel Area { get; set; }
		public MinMaxUrlFilterModel Floor { get; set; }

		public UrlFilterModel BuildingType { get; set; }
		public UrlFilterModel FloorType { get; set; }
		public UrlFilterModel Distance { get; set; }

		public ListUrlFilterModel<CityCodes> Cities { get; set; }

		public override string ToString()
		{
			return $"/skelbimai/{Page}?{Category}&{AdType}";
		}
		public SkelbiuLtUrlFilter()
		{
			Page = 1;
			AdType = new UrlFilterModel("type", AdTypes.Sales);
			Category = new UrlFilterModel("category_id");
			Keywords = new UrlFilterModel("keywords");
			Price = new MinMaxUrlFilterModel("cost");
			Area = new MinMaxUrlFilterModel("space");
			Rooms = new MinMaxUrlFilterModel("rooms");
			Year = new MinMaxUrlFilterModel("year");
			Floor = new MinMaxUrlFilterModel("floor");
			Cities = new ListUrlFilterModel<CityCodes>("cities");

			BuildingType = new UrlFilterModel("distance"); // Set building types
			FloorType = new UrlFilterModel("floor_type"); ; // Set floor types

			Submit = new UrlFilterModel("submit_bn"); // ??
		}
	}
}
