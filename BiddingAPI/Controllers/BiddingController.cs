using BiddingAPI.Models;
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

    [HttpPost]
    public ActionResult CreateBid([FromBody] CreateBidModel createBid)
    {
          var createIsSuccessful = _repository.CreateBid(createBid);
            if (createIsSuccessful)
                return Ok();
            // return CreatedAtAction("Bid Added",createIsSuccessful);
            else
                return BadRequest("Bid not created");
    }

        

    }
}
