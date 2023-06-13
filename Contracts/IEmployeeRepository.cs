using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
       Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);
       Task<Employee> GetEmployeeAsync(Guid id , bool trackChanges);
        void CreateEmployee(Guid companyId , Employee employee);
    }
}
