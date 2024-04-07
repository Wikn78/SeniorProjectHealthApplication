using System.Threading.Tasks;
using OpenFoodFactsCSharp.Clients;
using OpenFoodFactsCSharp.Models;

namespace SeniorProjectHealthApplication.Models
{
    public static class FoodDatabaseManager
    {
        public static async Task<ProductResponse> GetProductByBarCodeAsync(string code)
        {
            
            OpenFoodFactsApiLowLevelClient wrapper = new OpenFoodFactsApiLowLevelClient();

            return await wrapper.FetchProductByCodeAsync(code); // 034856890089 welech fruit snacks
            
        }
        
        public static async Task<MultipleProjectResponse> GetProductByNameAsync(string foodName)
        {
            
            OpenFoodFactsApiLowLevelClient wrapper = new OpenFoodFactsApiLowLevelClient();

            return await wrapper.FetchProductsByNameAsync(foodName); 
            
        }
        
    }
}