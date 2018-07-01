using ContentSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public interface IContentSearchRepository
    {
        Task<string> ExtractSiteContent(string url);
        Task<IList<string>> AllImages(string html);
        Task<KeyWordsDetail> MostOccurringWords(string html, int count);
    }
}
