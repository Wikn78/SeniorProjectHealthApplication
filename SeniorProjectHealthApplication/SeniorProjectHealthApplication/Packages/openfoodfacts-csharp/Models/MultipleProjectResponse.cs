using Newtonsoft.Json;

namespace OpenFoodFactsCSharp.Models
{
    public class MultipleProjectResponse
    {
        public int Page { get; set; }

        [JsonProperty("page_count")] public int PageCount { get; set; }

        [JsonProperty("page_size")] public int PageSize { get; set; }

        public Product[] Products { get; set; }
    }
}