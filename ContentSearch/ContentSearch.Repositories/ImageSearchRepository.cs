using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public class ImageSearchRepository : IImageSearchRepository
    {
        public async Task<IQueryable<string>> AllImages(string url)
        {
            return await Task.Factory.StartNew(() => new List<string>().AsQueryable());
        }

        public async Task<IQueryable<string>> MostOccurringWords(string url, int count)
        {
            return await Task.Factory.StartNew(() => new List<string>().AsQueryable());
        }
    }
}