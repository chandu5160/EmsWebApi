using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        void IEntityTypeConfiguration<ProjectEntity>.Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Status);
            builder.HasOne(p => p.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientId);
            builder.ToTable("Ems_Project");
        }
    }
}
