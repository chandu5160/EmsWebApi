﻿using Microsoft.EntityFrameworkCore;
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
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.HasOne(e => e.Project)
                 .WithMany()
                 .HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Role)
               .WithMany()
               .HasForeignKey(e => e.RoleId);
            builder.Property(e => e.RoleId).HasDefaultValue(1);
            builder.ToTable("Ems_Employee");

        }
    }
}
