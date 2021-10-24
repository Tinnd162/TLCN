using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;

namespace Product.API.Repositories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IProductContext _productContext;
        public CategoryRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Category> GetCategory(string CategoryName)
        {
            return await _productContext
                            .Categories
                            .Find(b => b.Id == CategoryName)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _productContext
                            .Categories
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}