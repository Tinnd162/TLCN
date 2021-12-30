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
    public class EditProductModel : PageModel
    {
        private readonly IInventoryService _inventoryService;

        public EditProductModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        private string Token { get; set; }
        public ProductDetailModel Product { get; set; }
        [BindProperty]
        public UpdateProductModel UpdateProductModel { get; set; } = new UpdateProductModel();

        public async Task<IActionResult> OnGet(string ProductID)
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
            var objProduct = await _inventoryService.GetProductDetailById(ProductID.Trim(), Token);
            Product = objProduct;
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
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

            try
            {
                var objProduct = await _inventoryService.GetProductDetailById(UpdateProductModel.Id.Trim(), Token);
                UpdateProductModel.Id = objProduct.Id;
                UpdateProductModel.LinkImage = objProduct.LinkImage;
                UpdateProductModel.IsDiscontinued = false;
                UpdateProductModel.IsStatus = false;
                UpdateProductModel.BrandDTO.Name = objProduct.Brand;
                UpdateProductModel.CategoryDTO.Name = objProduct.Category;
                if (UpdateProductModel.Description == null || UpdateProductModel.Description == "")
                    UpdateProductModel.Description = objProduct.Description;
                bool result = await _inventoryService.UpdateProduct(UpdateProductModel, Token);
                if (result)
                {
                    return RedirectToPage("/Product");
                }
                ViewData["Error"] = "Lỗi cập nhật dữ liệu sản phẩm";
            }
            catch (Exception objEx)
            {
                ViewData["Error"] = "Lỗi cập nhật dữ liệu sản phẩm";
            }
            return Page();
        }
    }
}
