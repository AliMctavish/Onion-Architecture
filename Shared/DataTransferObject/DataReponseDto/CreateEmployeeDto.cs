using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.DataReponseDto
{
    public record CreateEmployeeDto(string Name , int Age , string Position);
}
