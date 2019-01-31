using System.Collections.Generic;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.Ads
{
	internal class SkelbiuLtAd : SkelbiuLtAdBase
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string FeaturesDetails { get; set; }
		public string Price { get; set; }
		public string Currency { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public List<AdFieldGroup> OtherInfo { get; set; }

		public SkelbiuLtAd()
		{
			OtherInfo = new List<AdFieldGroup>();
		}
	}
}
