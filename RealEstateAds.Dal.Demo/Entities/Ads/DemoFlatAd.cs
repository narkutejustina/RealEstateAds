using RealEstateAds.Dal.Demo.Entities.RealEstateObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAds.Dal.Demo.Entities.Ads
{
	public class DemoFlatAd
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public decimal Price { get; set; }
		public string Phone { get; set; }

		//public long FlatId { get; set; } 
		public DemoFlat Flat { get; set; }
	}
}
