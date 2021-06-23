﻿using BidWeb.Models;
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
        public async Task<List<Products>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}