using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<DeliveryModel>> GetDeliveryInfos(string strCustomerId)
        {
            var response = await _client.GetAsync($"/Order/GetDeliveryInfos/{strCustomerId}");
            return await response.ReadContentAs<List<DeliveryModel>>();
        }

        public async Task<IEnumerable<PaymentModel>> GetPaymentInfos(string strCustomerId)
        {
            var response = await _client.GetAsync($"/Order/GetPaymentInfos/{strCustomerId}");
            return await response.ReadContentAs<List<PaymentModel>>();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetSaleOrderList(string strCustomerId)
        {
            var response = await _client.GetAsync($"/Order/GetSaleOrderList/{strCustomerId}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }

        public async Task<string> InsertSaleOrder(OrderResponseModel objSO)
        {
            var response = await _client.PostAsJson($"/SaleOrder/InsertSO", objSO);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<string>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
