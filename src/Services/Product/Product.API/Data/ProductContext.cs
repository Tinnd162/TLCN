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

            Products = database.GetCollection<ProductDTO>(_config.GetValue<string>("DatabaseSettings:ItemCollection"));
            Brands = database.GetCollection<Brand>(_config.GetValue<string>("DatabaseSettings:BrandCollection"));
            Categories = database.GetCollection<Category>(_config.GetValue<string>("DatabaseSettings:CategoryCollection"));

            ProductContextSeed.SeedData(Products, Brands, Categories);
        }

        public IMongoCollection<ProductDTO> Products { get; }
        public IMongoCollection<Brand> Brands { get; }
        public IMongoCollection<Category> Categories { get; }
    }
}