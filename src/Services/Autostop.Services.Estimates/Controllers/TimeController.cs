using System.Collections.Generic;
using System.Linq;
using Autostop.Services.Estimates.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Estimates.Controllers
{
	[Route("api/v1/estimate/time")]
	public class TimeController : ControllerBase
	{
	    [HttpGet]
		public IEnumerable<EstimateTime> Get(float start_latitude, float start_longitude)
	    {
		    return Enumerable.Repeat(new EstimateTime(), 10);
	    }
    }
}
