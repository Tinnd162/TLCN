using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Common;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Microsoft.AspNetCore.Http;

namespace Inventory.API.Repositories
{
    public interface IInventoryRepository
    {
        //Task<IEnumerable<InfoDTO>> GetCategories();
        Task<IEnumerable<InfoDTO>> GetSuppliers();
        Task<BrandWithCategoryDTO> GetBrandsWithByCategory(string strCategoryId);
        Task<IEnumerable<ProductDTO>> GetProductsByBrand(string strBrandId);
        Task<ProductDetailDTO> GetProductDetailById(string strProductId);
        Task<bool> AddDetailProduct(AddProductDTO objDetailProductDTO);
        Task<bool> RemoveProduct(string strProductId);
        ProductEventBO MapperEventRabbitMQ(AddProductDTO objAddProductDTO);
        Task<bool> UpdateDetailProduct(UpdateProductDTO objUpdateProductDTO);
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<List<UpdateParamsNumberOfSale>> UpdateNumberOfSaleAfterSO(List<UpdateParamsNumberOfSale> lstObjParams);
        Task<List<ProductDetailDTO>> Search(string strKeyword);
        Task<List<BrandWithCategoryDTO>> GetCategories();
    }
}