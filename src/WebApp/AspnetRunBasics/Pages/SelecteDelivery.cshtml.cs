using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics.Pages
{
    public class SelecteDeliveryModel : PageModel
    {
        private readonly IOrderService _orderService;
        public SelecteDeliveryModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IEnumerable<DeliveryModel> DeliveryModels { get; set; } = new List<DeliveryModel>();
        public async Task<IActionResult> OnGetAsync(string customerId)
        {
            customerId = "61b6f8d80a134a9697bba97c";
            DeliveryModels = await _orderService.GetDeliveryInfos(customerId);
            foreach (var item in DeliveryModels)
            {
                item.IsExist = true;
            }
            return Page();
        }
    }
}
