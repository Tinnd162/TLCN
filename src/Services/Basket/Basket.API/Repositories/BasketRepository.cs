using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string UserName)
        {           
            await _redisCache.RemoveAsync(UserName);                
        }

        public async Task<Cart> GetBasket(string UserName)
        {
            var basket = await _redisCache.GetStringAsync(UserName);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<Cart>(basket);
        }

        public async Task<Cart> UpdateBasket(Cart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
        }
    }
}
