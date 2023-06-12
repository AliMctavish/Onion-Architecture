using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;
using System.Collections;

namespace Application.Handlers
{
    internal sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCompaniesHandler(IRepositoryManager repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request,
        CancellationToken cancellationToken)
        {
            //var companies = await _repository.Company
            throw new NotImplementedException();
        }
    }
}
