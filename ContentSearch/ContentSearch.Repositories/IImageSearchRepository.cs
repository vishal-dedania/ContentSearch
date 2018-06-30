using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public interface IImageSearchRepository
    {
        Task<IList<string>> AllImages(string url);
        Task<IQueryable<string>> MostOccurringWords(string url, int count);
    }
}
