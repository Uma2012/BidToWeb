using BidWeb.Services;
using BidWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Controllers
{
    public class BidController : Controller
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            this._bidService = bidService;
        }

       [HttpGet("productid")]
        public async Task<ActionResult<PlaceBidViewModel>> GetCurrentValue(int productid, double baseprice, string productname)
        {
            var placebid = new PlaceBidViewModel();
            var currentValue =await _bidService.CurrentValue(productid);
            var noOfBidders = 0;
            if (baseprice == currentValue)
            {
                placebid.NoOfBidders = noOfBidders;
               // ViewBag.Bidders = noOfBidders;
            }
            else
            {
                //read from db. Group the prodId from biddingTable and count it. Assign to viewBag
            }

          

            placebid.BasePrice = baseprice;
            placebid.CurrentValue = currentValue;
            placebid.ProductName = $"{productname}.jpg";
            
            //ViewBag.Current = currentValue;
            //ViewBag.Baseprice = baseprice;
            //ViewBag.Productname = productname;
            return View(placebid);
        }
    }
}
