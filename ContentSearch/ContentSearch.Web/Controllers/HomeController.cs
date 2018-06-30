using ContentSearch.Models;
using ContentSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContentSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentSearchService _contentSearchService;

        public HomeController(IContentSearchService contentSearchService)
        {
            _contentSearchService = contentSearchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<SearchResult> Search(string url)
        {
            return await _contentSearchService.SearchAsync(url);
        }
    }
}