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
    public ActionResult<PlacebidModel> GetCurrentValue(int prodId)
    {
          var placebidValues = _repository.GetCurrentValueOfProduct(prodId);
          return Ok( placebidValues);
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
        
    [HttpGet]
    public ActionResult<OrderCreationModel> GetOrderCreationValues(int id)
    {
            var orderCreationValues = _repository.ValuesNeededForOrderCreation(id);
            if (orderCreationValues != null)
                return Ok(orderCreationValues);
            else
                return BadRequest();

    }

    [HttpGet]
    public ActionResult<List<BidPrice>> GetBidPrices(int prodId)
    {
            var bidValues = _repository.GetBidValues(prodId);
            if (bidValues != null)
                return Ok(bidValues);
            else
                return BadRequest();

    }

    }
    
}
