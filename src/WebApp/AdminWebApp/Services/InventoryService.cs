using AdminWebApp.Extensions;
using AdminWebApp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdminWebApp.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _client;

        public InventoryService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> AddProduct(AddProductModel objAddProductModel, string token)
        {
            var reqContent = new MultipartFormDataContent();
            reqContent.Add(new StringContent(objAddProductModel.Name), "Name");
            reqContent.Add(new StringContent(objAddProductModel.Quantity.ToString()), "Quantity");
            reqContent.Add(new StringContent(objAddProductModel.PriceLogDTO.SalePrice.ToString()), "PriceLogDTO.SalePrice");
            reqContent.Add(new StringContent(objAddProductModel.BrandDTO.Id), "BrandDTO.Id");
            reqContent.Add(new StringContent(objAddProductModel.BrandDTO.Name), "BrandDTO.Name");
            reqContent.Add(new StringContent(objAddProductModel.CategoryDTO.Id), "CategoryDTO.Id");
            reqContent.Add(new StringContent(objAddProductModel.CategoryDTO.Name), "CategoryDTO.Name");
            reqContent.Add(new StringContent(objAddProductModel.Description), "Description");
            reqContent.Add(new StringContent(objAddProductModel.UserUpdate), "UserUpdate");

            if (objAddProductModel.Image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    objAddProductModel.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    ByteArrayContent bytes = new ByteArrayContent(fileBytes);
                    reqContent.Add(bytes, "Image", objAddProductModel.Image.FileName);
                }
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsync("/Inventory/AddProduct", reqContent);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (dataAsString == "") return true;
            return JsonConvert.DeserializeObject<bool>(dataAsString);
        }

        public async Task<ProductDetailModel> GetProductDetailById(string strProductID, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/Inventory/GetProductDetailById/{strProductID}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProductDetailModel>(dataAsString);
        }

        public async Task<bool> UpdateProduct(UpdateProductModel objUpdateProductDTO, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson<UpdateProductModel>("/Inventory/UpdateProduct", objUpdateProductDTO);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (dataAsString == null)
                return false;
            return Convert.ToBoolean(dataAsString);
        }

        public async Task<List<ProductDetailModel>> Search(string strKeyword, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/Inventory/Search/{strKeyword}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ProductDetailModel>>(dataAsString);
        }
    }
}
