using System.Collections.Generic;
using System.Threading.Tasks;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(string categoryName);
    }
}