using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(string strId);
        IEnumerable<ProductDTO> GetProductByCategory(string strcategoryName);
        IEnumerable<ProductDTO> GetProductByBrand(string strbrandName);
        IEnumerable<ProductDTO> Search(string strKeyword);
        Task CreateProduct(ProductDTO objProduct);
        Task RemoveProduct(string strProductId);
        Task UpdateProduct(ProductDTO objProduct);
    }
}