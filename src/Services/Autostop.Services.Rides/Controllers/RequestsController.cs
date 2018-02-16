using Autostop.Services.Rides.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Rides.Controllers
{
    [Route("api/v1/requests/")]
    public class RequestsController : Controller
    {
	    [HttpPost]
	    public IActionResult Post([FromBody]RequestBody body)
	    {
		    return Ok();
	    }

		[HttpGet("current")]
        public RequestResponse CurrentGet()
		{
			return new RequestResponse();
		}

		[HttpPatch("current/{request_id}")]
	    public IActionResult CurrentPatch(string request_id, [FromBody]RequestBody body)
	    {
		    return Ok();
	    }

		[HttpDelete("current/{request_id}")]
	    public IActionResult CurrentDelete(string request_id)
		{
			return Ok();
		}

	    [HttpGet("{request_id}")]
		[Authorize(Roles = "Admin")]
	    public RequestResponse Get(string request_id)
	    {
		    return new RequestResponse();
	    }

	    [HttpPatch("{request_id}")]
	    [Authorize(Roles = "Admin")]
		public IActionResult Patch(string request_id, [FromBody]RequestBody body)
	    {
		    return Ok();
	    }

	    [HttpDelete("{request_id}")]
	    [Authorize(Roles = "Admin")]
		public IActionResult Delete(string request_id)
	    {
		    return Ok();
	    }
	}
}
