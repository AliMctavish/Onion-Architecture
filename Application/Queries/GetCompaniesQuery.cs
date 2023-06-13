using Entities.Models;
using MediatR;
using Shared.DataTransferObject.DataRequestDto;

namespace Application.Queries
{
    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
