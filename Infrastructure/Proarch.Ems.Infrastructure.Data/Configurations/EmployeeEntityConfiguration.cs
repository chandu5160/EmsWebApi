using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        void IEntityTypeConfiguration<EmployeeEntity>.Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EmployeeId).IsRequired();
            builder.HasIndex(e => e.EmployeeId).IsUnique();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.HasOne(e => e.Project)
                 .WithMany()
                 .HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Role)
               .WithMany()
               .HasForeignKey(e => e.RoleId);
            builder.ToTable("Ems_Employee");

        }
    }
}
