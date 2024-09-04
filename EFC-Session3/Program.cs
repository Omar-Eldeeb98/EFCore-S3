using Azure;
using EFCore_S3.Contexts;
using EFCore_S3.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFC_Session3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using AppDbContext appDbContext = new AppDbContext();  // to open the  conection with database

            #region Loading Navigational Property :

            // Note :
            //-------------------------------------------------------------------------//
            // ======> By Default  مش بيحصل loading navigational property <========  //
            //-------------------------------------------------------------------------//

            // Example01 :
            //var emp = appDbContext.Employees.FirstOrDefault(e => e.Id == 3);
            //Console.WriteLine(emp?.Id ?? 0);
            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(emp?.Age ?? 0);
            //Console.WriteLine(emp?.Address ?? "NA");
            //Console.WriteLine(emp?.Dept_Id ?? 0);
            //Console.WriteLine(emp?.Department?.Name ?? "NA");
            //Console.WriteLine("\n");

            // Example02 :
            //var department = appDbContext.Department.FirstOrDefault(d => d.Id == 1);
            //Console.WriteLine(department?.Id ?? 0);
            //Console.WriteLine(department?.Name ?? "NA");
            //Console.WriteLine("\n");

            //-------------------------------------------------------
            // Ways To Loading Navigational Property :
            //-------------------------------------------------------
            // 1 - Explicit Loading
            // 2 - Eager Loading
            // 3 - Lazy Loading [Implicit]
            //-------------------------------------------------------

            #region 1  - Explicit Loading :

            // Example01 :

            //var emp = appDbContext.Employees.FirstOrDefault(e => e.Id == 1);

            //appDbContext.Entry(emp).Reference("Department").Load();  //this command --> make explicit navigational property load

            //Console.WriteLine(emp?.Id ?? 0);
            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(emp?.Age ?? 0);
            //Console.WriteLine(emp?.Address ?? "NA");
            //Console.WriteLine(emp?.Dept_Id ?? 0);
            //Console.WriteLine(emp?.Department?.Name ?? "NA");
            //Console.WriteLine("\n");

            // Example02 :
            //var department = appDbContext.Departments.FirstOrDefault(d => d.Id == 1);

            //appDbContext.Entry(department).Collection(e => e.Employees).Load(); //this command --> make explicit navigational property load

            //Console.WriteLine(department?.Id ?? 0);
            //Console.WriteLine(department?.Name ?? "NA");
            //foreach (var item in department.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("\n");

            #endregion 1  - Explicit Loading :

            #region 2  - Eager Loading :

            // Example01 :
            /* var emp = appDbContext.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == 1);*/  // this command --> make Eager navigational property load
                                                                                                              // - الطرقة دي بتعمل تحميل لل navigational property  مع نفس الريكويست
                                                                                                              // - ممكن اعمل اكنر من include() ورا بعض على الجدول بتاعي

            //Console.WriteLine(emp?.Id ?? 0);
            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(emp?.Age ?? 0);
            //Console.WriteLine(emp?.Address ?? "NA");
            //Console.WriteLine(emp?.Dept_Id ?? 0);
            //Console.WriteLine(emp?.Department?.Name ?? "NA");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("\n");

            // Example02 :
            /* var department = appDbContext.Departments.Include(d => d.Employees).FirstOrDefault(d => d.Id == 1);*/ // this command-- > make Eager navigational property load

            //Console.WriteLine(department?.Id ?? 0);
            //Console.WriteLine(department?.Name ?? "NA");
            //Console.WriteLine("\n");
            //foreach (var item in department.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("\n");

            #endregion 2  - Eager Loading :

            #region 3  - Lazy Loading [Implicit] :

            //---------------------------------------------------------------------
            // Steps -->  to implement navigational propperty (Lazy Loading) :
            //---------------------------------------------------------------------
            // 1 - install package Proxies
            // 2 - use UseLazyLoadingProxies(true) in --->  OnConfiguring(){}
            // 3 -  make all Entities -->  Public
            // 4 - make all the Navigational property --> Virtual
            //---------------------------------------------------------------------

            // Example01 :
            //var emp = appDbContext.Employees.FirstOrDefault(e => e.Id == 1);
            //Console.WriteLine(emp?.Id ?? 0);
            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(emp?.Age ?? 0);
            //Console.WriteLine(emp?.Address ?? "NA");
            //Console.WriteLine(emp?.Dept_Id ?? 0);
            //Console.WriteLine(emp?.Department?.Name ?? "NA");
            //Console.WriteLine("---------------------");
            //Console.WriteLine("\n");

            // Example02 :
            //var department = appDbContext.Departments.FirstOrDefault(d => d.Id == 1);
            //Console.WriteLine(department?.Id ?? 0);
            //Console.WriteLine(department?.Name ?? "NA");
            //Console.WriteLine("\n");

            //foreach (var item in department.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion 3  - Lazy Loading [Implicit] :

            #endregion Loading Navigational Property :

            #region LINQ -  Join Operator :

            // Example01
            //fluent syntax
            //var res = appDbContext.Employees
            //     .Join(appDbContext.Departments,
            //     e => e.Dept_Id,
            //     d => d.Id,
            //     (e, d) => new
            //     {
            //         EmpId = e.Id,
            //         EmpName = e.Name,
            //         DeptId = d.Id,
            //         DeptName = d.Name
            //     }
            //     );
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\n");

            #endregion LINQ -  Join Operator :

            #region Tracking vs NoTracking:

            // ---> ازاي اخلى ال context يحس بالتغيرات اللي بتحصل على الجداول ولا لاء
            // Tracking ---> Default behaviour
            // to stop Tracking --> use AsNoTracking() function

            // Example01
            //var emp = appDbContext.Employees.AsNoTracking<Employee>().FirstOrDefault(e => e.Id == 2);
            //Console.WriteLine(emp?.Name ?? "NA"); // OMAR
            //Console.WriteLine(appDbContext.Entry(emp).State); //Detached

            #endregion Tracking vs NoTracking:

            #region Local vs Remote :

            // Example01 :
            //appDbContext.Employees.Load();
            // - هتعمل تحميل للداتا بتاعت الموظفين مره واحده بس وتخزنه عندي في الميموري و اي عمليات عليه هتكون لوكال  مش هيضطر يروح يكلم الداتا بيز

            //appDbContext.Employees.Local.Any();

            #endregion Local vs Remote :

            #region Mapping View:

            //var res = appDbContext.EmployessWorkForDepartments
            //    .FromSqlRaw("select * from EmployessWorkForDepartments");

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Employeename);
            //}

            #endregion Mapping View:
        }
    }
}