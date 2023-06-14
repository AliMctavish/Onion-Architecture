using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class GetCompanyHandler : IRequestHandler<GetCompanyQurey, CompanyDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public GetCompanyHandler(IRepositoryManager repository , IMapper mapper) 
        {
            _repository = repository; 
            _mapper = mapper;
        }
        
        async Task<CompanyDto> IRequestHandler<GetCompanyQurey, CompanyDto>.Handle(GetCompanyQurey request, CancellationToken cancellationToken)
        {
            var company= await _repository.Company.GetCompanyAsync(request.guid, request.trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(request.guid);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}
