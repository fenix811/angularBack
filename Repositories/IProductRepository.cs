using back.Models;
using System.Collections.Generic;

namespace back.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}