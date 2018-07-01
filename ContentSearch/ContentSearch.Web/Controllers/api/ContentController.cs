using ContentSearch.Services;
using ContentSearch.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<dynamic> Search(ContentSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            return await _contentSearchService.SearchAsync(model.Url);
        }
    }

    public class UrlValidatorAttribute : Attribute
    {

    }
}