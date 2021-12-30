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
    public class Product_DetailModel : PageModel
    {

        private readonly IInventoryService _inventoryService;

        public Product_DetailModel(IInventoryService inventoryService)
        {
            IsSearch = false;
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        private string Token { get; set; }
        public ProductDetailModel Product { get; set; }
        public bool IsSearch { get; set; }

        public async Task<ActionResult> OnGet(string ProductID)
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
            if (ProductID == null || ProductID == "")
            {
                ViewData["Error"] = "Lỗi lấy mã sản phẩm";
                return Page();
            }
            var objProduct = await _inventoryService.GetProductDetailById(ProductID.Trim(), Token);
            Product = objProduct;
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(string ProductID)
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
            if (ProductID == null || ProductID == "")
            {
                ViewData["Error"] = "Lỗi lấy mã sản phẩm";
                return Page();
            }
            bool bolResult = await _inventoryService.RemoveProduct(ProductID, Token);
            if (bolResult)
                return RedirectToPage("Product");
            ViewData["Error"] = "Lỗi xóa sản phẩm, thử lại";
            return Page();
        }
    }
}
