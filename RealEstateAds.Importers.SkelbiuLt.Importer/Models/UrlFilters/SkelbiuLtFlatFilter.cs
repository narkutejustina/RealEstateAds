using RealEstateAds.Importers.SkelbiuLt.Importer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters
{
	public class SkelbiuLtFlatFilter : SkelbiuLtUrlFilter
	{
		public SkelbiuLtFlatFilter() : base()
		{
			Category.Value = ((int)AdCategories.Flat).ToString();
		}
	}
}
