using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class EmployeeModel 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
    }
}
