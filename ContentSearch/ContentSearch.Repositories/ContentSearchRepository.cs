using ContentSearch.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public class ContentSearchRepository : IContentSearchRepository
    {
        public async Task<string> ExtractSiteContent(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            return restResponse.Content;
        }

        public async Task<IList<string>> AllImages(string html)
        {
            var images = new List<string>();

            await Task.Factory.StartNew(() =>
                images = ImageUtility.FetchImgsFromSource(html));

            return images;
        }

        public async Task<KeyWordsDetail> MostOccurringWords(string html, int count)
        {
            var items = new Dictionary<string, int>();
            var result = new KeyWordsDetail();

            await Task.Factory.StartNew(() => items = CountWords(html));

            result.TotalCount = items.Count;

            var sortedItems = from pair in items
                orderby pair.Value descending
                select pair;

            result.Items = result.TotalCount > count ? sortedItems.Take(count) : sortedItems.Take(result.TotalCount);

            return result;
        }

        private Dictionary<string, int> CountWords(string html)
        {
            var wordPattern = new Regex(@"\w+");

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (Match match in wordPattern.Matches(html))
            {
                if (!words.ContainsKey(match.Value))
                    words.Add(match.Value, 1);
                else
                    words[match.Value]++;
            }

            return words;
        }
    }
}