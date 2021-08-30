using BidWeb.Models;
using BidWeb.Repository;
using BidWeb.ViewModels;
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

        public async Task<List<BidPrices>> BidValues(int prodId)
        {
            return await _repository.BidValues(prodId);
        }

        public async Task<string> CreateBidPrice(CreateBidModel createBidModel)
        {
            return await _repository.CreateBid(createBidModel);
        }

        public async Task<string> CreateCurrentValue(CurrentValue value)
        {
            return await _repository.CreateCurrentValue(value);
        }

        public async Task<PlaceBidViewModel> CurrentValue(int prodId)
        {
            return await _repository.CurrentValue(prodId);
        }

        public async Task<OrderCreationModel> OrderCreationValues(int prodId)
        {
            return await _repository.OrderCreationValues(prodId);
        }
    }
}
