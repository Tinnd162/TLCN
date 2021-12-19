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
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ProductDetailModel(IProductService productService, IBasketService basketService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public CategoryModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _productService.GetProduct(productId);
            if (Product == null)
            {
                return NotFound();
            }
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
                if (strUserID != null && strUserID != "") bolIsLogin = true;
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

            if (basket == null)
            {
                basket = new BasketModel();
            }


            var itemTemp = basket.Items.FirstOrDefault(x => x.ProductID == productId && x.Color == Color);
            var basketTemp = basket;

            if (itemTemp != null)
            {
                foreach (var item in basketTemp.Items)
                {
                    if (item.ProductID == productId && item.Color == Color)
                    {
                        item.Quantity += Quantity;
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
                    Quantity = Quantity,
                    Color = Color,
                    ImageFile = product.ImageFile
                });
            }

            if (bolIsLogin)
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