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
                if(objSaleOrderBO == null)
                {
                    return Ok(new { error = true, content = strErrorMessage });
                }
                return Ok(new { error = false, data = objSaleOrderBO});
            }
            catch
            {
                return NotFound();
            }    
        }

        [HttpPost]
        [Route("InsertSaleOrder")]
        public ActionResult<string> InsertSaleOrder([FromBody] object objRequest)
        {
            OrderBO objSaleOrderBO = null;
            string strErrorMessage = string.Empty;
            try
            {
                var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());
                foreach (var objParam in objRequestParams)
                {
                    switch (objParam.Key.ToString().Trim().ToUpper())
                    {
                        case "SALEORDER":
                            objSaleOrderBO = JsonConvert.DeserializeObject<OrderBO>(objParam.Value.ToString());
                            break;
                        default:
                            break;
                    }
                }
                if (!_orderBL.InsertSaleOrder(objSaleOrderBO, ref strErrorMessage))
                {
                    return Ok(new { error = true, content = strErrorMessage });
                }
            }
            catch(Exception objEx)
            {
                return NotFound();
            }
            return Ok(new { error = false, data = objSaleOrderBO.OrderID});
        }
    }
}
