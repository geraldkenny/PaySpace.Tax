using Microsoft.AspNetCore.Mvc;

namespace PaySpace.Tax.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
