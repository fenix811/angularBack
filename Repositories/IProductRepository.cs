using back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}