using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;

namespace Product.API.Repositories.Impl
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IProductContext _productContext;
        public BrandRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Brand> GetBrand(string brandName)
        {
            return await _productContext
                            .Brands
                            .Find(b => b.Id == brandName)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _productContext
                            .Brands
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}