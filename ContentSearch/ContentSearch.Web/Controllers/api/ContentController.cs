using ContentSearch.Models;
using ContentSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContentSearch.Web.Controllers.api
{
    [Produces("application/json")]
    [Route("api/content")]
    public class ContentController : Controller
    {
        private readonly IContentSearchService _contentSearchService;

        public ContentController(IContentSearchService contentSearchService)
        {
            _contentSearchService = contentSearchService;
        }

        [HttpPost("search")]
        public async Task<SearchResult> Search(string url)
        {
            return await _contentSearchService.SearchAsync(url);
        }
    }
}