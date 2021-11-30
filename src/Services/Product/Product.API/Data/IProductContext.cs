using Product.API.Entities;
using MongoDB.Driver;

namespace Product.API.Data
{
    public interface IProductContext
    {
        IMongoCollection<ProductDTO> Products { get; }
    }
}