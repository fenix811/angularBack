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
        public Product GetProduct(int id)
        {
            return new Product() { Id = 1, Name = "Product1", Description = "Description1" };
        }
        public IList<Product> GetProducts()
        {
            var result = new List<Product>();
            result.Add(new Product() { Id = 1, Name = "Product1", Description = "Description1" });
            result.Add(new Product() { Id = 2, Name = "Product2", Description = "Description2" });
            result.Add(new Product() { Id = 3, Name = "Product3", Description = "Description3" });
            return result;
        }

        public void UpdateProduct(Product product)
        {
        }
    }
}
