using BidWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidWeb.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _repository;

        public BidService(IBidRepository repository)
        {
            this._repository = repository;
        }
        public async Task<double> CurrentValue(int prodId)
        {
            return await _repository.CurrentValue(prodId);
        }
    }
}
