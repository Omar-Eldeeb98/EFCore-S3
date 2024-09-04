using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_S3.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }

        public int Dept_Id { get; set; } // will be the (FK)
        public virtual Department Department { get; set; } // navigational property
    }
}