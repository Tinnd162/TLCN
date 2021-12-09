using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public CheckOutModel(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [BindProperty]
        public OrderResponseModel Order { get; set; }
        public BasketModel Cart { get; set; } = new BasketModel();
        public IEnumerable<DeliveryModel> lstDelivery { get; set; } = new List<DeliveryModel>();
        public IEnumerable<PaymentModel> lstPayment { get; set; } = new List<PaymentModel>();
        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Cart = await _basketService.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "swn";
            Cart = await _basketService.GetBasket(userName);
            // if (ModelState.IsValid)
            // {
            //     return Page();
            // }

            Order.CustomerName = userName;
            Order.CustomerID = "6a4b041e-36e0-42c3-b496-2c4086310086";
            Order.TotalAmount = Cart.TotalAmount;
            Order.OrderDetails = Cart.Items;

            await _orderService.InsertSaleOrder(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}