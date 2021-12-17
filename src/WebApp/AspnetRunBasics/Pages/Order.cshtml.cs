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

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderService.GetSaleOrderList("8e96bf62-8135-4332-931a-dc5aa25aa2a8");
            return Page();
        }
    }
}