using back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
    }
}