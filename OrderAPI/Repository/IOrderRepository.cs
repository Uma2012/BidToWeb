using OrderAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        List<Order> GetOrder(Guid userId);
        List<Order> GetAllOrder();
    }
}
