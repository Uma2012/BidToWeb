using BidWeb.Models;
using BidWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository )
        {
            this._repository = repository;
        }

        public async Task<int> CreateProduct(Products product)
        {
            return await _repository.CreateProduct(product);
        }

        public async Task<List<Products>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<ZeroRemaningDaysProduct>> IncrementDay()
        {
            return await _repository.IncrementDay();
        }
    }
}
