using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Estimates.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
	        return new RedirectResult("~/swagger");
		}
	}
}
