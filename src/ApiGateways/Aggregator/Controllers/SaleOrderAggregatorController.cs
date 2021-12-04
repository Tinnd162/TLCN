using Aggregator.Models;
using Aggregator.Services;
using Microsoft.AspNetCore.Mvc;
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
        public SaleOrderAggregatorController(IBasketService objIBasketService)
        {
            this.objIBasketService = objIBasketService;
        }

        [HttpPost]
        [Route("InsertSO/{UserName}")]
        public async Task<ActionResult> InsertSO(string UserName)
        {
            try
            {
                var objBasket = await objIBasketService.GetBasket(UserName);
                List<InventoryModel> lstObjProductInventory = null;
                decimal intTotalMoney = 0;
               if(objBasket != null && objBasket.Items != null && objBasket.Items.Count > 0)
                {
                    foreach (var item in objBasket.Items)
                    {
                        lstObjProductInventory = await objIInventoryService.GetProductDetailById(item.ProductID) as List<InventoryModel>;
                        if (item.ProductName.Trim() != lstObjProductInventory[0].Name && item.Price != lstObjProductInventory[0].UnitPrice)
                        {
                            return Ok(new { error = true, data="Lỗi kiểm tra dữ liệu đầu vào!"});
                        }
                        intTotalMoney += lstObjProductInventory[0].UnitPrice;
                    }
                    if(intTotalMoney != objBasket.TotalPrrice)
                    {
                        return Ok(new { error = true, data = "Lỗi kiểm tra tổng tiền!" });
                    }
                }
               //Gọi service Insert Order
                return Ok(new { error = false, data = objBasket });
            }
            catch{
                return NotFound();
            }
        }
    }
}
