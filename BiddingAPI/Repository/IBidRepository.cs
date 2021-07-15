using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Repository
{
    public interface IBidRepository
    {
        double GetCurrentValueOfProduct(int prodId);
    }
}
