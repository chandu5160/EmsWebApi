using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
   public class UserStoryModel : Model
    {
        public string Name { get; set; }

        public bool IsRecurring { get; set; }

        public int DefaultHours { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public void AddHours(int hours)
        {
            DefaultHours = hours;
        }
    }
}
