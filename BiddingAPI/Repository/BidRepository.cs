using BiddingAPI.Context;
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
        public  double GetCurrentValueOfProduct(int prodId)
        {
            var isProdIdExists = _context.Currentvalue.Any(x => x.ProdId == prodId);
            if (isProdIdExists)
            {
                //var currentValueOfProduct = _context.Currentvalue.Where(y => y.ProdId == prodId).Select(x => x.CurrentPrice);
                var currentValueRow =_context.Currentvalue.Where(y => y.ProdId == prodId).FirstOrDefault();
                return currentValueRow.CurrentPrice;
            }
            return 0;
        }

       
    }
}
