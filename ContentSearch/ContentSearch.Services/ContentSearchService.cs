using ContentSearch.Models;
using ContentSearch.Repositories;
using System.Threading.Tasks;

namespace ContentSearch.Services
{
    public class ContentSearchService : IContentSearchService
    {
        private readonly IContentSearchRepository _contentSearchRepository;

        public ContentSearchService(IContentSearchRepository contentSearchRepository)
        {
            _contentSearchRepository = contentSearchRepository;
        }

        public async Task<SearchResult> SearchAsync(string url)
        {
            var html = await _contentSearchRepository.ExtractSiteContent(url);

            var result = new SearchResult();
            if (string.IsNullOrEmpty(html)) return result;

            result.Images = await _contentSearchRepository.AllImages(html);
            result.KeyWords = await _contentSearchRepository.MostOccurringWords(html, 10);

            return result;
        }
    }
}