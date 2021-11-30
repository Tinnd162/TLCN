using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(string strId);
        Task<IEnumerable<ProductDTO>> GetProductByCategory(string strcategoryName);
        Task<IEnumerable<ProductDTO>> GetProductByBrand(string strbrandName);
        Task CreateProduct(ProductDTO objProduct);
        Task RemoveProduct(string strProductId);
        Task UpdateProduct(ProductDTO objProduct);
    }
}