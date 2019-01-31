using RealEstateAds.Dal.Demo.Entities.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAdsAPI.Models.AdsList
{
	public class AdsPageViewModel
	{
		public List<DemoFlatAd> Ads { get; set; }
		public int TotalCount { get; set; }
	}
}
