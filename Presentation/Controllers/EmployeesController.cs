using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.DataReponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion_Architecture.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IServiceManager _serviceManager;

        public EmployeesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _serviceManager.EmployeeService.GetAllEmployees(false);
            return Ok(employees);
        }

        [HttpGet("{id:guid}" , Name = "employeeById")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _serviceManager.EmployeeService.GetEmployee(id, false);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Guid companyId , CreateEmployeeDto createEmployeeDto)
        {
            if (createEmployeeDto is null)
                return BadRequest("please make sure that you are sane !");

            _serviceManager.EmployeeService.CreateEmployee(companyId, createEmployeeDto, false);

            return Ok();
        }
    }
}
