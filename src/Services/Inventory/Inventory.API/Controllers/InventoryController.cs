using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Inventory.API.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Inventory.API.Controllers
{
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IBus _bus;
        public InventoryController(IInventoryRepository inventoryRepository, IBus bus)
        {
            _bus = bus;
            _inventoryRepository = inventoryRepository;
        }
        [HttpGet]
        [Route("GetProductsByBrand")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByBrand(string strBrandId)
        {
            var products = await _inventoryRepository.GetProductsByBrand(strBrandId);
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProductDetailById")]
        public async Task<ActionResult<IEnumerable<ProductDetailDTO>>> GetProductDetailById(string strProductId)
        {
            var product = await _inventoryRepository.GetProductDetailById(strProductId);
            return Ok(product);
        }
        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<ActionResult<bool>> RemoveProduct(string strProductId)
        {
            bool bolIsRemoveProduct = await _inventoryRepository.RemoveProduct(strProductId);
            ProductEventBO objProductEventBO = new ProductEventBO()
            {
                Id = strProductId,
                IsDelete = true
            };
            if (bolIsRemoveProduct)
            {
                Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(objProductEventBO);
                return Ok("Success");
            }
            return BadRequest("Fail!");
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct(UpdateProductDTO objUpdateProductDTO)
        {
            bool bolIsUpdateProduct = await _inventoryRepository.UpdateDetailProduct(objUpdateProductDTO);
            ProductEventBO objProductEventBO = new ProductEventBO()
            {
                Id = objUpdateProductDTO.Id,
                Name = objUpdateProductDTO.Name,
                Description = objUpdateProductDTO.Description,
                Image = objUpdateProductDTO.LinkImage,
                Category = objUpdateProductDTO.CategoryDTO.Name,
                Brand = objUpdateProductDTO.BrandDTO.Name,
                Price = objUpdateProductDTO.PriceLogDTO.Price,
                IsUpdate = true,
            };
            if (bolIsUpdateProduct)
            {
                Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(objProductEventBO);
                return Ok("Success");
            }
            return BadRequest("Fail!");
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct(AddProductDTO objAddProductDTO)
        {
            objAddProductDTO.Id = ObjectId.GenerateNewId().ToString();
            bool bolIsAddProduct = await _inventoryRepository.AddDetailProduct(objAddProductDTO);
            ProductEventBO objProductEventBO = _inventoryRepository.MapperEventRabbitMQ(objAddProductDTO);
            if (bolIsAddProduct)
            {
                Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(objProductEventBO);
                return Ok("Success");
            }
            return BadRequest("Fail!");
        }
    }
}