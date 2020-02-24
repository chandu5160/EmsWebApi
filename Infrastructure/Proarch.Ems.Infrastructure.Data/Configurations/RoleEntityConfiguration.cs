using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        void IEntityTypeConfiguration<RoleEntity>.Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();

            builder.ToTable("Ems_Role");
        }
    }
}
