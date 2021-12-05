using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public interface IOrderService
    {
        public Task<string> InsertSaleOrder(object objRequest);
    }
}
