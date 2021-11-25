using Product.API.Entities;
using MongoDB.Driver;

namespace Product.API.Data
{
    public interface IProductContext
    {
        IMongoCollection<ProductDTO> Products { get; }

        IMongoCollection<Brand> Brands { get; }

        IMongoCollection<Category> Categories { get; }
    }
}