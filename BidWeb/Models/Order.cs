using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ProdId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }

    }
}
