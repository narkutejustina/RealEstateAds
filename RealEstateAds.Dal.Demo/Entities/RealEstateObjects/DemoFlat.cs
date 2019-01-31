using RealEstateAds.Dal.Demo.Entities.Ads;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstateAds.Dal.Demo.Entities.RealEstateObjects
{
	public class DemoFlat
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public int Floor { get; set; }
		public int Rooms { get; set; }

		[NotMapped]
		public ICollection<DemoFlatAd> Ads { get; set; }
	}
}
