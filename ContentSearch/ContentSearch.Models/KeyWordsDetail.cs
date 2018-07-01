using System.Collections.Generic;

namespace ContentSearch.Models
{
    public class KeyWordsDetail
    {
        public int TotalCount { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Items { get; set; }
    }
}