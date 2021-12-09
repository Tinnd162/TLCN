using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ProductModel(IProductService productService, IBasketService basketService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<CategoryModel> ProductList { get; set; } = new List<CategoryModel>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string category)
        {
            var productList = await _productService.GetProducts();
            CategoryList = productList.Select(p => p.Category).Distinct();

            if (!string.IsNullOrWhiteSpace(category))
            {
                ProductList = productList.Where(p => p.Category == category);
                SelectedCategory = category;
            }
            else
            {
                ProductList = productList;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _productService.GetProduct(productId);

            var userName = "swn";
            var basket = await _basketService.GetBasket(userName);

            var itemTemp = basket.Items.FirstOrDefault(x => x.ProductID == productId && x.Color == "Black");
            var basketTemp = basket;

            if (itemTemp != null)
            {
                foreach (var item in basketTemp.Items)
                {
                    if (item.ProductID == productId && item.Color == "Black")
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                basket.Items.Add(new BasketItemModel
                {
                    ProductID = productId,
                    ProductName = product.Name,
                    SalePrice = product.SalePrice,
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