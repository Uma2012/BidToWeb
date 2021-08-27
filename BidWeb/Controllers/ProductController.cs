using BidWeb.Models;
using BidWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBidService _bidService;
        private readonly IOrderService _orderService;
        private readonly UserManager<CustomUser> _usermanager;

        public ProductController(IProductService productService, IBidService bidService, IOrderService orderService, UserManager<CustomUser> usermanager)
        {
            this._productService = productService;
            this._bidService = bidService;
            this._orderService = orderService;
            this._usermanager = usermanager;
        }

        [Authorize]
        public async Task<ActionResult<List<Products>>> AllProducts()
        {
            var products = await _productService.GetAll();  
            
            var user = await _usermanager.GetUserAsync(User);
            if (user.IsAdmin)
            {
                return View("AllProductsAdmin", products);
            }
            return View(products);
        }

        [Authorize]
        public async Task<ActionResult> DayIncrementer()
        {
            var order = new Order();

            var listofproductidwithzeroremaningdays = await _productService.IncrementDay();

            if (listofproductidwithzeroremaningdays != null)
            {
                var temp1 = 0.0;
                var temp2 = "";
                foreach (var product in listofproductidwithzeroremaningdays)
                {
                    var ordercreationvalues = await _bidService.OrderCreationValues(product.ProdId);
                    order.UserId = ordercreationvalues.UserId;
                    order.Price = ordercreationvalues.ValueOfProduct;
                    order.ProdId = product.ProdId;
                    order.ProductName = product.ProductName;
                    order.OrderDate = DateTime.Now;
                    temp1 = ordercreationvalues.ValueOfProduct;
                    temp2 = product.ProductName;
                }

                if (temp1 != 0.0)
                {
                    var createdOrder = await _orderService.CreateOrder(order);
                    TempData["Message"] = $"Order created for product \"{order.ProductName}\" ";
                }

                if (temp1==0.0)
                {
                    TempData["Error"] = $"Order not created. No bidders for product \"{temp2}\"";
                }                

            }

             return RedirectToAction("AllProducts", "Product");
           
        }
       

    }
}
