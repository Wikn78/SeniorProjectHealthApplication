using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeniorProjectHealthApplication.Models
{
    public class FoodDatabaseManager
    {
        private const string ApiUrl = "https://world.openfoodfacts.org/api/v3";
        private readonly HttpClient _httpClient;
        
        public FoodDatabaseManager(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        
        public async Task<Product> FetchProductByCodeAsync(string code)
        {
            var requestUri = $"{ApiUrl}/product/{code}.json";
            var response = await _httpClient.GetAsync(requestUri);
            
            if (!response.IsSuccessStatusCode)
            {
                // Handle error or throw an exception
                throw new HttpRequestException($"Failed to fetch product by code: {code}");
            }


            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            return product;
        }
    }
}