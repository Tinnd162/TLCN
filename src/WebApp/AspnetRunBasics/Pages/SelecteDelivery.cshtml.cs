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
        private string Token { get; set; }

        public async Task<IActionResult> OnGetAsync(string customerId)
        {
            if (Request != null)
            {
                Token = Request.Cookies["token"];
                if (Token == null)
                    return RedirectToPage("Login");
            }
            else
            {
                return RedirectToPage("Login");
            }
            customerId = Request.Cookies["userid"].ToString().Trim();
            DeliveryModels = await _orderService.GetDeliveryInfos(customerId, Token);
            foreach (var item in DeliveryModels)
            {
                item.IsExist = true;
            }
            return Page();
        }
    }
}
