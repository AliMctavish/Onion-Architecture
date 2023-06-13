using Entities.Models;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public sealed record GetCompanyQurey(Guid guid,bool trackChanges) :IRequest<CompanyDto>;
}
