using BidWeb.Models;
using BidWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }

        public async Task<List<Order>> GetAllUserOrders()
        {
            return await _orderRepository.GetAllUserOrders();
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            return await _orderRepository.GetOrders(userId);
        }
    }
}
