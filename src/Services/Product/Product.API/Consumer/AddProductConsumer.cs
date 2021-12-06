using System.Threading.Tasks;
using Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Product.API.Entities;
using Product.API.Repositories;

namespace Product.API.Consumer
{
    public class AddProductConsumer : IConsumer<ProductEventBO>
    {
        private readonly IProductRepository _productRepository;
        public AddProductConsumer(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Consume(ConsumeContext<ProductEventBO> consumeContext)
        {
            ProductEventBO objProductEventBO = consumeContext.Message;
            ProductDTO objResult = new ProductDTO()
            {
                Id = objProductEventBO.Id,
                Name = objProductEventBO.Name,
                Description = objProductEventBO.Description,
                ImageFile = objProductEventBO.Image,
                Category = objProductEventBO.Category,
                Brand = objProductEventBO.Brand,
                Price = objProductEventBO.Price,
                IsDelete = objProductEventBO.IsDelete,
                IsUpdate = objProductEventBO.IsUpdate
            };
            if (objResult.IsDelete)
                _productRepository.RemoveProduct(objResult.Id);
            else if (objResult.IsUpdate)
                _productRepository.UpdateProduct(objResult);
            else
                _productRepository.CreateProduct(objResult);
            return null;
        }
    }
}