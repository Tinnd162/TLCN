using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.API.Data;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Repositories.Impl
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InventoryRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> AddProduct(ProductDetailDTO objProductDetailDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CheckProduct(string strProductId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetListProductByBrand(string strBrandId)
        {
            List<Product> lstProduct = await _context.Products.Where(x => x.BrandId == strBrandId).ToListAsync();
            // var Price = _context.PriceLogs.AsQueryable();

            // if (lstProduct != null && lstProduct.Count != 0)
            // {
            //     string strProductId = lstProduct.Select(x => x.Id).FirstOrDefault();
            //     var priceProduct = Price.Where(x => x.ProductId == strProductId);
            // }
            return _mapper.Map<IEnumerable<ProductDTO>>(lstProduct);
        }

        public Task<IEnumerable<ProductDTO>> GetListProductByCategory(string strCategoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductDetailDTO> GetProductDetailById(string strProductId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveProduct(string strProductId)
        {
            throw new System.NotImplementedException();
        }
    }
}