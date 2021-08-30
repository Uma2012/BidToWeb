using OrderAPI.Context;
using OrderAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            this._context = orderDbContext;
        }
        public Order CreateOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
               _context.SaveChanges();
                return order;
            }
            catch
            {
                return null;
            }
          

        }

        public List<Order> GetAllOrder()
        {
            try
            {
                var orders = _context.Orders.ToList();
                return orders;
            }
            catch
            {
                return null;
            }
        }

        public List<Order> GetOrder(Guid userId)
        {
            var orderList = new List<Order>();
            try
            {
                var isOrderExists = _context.Orders.Any(i => i.UserId == userId);
                if(isOrderExists)
                {
                   orderList= _context.Orders.Where(u => u.UserId == userId).ToList();
                }
                return orderList;
            }
            catch
            {
                return null;
            }
          
        }
    }
}
