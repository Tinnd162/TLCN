using Inventory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        //
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PriceLog> PriceLogs { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //
            builder.Entity<ProductColor>()
                .HasKey(x => new { x.ProductId, x.ColorId });

            builder.Entity<ProductColor>()
                .HasOne(x => x.Product)
                .WithMany(y => y.ProductColors)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductColor>()
                .HasOne(x => x.Color)
                .WithMany(y => y.ProductColors)
                .HasForeignKey(z => z.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<ProductSupplier>()
                .HasKey(x => new { x.ProductId, x.SupplierId });

            builder.Entity<ProductSupplier>()
                .HasOne(x => x.Supplier)
                .WithMany(y => y.ProductSuppliers)
                .HasForeignKey(z => z.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductSupplier>()
                .HasOne(x => x.Product)
                .WithMany(y => y.ProductSuppliers)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<Device>()
                .HasOne(x => x.Product)
                .WithMany(y => y.Devices)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<Product>(Entity =>
            {
                Entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,4)");

                Entity.HasOne(x => x.Brand)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

                Entity.HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            //
            builder.Entity<Brand>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Brands)
                .HasForeignKey(z => z.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<PriceLog>(Entity =>
            {
                Entity.Property(e => e.Price)
                .HasColumnType("decimal(18,4)");

                Entity.HasOne(x => x.Product)
                .WithMany(y => y.PriceLogs)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            //
            builder.Entity<Configuration>()
                .HasOne(x => x.Product)
                .WithOne(y => y.Configuration)
                .HasForeignKey<Product>(z => z.CongigurationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}