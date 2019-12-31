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
            var result = await _repository.GetCompanies();
            return Ok(result);
        }

    }
}
