using Contracts;
using Entities.Exceptions;
using Mapster;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var employees = _repositoryManager.Employee.GetAllEmployees(trackChanges).OrderBy(e=>e.Name).ToList();
                var employeesDto = employees.Adapt<List<EmployeeDto>>();
                return employeesDto;
        }

        public EmployeeDto GetEmployee(Guid id,bool trackChanges)
        {
            var employee = _repositoryManager.Employee.GetEmployee(id, trackChanges);

            if (employee is null)
                throw new EmployeeNotFoundException(id);

            var employeeDto = employee.Adapt<EmployeeDto>();

            return employeeDto;
        }

    }
}
