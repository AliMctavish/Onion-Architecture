using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;

namespace Application.Handlers
{
    internal sealed class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery,IEnumerable<EmployeeDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public GetEmployeesHandler(IRepositoryManager repository , IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }    
        public async Task<IEnumerable<EmployeeDto>>  Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.Employee.GetAllEmployeesAsync(request.trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees); 

            return employeesDto;
        }
    }
}
