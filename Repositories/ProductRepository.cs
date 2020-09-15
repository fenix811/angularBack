using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using Microsoft.EntityFrameworkCore;


namespace back.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ctx;

        public ProductRepository(ProductContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddProduct(Product product)
        {
            product.CompanyId = 1; //TODO 
            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();
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
            return _ctx.Products.ToListAsync();
        }

        public void UpdateProduct(Product product)
        {
        }
    }
}
