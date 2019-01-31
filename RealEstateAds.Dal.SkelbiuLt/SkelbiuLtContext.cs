using Microsoft.EntityFrameworkCore;
using RealEstateAds.Dal.SkelbiuLt.Models.Ads;
using RealEstateAds.Dal.SkelbiuLt.Models.RealEstateObjects;

namespace RealEstateAds.Dal.SkelbiuLt
{
	public class SkelbiuLtContext : DbContext
	{
		DbSet<SkelbiuLtFlat> Flats { get; set; }
		DbSet<SkelbiuLtFlatAd> FlatAds { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("SkelbiuLt");
		}
	}
}
