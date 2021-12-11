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
        public SOModel Order { get; set; }
        public BasketModel Cart { get; set; } = new BasketModel();
        public DeliveryModel objDelivery { get; set; } = new DeliveryModel();
        public IEnumerable<PaymentModel> lstPayment { get; set; } = new List<PaymentModel>();
        public async Task<IActionResult> OnGetAsync(string deliveryID, string firstName, string lastName, string email, string phoneNo, string address, bool isExist)
        {
            objDelivery.DeliveryID = deliveryID;
            objDelivery.FirstNameReceiver = firstName;
            objDelivery.LastNameReceiver = lastName;
            objDelivery.Email = email;
            objDelivery.PhoneNo = phoneNo;
            objDelivery.Address = address;
            objDelivery.IsExist = isExist;

            Cart = await _basketService.GetBasket("8e96bf62-8135-4332-931a-dc5aa25aa2a8");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            Cart = await _basketService.GetBasket("8e96bf62-8135-4332-931a-dc5aa25aa2a8");

            Order.CustomerName = "Viet";
            Order.CustomerID = "8e96bf62-8135-4332-931a-dc5aa25aa2a8";
            Order.TotalAmount = Cart.TotalAmount;
            Order.OrderDetails = Cart.Items;

            string strSOId = await _orderService.InsertSaleOrder(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted", strSOId);
        }
    }
}