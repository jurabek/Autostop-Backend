using System.Threading.Tasks;
using Google.Maps.DistanceMatrix;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Maps.Controllers
{
	[Route("api/distancematrix")]
	public class DistanceMatrixController : Controller
	{
		private readonly IDistanceMatrixService _distanceMatrixService;

		public DistanceMatrixController(IDistanceMatrixService distanceMatrixService)
		{
			_distanceMatrixService = distanceMatrixService;
		}

		[HttpGet]
		public Task<DistanceMatrixResponse> Get(string origins, string destinations)
		{
			return _distanceMatrixService.GetResponseAsync(new DistanceMatrixRequest
			{
				Language = "en",
			});
		}
	}
}
