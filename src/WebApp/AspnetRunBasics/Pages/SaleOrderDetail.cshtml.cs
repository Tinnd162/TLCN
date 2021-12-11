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
        public async Task<IActionResult> OnGetAsync(string customerId, string orderId)
        {
            SOModel = await _orderService.GetSO(customerId, orderId);
            return Page();
        }
    }
}
