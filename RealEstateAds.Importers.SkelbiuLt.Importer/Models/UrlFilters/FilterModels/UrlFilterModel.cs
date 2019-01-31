using RealEstateAds.Dal.Enums;
using RealEstateAds.Importers.SkelbiuLt.Importer.Enums;

namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters.Values
{

	public class UrlFilterModel
	{
		public string Text { get; }
		public string Value { get; set; }

		public UrlFilterModel(string text, string value)
		{
			Text = text;
			Value = value;
		}

		public UrlFilterModel(string text)
		{
			Text = text;
			Value = "";
		}

		public UrlFilterModel(string text, int? value)
		{
			Text = text;
			Value = (value ?? 0).ToString();
		}

		public UrlFilterModel(string text, AdCategories value)
		{
			Text = text;
			Value = ((int)value).ToString();
		}

		public UrlFilterModel(string text, AdTypes value)
		{
			Text = text;
			Value = ((int)value).ToString();
		}

		public override string ToString()
		{
			return $"{Text}={Value ?? ""}";
		}
	}
}
