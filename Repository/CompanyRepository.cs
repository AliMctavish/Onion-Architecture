using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company> , ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
        {
            var result = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return result.ToList();
        }

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
            return company;
        }


        public void CreateCompany(Company company)
        {
            Create(company);
        }
    }
}
