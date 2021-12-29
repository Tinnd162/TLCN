using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

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
        private string Token { get; set; }
        public async Task<IActionResult> OnGetAsync(string deliveryID, string firstName, string lastName, string email, string phoneNo, string address, bool isExist)
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
            objDelivery.DeliveryID = deliveryID;
            objDelivery.FirstNameReceiver = firstName;
            objDelivery.LastNameReceiver = lastName;
            objDelivery.Email = email;
            objDelivery.PhoneNo = phoneNo;
            objDelivery.Address = address;
            objDelivery.IsExist = isExist;

            string strUserID = null;
            string strCartList = null;
            if (Request != null && Request.Cookies["cart"] != null)
            {
                strCartList = Request.Cookies["cart"];
                if (strCartList != null && strCartList != "")
                {
                    Cart = JsonConvert.DeserializeObject<BasketModel>(strCartList);
                }
            }

            if (strUserID != null && (Cart.Items == null || Cart.Items.Count == 0))
                Cart = await _basketService.GetBasket(strUserID);
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
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
            string strUserID = null;
            string strUserName = null;
            string strCartList = null;
            if (Request != null && Request.Cookies["userid"] != null)
            {
                strUserID = Request.Cookies["userid"];
                strUserName = Request.Cookies["username"];
            }
            if (Request != null && Request.Cookies["cart"] != null)
            {
                strCartList = Request.Cookies["cart"];
                if (strCartList != null && strCartList != "")
                {
                    Cart = JsonConvert.DeserializeObject<BasketModel>(strCartList);
                }
            }

            if (strUserID != null && (Cart.Items == null || Cart.Items.Count == 0))
                Cart = await _basketService.GetBasket(strUserID);

            Order.CustomerName = strUserName;
            Order.CustomerID = strUserID;
            Order.TotalAmount = Cart.TotalAmount;
            Order.OrderDetails = Cart.Items;
            Order.Token = Token;
            string strSOId = await _aggregatorService.InsertSaleOrder(Order);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(-1));
            HttpContext.Response.Cookies.Append("cart", "", cookieOptions);
            return RedirectToPage("Confirmation", "OrderSubmitted", strSOId);
        }
    }
}