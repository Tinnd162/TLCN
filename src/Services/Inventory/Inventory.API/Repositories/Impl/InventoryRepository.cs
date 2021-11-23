using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.API.Data;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Repositories.Impl
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InventoryRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        #region Lấy thông tin sản phẩm, nhãn hàng, nhà cung cấp
        public async Task<BrandWithCategoryDTO> GetBrandsWithByCategory(string strCategoryId)
        {
            BrandWithCategoryDTO objBrandWithCategory = await _context.Categories.Where(x => x.Id == strCategoryId)
                                                                .Select(s1 => new BrandWithCategoryDTO
                                                                {
                                                                    Id = s1.Id,
                                                                    Name = s1.CategoryName,
                                                                    lstBrandDTO = s1.Brands.Select(s2 => new InfoDTO
                                                                    {
                                                                        Id = s2.Id,
                                                                        Name = s2.BrandName
                                                                    }).ToList()
                                                                }).FirstOrDefaultAsync();
            return objBrandWithCategory;
        }
        public async Task<IEnumerable<InfoDTO>> GetCategories()
        {
            List<InfoDTO> lstCategoryDTO = await _context.Categories
                                                            .Select(s => new InfoDTO
                                                            {
                                                                Id = s.Id,
                                                                Name = s.CategoryName
                                                            }).ToListAsync();

            return lstCategoryDTO;
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsByBrand(string strBrandId)
        {
            List<ProductDTO> lstProduct = await _context.Products
                                                        .Where(x => x.BrandId == strBrandId && x.IsDelete == false
                                                                && x.IsDiscontinued == false)
                                                        .Select(s => new ProductDTO
                                                        {
                                                            Id = s.Id,
                                                            Name = s.ProductName,
                                                            Price = s.PriceLogs
                                                            .OrderByDescending(x => x.UpdateDate)
                                                            .Select(x => x.Price)
                                                            .FirstOrDefault()
                                                        })
                                                        .ToListAsync();
            return lstProduct;
        }
        public async Task<ProductDetailDTO> GetProductDetailById(string strProductId)
        {
            ProductDetailDTO objProductDetailDTO = await _context.Products
                                                    .Where(x => x.Id == strProductId && x.IsDelete == false
                                                            && x.IsDiscontinued == false)
                                                    .Select(s1 => new ProductDetailDTO
                                                    {
                                                        Id = s1.Id,
                                                        Name = s1.ProductName,
                                                        Description = s1.Description,
                                                        LinkImage = s1.LinkImage,
                                                        UnitPrice = s1.UnitPrice,
                                                        Quantity = s1.Quantity,
                                                        UpdateDate = s1.UpdateDate,
                                                        DeleteDate = s1.DeleteDate,
                                                        IsUpdate = s1.IsUpdate,
                                                        IsStatus = s1.IsStatus,
                                                        IsDiscontinued = s1.IsDiscontinued,
                                                        IsDelete = s1.IsDelete,
                                                        lstColorDTO = s1.ProductColors.Select(s2 => new InfoDTO
                                                        {
                                                            Id = s2.Color.Id,
                                                            Name = s2.Color.ColorName
                                                        }).ToList()
                                                    }).FirstOrDefaultAsync();

            return objProductDetailDTO;
        }
        public async Task<IEnumerable<InfoDTO>> GetSuppliers()
        {
            List<InfoDTO> lstCategoryDTO = await _context.Suppliers
                                                            .Select(s => new InfoDTO
                                                            {
                                                                Id = s.Id,
                                                                Name = s.SupplierName
                                                            }).ToListAsync();

            return lstCategoryDTO;
        }
        #endregion


        #region CRUD sản phẩm.
        public async Task<bool> RemoveProduct(string strProductId)
        {
            Product objProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == strProductId);
            if (objProduct != null)
            {
                objProduct.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> AddDetailProduct(List<Dictionary<string, object>> dicAddProduct)
        {
            
            // objAddProductDTO.BrandDTO.Id = Convert.ToString(Guid.NewGuid());
            // objAddProductDTO.CategoryDTO.Id = Convert.ToString(Guid.NewGuid());
            // objAddProductDTO.Id = Convert.ToString(Guid.NewGuid());

            // Product objProduct = new Product()
            // {
            //     Id = Convert.ToString(Guid.NewGuid()),
            //     ProductName = objAddProductDTO.Name,
            //     Description = objAddProductDTO.Description,
            //     UnitPrice = objAddProductDTO.UnitPrice,
            //     Quantity = objAddProductDTO.Quantity,
            //     CreateDate = DateTime.Now,
            //     UpdateDate = DateTime.Now,
            //     DeleteDate = DateTime.Now,
            //     IsUpdate = false,
            //     IsStatus = false,
            //     IsDiscontinued = false,
            //     IsDelete = false,
            //     Brand = new Brand
            //     {
            //         Id = objAddProductDTO.BrandDTO.Id,
            //         BrandName = objAddProductDTO.BrandDTO.Name,
            //         CategoryId = objAddProductDTO.CategoryDTO.Id
            //     },
            //     Category = new Category
            //     {
            //         Id = objAddProductDTO.CategoryDTO.Id,
            //         CategoryName = objAddProductDTO.CategoryDTO.Name
            //     },
            // };

            // objProduct.PriceLogs = new List<PriceLog>{
            //     new PriceLog {

            //     }
            // }

            // await _context.Products.AddAsync(objProduct);
            // await _context.SaveChangesAsync();
            return true;
        }
        public Task<bool> AddConfigurationProduct(ConfigurationProductDTO objConfigurationProductDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProduct(ParamsUpdateProduct objParamsUpdateProduct)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateConfigurationProduct()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Kiểm tra tồn kho.
        public Task<bool> CheckEnoughQuantity(string strProductId)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}