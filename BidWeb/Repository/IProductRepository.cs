using BidWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Repository
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAll();
    }
}
