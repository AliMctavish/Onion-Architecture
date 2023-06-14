using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Mapster;
using Service.Contracts;
using Shared.DataTransferObject.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
                var employees = _repositoryManager.Employee.GetAllEmployeesAsync(trackChanges).Result.OrderBy(e=>e.Name).ToList();
                var employeesDto = employees.Adapt<List<EmployeeDto>>();
                return employeesDto;
        }

        public EmployeeDto GetEmployee(Guid id,bool trackChanges)
        {
            var employee = _repositoryManager.Employee.GetEmployeeAsync(id, trackChanges);

            if (employee is null)
                throw new EmployeeNotFoundException(id);

            var employeeDto = employee.Adapt<EmployeeDto>();

            return employeeDto;
        }


        public EmployeeDto CreateEmployee(Guid companyId ,CreateEmployeeDto employeeDto , bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);
            
            var employee = employeeDto.Adapt<Employee>();    

            _repositoryManager.Employee.CreateEmployee(companyId,employee);

            _repositoryManager.SaveAsync();

            var result = employee.Adapt<EmployeeDto>();

            return result;
        }
    }
}
