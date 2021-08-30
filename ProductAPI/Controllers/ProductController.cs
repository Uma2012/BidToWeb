using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repository.GetAllProducts();
            if (products != null && products.Any())
            {
                return Ok(products);
            }
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ZeroRemaingDaysProduct>> IncrementDayCounter()
        {
            var products =  _repository.DayIncrementer();
            if (products != null && products.Any())
            {
                return Ok(products);
            }
            return null;
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody]Product product)
        {
           var createdProduct= _repository.Create(product);
            if (createdProduct != null)
            {                 
                 return Ok(createdProduct.Id);
               // return CreatedAtAction("GetProducts", new { id = product.Id }, product);
            }
            else
                return BadRequest();

        }

    }
}
