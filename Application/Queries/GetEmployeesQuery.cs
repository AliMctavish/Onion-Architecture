using MediatR;
using Shared.DataTransferObject.DataRequestDto;

namespace Application.Queries
{
     public sealed record GetEmployeesQuery(bool trackChanges) : IRequest<IEnumerable<EmployeeDto>>;
}
