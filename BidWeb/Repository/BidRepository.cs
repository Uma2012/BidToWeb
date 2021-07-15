using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async Task<double> CurrentValue(int prodId)
        {
            var response = await _httpClient.GetAsync("/api/bidding/GetCurrentValue?prodId="+ prodId);
            var productResponse = await response.Content.ReadAsStringAsync();
           
           var output= JsonConvert.DeserializeObject<double>(productResponse);
            return output;
        }
    }
}
