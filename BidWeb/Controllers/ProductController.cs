using BidWeb.Models;
using BidWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private  IWebHostEnvironment _hostEnvironment { get; }

        public ProductController(IProductService productService, 
                                    IBidService bidService, 
                                    IOrderService orderService,
                                    UserManager<CustomUser> usermanager,
                                    IWebHostEnvironment hostEnvironment)
        {
            this._productService = productService;
            this._bidService = bidService;
            this._orderService = orderService;
            this._usermanager = usermanager;
            _hostEnvironment = hostEnvironment;
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

        [Authorize]
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(IFormFile file, Products product)
        {            
            var webRootPath = _hostEnvironment.WebRootPath;
            var folderName = @"image\";
            var newPath = Path.Combine(webRootPath, folderName);
            //var extention = file.ContentType.Split("/"[1]);
            var selectedfile = file.FileName;
            var filename = @"image/" + file.FileName;
            var fullPath = Path.Combine(newPath, selectedfile);
            if(file!=null)
            {
                using (FileStream stream=new FileStream(fullPath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
           
            product.ImageUrl = filename;
            product.CreatedDate = DateTime.Now;
            product.ExpiryDate = product.CreatedDate.AddDays(5);
            product.RemainingDays = 5;
            product.TodaysDate = DateTime.Now;
            var createdproductId = await _productService.CreateProduct(product);
            var currenValue = new CurrentValue()
            {
                CurrentPrice = product.BasePrice,
                ProdId=createdproductId

            };
            var createCurrentPrice = await _bidService.CreateCurrentValue(currenValue);
            

            return RedirectToAction("AllProducts", "Product");
        }

    }
}
