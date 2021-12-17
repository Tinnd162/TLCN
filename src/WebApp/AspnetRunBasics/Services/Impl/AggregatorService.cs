using System;
using System.Net.Http;
using System.Threading.Tasks;
using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services.Impl
{
    public class AggregatorService : IAggregatorService
    {
        private readonly HttpClient _client;
        public AggregatorService(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> InsertSaleOrder(SOModel objSO)
        {
            var response = await _client.PostAsJson($"/api/v1/SaleOrder/InsertSO", objSO);
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