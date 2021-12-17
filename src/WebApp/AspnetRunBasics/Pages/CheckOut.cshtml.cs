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
        private readonly IAggregatorService _aggregatorService;

        public CheckOutModel(IBasketService basketService, IAggregatorService aggregatorService)
        {
            _aggregatorService = aggregatorService ?? throw new ArgumentNullException(nameof(aggregatorService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
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

            Cart = await _basketService.GetBasket("61b6f8d80a134a9697bba97c");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            Cart = await _basketService.GetBasket("61b6f8d80a134a9697bba97c");

            Order.CustomerName = "Viet";
            Order.CustomerID = "61b6f8d80a134a9697bba97c";
            Order.TotalAmount = Cart.TotalAmount;
            Order.OrderDetails = Cart.Items;

            string strSOId = await _aggregatorService.InsertSaleOrder(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted", strSOId);
        }
    }
}