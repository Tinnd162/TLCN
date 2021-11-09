using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Inventory.API.DTOs;
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
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetListProductByBrand(string strBrandId)
        {
            var products = await _inventoryRepository.GetListProductByBrand(strBrandId);
            return Ok(products);
        }
    }
}