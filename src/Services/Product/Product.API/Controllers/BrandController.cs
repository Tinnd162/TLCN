using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repositories;

namespace Product.API.Controllers
{
    public class BrandController : BaseApiController
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository, ILogger<BrandController> logger)
        {
            _brandRepository = brandRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Brand>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands = await _brandRepository.GetBrands();
            return Ok(brands);
        }

        [HttpGet("{brand:length(24)}", Name = "GetBrand")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Brand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Brand>> GetBrand(string brandName)
        {
            var brand = await _brandRepository.GetBrand(brandName);
            if (brand == null)
            {
                _logger.LogError($"Item with id: {brand}, not found.");
                return NotFound();
            }
            return Ok(brand);
        }
    }
}