using BidWeb.Models;
using BidWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Repository
{
    public interface IBidRepository
    {
        Task<PlaceBidViewModel> CurrentValue(int prodId);
        Task CreateBid(CreateBidModel createBidModel);
        Task<OrderCreationModel> OrderCreationValues(int prodid);
        Task<List<BidPrices>> BidValues(int prodId);
    }
}
