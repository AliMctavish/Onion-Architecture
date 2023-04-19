using Contracts;
using Entities.Models;
using Service.Contracts;
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

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            try
            {
                var employees = _repositoryManager.Employee.GetAllEmployees(trackChanges).OrderBy(e=>e.Name).ToList();
                return employees;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"something went wrong while excuting {GetAllEmployees} service method {ex}");
                throw;
            }
        }

    }
}
