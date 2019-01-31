using Microsoft.EntityFrameworkCore;
using RealEstateAds.Dal.Demo.Entities.Ads;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateAds.Dal.Demo.Repositories.AdsList
{
	public interface IAdsListItemsRepository
	{
		List<DemoFlatAd> GetAds(int page = 0, int take = 20);
		DemoFlatAd GetAd(long id);
	}

	public class AdsListItemsRepository : IAdsListItemsRepository
	{
		private DemoContext _context;
		public AdsListItemsRepository(DemoContext demoContext)
		{
			_context = demoContext ?? throw new ArgumentNullException(nameof(demoContext));
		}

		public DemoFlatAd GetAd(long id)
		{
			return _context.FlatAds.SingleOrDefault(x => x.Id == id);
		}

		public List<DemoFlatAd> GetAds(int page = 0, int take = 20)
		{
			return _context.FlatAds
				.Skip(page * take)
				.Take(take)
				.Include(x => x.Flat)
				.ToList();
		}
	}
}
