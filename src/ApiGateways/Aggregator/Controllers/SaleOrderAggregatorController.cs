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
            OrderModel objSaleOrderBO = new OrderModel();
            try
            {
                var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());

                foreach (var objParam in objRequestParams)
                {
                    switch (objParam.Key.ToString().Trim().ToUpper())
                    {
                        case "CUSTOMERID":
                            objSaleOrderBO.CustomerID = objParam.Value.ToString();
                            break;
                        case "CUSTOMERNAME":
                            objSaleOrderBO.CustomerName = objParam.Value.ToString();
                            break;
                        case "TOTALAMOUNT":
                            objSaleOrderBO.TotalAmount = Convert.ToDouble(objParam.Value.ToString());
                            break;
                        case "DELIVERYINFO":
                            objSaleOrderBO.DeliveryInfo = JsonConvert.DeserializeObject<DeliveryModel>(objParam.Value.ToString());
                            break;
                        case "PAYMENTINFO":
                            objSaleOrderBO.PaymentInfo = JsonConvert.DeserializeObject<PaymentModel>(objParam.Value.ToString());
                            break;
                        case "ORDERDETAILS":
                            objSaleOrderBO.OrderDetails = JsonConvert.DeserializeObject<List<OrderDetailModel>>(objParam.Value.ToString());
                            break;
                        default:
                            break;
                    }
                }
                InventoryModel objProductInventory = new InventoryModel();
                List<ParamsUpdateModel> lstObjParams = new List<ParamsUpdateModel>();
                foreach (var item in objSaleOrderBO.OrderDetails)
                {
                    ParamsUpdateModel objParams = new ParamsUpdateModel
                    {
                        ProductId = item.ProductID,
                        NumberOfSale = item.Quantity
                    };
                    lstObjParams.Add(objParams);
                }
                decimal intTotalMoney = 0;
                if (objSaleOrderBO != null && objSaleOrderBO.OrderDetails != null && objSaleOrderBO.OrderDetails.Count > 0)
                {
                    foreach (var item in objSaleOrderBO.OrderDetails)
                    {
                        objProductInventory = await objIInventoryService.GetProductDetailById(item.ProductID);
                        if (item.ProductName.Trim() != objProductInventory.Name/* && Convert.ToDecimal(item.SalePrice) != objProductInventory.Price*/)
                        {
                            return Ok(new { error = true, data = "Lỗi kiểm tra dữ liệu đầu vào!" });
                        }
                        intTotalMoney += objProductInventory.SalePrice * item.Quantity;
                    }
                    if (intTotalMoney != Convert.ToDecimal(objSaleOrderBO.TotalAmount))
                    {
                        return Ok(new { error = true, data = "Lỗi kiểm tra tổng tiền!" });
                    }
                }
                string strSaleOrderId = await objIOrderService.InsertSaleOrder(objSaleOrderBO);

                if (string.IsNullOrEmpty(strSaleOrderId))
                    return Ok(new { error = true, data = "Lỗi thêm thông tin đơn hàng" });

                await objIBasketService.DeleteBasket(objSaleOrderBO.CustomerID);
                await objIInventoryService.UpdateNumberOfSaleAfterSO(lstObjParams);

                return Ok(new { error = false, data = strSaleOrderId });
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
