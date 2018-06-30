using System.Linq;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public interface IImageSearchRepository
    {
        Task<IQueryable<string>> AllImages(string url);
        Task<IQueryable<string>> MostOccurringWords(string url, int count);
    }
}
