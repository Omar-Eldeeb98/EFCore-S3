using InheritanceExample.Contexts;
using InheritanceExample.Entities;

namespace InheritanceExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //----------------> الطرق اللي بستخدمها عشان اعمل سكيمة لما بيكون عندي فيه وراثة بين الجداول وبعضها <-----------------//

            using App2Context app2Context = new App2Context();

            #region 1 - [TPC] ---> Table Per Class

            // - by default if  there is no  inheritance , EFCore bydefault use (TPC) Way To generate Schema

            // Example01
            //FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            //{
            //    Name = "Omar",
            //    Adress = "Cairo",
            //    Email = "omar@gmail.com",
            //    Salary = 7000
            //};
            //app2Context.FullTimeEmployees.Add(fullTimeEmployee);
            //app2Context.SaveChanges();

            ////Example02
            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            //{
            //    Name = "John",
            //    Adress = "New York",
            //    Email = "John@gmail.com",
            //    NumberOfHours = 40,
            //    HourRate = 10.50
            //};
            //app2Context.PartTimeEmployees.Add(partTimeEmployee);
            //app2Context.SaveChanges();

            #endregion 1 - [TPC] ---> Table Per Class

            #region 2 - [TPH] ---> Table Per Hireracy

            // - by default if  there is a  inheritance , EFCore bydefault use (TPH) Way To generate Schema
            //  - in our case EFCore Will Create one table

            // Exmaple01
            //FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            //{
            //    Name = "Mark",
            //    Adress = "London",
            //    Email = "Mark@gmail.com",
            //    Salary = 12000
            //};

            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            //{
            //    Name = "Omar",
            //    Adress = "Egypt",
            //    Email = "Omar@gmail.com",
            //    NumberOfHours = 40,
            //    HourRate = 10.50
            //};
            //app2Context.Employees.Add(fullTimeEmployee);
            //app2Context.Employees.Add(partTimeEmployee);
            //app2Context.SaveChanges();

            // Example02
            //var res = app2Context.Employees.OfType<PartTimeEmployee>();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Name);  //Omar
            //}
            //Console.WriteLine("\n");

            #endregion 2 - [TPH] ---> Table Per Hireracy

            #region 3 - [TPCC] ---> Table Per Concret Class

            //Exmaple01
            //FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            //{
            //    Name = "Mark",
            //    Adress = "London",
            //    Email = "Mark@gmail.com",
            //    Salary = 12000
            //};

            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            //{
            //    Name = "Omar",
            //    Adress = "Egypt",
            //    Email = "Omar@gmail.com",
            //    NumberOfHours = 40,
            //    HourRate = 10.50
            //};

            //app2Context.FullTimeEmployees.Add(fullTimeEmployee);
            //app2Context.PartTimeEmployees.Add(partTimeEmployee);
            //app2Context.SaveChanges();

            #endregion 3 - [TPCC] ---> Table Per Concret Class
        }
    }
}