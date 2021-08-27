using BidWeb.Models;
using BidWeb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<CustomUser> _usermanager;

        public OrderController(IOrderService orderService, UserManager<CustomUser> usermanager)
        {
            this._orderService = orderService;
            this._usermanager = usermanager;
        }
        public async Task<ActionResult<List<Order>>> GetOrders(Guid userID)
        {
           var orders = new List<Order>();

          
            var user = await _usermanager.GetUserAsync(User);
            if (user.IsAdmin)
                orders =await _orderService.GetAllUserOrders();               
            
            else            
                orders =await _orderService.GetOrders(Guid.Parse(user.Id));              
            
            return View(orders);
        }
    }
}
