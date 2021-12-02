using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repositories;

namespace Product.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var items = await _productRepository.GetProducts();
            return Ok(items);
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(string id)
        {
            var item = await _productRepository.GetProduct(id);
            if (item == null)
            {
                _logger.LogError($"Item with id: {id}, not found.");
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("GetProductByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByCategory(string categoryName)
        {
            var items = await _productRepository.GetProductByCategory(categoryName);
            if (items == null)
            {
                _logger.LogError($"Item with category: {categoryName}, not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet]
        [Route("GetProductByBrand")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByBrand(string brandName)
        {
            var items = await _productRepository.GetProductByBrand(brandName);
            if (items == null)
            {
                _logger.LogError($"Item with brand: {brandName}, not found.");
                return NotFound();
            }
            return Ok(items);
        }
    }
}