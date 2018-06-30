using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContentSearch.Repositories
{
    public class ImageSearchRepository : IImageSearchRepository
    {
        public async Task<IList<string>> AllImages(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            var images = ImageUtility.FetchImgsFromSource(restResponse.Content);

            return images;
        }

        public async Task<IQueryable<string>> MostOccurringWords(string url, int count)
        {
            return await Task.Factory.StartNew(() => new List<string>().AsQueryable());
        }
    }
}