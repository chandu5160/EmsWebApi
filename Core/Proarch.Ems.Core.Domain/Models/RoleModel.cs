using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
  public  class RoleModel :Model
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
