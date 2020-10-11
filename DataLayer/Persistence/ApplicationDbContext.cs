using DataLayer.Models.Persons;
using DataLayer.Models.Users;
using DataLayer.Models.Works;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.State == Enums.SharedStateEnum.Active);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<TaskW> TaskWs { get; set; }
        public DbSet<TaskWork> TaskWork { get; set; }


    }
}
