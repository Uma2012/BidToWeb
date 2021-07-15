using BiddingAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BiddingController : ControllerBase
    {
        private readonly IBidRepository _repository;

        public BiddingController(IBidRepository repository)
        {
            this._repository = repository;
        }


    [HttpGet]
    public ActionResult<double> GetCurrentValue(int prodId)
    {
          var currentValue = _repository.GetCurrentValueOfProduct(prodId);
          return Ok( currentValue);
    }

        //public async Task<ActionResult<List<Product>>> GetProducts()
        //{
        //    var products = await _repository.GetAllProducts();
        //    if (products != null && products.Any())
        //    {
        //        return Ok(products);
        //    }
        //    return NoContent();
        //}

    }
}
