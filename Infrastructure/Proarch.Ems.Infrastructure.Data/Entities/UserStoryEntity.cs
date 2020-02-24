using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class UserStoryEntity : Entity
    {
        public string Name { get; set; }

        public bool IsRecurring { get; set; }

        public int DefaultHours { get; set; }

        public int ProjectId { get; set; }

        public ProjectEntity Project { get; set; }
    }
}
