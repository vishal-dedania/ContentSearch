using Microsoft.AspNetCore.Mvc;

namespace ContentSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChartDemo()
        {
            return View("ChartDemo");
        }
    }
}