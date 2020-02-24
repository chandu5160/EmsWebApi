using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configurations
{
    internal class ClientEntityConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        void IEntityTypeConfiguration<ClientEntity>.Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Status);
            builder.ToTable("Ems_client");
        }
    }
}
