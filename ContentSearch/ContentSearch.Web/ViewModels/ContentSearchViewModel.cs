using System.ComponentModel.DataAnnotations;

namespace ContentSearch.Web.ViewModels
{
    public class ContentSearchViewModel
    {
        [Url]
        [Required]
        public string Url { get; set; }
    }
}
