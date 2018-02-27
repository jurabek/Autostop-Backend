using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Rides.Controllers
{
    [Route("api/v1/rides/history")]
    public class RideHistoryController : ControllerBase
	{
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
