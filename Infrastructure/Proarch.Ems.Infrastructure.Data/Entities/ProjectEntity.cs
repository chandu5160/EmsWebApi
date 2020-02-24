using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class ProjectEntity : Entity
    {
        public string Name { get; set; }

        public int ClientId { get; set; }

        public ClientEntity Client { get; set; }
    }
}
