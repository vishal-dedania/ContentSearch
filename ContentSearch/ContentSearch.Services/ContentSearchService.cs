using ContentSearch.Models;
using System.Threading.Tasks;

namespace ContentSearch.Services
{
    public class ContentSearchService : IContentSearchService
    {
        public async Task<SearchResult> SearchAsync(string url)
        {
            return await Task.Factory.StartNew(() => new SearchResult());
        }
    }
}