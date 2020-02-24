using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class RoleEntity :Entity
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
