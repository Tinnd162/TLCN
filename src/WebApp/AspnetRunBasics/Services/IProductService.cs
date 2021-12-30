using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IProductService
    {
        Task<IEnumerable<CategoryModel>> GetProducts();
        Task<IEnumerable<CategoryModel>> GetProductByCategory(string strCategory);
        Task<IEnumerable<CategoryModel>> GetProductByBrand(string strBrand);
        Task<CategoryModel> GetProduct(string id);
        Task<List<CategoryModel>> Search(string strKeyWord);
    }
}
