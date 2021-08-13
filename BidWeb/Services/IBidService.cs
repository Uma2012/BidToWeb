using BidWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public interface IBidService
    {
        Task<double> CurrentValue(int prodId);
        Task CreateBidPrice(CreateBidModel createBidModel);
    }
}
