using Aggregator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        public OrderService(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> InsertSaleOrder(OrderModel objSaleOrderBO)
        {
            var response = await _client.PostAsJson($"/Order/Insert", objSaleOrderBO);
            if (response.IsSuccessStatusCode)
            {
                var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return dataAsString;
            }
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
