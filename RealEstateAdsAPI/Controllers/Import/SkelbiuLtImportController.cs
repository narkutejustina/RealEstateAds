using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealEstateAds.Dal.SkelbiuLt.Models.Ads;
using RealEstateAds.Importers.SkelbiuLt.Importer;

namespace RealEstateAds.Controllers.Import
{
	[ApiController]
	[Route("api/import/skelbiu-lt")]
	[EnableCors("AllowSpecificOrigin")]
	public class SkelbiuLtImportController : ControllerBase
	{
		private readonly SkelbiuLtImporter _importer;
		public SkelbiuLtImportController()
		{
			_importer = new SkelbiuLtImporter();
		}

		[HttpPost("by-link/flat")]
		public SkelbiuLtFlatAd ImportFlatByLink([FromBody]string urlLink)
		{
			var flat = _importer.ImportFlatAdByUrl(urlLink);
			return flat;
		}
	}
}
