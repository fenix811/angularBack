using back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompanies();
    }
}