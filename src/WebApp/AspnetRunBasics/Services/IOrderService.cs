using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetSaleOrderList(string strCustomerId);
        Task<string> InsertSaleOrder(OrderResponseModel objSO);
        Task<IEnumerable<PaymentModel>> GetPaymentInfos(string strCustomerId);
        Task<IEnumerable<DeliveryModel>> GetDeliveryInfos(string strCustomerId);
    }

}
