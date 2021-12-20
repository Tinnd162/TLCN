using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public IEnumerable<SOModel> Orders { get; set; } = new List<SOModel>();
        private string Token { get; set; }
        public async Task<IActionResult> OnGetAsync()
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
            string strCustomerId = Request.Cookies["userid"].ToString().Trim();
            Orders = await _orderService.GetSaleOrderList(strCustomerId, Token);
            return Page();
        }
    }
}