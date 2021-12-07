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

            var userName = "swn";
            var basket = await _basketService.GetBasket(userName);

            var itemTemp = basket.Items.FirstOrDefault(x => x.ProductId == productId && x.Color == "Black");
            var basketTemp = basket;

            if (itemTemp != null)
            {
                foreach (var item in basketTemp.Items)
                {
                    if (item.ProductId == productId && item.Color == "Black")
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                basket.Items.Add(new BasketItemModel
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    Color = "Black",
                    ImageFile = product.ImageFile
                });
            }
            var basketUpdated = await _basketService.UpdateBasket(basketTemp);

            return RedirectToPage("Cart");
        }
    }
}
