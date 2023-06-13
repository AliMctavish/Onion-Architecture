using Shared.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICompanyService
    {


        CompanyDto GetCompany(Guid companyId , bool trackChanges);

        CompanyDto CreateCompany(CreateCompanyDto companyDto);


    }
}
