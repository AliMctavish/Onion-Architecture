using MediatR;
using Shared.DataTransferObject.DataReponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    internal sealed record UpdateCompanyCommand(Guid id  ,UpdateCompanyDto company , bool trackChanges) : IRequest;
}
