using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        
        [Route("api/product/getproductsbyname/{searchText}")]
        [HttpGet]
        public async Task<IActionResult> getproductsbyname(string searchText)
        {
            var result = await _repository.GetProducts();
            var r = result.FindAll(a => a.Name.Contains(searchText));
            return Ok(r);
        }

        [Route("api/product/getcompanyproducts/{companyId}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyProducts(int companyId)
        {
            var result = await _repository.GetProducts();
            return Ok(result.FindAll(a => a.CompanyId == companyId));
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
        public async void AddProduct([FromBody]Product product)
        {
            await _repository.AddProduct(product);
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

        [Route("api/product/test2")]
        [HttpGet]
        public string test2()
        {
            Thread.Sleep(5000);
            return "test2";
        }
    }
}
