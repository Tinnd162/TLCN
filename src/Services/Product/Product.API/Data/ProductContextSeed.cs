using System.Collections.Generic;
using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Item> itemCollection, IMongoCollection<Brand> brandCollection, IMongoCollection<Category> categoryCollection)
        {
            //
            bool existItem = itemCollection.Find(p => true).Any();
            if (!existItem)
            {
                itemCollection.InsertManyAsync(GetPreconfiguredProducts());
            }

            bool existBrand = brandCollection.Find(p => true).Any();
            if (!existBrand)
            {
                brandCollection.InsertManyAsync(GetPreconfiguredBrands());
            }
            //
            bool existCategory = categoryCollection.Find(p => true).Any();
            if (!existCategory)
            {
                categoryCollection.InsertManyAsync(GetPreconfiguredCategories());
            }
        }

        private static IEnumerable<Item> GetPreconfiguredProducts()
        {
            return new List<Item>()
            {
                new Item()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Color ="Color",
                    Summary = "Summary",
                    Description = "Description",
                    Images = "Images",
                    Price = 950.00M,
                    CategoryId="CatelogId",
                    CategotyName = "Smart Phone",
                    BrandId="BrandId",
                    BrandName="BrandName"
                },
                new Item()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Sony",
                    Color ="Color",
                    Summary = "Summary",
                    Description = "Description",
                    Images = "Images",
                    Price = 950.00M,
                    CategoryId="CatelogId",
                    CategotyName = "Smart Phone",
                    BrandId="BrandId",
                    BrandName="BrandName"
                },
                new Item()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Samsung",
                    Color ="Color",
                    Summary = "Summary",
                    Description = "Description",
                    Images = "Images",
                    Price = 950.00M,
                    CategoryId="CatelogId",
                    CategotyName = "Smart Phone",
                    BrandId="BrandId",
                    BrandName="BrandName"
                },
            };
        }

        private static IEnumerable<Brand> GetPreconfiguredBrands()
        {
            return new List<Brand>()
            {
                new Brand()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    BrandName = "Dell"
                },
                new Brand()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    BrandName = "Apple"
                },
                new Brand()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    BrandName = "Samsung"
                },
            };
        }
        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    CategoryName = "SmartPhone"
                },
                new Category()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    CategoryName = "Máy tính bảng"
                },
                new Category()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    CategoryName = "Laptop"
                },
            };
        }
    }
}