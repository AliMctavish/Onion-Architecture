using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _IcompanyRepository;
        private readonly Lazy<IEmployeeRepository> _IemployeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _IcompanyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _IemployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }
        public ICompanyRepository Company => _IcompanyRepository.Value;
       
        public IEmployeeRepository Employee => _IemployeeRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }

}
