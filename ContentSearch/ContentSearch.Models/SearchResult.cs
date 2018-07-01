using System.Collections.Generic;

namespace ContentSearch.Models
{
    public class SearchResult
    {
        public IList<string> Images { get; set; }
        public KeyWordsDetail KeyWords { get; set; }
    }
}
