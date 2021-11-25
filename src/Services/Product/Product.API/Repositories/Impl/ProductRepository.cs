using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;

namespace Product.API.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _productContext;
        public ProductRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Brand> GetBrand(string strbrandName)
        {
            return await _productContext
                            .Brands
                            .Find(b => b.Id == strbrandName)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _productContext
                            .Brands
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Category> GetCategory(string strCategoryName)
        {
            return await _productContext
                            .Categories
                            .Find(b => b.Id == strCategoryName)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _productContext
                            .Categories
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _productContext
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<ProductDTO> GetProduct(string strId)
        {
            return await _productContext
                           .Products
                           .Find(p => p.Id == strId)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByBrand(string strbrandName)
        {
            FilterDefinition<ProductDTO> filter = Builders<ProductDTO>.Filter.Eq(p => p.BrandName, strbrandName);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<ProductDTO> filter = Builders<ProductDTO>.Filter.Eq(p => p.CategotyName, categoryName);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public Task<IEnumerable<ProductDTO>> GetProductByName(string strProductname)
        {
            throw new System.NotImplementedException();
        }
    }
}