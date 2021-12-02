namespace Inventory.API.DTOs
{
    public class UpdateProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public int Quantity { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsStatus { get; set; }
        public InfoDTO BrandDTO { get; set; }
        public InfoDTO CategoryDTO { get; set; }
        public PriceLogDTO PriceLogDTO { get; set; }
        public ConfigurationProductDTO ConfigurationProductDTO { get; set; }
        public InfoDTO SupplierDTO { get; set; }
    }
}