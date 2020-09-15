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
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [Route("getproducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _repository.GetProducts();
            return Ok(result);
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            await _repository.AddProduct(product);
            return Ok();
        }


        [Route("getproductsbyname/{searchText}")]
        [HttpGet]
        public async Task<IActionResult> getproductsbyname(string searchText)
        {
            var result = await _repository.GetProducts();
            var r = result.FindAll(a => a.Name.Contains(searchText));
            return Ok(r);
        }

        [Route("getcompanyproducts/{companyId}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyProducts(int companyId)
        {
            var result = await _repository.GetProducts();
            return Ok(result.FindAll(a => a.CompanyId == companyId));
        }

        [Route("getproduct")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _repository.GetProduct(id);
            return Ok(result);
        }


        [Route("updateproduct")]
        [HttpPut("{id}")]
        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
        }

        [Route("test")]
        [HttpPost]
        public async void Test([FromBody]Product product)
        {
            await _repository.AddProduct(new Product { Name="qwe", CompanyId=1});
        }


    }
}
