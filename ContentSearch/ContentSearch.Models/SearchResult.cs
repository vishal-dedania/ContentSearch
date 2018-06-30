using System.Collections.Generic;
using System.Linq;

namespace ContentSearch.Models
{
    public class SearchResult
    {
        public IList<string> Images { get; set; }
        public IQueryable<string> KeyWords { get; set; }
    }
}
