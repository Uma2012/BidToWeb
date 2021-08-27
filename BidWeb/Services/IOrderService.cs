using BidWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetOrders(Guid userId);
        Task<List<Order>> GetAllUserOrders();
    }
}
