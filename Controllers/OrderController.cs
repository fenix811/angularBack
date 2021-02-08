using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using back.Models;
using back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }
        [Route("api/order/getorders")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _repository.GetOrders();
            return Ok(result);
        }

        [Route("api/add/addorder")]
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await _repository.AddOrder(order);
            return Ok();
        }
    }
}
