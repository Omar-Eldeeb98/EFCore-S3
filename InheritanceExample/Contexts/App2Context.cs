using InheritanceExample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample.Contexts
{
    internal class App2Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---------------------------------------------------------------------------
            // 1 -  TPC way :
            //---------------------------------------------------------------------------
            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");
            //modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");
            //---------------------------------------------------------------------------

            //---------------------------------------------------------------------------
            // 2 - TPH way :
            //---------------------------------------------------------------------------
            //modelBuilder.Entity<FullTimeEmployee>().HasBaseType<Employee>();
            //modelBuilder.Entity<PartTimeEmployee>().HasBaseType<Employee>();
            //---------------------------------------------------------------------------

            //---------------------------------------------------------------------------
            // 3 -  TPCC way :
            //---------------------------------------------------------------------------
            // -
            // -
            // -

            //---------------------------------------------------------------------------

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = App2DB ; Trusted_Connection = True ; TrustServerCertificate = True ");
        }

        //---------------------------------------------------------------------------
        // 1 -  DbSet for TPC way :
        //---------------------------------------------------------------------------
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        // 2 -  DbSet for TPH way :
        //---------------------------------------------------------------------------
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        //---------------------------------------------------------------------------

        //---------------------------------------------------------------------------
        // 3 -  DbSet for TPCC way :
        //---------------------------------------------------------------------------
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

        //public DbSet<Employee> Employees { get; set; }
        //---------------------------------------------------------------------------
    }
}