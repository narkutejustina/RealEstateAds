using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAds.Dal.Models.RealEstateObjects
{
	internal class Flat
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public int? Area { get; set; }
		public string Features { get; set; }
		public string Installation { get; set; }//TODO: Enum

		public string Neighborhood { get; set; }
		public string Street { get; set; }

		//Simmilar to City but might be broader
		public string Place { get; set; }
		public string City { get; set; } //TODO: Enum
		public string HouseNumber { get; set; }
		public string Adress => $"{Street} {HouseNumber}, {City}";

		public int? Rooms { get; set; }
		public int? Floor { get; set; }
		public int? TotalFloors { get; set; }

		public string Year { get; set; }
		public string Heating { get; set; }//TODO: Enum
	}
}
