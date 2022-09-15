using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }
        // Be careful! Some of problems dont define clearly the name of the DbSet, usually "DbSet<Homework> Homeworks" , but not this time!!!!
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; } // Error ->'StudentSystemContext' does not contain a definition for 'HomeworkSubmissions'
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; } //Error ->'StudentSystemContext' does not contain a definition for 'StudentCourses'


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(e => 
            {
                e.HasKey(x => new { x.StudentId, x.CourseId }); // composite PK
            });
                        
                
        }
    }
}
