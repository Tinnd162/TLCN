using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("GetBasket/{UserName}")]
        public async Task<ActionResult<Cart>> GetBasket(string UserName)
        {
            var basket = await _repository.GetBasket(UserName);
            return Ok(basket ?? new Cart(UserName));
        }

        [HttpPost]
        [Route("UpdateBasket")]
        public async Task<ActionResult<Cart>> UpdateBasket([FromBody] Cart basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete]
        [Route("DeleteBasket/{UserName}")]
        public async Task<IActionResult> DeleteBasket(string UserName)
        {
            await _repository.DeleteBasket(UserName);
            return Ok();
        }
    }
}
