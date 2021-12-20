using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<DeliveryModel>> GetDeliveryInfos(string strCustomerId, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.GetAsync($"/Order/GetDeliveryInfos/{strCustomerId}");
            return await response.ReadContentAs<List<DeliveryModel>>();
        }

        public async Task<IEnumerable<PaymentModel>> GetPaymentInfos(string strCustomerId, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.GetAsync($"/Order/GetPaymentInfos/{strCustomerId}");
            return await response.ReadContentAs<List<PaymentModel>>();
        }

        public async Task<SOModel> GetSO(string strCustomerId, string strSaleOrderId, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.GetAsync($"/Order/GetSO/{strCustomerId}/{strSaleOrderId}");
            return await response.ReadContentAs<SOModel>();
        }

        public async Task<IEnumerable<SOModel>> GetSaleOrderList(string strCustomerId, string strToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.GetAsync($"/Order/GetSaleOrderList/{strCustomerId}");
            return await response.ReadContentAs<List<SOModel>>();
        }
    }
}
