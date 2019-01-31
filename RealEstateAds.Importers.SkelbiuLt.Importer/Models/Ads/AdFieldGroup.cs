using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.Ads
{
	internal class AdFieldGroup
	{
		public AdFieldGroup(string text, string value)
		{
			Text = text;
			Value = value;
		}

		public string Text { get; set; }
		public string Value { get; set; }
	}
}
