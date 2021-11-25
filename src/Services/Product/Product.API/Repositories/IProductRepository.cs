using System.Collections.Generic;
using System.Threading.Tasks;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(string strbrandName);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(string strId);
        Task<IEnumerable<ProductDTO>> GetProductByName(string strProductname);
        Task<IEnumerable<ProductDTO>> GetProductByCategory(string strcategoryName);
        Task<IEnumerable<ProductDTO>> GetProductByBrand(string strbrandName);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(string strcategoryName);
    }
}