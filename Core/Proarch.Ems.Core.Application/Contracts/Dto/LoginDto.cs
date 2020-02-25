using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Contracts.Dto
{
    public class LoginDto
    {
        public int EmployeeId { get; set; }

        public string Password { get; set; }
    }
}
