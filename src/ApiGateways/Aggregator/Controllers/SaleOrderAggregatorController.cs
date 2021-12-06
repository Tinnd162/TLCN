using Aggregator.Models;
using Aggregator.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/SaleOrder")]
    public class SaleOrderAggregatorController : ControllerBase
    {
        private readonly IBasketService objIBasketService;
        private readonly IInventoryService objIInventoryService;
        private readonly IOrderService objIOrderService;
        public SaleOrderAggregatorController(IBasketService objIBasketService, IInventoryService objIInventoryService, IOrderService objIOrderService)
        {
            this.objIBasketService = objIBasketService;
            this.objIInventoryService = objIInventoryService;
            this.objIOrderService = objIOrderService;
        }

        [HttpPost]
        [Route("InsertSO")]
        public async Task<ActionResult> InsertSO([FromBody] object objRequest)
        {
            OrderModel objSaleOrderBO = null;
            try
            {
                var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());
                foreach (var objParam in objRequestParams)
                {
                    switch (objParam.Key.ToString().Trim().ToUpper())
                    {
                        case "SALEORDER":
                            objSaleOrderBO = JsonConvert.DeserializeObject<OrderModel>(objParam.Value.ToString());
                            break;
                        default:
                            break;
                    }
                }
                List<InventoryModel> lstObjProductInventory = null;
                decimal intTotalMoney = 0;
               if(objSaleOrderBO != null && objSaleOrderBO.OrderDetails != null && objSaleOrderBO.OrderDetails.Count > 0)
                {
                    foreach (var item in objSaleOrderBO.OrderDetails)
                    {
                        lstObjProductInventory = await objIInventoryService.GetProductDetailById(item.ProductID) as List<InventoryModel>;
                        if (item.ProductName.Trim() != lstObjProductInventory[0].Name && Convert.ToDecimal(item.SalePrice) != lstObjProductInventory[0].UnitPrice)
                        {
                            return Ok(new { error = true, data="Lỗi kiểm tra dữ liệu đầu vào!"});
                        }
                        intTotalMoney += lstObjProductInventory[0].UnitPrice;
                    }
                    if(intTotalMoney != Convert.ToDecimal(objSaleOrderBO.TotalAmount))
                    {
                        return Ok(new { error = true, data = "Lỗi kiểm tra tổng tiền!" });
                    }
                }
                string strSaleOrderID =  await objIOrderService.InsertSaleOrder(objRequest);
                if(strSaleOrderID != null)
                {
                    await objIBasketService.DeleteBasket(objSaleOrderBO.CustomerID);
                }
                return Ok(new { error = false, data = strSaleOrderID });
            }
            catch{
                return NotFound();
            }
        }
    }
}
