using BidWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public interface IProductService
    {
        Task<List<Products>> GetAll();
        Task<List<ZeroRemaningDaysProduct>> IncrementDay();
        Task<int> CreateProduct(Products product);
    }
}
