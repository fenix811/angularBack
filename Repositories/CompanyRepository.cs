using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProductContext _ctx;

        public CompanyRepository(ProductContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var result = await _ctx.Companies.ToListAsync<Company>();
            return result;
        }

    }
}
