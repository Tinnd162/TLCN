using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
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

        public async Task<IEnumerable<ProductDTO>> GetProductByBrand(string strBrand)
        {
            FilterDefinition<ProductDTO> filter = Builders<ProductDTO>.Filter.Eq(p => p.Brand, strBrand);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByCategory(string strCategory)
        {
            FilterDefinition<ProductDTO> filter = Builders<ProductDTO>.Filter.Eq(p => p.Category, strCategory);

            return await _productContext
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateProduct(ProductDTO objProduct)
        {
            await _productContext.Products.InsertOneAsync(objProduct);
            return;
        }

        public async Task RemoveProduct(string strProductId)
        {
            await _productContext.Products.DeleteOneAsync(x => x.Id == strProductId);
            return;
        }

        public async Task UpdateProduct(ProductDTO objProduct)
        {
            if (objProduct.ParamsUpdate != null && objProduct.IsUpdateQuantityAfterSO)
            {
                foreach (var item in objProduct.ParamsUpdate)
                {
                    ProductDTO objResult = await _productContext.Products.Find(x => x.Id == item.ProductId).FirstOrDefaultAsync();
                    objResult.NumberOfSale = item.NumberOfSale;
                    objResult.PurchaseDate = objProduct.PurchaseDate;
                    await _productContext.Products.ReplaceOneAsync(x => x.Id == objResult.Id, objResult);
                }
                return;
            }
            else
                await _productContext.Products.ReplaceOneAsync(x => x.Id == objProduct.Id, objProduct);
            return;
        }
    }
}