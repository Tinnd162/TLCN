using Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _client;
        public InventoryService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<InventoryModel>> GetProductDetailById(string strProductId)
        {
            var response = await _client.GetAsync($"/Inventory/GetProductDetailById?strProductId={strProductId}");
            return await response.ReadContentAs<IEnumerable<InventoryModel>>();
        }
    }
}
