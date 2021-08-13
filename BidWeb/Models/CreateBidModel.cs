using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Models
{
    public class CreateBidModel
    {
        public Guid UserId { get; set; }
        public double BidPrice { get; set; }
        public int Prodid { get; set; } 
    }
}
