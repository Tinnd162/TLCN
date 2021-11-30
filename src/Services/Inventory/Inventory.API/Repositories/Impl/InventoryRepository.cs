using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Inventory.API.Data;
using Inventory.API.DTOs;
using Inventory.API.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                                                        lstColorDTO = s1.Colors.Select(s2 => new InfoDTO
                                                        {
                                                            Id = s2.Id,
                                                            Name = s2.ColorName
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

        public async Task<bool> AddDetailProduct(AddProductDTO objAddProductDTO)
        {
            objAddProductDTO.BrandDTO.Id = Convert.ToString(Guid.NewGuid());
            objAddProductDTO.CategoryDTO.Id = Convert.ToString(Guid.NewGuid());
            objAddProductDTO.ConfigurationProductDTO.Id = Convert.ToString(Guid.NewGuid());
            objAddProductDTO.SupplierDTO.Id = Convert.ToString(Guid.NewGuid());

            Product objProduct = new Product()
            {
                Id = objAddProductDTO.Id,
                ProductName = objAddProductDTO.Name,
                Description = objAddProductDTO.Description,
                UnitPrice = objAddProductDTO.UnitPrice,
                Quantity = objAddProductDTO.Quantity,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                IsUpdate = false,
                IsStatus = false,
                IsDiscontinued = false,
                IsDelete = false,
                Supplier = new Supplier
                {
                    Id = objAddProductDTO.SupplierDTO.Id,
                    SupplierName = objAddProductDTO.SupplierDTO.Name
                },
                Brand = new Brand
                {
                    Id = objAddProductDTO.BrandDTO.Id,
                    BrandName = objAddProductDTO.BrandDTO.Name,
                    CategoryId = objAddProductDTO.CategoryDTO.Id
                },
                Category = new Category
                {
                    Id = objAddProductDTO.CategoryDTO.Id,
                    CategoryName = objAddProductDTO.CategoryDTO.Name
                },
                Configuration = new Configuration
                {
                    Id = objAddProductDTO.ConfigurationProductDTO.Id,
                    OperatingSystem = objAddProductDTO.ConfigurationProductDTO.OperatingSystem,
                    RearCamera = objAddProductDTO.ConfigurationProductDTO.RearCamera,
                    FrontCamera = objAddProductDTO.ConfigurationProductDTO.FrontCamera,
                    Chips = objAddProductDTO.ConfigurationProductDTO.Chips,
                    RAM = objAddProductDTO.ConfigurationProductDTO.RAM,
                    InternalMemory = objAddProductDTO.ConfigurationProductDTO.InternalMemory,
                    SIM = objAddProductDTO.ConfigurationProductDTO.SIM,
                    Batteries = objAddProductDTO.ConfigurationProductDTO.Batteries
                },
                PriceLogs = new Collection<PriceLog>(){
                    new PriceLog(){
                        Id=Convert.ToString(Guid.NewGuid()),
                        Price=objAddProductDTO.PriceLogDTO.Price,
                        UserUpdate=null,
                        ProductId=objAddProductDTO.Id,
                        IsUpdate=false,
                        CreateDate=DateTime.Now,
                        UpdateDate=DateTime.Now,
                    }
                },
            };
            await _context.Products.AddAsync(objProduct);
            return await _context.SaveChangesAsync() > 0;
        }

        public ProductEventBO MapperEventRabbitMQ(AddProductDTO objAddProductDTO)
        {
            return _mapper.Map<ProductEventBO>(objAddProductDTO);
        }
        #endregion
    }
}