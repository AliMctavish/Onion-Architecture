using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataReponseDto;
using System.Net.Security;

namespace Onion_Architecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        
        private readonly IServiceManager _service;


        public CompaniesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
                var companies = _service.CompanyService.GetAllCompanies(trackChanges:false);
                return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "companyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.CompanyService.GetCompany(id , false);
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
