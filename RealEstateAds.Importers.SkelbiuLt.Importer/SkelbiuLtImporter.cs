using CsQuery;
using Microsoft.AspNetCore.Mvc;
using RealEstateAds.Dal.SkelbiuLt.Models.Ads;
using RealEstateAds.Importers.SkelbiuLt.Importer.Extensions;
using RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace RealEstateAds.Importers.SkelbiuLt.Importer
{
	public class SkelbiuLtImporter
	{
		private readonly HttpClient _client;
		private readonly SkelbiuLtParser _parser;
		public const string BASEURL = "https://www.skelbiu.lt";

		public SkelbiuLtImporter()
		{
			_client = new HttpClient();
			_parser = new SkelbiuLtParser();
		}

		private string GenerateUrl(SkelbiuLtUrlFilter filter)
		{
			return $"{BASEURL}{filter.ToString()}";
		}

		private string GenerateUrl(string text)
		{
			return $"{BASEURL}{text}";
		}

		public SkelbiuLtFlatAd ImportFlatAdByUrl(string url)
		{
			var ad = _parser.LoadFullFlatAd(url);
			return ad.ToFlatAd();
		}

		public async Task Start()
		{
			var flatAds = new List<SkelbiuLtFlatAd>();

			var nextPageUrl = GenerateUrl(new SkelbiuLtFlatFilter());

			try
			{
				var pageCounter = 1;
				while (nextPageUrl != null)
				{
					var html = CQ.CreateFromUrl(nextPageUrl);

					var parser = new SkelbiuLtParser();
					var adBaseInfo = parser.GetItemsBases(html);
					nextPageUrl = GenerateUrl(parser.GetNextPageLink(html));

					Console.WriteLine($"Parsing. Page: {pageCounter++}. Items: {adBaseInfo.Count}.");

					//#21 Recognize if Ad is closed
					foreach (var adBase in adBaseInfo)
					{
						var flat = ImportFlatAdByUrl(adBase.Link);
						flatAds.Add(flat);
					}
				}
				Console.ReadLine();
			}
			catch (XmlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
