using Shared.DataTransferObject;
using Shared.DataTransferObject.DataReponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);

        EmployeeDto GetEmployee(Guid id , bool trackChanges);

        EmployeeDto CreateEmployee(Guid companyId ,CreateEmployeeDto employeeDto , bool trackChanges);

    }
}

