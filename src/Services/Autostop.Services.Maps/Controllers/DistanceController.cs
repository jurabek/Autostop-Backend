using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.DistanceMatrix;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Maps.Controllers
{
	[Route("api/v1/map/distance")]
	public class DistanceController : ControllerBase
	{
		private readonly IDistanceMatrixService _distanceMatrixService;

		public DistanceController(IDistanceMatrixService distanceMatrixService)
		{
			_distanceMatrixService = distanceMatrixService;
		}

		[HttpGet]
		public Task<DistanceMatrixResponse> Get(float start_latitude, float start_longitude, float end_latitude, float end_longitude)
		{
			var startLocation = new LatLng(start_latitude, start_longitude);
			var endLocation = new LatLng(end_latitude, end_longitude);
			var request = new DistanceMatrixRequest { Language = "en" };
			request.AddOrigin(startLocation);
			request.AddDestination(endLocation);

			return _distanceMatrixService.GetResponseAsync(request);
		}
	}
}
