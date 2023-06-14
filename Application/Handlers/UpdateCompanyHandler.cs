using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public UpdateCompanyHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken
    cancellationToken)
        {
            var companyEntity = await
            _repository.Company.GetCompanyAsync(request.id, request.trackChanges);
            if (companyEntity is null)
                throw new CompanyNotFoundException(request.id);
            _mapper.Map(request.company, companyEntity);
            await _repository.SaveAsync();
            return Unit.Value;

        }
    }
}
