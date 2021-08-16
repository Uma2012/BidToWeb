using BidWeb.Models;
using BidWeb.Services;
using BidWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<CustomUser> _userManager;

        public BidController(IBidService bidService, UserManager<CustomUser> userManager)
        {
            this._bidService = bidService;
            this._userManager = userManager;
        }

       [Authorize]
       [HttpGet("productid")]
        public async Task<ActionResult<PlaceBidViewModel>> GetCurrentValue(int productid, double baseprice, string productname)
        {
            var placebid = new PlaceBidViewModel();
            var currentValue =await _bidService.CurrentValue(productid);
            var noOfBidders = 0;
            if (baseprice == currentValue)
            {
                placebid.NoOfBidders = noOfBidders;
              
            }
            else
            {
                //read from db. Group the prodId from biddingTable and count it. Assign to viewBag
            }                     

            placebid.BasePrice = baseprice;
            placebid.CurrentValue = currentValue;
            placebid.ProductName = $"{productname}.jpg";
            placebid.ProdId = productid;
            
          
            return View(placebid);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateBid(int ProdId,string bidValue)
        {
            var userId = _userManager.GetUserId(User);
            CreateBidModel createBidModel = new CreateBidModel() { UserId=Guid.Parse(userId), Prodid= ProdId, BidPrice=Convert.ToDouble(bidValue)};

             await _bidService.CreateBidPrice(createBidModel);
            ViewBag.BidValue = bidValue;
            return View();
        }

    }
}
