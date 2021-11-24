using Ordering.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BL.Interfaces
{
    public interface IOrderBL
    {
        Task<OrderBO> GetOrderByID(string strCustomerID, string strSaleOrderID);
    }
}
