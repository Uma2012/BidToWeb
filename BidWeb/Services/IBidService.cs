using BidWeb.Models;
using BidWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public interface IBidService
    {
        Task<PlaceBidViewModel> CurrentValue(int prodId);
        Task<string> CreateBidPrice(CreateBidModel createBidModel);
        Task<OrderCreationModel> OrderCreationValues(int prodId);
        Task<List<BidPrices>> BidValues(int prodId);
        Task<string> CreateCurrentValue(CurrentValue value);
    }
}
