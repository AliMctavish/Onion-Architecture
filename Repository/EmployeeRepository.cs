using Contracts;
using Entities.Models;
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

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(e => e.Name).ToList();
        }

        public Employee GetEmployee(Guid id, bool trackChanges)
        {
            var employee = FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefault();
            return employee;
        }

        public void CreateEmployee(Guid companyId , Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }



    }
}
