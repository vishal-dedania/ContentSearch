using ContentSearch.Models;
using System.Threading.Tasks;

namespace ContentSearch.Services
{
    public class ContentSearchService : IContentSearchService
    {
        public Task<SearchResult> SearchAsync(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}