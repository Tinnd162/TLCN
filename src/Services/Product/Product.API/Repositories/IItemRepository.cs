using System.Collections.Generic;
using System.Threading.Tasks;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(string id);
        Task<IEnumerable<Item>> GetItemByName(string name);
        Task<IEnumerable<Item>> GetItemByCategory(string categoryName);
        Task<IEnumerable<Item>> GetItemByBrand(string brandName);
    }
}