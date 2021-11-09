using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<OrderBO> GetOrderByID(string OrderID)
        {
            return Ok(_orderBL.GetOrderByID("lhv", OrderID));
        }
    }
}
