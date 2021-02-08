using back.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private IProductRepository _prRepository;
        private ICompanyRepository _cmRepository;
        private IOrderRepository _orRepository;
        public AdminController(IProductRepository prRepository,
            ICompanyRepository cmRepository,
            IOrderRepository orRepository)
        {
            _prRepository = prRepository;
            _cmRepository = cmRepository;
            _orRepository = orRepository;
        }

        [Route("getadmindata")]
        [HttpGet]
        public async Task<IActionResult> GetAdminData()
        {
            var products = await _prRepository.GetProducts();
            var companies = await _cmRepository.GetCompanies();
            var orders = await _orRepository.GetOrders();
            
            return Ok(new { products = products, companies = companies, orders = orders});
        }

    }
}
