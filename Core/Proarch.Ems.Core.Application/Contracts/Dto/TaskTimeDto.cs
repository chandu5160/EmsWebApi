using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Contracts.Dto
{
    public class TaskTimeDto
    {
        public int Id { get; set; }

        public int Hours { get; set; }

        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        public int UserStoryId { get; set; }

        public string UserStoryName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}

