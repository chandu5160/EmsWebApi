using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class TaskTimeEntity
    {
        public int Id { get; set; }

        public int Hours { get; }

        public string Remarks { get; }

        public DateTime Date { get; }

        public int UserStoryId { get; set; }

        public UserStoryEntity UserStory { get; set; }
    }
}
