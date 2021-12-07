using System.Collections.Generic;
using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<ProductDTO> itemCollection)
        {
            bool existItem = itemCollection.Find(p => true).Any();
            if (!existItem)
            {
                itemCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<ProductDTO> GetPreconfiguredProducts()
        {
            return new List<ProductDTO>()
            {
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 950.00M,
                    Category = "Smart Phone",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 840.00M,
                    Category = "Smart Phone",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Huawei Plus",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 650.00M,
                    Category = "White Appliances",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Xiaomi Mi 9",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 470.00M,
                    Category = "White Appliances",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "HTC U11+ Plus",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 380.00M,
                    Category = "Smart Phone",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "LG G7 ThinQ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1627224460/jrqdbberc90yi70yuhul.jpg",
                    Price = 240.00M,
                    Category = "Home Kitchen",
                    Brand="BrandName",
                    PurchaseDate=null,
                    NumberOfSale=0
                }
            };
        }
    }
}