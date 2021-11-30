using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductContext : IProductContext
    {
        private readonly IConfiguration _config;
        public ProductContext(IConfiguration config)
        {
            _config = config;
            var client = new MongoClient(_config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(_config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<ProductDTO>(_config.GetValue<string>("DatabaseSettings:ProductsCollection"));
            ProductContextSeed.SeedData(Products);
        }

        public IMongoCollection<ProductDTO> Products { get; }
    }
}