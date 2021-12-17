using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common;
using Inventory.API.Data;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Inventory.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Inventory.API.Repositories.Impl
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        public InventoryRepository(DataContext context, IMapper mapper, IOptions<CloudinarySettings> config)
        {
            _mapper = mapper;
            _context = context;
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        #region Lấy thông tin sản phẩm, nhãn hàng, nhà cung cấp
        public async Task<BrandWithCategoryDTO> GetBrandsWithByCategory(string strCategoryId)
        {
            try
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
            catch (Exception objExcep)
            {
                return null;
            }
        }
        public async Task<IEnumerable<InfoDTO>> GetCategories()
        {
            try
            {
                List<InfoDTO> lstCategoryDTO = await _context.Categories
                                                            .Select(s => new InfoDTO
                                                            {
                                                                Id = s.Id,
                                                                Name = s.CategoryName
                                                            }).ToListAsync();
                return lstCategoryDTO;
            }
            catch (Exception objExcep)
            {
                return null;
            }
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsByBrand(string strBrandId)
        {
            try
            {
                List<ProductDTO> lstProduct = await _context.Products
                                                      .Where(x => x.BrandId == strBrandId && x.IsDelete == false
                                                              && x.IsDiscontinued == false && x.IsStatus == false)
                                                      .Select(s => new ProductDTO
                                                      {
                                                          Id = s.Id,
                                                          Name = s.ProductName,
                                                          SalePrice = s.PriceLogs
                                                          .OrderByDescending(x => x.UpdateDate)
                                                          .Select(x => x.SalePrice)
                                                          .FirstOrDefault()
                                                      })
                                                      .ToListAsync();
                return lstProduct;
            }
            catch (Exception objExcep)
            {
                return null;
            }
        }
        public async Task<ProductDetailDTO> GetProductDetailById(string strProductId)
        {
            try
            {
                ProductDetailDTO objProductDetailDTO = await _context.Products
                                                                  .Where(x => x.Id == strProductId && x.IsDelete == false
                                                                          && x.IsDiscontinued == false && x.IsStatus == false)
                                                                  .Include(x => x.PriceLogs)
                                                                  .Select(s1 => new ProductDetailDTO
                                                                  {
                                                                      Id = s1.Id,
                                                                      Name = s1.ProductName,
                                                                      Description = s1.Description,
                                                                      LinkImage = s1.LinkImage,
                                                                      Quantity = s1.Quantity,
                                                                      SalePrice = s1.PriceLogs.OrderByDescending(x => x.UpdateDate).Select(x => x.SalePrice).FirstOrDefault()
                                                                  }).FirstOrDefaultAsync();
                return objProductDetailDTO;
            }
            catch (Exception objExcep)
            {
                return null;
            }

        }
        public async Task<IEnumerable<InfoDTO>> GetSuppliers()
        {
            try
            {
                List<InfoDTO> lstCategoryDTO = await _context.Suppliers
                                                          .Select(s => new InfoDTO
                                                          {
                                                              Id = s.Id,
                                                              Name = s.SupplierName
                                                          }).ToListAsync();
                return lstCategoryDTO;

            }
            catch (Exception objExcep)
            {
                return null;
            }
        }
        #endregion


        #region CRUD sản phẩm.
        public async Task<bool> RemoveProduct(string strProductId)
        {
            try
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
            catch (Exception objExcep)
            {
                return false;
            }

        }

        public async Task<bool> AddDetailProduct(AddProductDTO objAddProductDTO)
        {
            try
            {
                //objAddProductDTO.BrandDTO.Id = ObjectId.GenerateNewId().ToString();
                //objAddProductDTO.CategoryDTO.Id = ObjectId.GenerateNewId().ToString();
                var objBrand = _context.Brands.First(x => x.BrandName.ToUpper() == objAddProductDTO.BrandDTO.Name.ToUpper());
                var objCategory = _context.Categories.First(x => x.CategoryName.ToUpper() == objAddProductDTO.CategoryDTO.Name.ToUpper());
                Product objProduct = new Product()
                {
                    Id = objAddProductDTO.Id,
                    ProductName = objAddProductDTO.Name,
                    Description = objAddProductDTO.Description,
                    UnitPrice = objAddProductDTO.UnitPrice,
                    Quantity = objAddProductDTO.Quantity,
                    LinkImage = objAddProductDTO.LinkImage,
                    CreateDate = DateTime.Now,
                    IsUpdate = false,
                    IsStatus = false,
                    IsDiscontinued = false,
                    IsDelete = false,
                    BrandId = objBrand.Id,
                    CategoryId = objCategory.Id,
                    PriceLogs = new Collection<PriceLog>(){
                        new PriceLog(){
                            Id=ObjectId.GenerateNewId().ToString(),
                            SalePrice=objAddProductDTO.PriceLogDTO.SalePrice,
                            ProductId=objAddProductDTO.Id,
                            IsUpdate=false,
                            CreateDate=DateTime.Now,
                            UserUpdate=objAddProductDTO.UserUpdate,
                            UpdateDate = DateTime.Now
                        }
                    },
                };
                await _context.Products.AddAsync(objProduct);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception objExcep)
            {
                return false;
            }

        }
        public async Task<bool> UpdateDetailProduct(UpdateProductDTO objUpdateProductDTO)
        {
            try
            {
                var objBrand = _context.Brands.First(x => x.BrandName.ToUpper() == objUpdateProductDTO.BrandDTO.Name.ToUpper());
                var objCategory = _context.Categories.First(x => x.CategoryName.ToUpper() == objUpdateProductDTO.CategoryDTO.Name.ToUpper());
                Product objProduct = _context.Products.FirstOrDefault(x => x.Id == objUpdateProductDTO.Id);
                if (objProduct != null)
                {
                    objProduct.Id = objUpdateProductDTO.Id;
                    objProduct.ProductName = objUpdateProductDTO.Name;
                    objProduct.Description = objUpdateProductDTO.Description;
                    objProduct.LinkImage = objUpdateProductDTO.LinkImage;
                    objProduct.Quantity = objUpdateProductDTO.Quantity;
                    objProduct.IsDiscontinued = objUpdateProductDTO.IsDiscontinued;
                    objProduct.IsStatus = objUpdateProductDTO.IsStatus;
                    objProduct.UpdateDate = DateTime.Now;
                    objProduct.IsUpdate = true;
                    objProduct.IsDelete = false;
                    objProduct.BrandId = objBrand.Id;
                    objProduct.CategoryId = objCategory.Id;
                    objProduct.PriceLogs = new Collection<PriceLog>()
                {
                    new PriceLog()
                    {
                        Id=ObjectId.GenerateNewId().ToString(),
                        SalePrice=objUpdateProductDTO.PriceLogDTO.SalePrice,
                        IsUpdate=true,
                        UpdateDate=DateTime.Now,
                        UserUpdate=objUpdateProductDTO.UserUpdate
                    }
                };
                    _context.Update<Product>(objProduct);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception objExcep)
            {
                return false;
            }

        }
        public async Task<bool> UpdateNumberOfSaleAfterSO(List<UpdateParamsNumberOfSale> lstObjParams)
        {
            try
            {
                foreach (var item in lstObjParams)
                {
                    Product objProduct = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                    if (objProduct == null)
                        return false;

                    objProduct.NumberOfSale = item.NumberOfSale;
                    objProduct.PurchaseDate = DateTime.Now;
                    _context.Update<Product>(objProduct);

                    if (!(await _context.SaveChangesAsync() > 0))
                        return false;
                }
                return true;
            }
            catch (Exception objExcep)
            {
                return false;
            }

        }
        #endregion

        #region Image
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            try
            {
                if (file.Length > 0)
                {
                    using var stream = file.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }
            catch (Exception objExcep)
            {

            }
            return uploadResult;
        }
        #endregion

        #region Mapping
        public ProductEventBO MapperEventRabbitMQ(AddProductDTO objAddProductDTO)
        {
            return _mapper.Map<ProductEventBO>(objAddProductDTO);
        }
        #endregion
    }
}