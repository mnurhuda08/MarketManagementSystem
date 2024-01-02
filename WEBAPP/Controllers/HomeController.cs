using Microsoft.AspNetCore.Mvc;

namespace WEBAPP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
