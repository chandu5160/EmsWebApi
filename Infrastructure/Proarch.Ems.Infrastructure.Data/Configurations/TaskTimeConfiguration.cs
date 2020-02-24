using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class TaskTimeConfiguration : IEntityTypeConfiguration<TaskTimeEntity>
    {
        void IEntityTypeConfiguration<TaskTimeEntity>.Configure(EntityTypeBuilder<TaskTimeEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Remarks).IsRequired();
            builder.Property(t => t.Hours).IsRequired().HasColumnType("int");
            builder.Property(t => t.Date).IsRequired().HasColumnType("DateTime");
            builder.HasOne(t => t.UserStory)
               .WithMany()
               .HasForeignKey(t => t.UserStoryId);
            builder.ToTable("Ems_TaskTime");
        }
    }
}
