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
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var items = _productRepository.GetProducts();
            return Ok(items);
        }

        [HttpGet]
        [Route("GetProduct/{strProductId}")]
        public ActionResult<ProductDTO> GetProduct(string strProductId)
        {
            var item = _productRepository.GetProduct(strProductId);
            if (item == null)
            {
                _logger.LogError($"Item with id: {strProductId}, not found.");
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("GetProductByCategory/{strCategory}")]
        public ActionResult<IEnumerable<ProductDTO>> GetProductByCategory(string strCategory)
        {
            var items = _productRepository.GetProductByCategory(strCategory);
            if (items == null)
            {
                _logger.LogError($"Item with category: {strCategory}, not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet]
        [Route("GetProductByBrand/{strBrand}")]
        public ActionResult<IEnumerable<ProductDTO>> GetProductByBrand(string strBrand)
        {
            var items = _productRepository.GetProductByBrand(strBrand);
            if (items == null)
            {
                _logger.LogError($"Item with brand: {strBrand}, not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet]
        [Route("Search/{strKeyWord}")]
        public ActionResult<IEnumerable<ProductDTO>> Search(string strKeyWord)
        {
            var items = _productRepository.Search(strKeyWord);
            if (items == null)
            {
                _logger.LogError($"Item with brand: {strKeyWord}, not found.");
                return NotFound();
            }
            return Ok(items);
        }
    }
}