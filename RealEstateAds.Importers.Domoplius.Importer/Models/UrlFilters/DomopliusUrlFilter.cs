
using RealEstateAds.Importers.Domoplius.Importer.Enums;

namespace RealEstateAds.Importers.Domoplius.Importer.Models.UrlFilters.FilterModels
{
	internal class DomopliusFlatsUrlFilter : DomopliusUrlFilter
	{
		public override string ToString()
		{
			return $"/skelbimai/butai?{Category}&{ActionType}";
		}
	}
	internal class DomopliusUrlFilter
	{
		public UrlFilterModel Category { get; set; }

		public UrlFilterModel Page { get; set; }

		public UrlFilterModel Keywords { get; set; }
		public UrlFilterModel Submit { get; set; } // What is this for
		public UrlFilterModel ActionType { get; set; }

		public MinMaxUrlFilterModel Year { get; set; }
		public MinMaxUrlFilterModel Rooms { get; set; }
		public MinMaxUrlFilterModel Price { get; set; }
		public MinMaxUrlFilterModel Area { get; set; }
		public MinMaxUrlFilterModel Floor { get; set; }

		public UrlFilterModel BuildingType { get; set; }
		public UrlFilterModel FloorType { get; set; }
		public UrlFilterModel Distance { get; set; }

		public UrlFilterModel City { get; set; }

		//public override string ToString()
		//{
		//	return $"/skelbimai/{Page}?{Category}&{AdType}";
		//}
		public DomopliusUrlFilter()
		{
			Page = new UrlFilterModel("page_nr", 1);
			Price = new MinMaxUrlFilterModel("sell_price");
			Area = new MinMaxUrlFilterModel("space");
			Rooms = new MinMaxUrlFilterModel("rooms");
			Year = new MinMaxUrlFilterModel("year");
			Floor = new MinMaxUrlFilterModel("floor");
			City = new UrlFilterModel("adress_1");
			ActionType = new UrlFilterModel("action_type");

			//BuildingType = new UrlFilterModel("distance"); // Set building types
			//FloorType = new UrlFilterModel("floor_type"); ; // Set floor types

			//Submit = new UrlFilterModel("submit_bn"); // ??
		}
	}
}
