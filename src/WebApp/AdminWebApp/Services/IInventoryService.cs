using AdminWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Services
{
    public interface IInventoryService
    {
        public Task<ProductDetailModel> GetProductDetailById(string strProductID, string token);
        public Task<bool> AddProduct(AddProductModel objAddProductModel, string token);
    }
}
