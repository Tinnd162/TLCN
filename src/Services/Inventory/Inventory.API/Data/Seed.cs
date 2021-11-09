using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Inventory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            #region Insert Data
            if (await context.Categories.AnyAsync()) return;
            var categoryData = await System.IO.File.ReadAllTextAsync("Data/CategorySeedData.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);
            context.Categories.AddRange(categories);


            if (await context.Brands.AnyAsync()) return;
            var brandData = await System.IO.File.ReadAllTextAsync("Data/BrandSeedData.json");
            var brands = JsonSerializer.Deserialize<List<Brand>>(brandData);
            context.Brands.AddRange(brands);

            if (await context.Colors.AnyAsync()) return;
            var colorData = await System.IO.File.ReadAllTextAsync("Data/ColorSeedData.json");
            var colors = JsonSerializer.Deserialize<List<Color>>(colorData);
            context.Colors.AddRange(colors);

            if (await context.Configurations.AnyAsync()) return;
            var configurationData = await System.IO.File.ReadAllTextAsync("Data/ConfigurationSeedData.json");
            var configurations = JsonSerializer.Deserialize<List<Configuration>>(configurationData);
            context.Configurations.AddRange(configurations);

            if (await context.Suppliers.AnyAsync()) return;
            var supplierData = await System.IO.File.ReadAllTextAsync("Data/SupplierSeedData.json");
            var suppliers = JsonSerializer.Deserialize<List<Supplier>>(supplierData);
            context.Suppliers.AddRange(suppliers);

            if (await context.Products.AnyAsync()) return;
            var productData = await System.IO.File.ReadAllTextAsync("Data/ProductSeedData.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productData);
            context.Products.AddRange(products);

            if (await context.Devices.AnyAsync()) return;
            var deviceData = await System.IO.File.ReadAllTextAsync("Data/DeviceSeedData.json");
            var devices = JsonSerializer.Deserialize<List<Device>>(deviceData);
            context.Devices.AddRange(devices);

            if (await context.PriceLogs.AnyAsync()) return;
            var pricelogData = await System.IO.File.ReadAllTextAsync("Data/PriceLogSeedData.json");
            var pricelogs = JsonSerializer.Deserialize<List<PriceLog>>(pricelogData);
            context.PriceLogs.AddRange(pricelogs);

            if (await context.ProductColors.AnyAsync()) return;
            var productcolorData = await System.IO.File.ReadAllTextAsync("Data/ProductColorSeedData.json");
            var productColors = JsonSerializer.Deserialize<List<ProductColor>>(productcolorData);
            context.ProductColors.AddRange(productColors);

            if (await context.ProductSuppliers.AnyAsync()) return;
            var productsupplierData = await System.IO.File.ReadAllTextAsync("Data/ProductSupplierSeedData.json");
            var productSuppliers = JsonSerializer.Deserialize<List<ProductSupplier>>(productsupplierData);
            context.ProductSuppliers.AddRange(productSuppliers);

            await context.SaveChangesAsync();
            #endregion
        }
    }
}