using System;

namespace Proarch.Ems.Infrastructure.Data.Entities
{
    public class TaskTimeEntity
    {
        public int Id { get; set; }

        public int Hours { get; set; }

        public string Remarks { get; set; }

        public DateTime Date { get; set; }

        public int UserStoryId { get; set; }

        public UserStoryEntity UserStory { get; set; }
    }
}
