using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObject.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IMapper _mapper;   
        private readonly IRepositoryManager _repositoryManager; 

        public CreateEmployeeHandler(IRepositoryManager repository , IMapper mapper) 
        { 
            _repositoryManager = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empoyeeEntity = _mapper.Map<Employee>(request.createEmployee);

            _repositoryManager.Employee.CreateEmployee(request.CompanyId , empoyeeEntity);

            await _repositoryManager.SaveAsync();

            var employeeResult = _mapper.Map<EmployeeDto>(empoyeeEntity);

            return employeeResult;
        }
    }
}
