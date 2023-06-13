using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery , EmployeeDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public GetEmployeeHandler(IRepositoryManager repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<EmployeeDto> IRequestHandler<GetEmployeeQuery, EmployeeDto>.Handle(Application.Queries.GetEmployeeQuery request, System.Threading.CancellationToken cancellationToken)
        {
            var employee = _repository.Employee.GetEmployeeAsync(request.guid, request.trackChanges);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }
    }
}
