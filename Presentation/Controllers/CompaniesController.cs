using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataReponseDto;
using System.Net.Security;
using Application;
using MediatR;
using Application.Queries;

namespace Onion_Architecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ISender _sender;

        public CompaniesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
                var companies = await _sender.Send(new GetCompaniesQuery(false));

                return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCompany(Guid guid)
        {
            var company = await _sender.Send(new GetCompanyQurey(guid, false));
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CreateCompanyDto createCompany)
        {
            if (createCompany is null)
                return BadRequest("company for creation dto object is null");


            var result = _service.CompanyService.CreateCompany(createCompany);


            return CreatedAtRoute("companyById" , new { id = result.Id } , result );
        }

    }
}
