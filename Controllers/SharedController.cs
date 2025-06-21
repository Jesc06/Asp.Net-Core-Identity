using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_Identity_Auth.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult _LoginPartial()
        {
            return View();
        }
    }
}
