namespace RealEstateAds.Importers.SkelbiuLt.Importer.Models.UrlFilters.Values
{
	public class MinMaxUrlFilterModel
	{
		public string Text { get; set; }
		public UrlFilterModel MinValue { get; set; }
		public UrlFilterModel MaxValue { get; set; }

		public MinMaxUrlFilterModel(string text, string minValue = null, string maxValue = null)
		{
			Text = text;
			MinValue = new UrlFilterModel($"{Text}_min", minValue);
			MaxValue = new UrlFilterModel($"{Text}_max", maxValue);
		}

		public override string ToString()
		{
			return $"{MinValue.ToString()}&{MaxValue.ToString()}";
		}
	}
}
