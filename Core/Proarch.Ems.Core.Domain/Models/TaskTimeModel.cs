using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Models
{
    public class TaskTimeModel : Model
    {
        public int Hours { get; set; }

        public string Remarks { get; set; }

        public DateTime Date { get; set; }

        public int UserStoryId { get; set; }
    }
}
