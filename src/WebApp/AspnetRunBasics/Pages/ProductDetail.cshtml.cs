using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

            var userName = "8e96bf62-8135-4332-931a-dc5aa25aa2a8";
            var basket = await _basketService.GetBasket(userName);

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
            var basketUpdated = await _basketService.UpdateBasket(basketTemp);

            return RedirectToPage("Cart");
        }
    }
}