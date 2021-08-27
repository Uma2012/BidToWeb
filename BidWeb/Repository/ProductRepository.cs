using BidWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
