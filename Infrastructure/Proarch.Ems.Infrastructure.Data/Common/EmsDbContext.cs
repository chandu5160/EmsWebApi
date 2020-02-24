using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Infrastructure.Data.Configurations;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Common
{
    public class EmsDbContext : DbContext
    {
        public EmsDbContext(DbContextOptions<EmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientEntity> Client { get; set; }

        public DbSet<ProjectEntity> Project { get; set; }

        public DbSet<TaskTimeEntity> TaskTime { get; set; }

        public DbSet<UserStoryEntity> UserStorie { get; set; }
        public DbSet<EmployeeEntity> Employee { get; set; }

        public DbSet<RoleEntity> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());

            modelBuilder.ApplyConfiguration(new UserStoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new TaskTimeConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());

            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());

        }
    }
}
