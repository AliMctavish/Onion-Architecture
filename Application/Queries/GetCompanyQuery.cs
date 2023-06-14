using MediatR;
using Shared.DataTransferObject.DataRequestDto;

namespace Application.Queries
{
    public sealed record GetCompanyQurey(Guid guid,bool trackChanges) :IRequest<CompanyDto>;
}
