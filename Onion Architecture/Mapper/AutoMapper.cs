using AutoMapper;
using Entities.Models;
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
        }
    }
}
