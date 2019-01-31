
using CsQuery;
using System;
using System.Net;

namespace RealEstateAds.Importers.Domoplius.Importer
{
	public class DomopliusImporter
	{
		private DomopliusAdsParser _parser;

		public DomopliusImporter()
		{
			_parser = new DomopliusAdsParser();
		}
		public void ImportFlatAdByUrl(string url)
		{
			var ad = _parser.LoadFlatAd(url);
			//return ad.ToFlatAd();
		}

	}

	internal class DomopliusAdsParser
	{
		internal string LoadFlatAd(string url)
		{
			try
			{
				var adPage = CQ.CreateFromUrl(url);

				var id = adPage["#adID"].Text();
				var title = adPage[".title-view"].Text();
				var description = adPage["#adDescription"].Text();
				var featuresDetails = adPage["#featuresDetails"].Text();
				var price = adPage["meta[itemprop='price']"].Attr("content");
				var currency = adPage["meta[itemprop='priceCurrency']"].Attr("content");
				var city = adPage[".seller-location > .seller-location-main"].Text();
				var phone = adPage[".seller-phone"].Text();

				var ad = new 
				{
					Link = url,
					//IsBold = baseAd.IsBold,
					Id = id,
					City = city,
					Currency = currency,
					Description = description,
					FeaturesDetails = featuresDetails,
					Phone = phone,
					Price = price,
					Title = title
				};

				//var groups = adPage[".fieldGroupArea"].Selection.ToList();
				//var values = adPage[".fieldGroupArea > .fieldValue"].Text();
				//for (var i = 0; i < groups.Count(); i++)
				//{
				//	ad.OtherInfo.Add(new AdFieldGroup(
				//		groups[i].ChildNodes[0].InnerText.Replace(":", "").Trim(),
				//		groups[i].ChildNodes[1].InnerText.Trim()));
				//}

				return null;
			}
			catch (WebException exception)
			{
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
