using BidWeb.Models;
using BidWeb.ViewModels;
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
    public class BidRepository : IBidRepository
    {
        private readonly HttpClient _httpClient;

        public BidRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<BidPrices>> BidValues(int prodId)
        {
            var request = await _httpClient.GetAsync("/api/bidding/GetBidPrices?prodId=" + prodId);
            var response = await request.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<List<BidPrices>>(response);
            return output;
        }

        public async Task<string> CreateBid(CreateBidModel createBidModel)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/bidding/CreateBid", createBidModel,options);          
            return request.StatusCode.ToString();
        }

        public async Task<string> CreateCurrentValue(CurrentValue value)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/bidding/CreateCurrentValue", value, options);
            return request.StatusCode.ToString();
        }

        public async Task<PlaceBidViewModel> CurrentValue(int prodId)
        {
            var request = await _httpClient.GetAsync("/api/bidding/GetCurrentValue?prodId="+ prodId);
            var productResponse = await request.Content.ReadAsStringAsync();
           
           var output= JsonConvert.DeserializeObject<PlaceBidViewModel>(productResponse);
            return output;
        }

        public async Task<OrderCreationModel> OrderCreationValues(int prodId)
        {
            var request = await _httpClient.GetAsync("/api/bidding/GetOrderCreationValues?id=" + prodId);
            var productResponse = await request.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<OrderCreationModel>(productResponse);
            return output;
        }
    }
}
