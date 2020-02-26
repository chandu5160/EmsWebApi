using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class UserStoryEntityConfiguration : IEntityTypeConfiguration<UserStoryEntity>
    {
        void IEntityTypeConfiguration<UserStoryEntity>.Configure(EntityTypeBuilder<UserStoryEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.IsRecurring);
            builder.Property(u => u.DefaultHours).HasColumnType("int");
            builder.HasOne(u => u.Project)
                .WithMany()
                .HasForeignKey(u => u.ProjectId);
            builder.HasOne(u => u.Employee)
                .WithMany()
                .HasForeignKey(u => u.EmployeeId);
            builder.ToTable("Ems_UserStory");
        }
    }
}
