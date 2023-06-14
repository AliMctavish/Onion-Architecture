using MediatR;
using Shared.DataTransferObject.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public sealed record CreateEmployeeCommand(Guid CompanyId,CreateEmployeeDto createEmployee) : IRequest<EmployeeDto>;
}
