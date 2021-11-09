using Ordering.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Interfaces
{
    public interface IOrderDA
    {
        Task<OrderBO> GetOrderByID(string OrderID);
        Task<OrderBO> GetOrders();
        Task CreateOrder(ref OrderBO Order);
        Task<bool> DeleteOrder(string OrderID);
    }
}
