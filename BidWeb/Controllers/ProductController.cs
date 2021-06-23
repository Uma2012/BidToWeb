using BidWeb.Models;
using BidWeb.Services;
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

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public async Task<ActionResult<List<Products>>> AllProducts()
        {
            var products = await _productService.GetAll();
            return View(products);
        }
    }
}
