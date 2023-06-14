using MediatR;
using Shared.DataTransferObject.DataRequestDto;

namespace Application.Queries
{
    public sealed record GetEmployeeQuery(Guid guid , bool trackChanges) : IRequest<EmployeeDto>;
}
