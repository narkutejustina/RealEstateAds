using RealEstateAds.Dal.Domoplius.Models.RealEstateObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAds.Dal.Domoplius.Models.Ads
{
	public class DomopliusFlatAd
	{
		public Flat Flat { get; set; }
		public long FlatId { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string WebId { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
		public string FullLink { get; set; }

		public string Phone { get; set; }

		public decimal Price { get; set; }
		public string Currency { get; set; }
	}
}
