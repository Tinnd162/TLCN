﻿using Ordering.BL.Interfaces;
using Ordering.BO;
using Ordering.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BL
{
    public class OrderBL : IOrderBL
    {
        public IOrderDA _orderDA;
        public OrderBL(IOrderDA orderDA)
        {
            _orderDA = orderDA;
        }
        public async Task<OrderBO> GetOrderByID(string strCustomerID, string strSaleOrderID)
        {
            try
            {
                var objSaleOrderBO = await _orderDA.GetOrderByID(strSaleOrderID);
                return objSaleOrderBO;
            }
            catch(Exception objEx)
            {
                throw objEx;
            }
            return null;
        }
    }
}
