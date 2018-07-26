using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = _repository.GetProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = _repository.GetProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public void AddProduct(Product product)
        {
        }

        [HttpPut("{id}")]
        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteProduct(id);
        }
    }
}
