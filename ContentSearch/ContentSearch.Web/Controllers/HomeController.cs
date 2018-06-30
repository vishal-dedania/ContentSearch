using Microsoft.AspNetCore.Mvc;

namespace ContentSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}