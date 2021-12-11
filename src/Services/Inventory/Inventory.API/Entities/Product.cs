using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Inventory.API.Entities
{
    [Table("Product")]
    public class Product
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int NumberOfSale { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsUpdate { get; set; }
        [Description("Tình trạng sản phẩm: còn hàng, hết hàng")]
        public bool IsStatus { get; set; }
        [Description("Tình trạng sản phẩm: Đã ngưng sản xuất")]
        public bool IsDiscontinued { get; set; }
        public bool IsDelete { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        // public string CongigurationId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        // public Configuration Configuration { get; set; }
        // public ICollection<Device> Devices { get; set; }
        public ICollection<PriceLog> PriceLogs { get; set; }
        public ICollection<Color> Colors { get; set; }
    }
}