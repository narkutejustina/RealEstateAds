using RealEstateAds.Importers.Domoplius.Importer.Models.UrlFilters.FilterModels;

namespace RealEstateAds.Importers.Domoplius.Importer.Models.UrlFilters.FilterModels
{
	internal class MinMaxUrlFilterModel
	{
		public string Text { get; set; }
		public UrlFilterModel MinValue { get; set; }
		public UrlFilterModel MaxValue { get; set; }

		public MinMaxUrlFilterModel(string text, string minValue = null, string maxValue = null)
		{
			Text = text;
			MinValue = new UrlFilterModel($"{Text}_from", minValue);
			MaxValue = new UrlFilterModel($"{Text}_to", maxValue);
		}

		public override string ToString()
		{
			return $"{MinValue.ToString()}&{MaxValue.ToString()}";
		}
	}
}
