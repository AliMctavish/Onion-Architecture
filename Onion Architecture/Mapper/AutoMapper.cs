using AutoMapper;
using Entities.Models;
using Shared.DataReponseDto;
using Shared.DataTransferObject.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.Address,
            opt => opt.MapFrom(x => string.Join(' ', x.Address,
            x.Country)));

            CreateMap<CreateCompanyDto, Company>();

            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<Employee,EmployeeDto> ();

            //CreateMap<CreateEmployeeDto, EmployeeDto>();
        }
    }
}
