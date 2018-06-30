using System.Threading.Tasks;
using ContentSearch.Models;

namespace ContentSearch.Services
{
    public interface IContentSearchService
    {
        Task<SearchResult> SearchAsync(string url);
    }
}
