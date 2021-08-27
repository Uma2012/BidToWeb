using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int RemainingDays { get; set; }
        public double BasePrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime TodaysDate { get; set; }
    }
}
