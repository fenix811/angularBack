using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    //[Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [Route("api/product/getproducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _repository.GetProducts();
            return Ok(result);
        }

        [Route("api/product/getproduct")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _repository.GetProduct(id);
            return Ok(result);
        }

        [Route("api/product/AddProduct")]
        [HttpPost]
        public void AddProduct(Product product)
        {
        }

        [Route("api/product/updateproduct")]
        [HttpPut("{id}")]
        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        [Route("api/product/deleteproduct")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteProduct(id);
        }
    }
}
