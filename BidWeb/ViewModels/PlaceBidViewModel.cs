using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.ViewModels
{
    public class PlaceBidViewModel
    {
        public double CurrentValue { get; set; }
        public double BasePrice { get; set; }
        public int NoOfBidders { get; set; }
        public string ProductName { get; set; }
        public int ProdId { get; set; }
    }
}
