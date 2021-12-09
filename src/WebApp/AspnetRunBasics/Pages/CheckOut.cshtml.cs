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
            var userName = "d7f522e1-a49e-4e98-a834-4b0b7aadd82a";
            Cart = await _basketService.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "d7f522e1-a49e-4e98-a834-4b0b7aadd82a";
            Cart = await _basketService.GetBasket(userName);

            Order.CustomerName = "Viet";
            Order.CustomerID = "d7f522e1-a49e-4e98-a834-4b0b7aadd82a";
            Order.TotalAmount = Cart.TotalAmount;
            Order.OrderDetails = Cart.Items;

            await _orderService.InsertSaleOrder(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}