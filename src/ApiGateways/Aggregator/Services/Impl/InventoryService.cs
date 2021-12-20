using Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async Task<InventoryModel> GetProductDetailById(string strProductId, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.GetAsync($"/Inventory/GetProductDetailById/{strProductId}");
            return await response.ReadContentAs<InventoryModel>();
        }
        public async Task<bool> UpdateNumberOfSaleAfterSO(List<ParamsUpdateModel> lstObjParams, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PutAsJson($"/Inventory/UpdateNumberOfSaleAfterSO", lstObjParams);
            return await response.ReadContentAs<bool>();
        }
    }
}
