﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record EmployeeDto(Guid Guid , string Name  , int Age , string position , Guid CompanyId );
    
}
