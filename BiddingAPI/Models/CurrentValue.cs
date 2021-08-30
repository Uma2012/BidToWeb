using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Models
{
    public class CurrentValue
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public double CurrentPrice { get; set; }
    }
}
