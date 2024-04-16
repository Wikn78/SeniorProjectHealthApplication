using Newtonsoft.Json;

namespace OpenFoodFactsCSharp.Models
{
    public class ProductMulti
    {
        public string Code { get; set; }

        public string Status { get; set; }

        public Nutriments Nutriments { get; set; }

        [JsonProperty("product_Name_en")] public string ProductName { get; set; }
    }
}