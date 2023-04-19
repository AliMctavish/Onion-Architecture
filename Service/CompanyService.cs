using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Service.Contracts;

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

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
                return companies;
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"something went wrong with {nameof(GetAllCompanies)} service method {ex}" );
                throw;
            }
        }
    }
}
