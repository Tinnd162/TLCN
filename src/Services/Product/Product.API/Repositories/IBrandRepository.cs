using System.Collections.Generic;
using System.Threading.Tasks;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(string brandName);
    }
}