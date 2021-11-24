using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Inventory.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository inventoryRepository)
        {
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
        [HttpPut]
        [Route("RemoveProduct")]
        public async Task<ActionResult<bool>> RemoveProduct(string strProductId)
        {
            bool bolIsRemoveProduct = await _inventoryRepository.RemoveProduct(strProductId);
            return Ok(bolIsRemoveProduct);
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct(AddProductDTO objAddProductDTO)
        {
            bool bolIsAddProduct = await _inventoryRepository.AddDetailProduct(objAddProductDTO);
            return Ok(bolIsAddProduct);
        }
    }
}