using ContentSearch.Models;
using ContentSearch.Repositories;
using System.Threading.Tasks;

namespace ContentSearch.Services
{
    public class ContentSearchService : IContentSearchService
    {
        private readonly IImageSearchRepository _imageSearchRepository;

        public ContentSearchService(IImageSearchRepository imageSearchRepository)
        {
            _imageSearchRepository = imageSearchRepository;
        }

        public async Task<SearchResult> SearchAsync(string url)
        {
            var result = new SearchResult
            {
                Images = await _imageSearchRepository.AllImages(url),
                KeyWords = await _imageSearchRepository.MostOccurringWords(url, 10)
            };

            return result;
        }
    }
}