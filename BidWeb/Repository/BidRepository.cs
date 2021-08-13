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
    public class BidRepository : IBidRepository
    {
        private readonly HttpClient _httpClient;

        public BidRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task CreateBid(CreateBidModel createBidModel)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/bidding/CreateBid", createBidModel,options);
            var Response = await request.Content.ReadAsStringAsync();
            
        }

        public async Task<double> CurrentValue(int prodId)
        {
            var request = await _httpClient.GetAsync("/api/bidding/GetCurrentValue?prodId="+ prodId);
            var productResponse = await request.Content.ReadAsStringAsync();
           
           var output= JsonConvert.DeserializeObject<double>(productResponse);
            return output;
        }
    }
}
