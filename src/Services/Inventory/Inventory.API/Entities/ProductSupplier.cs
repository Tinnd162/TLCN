namespace Inventory.API.Entities
{
    public class ProductSupplier
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}