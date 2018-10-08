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
    public class CompanyController : Controller
    {
        private ICompanyRepository _repository;
        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await _repository.GetCompanies();
            return Ok(result);
        }

    }
}
