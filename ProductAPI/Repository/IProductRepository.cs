using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}
