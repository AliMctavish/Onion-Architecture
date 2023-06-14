using Application.Commands;
using Application.Queries;
using MediatR;
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
        private readonly ISender _sender;

        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _sender.Send(new GetEmployeesQuery(false));
            return Ok(employees);
        }

        [HttpGet("{id:guid}" , Name = "employeeById")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _sender.Send(new GetEmployeeQuery(id, false));
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Guid companyId , CreateEmployeeDto createEmployeeDto)
        {
            if (createEmployeeDto is null)
                return BadRequest("please make sure that you are sane !");

            var employee = await _sender.Send(new CreateEmployeeCommand(companyId, createEmployeeDto));

            return Ok(employee);
        }
    }
}
