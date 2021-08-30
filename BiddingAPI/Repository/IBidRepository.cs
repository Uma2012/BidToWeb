using BiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Repository
{
    public interface IBidRepository
    {
        PlacebidModel GetCurrentValueOfProduct(int prodId);
        bool CreateBid(CreateBidModel createBid);
        OrderCreationModel ValuesNeededForOrderCreation(int prodId);
        List<BidPrice> GetBidValues(int prodId);
        bool CreateCurrentValue(CurrentValue value);
    }
}
