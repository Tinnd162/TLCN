using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private string Token { get; set; }
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
                var brand = ProductModel.BrandDTO.Id.Split("-");
                ProductModel.BrandDTO.Id = brand[0].Trim();
                ProductModel.BrandDTO.Name = brand[1].Trim();
                var category = ProductModel.CategoryDTO.Id.Split("-");
                ProductModel.CategoryDTO.Id = category[0].Trim();
                ProductModel.CategoryDTO.Name = category[1].Trim();

                var result = await _inventoryService.AddProduct(ProductModel, Token);

                return RedirectToPage("/Product");
            }
            return Page();
        }
    }
}
