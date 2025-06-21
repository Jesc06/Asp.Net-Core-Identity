using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_Identity_Auth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
