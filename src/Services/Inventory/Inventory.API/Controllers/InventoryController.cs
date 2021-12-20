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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Inventory.API.Controllers
{
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IBus _bus;
        private readonly IPublishEndpoint _publishEndpoint;
        public InventoryController(IInventoryRepository inventoryRepository, IBus bus, IPublishEndpoint publishEndpoint)
        {
            _bus = bus;
            _publishEndpoint = publishEndpoint;
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
        [Route("GetProductDetailById/{strProductId}")]
        public async Task<ActionResult<ProductDetailDTO>> GetProductDetailById(string strProductId)
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
                // Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                // var endPoint = await _bus.GetSendEndpoint(uri);
                // await endPoint.Send(objProductEventBO);
                // return Ok("Success");
                await _publishEndpoint.Publish<ProductEventBO>(objProductEventBO);
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct(UpdateProductDTO objUpdateProductDTO)
        {
            bool bolIsUpdateProduct = await _inventoryRepository.UpdateDetailProduct(objUpdateProductDTO);
            //ProductEventBO objProductEventBO = new ProductEventBO()
            //{
            //    Id = objUpdateProductDTO.Id,
            //    Name = objUpdateProductDTO.Name,
            //    Description = objUpdateProductDTO.Description,
            //    NumberOfSale = 0,
            //    Image = objUpdateProductDTO.LinkImage,
            //    Category = objUpdateProductDTO.CategoryDTO.Name,
            //    Brand = objUpdateProductDTO.BrandDTO.Name,
            //    SalePrice = objUpdateProductDTO.PriceLogDTO.SalePrice,
            //    IsUpdate = true,
            //    PurchaseDate = null,
            //};
            if (bolIsUpdateProduct)
            {
                // Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                // var endPoint = await _bus.GetSendEndpoint(uri);
                // await endPoint.Send(objProductEventBO);
                // return Ok("Success");
                //await _publishEndpoint.Publish<ProductEventBO>(objProductEventBO);
                return true;
            }
            return false;
        }
        
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct([FromForm] AddProductDTO objAddProductDTO)
        {
            var result = await _inventoryRepository.AddPhotoAsync(objAddProductDTO.Image);
            if (result.Error != null) return BadRequest(result.Error.Message);

            objAddProductDTO.Id = ObjectId.GenerateNewId().ToString();
            objAddProductDTO.LinkImage = result.SecureUrl.AbsoluteUri;

            bool bolIsAddProduct = await _inventoryRepository.AddDetailProduct(objAddProductDTO);
            ProductEventBO objProductEventBO = _inventoryRepository.MapperEventRabbitMQ(objAddProductDTO);
            objProductEventBO.NumberOfSale = 0;
            objProductEventBO.PurchaseDate = null;

            if (bolIsAddProduct)
            {
                // Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                // var endPoint = await _bus.GetSendEndpoint(uri);
                // await endPoint.Send(objProductEventBO);
                // return Ok("Success");
                await _publishEndpoint.Publish<ProductEventBO>(objProductEventBO);
                return true;
            }
            return false;
        }
        [HttpPut]
        [Route("UpdateNumberOfSaleAfterSO")]
        public async Task<ActionResult<bool>> UpdateNumberOfSaleAfterSO(List<UpdateParamsNumberOfSale> lstObjParams)
        {
            bool bolIsUpdateQuantity = await _inventoryRepository.UpdateNumberOfSaleAfterSO(lstObjParams);

            ProductEventBO objProductEventBO = new ProductEventBO()
            {
                IsUpdateQuantityAfterSO = true,
                IsUpdate = true,
                PurchaseDate = DateTime.Now,
                ParamsUpdate = lstObjParams
            };
            if (bolIsUpdateQuantity)
            {
                // Uri uri = new Uri(RabbitMQConstants.RabbitMqUri);
                // var endPoint = await _bus.GetSendEndpoint(uri);
                // await endPoint.Send(objProductEventBO);
                await _publishEndpoint.Publish<ProductEventBO>(objProductEventBO);
                return true;
            }
            return false;
        }
    }
}