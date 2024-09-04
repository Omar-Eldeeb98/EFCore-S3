using EFC_Session3.Entities;
using EFCore_S3.Configurations;
using EFCore_S3.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_S3.Contexts
{
    internal class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());

            modelBuilder.Entity<EmployessWorkForDepartments>().ToView("EmployessWorkForDepartments");
            modelBuilder.Entity<EmployessWorkForDepartments>().HasNoKey();

            #region one-to-many (Employee,Department)

            //modelBuilder.Entity<Employee>().HasOne(e => e.Department)
            //    .WithMany(d => d.Employees)
            //    .HasForeignKey(x => x.Dept_Id);

            #endregion one-to-many (Employee,Department)

            #region many-to-many (Student, Course)

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseStudents)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            #endregion many-to-many (Student, Course)

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true); // enable lazy loading by default
            optionsBuilder.UseSqlServer("Server = . ; Database = AppDB; Trusted_Connection = True; TrustServerCertificate = True");
        }

        // Dbsets

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        public DbSet<EmployessWorkForDepartments> EmployessWorkForDepartments { get; set; }
    }
}