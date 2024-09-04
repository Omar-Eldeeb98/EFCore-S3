using DBFirst.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DBFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using NorthwindDBContext northwindDBContext = new NorthwindDBContext();

            // Example01:
            //var res = northwindDBContext.Categories.ToList();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.CategoryName);
            //}
            //Console.WriteLine("\n");

            #region Run SQL Query :

            #region 1 - Select statements : --> FromSqlRaw(), FromSqlInterpolated()

            //Example01:
            //var res = northwindDBContext.Categories.FromSqlRaw("select * from categories");
            //var res = northwindDBContext.Products.FromSqlRaw("select * from products where unitsinstock = 0 ");
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            //Console.WriteLine("------------------------------------------");

            #endregion 1 - Select statements : --> FromSqlRaw(), FromSqlInterpolated()

            #region 2 - DML Statements [insert, update, delete] : --->  ExcuteSqlRaw(), ExcuteSqlInterpolated()

            // Example01:
            //var res = northwindDBContext.Database.ExecuteSqlRaw("update products set unitsinstock = 40 where productid = 1");
            //Console.WriteLine("\n");

            #endregion 2 - DML Statements [insert, update, delete] : --->  ExcuteSqlRaw(), ExcuteSqlInterpolated()

            #endregion Run SQL Query :
        }
    }
}