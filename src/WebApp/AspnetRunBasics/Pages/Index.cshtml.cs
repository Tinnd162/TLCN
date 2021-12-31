using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public IndexModel(IProductService productService, IBasketService basketService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<CategoryModel> ProductList { get; set; } = new List<CategoryModel>();
        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productService.GetProducts();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _productService.GetProduct(productId);
            string strUserID = null;
            BasketModel basket = null;
            string strCartList = null;
            bool bolIsLogin = false;

            if (Request != null && Request.Cookies["userid"] != null)
            {
                strUserID = Request.Cookies["userid"];
                if(strUserID != null && strUserID != "") bolIsLogin = true;
            }

            if (Request != null && Request.Cookies["cart"] != null)
            {
                strCartList = Request.Cookies["cart"];
                if (strCartList != null && strCartList != "")
                {
                    basket = JsonConvert.DeserializeObject<BasketModel>(strCartList);
                    if (bolIsLogin)
                        basket.Username = strUserID.Trim();
                }
            }

            if (strUserID != null && basket != null)
            {               
                basket = await _basketService.GetBasket(strUserID);
                if (basket.Username == null)
                    basket.Username = strUserID.Trim();
            }

            if(basket == null)
            {
                basket = new BasketModel();
            }

            var itemTemp = basket.Items.FirstOrDefault(x => x.ProductID == productId && x.Color == "Đen");
            var basketTemp = basket;

            if (itemTemp != null)
            {
                foreach (var item in basketTemp.Items)
                {
                    if (item.ProductID == productId && item.Color == "Đen")
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                basket.Items.Add(new SODetailModel
                {
                    ProductID = productId,
                    ProductName = product.Name,
                    SalePrice = product.SalePrice,
                    Quantity = 1,
                    Color = "Đen",
                    ImageFile = product.ImageFile
                });
            }

            //login hay ko login đều lưu cart vào cookie
            if(bolIsLogin)
            {
                basketTemp.Username = strUserID.Trim();
                await _basketService.UpdateBasket(basketTemp);
            }

            string strbasket = JsonConvert.SerializeObject(basket);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(1));
            HttpContext.Response.Cookies.Append("cart", strbasket, cookieOptions);

            return RedirectToPage("Cart");
        }
    }
}
