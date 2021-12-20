using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminWebApp.Models;
using AdminWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminWebApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public ProductModel(IInventoryService inventoryService)
        {
            IsSearch = false;
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        private string Token { get; set; }
        public ProductDetailModel Product { get; set; }
        public bool IsSearch { get; set; }

        public IActionResult OnGet()
        {
            if (Request != null)
            {
                Token = Request.Cookies["token"];
                if (Token == null)
                    return RedirectToPage("Login");
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }

        public async Task<IActionResult> OnPostSearch(string ProductID)
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
            IsSearch = true;
            if(ProductID == null || ProductID == "")
            {
                ViewData["Error"] = "Vui lòng nhập mã sản phẩm";
                return Page();
            }
           var objProduct = await _inventoryService.GetProductDetailById(ProductID.Trim(), Token);
            Product = objProduct;
            return Page();
        }
    }
}
