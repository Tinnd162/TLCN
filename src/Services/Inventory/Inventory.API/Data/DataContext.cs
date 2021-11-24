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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PriceLog> PriceLogs { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

                Entity.HasOne(x => x.Supplier)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.SupplierId)
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
            builder.Entity<Color>()
                .HasOne(x => x.Product)
                .WithMany(y => y.Colors)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<Configuration>()
                .HasOne(x => x.Product)
                .WithOne(y => y.Configuration)
                .HasForeignKey<Product>(z => z.CongigurationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}