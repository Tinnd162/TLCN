using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<SOModel>> GetSaleOrderList(string strCustomerId);
        Task<string> InsertSaleOrder(SOModel objSO);
        Task<IEnumerable<PaymentModel>> GetPaymentInfos(string strCustomerId);
        Task<IEnumerable<DeliveryModel>> GetDeliveryInfos(string strCustomerId);
        Task<SOModel> GetSO(string strCustomerId, string strSaleOrderId);
    }

}
