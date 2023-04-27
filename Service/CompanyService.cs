using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Mapster;
using Service.Contracts;
using Shared.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    { 
        private readonly IRepositoryManager _repositoryManager;   
        private readonly ILoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repositoryManager , ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
                var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
                var companyDto = companies.Adapt<List<CompanyDto>>();
                return companyDto;
        }

        public CompanyDto GetCompany(Guid companyId ,bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId , trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var companyDto = company.Adapt<CompanyDto>();
            return companyDto;
        }
        public CompanyDto CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var createCompany = createCompanyDto.Adapt<Company>();

            _repositoryManager.Company.CreateCompany(createCompany);

            _repositoryManager.Save();

            var mappedResult = createCompany.Adapt<CompanyDto>();

            return mappedResult;
        }
    }
}

