using Microsoft.AspNetCore.Mvc;

namespace Autostop.Services.Identity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}