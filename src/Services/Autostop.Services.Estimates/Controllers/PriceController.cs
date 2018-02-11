using System.Collections.Generic;
using System.Linq;
using Autostop.Services.Estimates.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Estimates.Controllers
{
	[Route("api/v1/estimate/price")]
	public class PriceController : Controller
    {
	    [HttpGet]
		public IEnumerable<EstimatePrice> Get(float start_latitude, float start_longitude, float end_latitude, float end_longitude)
	    {
		    return Enumerable.Repeat(new EstimatePrice(), 10);
	    }
    }
}
