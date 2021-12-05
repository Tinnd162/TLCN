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
        public async Task<string> InsertSaleOrder(object objRequest)
        {
            var myContent = JsonConvert.SerializeObject(objRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = _client.PostAsync($"/Order/Insert", byteContent).Result;
            return await response.ReadContentAs<string>();
        }
    }
}
