using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _ctx;

        public OrderRepository(ProductContext context)
        {
            _ctx = context;
        }

        public async Task AddOrder(Order order)
        {
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _ctx.Orders.ToListAsync();
        }

    }
}
