using Microsoft.AspNetCore.Mvc;
using RealEstateAds.Dal.Demo.Entities.Ads;
using RealEstateAds.Dal.Demo.Repositories.AdsList;
using RealEstateAdsAPI.Models.AdsList;
using System;
using System.Collections.Generic;

namespace RealEstateAdsAPI.Controllers.Ads
{
    [Route("api/ads")]
    [ApiController]
    public class AdsController : ControllerBase
    {
		private readonly IAdsListItemsRepository _adsRepository;
		public AdsController(IAdsListItemsRepository adsListItemsRepository)
		{
			_adsRepository = adsListItemsRepository ?? throw new ArgumentNullException(nameof(adsListItemsRepository));
		}

		public AdsPageViewModel GetAds()
		{
			var ads = _adsRepository.GetAds();
			return new AdsPageViewModel
			{
				Ads = ads,
				TotalCount = ads.Count
			};
		}

		[Route("{id}")]
		public DemoFlatAd GetAd(long id)
		{
			return _adsRepository.GetAd(id);
		}

		[HttpPost]
		public List<DemoFlatAd> GetAds(AdsListFilter filter)
		{
			return _adsRepository.GetAds(filter.Page, filter.Take);
		}
	}
}