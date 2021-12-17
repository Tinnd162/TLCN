using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            Cart = await _basketService.GetBasket("8e96bf62-8135-4332-931a-dc5aa25aa2a8");
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId, string color)
        {
            var basket = await _basketService.GetBasket("8e96bf62-8135-4332-931a-dc5aa25aa2a8");

            var SODetail = basket.Items.Single(x => x.ProductID == productId && x.Color == color);
            basket.Items.Remove(SODetail);

            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}