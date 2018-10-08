using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;

namespace back.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
        }

        public void DeleteProduct(int id)
        {
        }
        public Task<Product> GetProduct(int id)
        {
            var result = new Product() { Id = 4, Name = "Product4", Description = "Description4" };
            return Task.Run(() => result);
        }
        public Task<List<Product>> GetProducts()
        {
            var result = new List<Product>();
            result.Add(new Product() { Id = 1, Name = "Product1", Description = "Description1", CompanyId = 1 });
            result.Add(new Product() { Id = 2, Name = "Product2", Description = "Description2", CompanyId = 1 });
            result.Add(new Product() { Id = 3, Name = "Product3", Description = "Description3", CompanyId = 1 });
            var qwe = Task.Run(() => result);

            return qwe;
        }

        public void UpdateProduct(Product product)
        {
        }
    }
}
