using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;

namespace Product.API.Repositories.Impl
{
    public class ItemRepository : IItemRepository
    {
        private readonly IProductContext _productContext;
        public ItemRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _productContext
                            .Items
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Item> GetItem(string id)
        {
            return await _productContext
                           .Items
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemByBrand(string brandName)
        {
            FilterDefinition<Item> filter = Builders<Item>.Filter.Eq(p => p.BrandName, brandName);

            return await _productContext
                            .Items
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemByCategory(string categoryName)
        {
            FilterDefinition<Item> filter = Builders<Item>.Filter.Eq(p => p.CategotyName, categoryName);

            return await _productContext
                            .Items
                            .Find(filter)
                            .ToListAsync();
        }

        public Task<IEnumerable<Item>> GetItemByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}