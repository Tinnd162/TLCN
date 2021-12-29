using AdminWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Services
{
    public interface IInventoryService
    {
        Task<ProductDetailModel> GetProductDetailById(string strProductID, string token);
        Task<bool> AddProduct(AddProductModel objAddProductModel, string token);
        Task<bool> UpdateProduct(UpdateProductModel objUpdateProductDTO, string token);
        Task<List<ProductDetailModel>> Search(string strKeyword, string token);

    }
}
