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
    public class SaleOrderDetailModel : PageModel
    {
        private readonly IOrderService _orderService;
        public SaleOrderDetailModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public SOModel SOModel { get; set; } = new SOModel();
        private string Token { get; set; }
        public async Task<IActionResult> OnGetAsync(string customerId, string orderId)
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
            SOModel = await _orderService.GetSO(customerId, orderId, Token);
            return Page();
        }
    }
}
