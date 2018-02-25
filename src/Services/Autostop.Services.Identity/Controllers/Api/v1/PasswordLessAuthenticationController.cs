using System.Threading.Tasks;
using Autostop.Services.Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Identity.Controllers.Api.v1
{
    [Route("api/v1/passwordless_authentication")]
    public class PasswordLessAuthenticationController : ControllerBase
    {
		[HttpPost]
	    public async Task<IActionResult> Login(PasswordLessLoginViewModel model)
		{
			return Ok();
		}
    }
}
