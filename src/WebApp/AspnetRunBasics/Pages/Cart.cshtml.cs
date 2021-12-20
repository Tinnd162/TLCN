using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            string strUserID = null;
            string strCartList = null;
            if (Request != null)
            {
                strUserID = Request.Cookies["userid"];
            }

            if (Request != null && Request.Cookies["cart"] != null)
            {
                strCartList = Request.Cookies["cart"];
                if (strCartList != null && strCartList != "")
                {
                    Cart = JsonConvert.DeserializeObject<BasketModel>(strCartList);
                }
            }

            if(strUserID !=null && (Cart.Items == null || Cart.Items.Count == 0))
                Cart = await _basketService.GetBasket(strUserID);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId, string color)
        {
            string strUserID = null;
            string strCartList = null;
            if (Request != null && Request.Cookies["userid"] != null)
            {
                strUserID = Request.Cookies["userid"];
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


            var SODetail = Cart.Items.Single(x => x.ProductID == productId && x.Color == color);
            Cart.Items.Remove(SODetail);

            if(strUserID != null)
                await _basketService.UpdateBasket(Cart);
            string strbasket = JsonConvert.SerializeObject(Cart);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(1));
            HttpContext.Response.Cookies.Append("cart", strbasket, cookieOptions);

            return RedirectToPage();
        }
    }
}