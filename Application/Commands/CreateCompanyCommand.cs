using MediatR;
using Shared.DataReponseDto;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public sealed record CreateCompanyCommand(CreateCompanyDto company) : IRequest<CompanyDto>;
}
