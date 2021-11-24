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
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public IOrderBL _orderBL;
        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [Route("GetOrderByID")]
        [HttpGet]
        public ActionResult<OrderBO> GetOrderByID(string strCustomerID, string strSaleOrderID)
        {
            try
            {
                return Ok(_orderBL.GetOrderByID(strCustomerID, strSaleOrderID));
            }
            catch
            {
                return NotFound();
            }    
        }

        //[Route("InsertSaleOrder")]
        //[HttpPost]
        //public ActionResult<string> InsertSaleOrder([FromBody] object objRequest)
        //{
        //    try
        //    {
        //        var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());

        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
