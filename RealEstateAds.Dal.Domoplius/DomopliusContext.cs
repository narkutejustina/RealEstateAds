using Microsoft.EntityFrameworkCore;
using RealEstateAds.Dal.Domoplius.Models.Ads;
using RealEstateAds.Dal.Domoplius.Models.RealEstateObjects;

namespace RealEstateAds.Dal.Domoplius
{
	public class DomopliusContext : DbContext
	{
		DbSet<Flat> Flats { get; set; }
		DbSet<DomopliusFlatAd> FlatAds { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Domoplius");
		}
	}
}
