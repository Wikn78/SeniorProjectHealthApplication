
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;

namespace OpenFoodFactsCSharp.Clients
{
    public class OpenFoodFactsApiLowLevelClient
    {
        private const string ApiUrl = "https://world.openfoodfacts.org/api/v2";

        private const string FoodSearchApiUrl =
            "https://world.openfoodfacts.org/cgi/search.pl?search_terms=";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<ProductResponse> FetchProductByCodeAsync(string code)
        {
            try
            {
                var requestUri = $"{ApiUrl}/products/{code}.json";
                Uri uri = new Uri(requestUri);
                var response = await _httpClient.GetAsync(uri);
    
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to fetch product by code: {code}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductResponse>(content);

                return product;
            }
            catch (Exception ex)
            {
                // Handle and log the exception details here
                Console.WriteLine("------------------- Error ---------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("------------------- Error ---------------------");
                throw;
            }
        }

        public async Task<MultipleProjectResponse> FetchProductsByNameAsync(string foodName)
        {
            try
            {
                var foodNameUpdated = foodName.Replace(' ', '_');

                var Url =
                    "https://world.openfoodfacts.org/cgi/search.pl?search_terms=chicken_breast&search_simple=1&action=process&json=1";
                var requestUri = $"{FoodSearchApiUrl}{foodNameUpdated}&search_simple=1&action=process&json=1";
                Uri uri = new Uri(requestUri);
                var response = await _httpClient.GetAsync(uri);
    
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to fetch product by code: {foodName}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<MultipleProjectResponse>(content);

                return products;
            }
            catch (Exception ex)
            {
                // Handle and log the exception details here
                Console.WriteLine("------------------- Error ---------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("------------------- Error ---------------------");
                throw;
            }
        }
        
    }
}
