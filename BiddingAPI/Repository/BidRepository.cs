using BiddingAPI.Context;
using BiddingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Repository
{
    public class BidRepository : IBidRepository
    {
        private readonly BiddingDbContext _context;

        public BidRepository(BiddingDbContext context)
        {
            this._context = context;
        }

        public bool CreateBid(CreateBidModel createBid)
        {
            int aliasId =  AliasChecking(createBid);
            if (aliasId > 0)
            {
                bool isBidCreated = BidPriceCreation(aliasId, createBid);

                if (isBidCreated)
                {
                    bool isCurrentPriceUpdated = UpdateCurrentPrice(createBid);

                   if(isCurrentPriceUpdated)
                    {
                        return true;
                    }
                   else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
            }
            return false;
        }

        public  int AliasChecking(CreateBidModel createBid)
        {
            var aliasID = 0;
            var isAliasExists = _context.Aliases.Any(x => x.ProdId == createBid.Prodid && x.UserId == createBid.UserId);

            if (isAliasExists)
            {
               
                aliasID =  _context.Aliases.Where(x => x.ProdId == createBid.Prodid && x.UserId == createBid.UserId).Select(a => a.AliasId).FirstOrDefault();
                return aliasID;
            }
            else
            {
                Alias aliasRow = new Alias();
                var prodIdExists = _context.Aliases.Any(x => x.ProdId == createBid.Prodid);
                if (prodIdExists)
                {
                    aliasID = _context.Aliases.Where(x => x.ProdId == createBid.Prodid).Select(a => a.AliasId).Max();
                    aliasRow.AliasId = aliasID +1;   //check this with +1
                    aliasRow.ProdId = createBid.Prodid;
                    aliasRow.UserId = createBid.UserId;

                    try
                    {
                        _context.Aliases.Add(aliasRow);
                         _context.SaveChanges();
                    }
                    catch
                    {
                        return 0;
                    }

                    return aliasRow.AliasId;

                }
                else
                {

                    aliasRow.ProdId = createBid.Prodid;
                    aliasRow.UserId = createBid.UserId;
                    aliasRow.AliasId = aliasID+1;

                    try
                    {
                        _context.Aliases.Add(aliasRow);
                         _context.SaveChanges();
                    }
                    catch
                    {
                        return 0;
                    }

                    return aliasRow.AliasId;
                }

            }
           

        }

        public  bool BidPriceCreation(int aliasId,CreateBidModel createBid)
        {
            BidPrice bidPrice = new BidPrice();
            bidPrice.AliasId = aliasId;
            bidPrice.BidValue = createBid.BidPrice;
            bidPrice.ProdId = createBid.Prodid;
            try
            {
                _context.BidPrices.Add(bidPrice);
                 _context.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public  bool UpdateCurrentPrice(CreateBidModel bidModel)
        {
            var isProdIdExists = _context.Currentvalue.Any(x => x.ProdId == bidModel.Prodid);
            if (isProdIdExists)
            {
                var query = _context.Currentvalue.GroupBy(s => s.ProdId)
                                               .Select(s => new
                                               {
                                                   PRODID = s.Key,
                                                   Maxi = s.Max(m => m.CurrentPrice)
                                               })
                                               .Where(y => y.PRODID == bidModel.Prodid).FirstOrDefault();
                var updatedCurrentPrice = query.Maxi + bidModel.BidPrice;
                CurrentValue currentValue = new CurrentValue() { ProdId = bidModel.Prodid, CurrentPrice = updatedCurrentPrice };
                try
                {
                    _context.Currentvalue.Add(currentValue);
                     _context.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

                return true;
        }

        public  double GetCurrentValueOfProduct(int prodId)
        {
            var isProdIdExists = _context.Currentvalue.Any(x => x.ProdId == prodId);
            if (isProdIdExists)
            {
                //var currentValueOfProduct = _context.Currentvalue.Where(y => y.ProdId == prodId).Select(x => x.CurrentPrice);
               // var currentValueRow =_context.Currentvalue.Where(y => y.ProdId == prodId).Max();
             //var query = _context.Currentvalue.GroupBy(s => s.ProdId)
             //                                   .Select(s => new 
             //                                   {
             //                                   PRODID = s.Key,               
             //                                   Maxi = s.Max(m => m.CurrentPrice)
             //                                   })
             //                                   .ToList();

             //var requiredCurrentValue = query.Where(y=>y.PRODID==prodId).Select(x=>x.Maxi).FirstOrDefault();

                var query = _context.Currentvalue.GroupBy(s => s.ProdId)
                                                .Select(s => new
                                                {
                                                    PRODID = s.Key,
                                                    Maxi = s.Max(m => m.CurrentPrice)
                                                })
                                                .Where(y=>y.PRODID==prodId).FirstOrDefault();
                var requiredCurrentValue = query.Maxi;

                return requiredCurrentValue;

            }

            return 0;
        }

       
    }
}
