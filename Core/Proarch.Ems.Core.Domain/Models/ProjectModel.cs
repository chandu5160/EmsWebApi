using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class ProjectModel : Model
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
    }
}
