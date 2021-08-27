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
                    aliasRow.AliasId = aliasID +1;   
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
            catch(Exception)
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

        public  PlacebidModel GetCurrentValueOfProduct(int prodId)
        {
            PlacebidModel placebidModel = new PlacebidModel();
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

                //var bidder = _context.Currentvalue.Where(p => p.ProdId == prodId).Count();
                var isBidderExsits = _context.Aliases.Any(x => x.ProdId == prodId);
                if (isBidderExsits)
                {
                    placebidModel.NoOfBidders = _context.Aliases.Where(p => p.ProdId == prodId).Count();
                   
                }
                else
                {
                    placebidModel.NoOfBidders = 0;
                }

                

                placebidModel.CurrentValue = query.Maxi;
              

                return placebidModel;

            }

            return null;
        }

        public OrderCreationModel ValuesNeededForOrderCreation(int prodId)
        {
            OrderCreationModel orderCreationModel = new OrderCreationModel();
            try
            {                
                var maxIdOfProd = _context.BidPrices
                            .GroupBy(p => p.ProdId)
                            .Select(s =>new 
                            {
                                ProdId=s.Key,
                                Id=s.Max(i=>i.Id)
                            })
                            .Where(y => y.ProdId == prodId)
                            .FirstOrDefault();

                
                var aliasId = _context.BidPrices.Where(i => i.Id == maxIdOfProd.Id).Select(a => a.AliasId).FirstOrDefault();             

                var userId = _context.Aliases.Where(a => a.AliasId == aliasId && a.ProdId == prodId).Select(u => u.UserId).FirstOrDefault();

              
               var maxIdofCurrentValue = _context.Currentvalue.GroupBy(s => s.ProdId)
                                                        .Select(s => new
                                                              {
                                                                PRODID = s.Key,
                                                                ID = s.Max(m => m.Id)
                                                               })
                                                        .Where(y => y.PRODID == prodId)
                                                        .FirstOrDefault();

                var currentValue = _context.Currentvalue.Where(i => i.Id == maxIdofCurrentValue.ID).Select(m => m.CurrentPrice).FirstOrDefault();

                orderCreationModel.UserId = userId;
                orderCreationModel.ValueOfProduct = currentValue;
            }
            catch(Exception)
            {
                return null;
            }
            
            return orderCreationModel;
        }

        public List<BidPrice> GetBidValues(int prodId)
        {
            var output = new List<BidPriceWithAlias>();
            var query = _context.BidPrices.Where(p => p.ProdId == prodId).ToList();

            
            return query;
        }
    }
}
