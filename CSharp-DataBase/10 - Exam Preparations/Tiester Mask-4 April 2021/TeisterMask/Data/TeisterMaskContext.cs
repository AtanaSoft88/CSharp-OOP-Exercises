﻿namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Composite PK in Fluent API
            modelBuilder.Entity<EmployeeTask>(e=>
            {
                e.HasKey(et => new 
                {
                    et.TaskId,
                    et.EmployeeId
                });
            });
        }
    }
}