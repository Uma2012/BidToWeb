using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Models
{
    public class OrderCreationModel
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public Guid UserId { get; set; }
        public double ValueOfProduct { get; set; }
    }
}
