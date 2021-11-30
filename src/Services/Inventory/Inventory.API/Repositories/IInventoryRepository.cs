using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Inventory.API.DTOs;
using Inventory.API.Entities;

namespace Inventory.API.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InfoDTO>> GetCategories();
        Task<IEnumerable<InfoDTO>> GetSuppliers();
        Task<BrandWithCategoryDTO> GetBrandsWithByCategory(string strCategoryId);
        Task<IEnumerable<ProductDTO>> GetProductsByBrand(string strBrandId);
        Task<ProductDetailDTO> GetProductDetailById(string strProductId);
        Task<bool> AddDetailProduct(AddProductDTO objDetailProductDTO);
        Task<bool> RemoveProduct(string strProductId);
        ProductEventBO MapperEventRabbitMQ(AddProductDTO objAddProductDTO);
    }
}