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
    public class AddProductModel : PageModel
    {

        private readonly IInventoryService _inventoryService;

        public AddProductModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        [BindProperty]
        public Models.AddProductModel ProductModel { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public CategoryModel CateSelected { get; set; }

        private string Token { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (Request != null)
            {
                Token = Request.Cookies["token"];
                if (Token == null)
                    return RedirectToPage("Login");
                Categories = await _inventoryService.GetCategories(Token);
                CateSelected = Categories.Where(x => x.Name == "Điện thoại").FirstOrDefault();
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }

        public async Task<IActionResult> OnPostAddProduct()
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
            if (ProductModel != null)
            {
                ProductModel.BrandDTO.Name = ProductModel.BrandDTO.Id;
                ProductModel.CategoryDTO.Name = ProductModel.CategoryDTO.Id;
                ProductModel.UserUpdate = Request.Cookies["username"];
                var result = await _inventoryService.AddProduct(ProductModel, Token);

                return RedirectToPage("/Product");
            }
            return Page();
        }
    }
}
