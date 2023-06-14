using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IMapper _mapper;   
        private readonly IRepositoryManager _repositoryManager;

        public CreateCompanyHandler(IRepositoryManager repository ,  IMapper mapper) 
        {
            _repositoryManager = repository;
            _mapper = mapper;
        }  

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var compayEntity = _mapper.Map<Company>(request.company);

            _repositoryManager.Company.CreateCompany(compayEntity);

            await _repositoryManager.SaveAsync();

            var CompanyResult = _mapper.Map<CompanyDto>(compayEntity);

            return CompanyResult;
        }
    }
}
