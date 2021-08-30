using BidWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BidWeb.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;

        public ProductRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<int> CreateProduct(Products product)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/product/Create", product, options);
            var response = await request.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<int>(response);
            return output;
        }

        public async Task<List<Products>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/product/GetProducts");
            var productResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Products>>(productResponse);
        }

        public async Task<List<ZeroRemaningDaysProduct>> IncrementDay()
        {
            var response = await _httpClient.GetAsync("/api/product/IncrementDayCounter");
            var productResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ZeroRemaningDaysProduct>>(productResponse);
        }
    }
}
