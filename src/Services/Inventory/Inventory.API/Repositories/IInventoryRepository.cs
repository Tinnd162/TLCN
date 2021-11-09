using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.API.DTOs;

namespace Inventory.API.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<ProductDTO>> GetListProductByBrand(string strBrandId);
        Task<IEnumerable<ProductDTO>> GetListProductByCategory(string strCategoryId);
        Task<ProductDetailDTO> GetProductDetailById(string strProductId);
        Task<bool> AddProduct(ProductDetailDTO objProductDetailDTO);
        Task<bool> RemoveProduct(string strProductId);
        Task<bool> CheckProduct(string strProductId);
    }
}