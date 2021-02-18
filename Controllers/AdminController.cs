using back.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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

        private IMemoryCache _cache;

        public AdminController(IMemoryCache memoryCache, 
            IProductRepository prRepository,
            ICompanyRepository cmRepository,
            IOrderRepository orRepository)
        {
            _prRepository = prRepository;
            _cmRepository = cmRepository;
            _orRepository = orRepository;
            _cache = memoryCache;
        }

        [Route("getadmindata")]
        [HttpGet]
        public async Task<IActionResult> GetAdminData()
        {
            DateTime cacheEntry;

            if (!_cache.TryGetValue("_Entry", out cacheEntry))
            {
                cacheEntry = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _cache.Set("_Entry", cacheEntry, cacheEntryOptions);
            }

            var products = await _prRepository.GetProducts();
            var companies = await _cmRepository.GetCompanies();
            var orders = await _orRepository.GetOrders();
            
            return Ok(new { products = products, companies = companies, orders = orders});
        }


    }
}
