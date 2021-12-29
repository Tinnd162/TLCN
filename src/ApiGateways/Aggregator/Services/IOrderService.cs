using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aggregator.Models;

namespace Aggregator.Services
{
    public interface IOrderService
    {
        public Task<string> InsertSaleOrder(OrderModel objSaleOrderBO, string strToken);
    }
}
