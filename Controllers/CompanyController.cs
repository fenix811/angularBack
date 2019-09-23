using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using back.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
//    [Authorize]
    public class CompanyController : Controller
    {
        private ICompanyRepository _repository;
        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        [Route("api/company/GetCompanies")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            //var result = await _repository.GetCompanies();
            var result = new List<Company>();
            result.Add(new Company() { Id = 1, Name = "Company 1", Address = "address 1" });
            result.Add(new Company() { Id = 2, Name = "Company 2", Address = "address 2" });
            result.Add(new Company() { Id = 3, Name = "Company 3", Address = "address 3" });
            return Ok(result);
        }

    }
}
