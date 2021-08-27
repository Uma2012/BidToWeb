﻿using BidWeb.Models;
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

            var output =await _bidService.CurrentValue(productid);                            

            placebid.BasePrice = baseprice;
            placebid.CurrentValue = output.CurrentValue;
            placebid.NoOfBidders = output.NoOfBidders;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<BidPrices>>> GetBidValues(int id)
        {
            var response =await _bidService.BidValues(id);            

            return View(response);
        }

    }
}
