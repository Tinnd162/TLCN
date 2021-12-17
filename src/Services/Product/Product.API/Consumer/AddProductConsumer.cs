using System.Collections.Generic;
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
            ProductEventBO obj = consumeContext.Message;

            ProductDTO objResult = new ProductDTO()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                ImageFile = obj.Image,
                Category = obj.Category,
                Brand = obj.Brand,
                SalePrice = obj.SalePrice,
                IsDelete = obj.IsDelete,
                IsUpdate = obj.IsUpdate,
                NumberOfSale = obj.NumberOfSale,
                IsUpdateQuantityAfterSO = obj.IsUpdateQuantityAfterSO,
                PurchaseDate = obj.PurchaseDate,
                ParamsUpdate = obj.ParamsUpdate
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