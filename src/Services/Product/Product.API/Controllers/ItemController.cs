using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repositories;

namespace Product.API.Controllers
{
    public class ItemController : BaseApiController
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository, ILogger<ItemController> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _itemRepository.GetItems();
            return Ok(items);
        }

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> GetItem(string id)
        {
            var item = await _itemRepository.GetItem(id);
            if (item == null)
            {
                _logger.LogError($"Item with id: {id}, not found.");
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByCategory(string categoryName)
        {
            var items = await _itemRepository.GetItemByCategory(categoryName);
            if (items == null)
            {
                _logger.LogError($"Item with category: {categoryName}, not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]/{brand}", Name = "GetProductByBrand")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByBrand(string brandName)
        {
            var items = await _itemRepository.GetItemByBrand(brandName);
            if (items == null)
            {
                _logger.LogError($"Item with brand: {brandName}, not found.");
                return NotFound();
            }
            return Ok(items);
        }
    }
}