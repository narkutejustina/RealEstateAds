using RealEstateAds.Dal.SkelbiuLt.Models.Ads;
using RealEstateAds.Dal.SkelbiuLt.Models.RealEstateObjects;
using RealEstateAds.Importers.SkelbiuLt.Importer.Converters.AdToFlatConverters;
using RealEstateAds.Importers.SkelbiuLt.Importer.Models.Ads;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Extensions
{
	internal static class SkelbiuLtAdExtensions
	{
		public static SkelbiuLtFlatAd ToFlatAd(this SkelbiuLtAd ad)
		{
			if (ad.Price == null)
			{

			}
			return new SkelbiuLtFlatAd()
			{
				WebId = ad.Id,
				Title = ad.Title,
				FullLink = ad.Link,
				Price = decimal.Parse(ad.Price),
				Currency = ad.Currency,
				Description = ad.Description,
				Flat = new SkelbiuLtFlat
				{
					City = ad.City,
					Place = AdToFlatAdParser.GetPlace(ad.OtherInfo),
					Area = AdToFlatAdParser.GetArea(ad.OtherInfo),
					Features = ad.FeaturesDetails,
					Floor = AdToFlatAdParser.GetFloor(ad.OtherInfo),
					TotalFloors = AdToFlatAdParser.GetFloors(ad.OtherInfo),
					Heating = AdToFlatAdParser.GetHeating(ad.OtherInfo),
					HouseNumber = AdToFlatAdParser.GetHouseNum(ad.OtherInfo),
					Installation = AdToFlatAdParser.GetInstallation(ad.OtherInfo),
					Neighborhood = AdToFlatAdParser.GetNeighborhood(ad.OtherInfo),
					Rooms = AdToFlatAdParser.GetRooms(ad.OtherInfo),
					Street = AdToFlatAdParser.GetStreet(ad.OtherInfo),
					Year = AdToFlatAdParser.GetYear(ad.OtherInfo)
				},
				Phone = ad.Phone
			};
		}
	}
}
