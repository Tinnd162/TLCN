using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<SOModel>> GetSaleOrderList(string strCustomerId, string strToken);
        Task<IEnumerable<PaymentModel>> GetPaymentInfos(string strCustomerId, string strToken);
        Task<IEnumerable<DeliveryModel>> GetDeliveryInfos(string strCustomerId, string strToken);
        Task<SOModel> GetSO(string strCustomerId, string strSaleOrderId, string strToken);
    }

}
