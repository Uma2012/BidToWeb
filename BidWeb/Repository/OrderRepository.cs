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
    public class OrderRepository:IOrderRepository
    {
        private readonly HttpClient _httpClient;

        public OrderRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
      

        public async Task<Order> CreateOrder(Order order)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var request = await _httpClient.PostAsJsonAsync("/api/order/Create", order, options);
            var response = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(response);
        }

        public async Task<List<Order>> GetAllUserOrders()
        {
            var request = await _httpClient.GetAsync("/api/order/GetAllOrders");
            var response = await request.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<List<Order>>(response);
            return output;
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            var request = await _httpClient.GetAsync("/api/order/GetOrders?userId=" + userId);
            var response = await request.Content.ReadAsStringAsync();

            var output = JsonConvert.DeserializeObject<List<Order>>(response);
            return output;
        }

    }
}
