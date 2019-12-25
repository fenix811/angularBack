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
        public Task<List<Order>> GetOrders()
        {
            //var result = new List<Order>();
            //result.Add(new Product() { Id = 1, Name = "Product1", Description = "Description1", CompanyId = 1 });
            //result.Add(new Product() { Id = 2, Name = "Product2", Description = "Description2", CompanyId = 1 });
            //result.Add(new Product() { Id = 3, Name = "Product3", Description = "Description3", CompanyId = 1 });
            //var qwe = Task.Run(() => result);

            return _ctx.Orders.ToListAsync();
        }

    }
}
