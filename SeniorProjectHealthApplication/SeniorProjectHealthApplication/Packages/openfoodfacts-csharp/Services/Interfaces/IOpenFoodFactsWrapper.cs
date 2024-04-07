using System.Threading.Tasks;
using OpenFoodFactsCSharp.Models;

namespace OpenFoodFactsCSharp.Services.Interfaces
{
    public interface IOpenFoodFactsWrapper
    {
        Task<ProductResponse> FetchProductByCodeAsync(string code);
    }
}