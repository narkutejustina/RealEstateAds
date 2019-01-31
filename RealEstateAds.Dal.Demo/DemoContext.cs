using Microsoft.EntityFrameworkCore;
using RealEstateAds.Dal.Demo.Entities.Ads;
using RealEstateAds.Dal.Demo.Entities.RealEstateObjects;

namespace RealEstateAds.Dal.Demo
{
	public class DemoContext: DbContext
	{
		public DemoContext(DbContextOptions<DemoContext> options): base(options)
		{
			Database.Migrate();
		}

		public DbSet<DemoFlat> Flats { get; set; }
		public DbSet<DemoFlatAd> FlatAds { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Demo");
		}
	}
}
