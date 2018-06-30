using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContentSearch.Repositories
{
    public static class ImageUtility
    {
        internal static List<string> FetchImgsFromSource(string htmlSource)
        {
            var listOfImgdata = new List<string>();
            var regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            var matchesImgSrc =
                Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match m in matchesImgSrc)
            {
                var imageUrl = m.Groups[1].Value;
                if (!listOfImgdata.Contains(imageUrl))
                    listOfImgdata.Add(imageUrl);
            }
            return listOfImgdata;
        }
    }
}

