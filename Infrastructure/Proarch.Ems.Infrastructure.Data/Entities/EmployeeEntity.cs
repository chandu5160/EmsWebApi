using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class EmployeeEntity 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }
       
    }
}
