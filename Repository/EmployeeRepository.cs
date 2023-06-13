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
    public class EmployeeRepository : RepositoryBase<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        } 

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges)
        {
            var result = await FindAll(trackChanges).OrderBy(e => e.Name).ToListAsync();
            return result;
        }

        public async Task<Employee> GetEmployeeAsync(Guid id, bool trackChanges)
        {
            var employee = await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return employee;
        }

        public void CreateEmployee(Guid companyId , Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }
    }
}
