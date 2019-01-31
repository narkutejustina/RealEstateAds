using CsQuery;
using RealEstateAds.Importers.SkelbiuLt.Importer.Models.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RealEstateAds.Importers.SkelbiuLt.Importer
{
	public class SkelbiuLtParser
	{
		//https://www.w3schools.com/xml/xpath_syntax.asp
		public List<string> GeItemsLinks(XElement html)
		{
			var items = html.XPathEvaluate("//itemsList/ul/li[@class='boldAds']/@id");
			return null;

		}

		public string GetNextPageLink(CQ html)
		{
			return html["link[rel='next']"].Selection.FirstOrDefault()?.Attributes["href"];
		}

		internal List<SkelbiuLtAdBase> GetItemsBases(CQ html)
		{
			var list = new List<SkelbiuLtAdBase>();
			var boldAds = html["#itemsList > ul > .boldAds > a"];
			foreach (var adLinkTag in boldAds.Selection)
			{
				var link = adLinkTag.Attributes["href"];
				list.Add(new SkelbiuLtAdBase
				{
					Link = link,
					IsBold = true
				});
			}

			var simpleAds = html["#itemsList > ul > .simpleAds > a"];
			foreach (var adLinkTag in simpleAds.Selection)
			{
				var link = adLinkTag.Attributes["href"];
				list.Add(new SkelbiuLtAdBase { Link = link });
			}

			return list;
		}

		internal SkelbiuLtAd LoadFullFlatAd(string url)
		{
			try
			{
				var adPage = CQ.CreateFromUrl(url);

				var id = adPage["#adID"].Text();
				var title = adPage["#adTitle"].Text();
				var description = adPage["#adDescription"].Text();
				var featuresDetails = adPage["#featuresDetails"].Text();
				var price = adPage["meta[itemprop='price']"].Attr("content");
				var currency = adPage["meta[itemprop='priceCurrency']"].Attr("content");
				var city = adPage[".seller-location > .seller-location-main"].Text();
				var phone = adPage[".seller-phone"].Text();

				var ad = new SkelbiuLtAd()
				{
					Link = url,
					Id = id,
					City = city,
					Currency = currency,
					Description = description,
					FeaturesDetails = featuresDetails,
					Phone = phone,
					Price = price,
					Title = title
				};

				var groups = adPage[".fieldGroupArea"].Selection.ToList();
				var values = adPage[".fieldGroupArea > .fieldValue"].Text();
				for (var i = 0; i < groups.Count(); i++)
				{
					ad.OtherInfo.Add(new AdFieldGroup(
						groups[i].ChildNodes[0].InnerText.Replace(":", "").Trim(),
						groups[i].ChildNodes[1].InnerText.Trim()));
				}

				return ad;
			}
			catch(WebException exception)
			{
				return null;
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		internal SkelbiuLtAd LoadFullAd(SkelbiuLtAdBase baseAd)
		{
			return LoadFullFlatAd($"{SkelbiuLtImporter.BASEURL}{baseAd.Link}");
		}

		protected void LogError(string error)
		{
			Console.WriteLine($"ERROR: {error}");
		}
	}
}
