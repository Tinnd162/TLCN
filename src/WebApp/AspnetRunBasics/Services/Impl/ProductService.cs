using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CategoryModel>> GetProducts()
        {
            var response = await _client.GetAsync("/Product/GetProducts");
            return await response.ReadContentAs<List<CategoryModel>>();
        }

        public async Task<IEnumerable<CategoryModel>> GetProductByCategory(string strCategory)
        {
            var response = await _client.GetAsync($"/Product/GetProductByCategory/{strCategory}");
            return await response.ReadContentAs<List<CategoryModel>>();
        }

        public async Task<IEnumerable<CategoryModel>> GetProductByBrand(string strBrand)
        {
            var response = await _client.GetAsync($"/Product/GetProductByBrand/{strBrand}");
            return await response.ReadContentAs<List<CategoryModel>>();
        }

        public async Task<CategoryModel> GetProduct(string strProductId)
        {
            var response = await _client.GetAsync($"/Product/GetProduct/{strProductId}");
            return await response.ReadContentAs<CategoryModel>();
        }
    }
}
