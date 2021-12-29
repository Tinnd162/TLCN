using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ordering.BL.Interfaces;
using Ordering.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        public IOrderBL _orderBL;
        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpGet]
        [Route("GetOrderByID/{CustomerID}/{SaleOrderID}")]
        public ActionResult<OrderBO> GetOrderByID(string CustomerID, string SaleOrderID)
        {
            string strErrorMessage = string.Empty;
            OrderBO objSaleOrderBO = null;
            try
            {
                objSaleOrderBO = _orderBL.GetOrderByID(CustomerID, SaleOrderID, ref strErrorMessage);
                if (objSaleOrderBO == null)
                {
                    return Ok(new { error = true, content = strErrorMessage });
                }
                return Ok(objSaleOrderBO);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("InsertSaleOrder")]
        public ActionResult<string> InsertSaleOrder(OrderBO objSaleOrderBO)
        {
            // OrderBO objSaleOrderBO = new OrderBO();
            string strErrorMessage = string.Empty;
            try
            {
                if (!_orderBL.InsertSaleOrder(objSaleOrderBO, ref strErrorMessage))
                {
                    return null;
                }
            }
            catch (Exception objEx)
            {
                return NotFound();
            }
            return Ok(objSaleOrderBO.OrderID);
        }

        [HttpGet]
        [Route("GetPaymentInfos/{CustomerID}")]
        public ActionResult<List<PaymentInfo>> GetPaymentInfos(string CustomerID)
        {
            string strErrorMessage = null;
            try
            {
                if (CustomerID != null)
                {
                    var lstobjSO = _orderBL.GetPaymentInfos(CustomerID, ref strErrorMessage);
                    if (strErrorMessage != null)
                    {
                        return Ok(new { error = true, data = strErrorMessage });
                    }
                    return lstobjSO;
                }
                return Ok(new { error = true, data = "Chưa nhập mã khách hàng!" });
            }
            catch (Exception objEx)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetDeliveryInfos/{CustomerID}")]
        public ActionResult<List<DeliveryInfo>> GetDeliveryInfos(string CustomerID)
        {
            string strErrorMessage = null;
            try
            {
                if (CustomerID != null)
                {
                    var lstobjSO = _orderBL.GetDeliveryInfos(CustomerID, ref strErrorMessage);
                    if (strErrorMessage != null)
                    {
                        return Ok(new { error = true, data = strErrorMessage });
                    }
                    return lstobjSO;
                }
                return Ok(new { error = true, data = "Chưa nhập mã khách hàng!" });
            }
            catch (Exception objEx)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetSaleOrderList/{CustomerID}")]
        public ActionResult<List<OrderBO>> GetSaleOrderList(string CustomerID)
        {
            string strErrorMessage = null;
            try
            {
                if (CustomerID != null)
                {
                    var lstobjSO = _orderBL.GetSaleOrderList(CustomerID, ref strErrorMessage);
                    if (strErrorMessage != null)
                    {
                        return Ok(new { error = true, data = strErrorMessage });
                    }
                    return lstobjSO;
                }
                return Ok(new { error = true, data = "Chưa nhập mã khách hàng!" });
            }
            catch (Exception objEx)
            {
                return NotFound();
            }
        }
    }
}
