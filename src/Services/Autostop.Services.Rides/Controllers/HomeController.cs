using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Rides.Controllers
{
    public class HomeController : Controller
    {
	    public IActionResult Index()
	    {
		    return new RedirectResult("~/swagger");
	    }
	}
}
