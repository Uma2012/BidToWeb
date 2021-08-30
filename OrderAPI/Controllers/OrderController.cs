using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model;
using OrderAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository orderRepository)
        {
            this._repository = orderRepository;
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody]Order order)
        {
            var output = _repository.CreateOrder(order);

            if (output != null)
                return Ok(output);
            else
                return BadRequest();
        }

        [HttpGet]
        public ActionResult<List<Order>> GetOrders(Guid userId)
        {
            var output = _repository.GetOrder(userId);
            if (output != null)
                return Ok(output);
            else
                return BadRequest();
        }
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var output = _repository.GetAllOrder();
            if (output != null)
                return Ok(output);
            else
                return BadRequest();
        }
    }
}
