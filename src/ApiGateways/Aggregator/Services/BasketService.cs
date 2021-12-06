using Aggregator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class BasketService :IBasketService
    {
        private readonly HttpClient _client;
        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task DeleteBasket(string UserName)
        {
            await _client.DeleteAsync($"/Basket/{UserName}");
        }

        public async Task<BasketModel> GetBasket(string UserName)
        {
            var response = await _client.GetAsync($"/Basket/{UserName}");
            return await response.ReadContentAs<BasketModel>();
        }
    }
}
