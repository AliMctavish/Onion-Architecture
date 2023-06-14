using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.DataReponseDto
{
    public record UpdateCompanyDto(string Name, string Address, string Country);
}
