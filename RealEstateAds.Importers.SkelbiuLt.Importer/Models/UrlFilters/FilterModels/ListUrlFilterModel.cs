using System.Collections.Generic;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters.Values
{
	public class ListUrlFilterModel<T>
	{
		public string Text { get; }
		public List<T> Values { get; set; }

		public ListUrlFilterModel(string text, List<T> values = null)
		{
			Text = text;
			Values = values ?? new List<T>();
		}

		public override string ToString()
		{
			return $"{Text}={string.Join("%2C", Values)}";
		}
	}
}
