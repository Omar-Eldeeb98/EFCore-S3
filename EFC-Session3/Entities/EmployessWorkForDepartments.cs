using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Session3.Entities
{
    public class EmployessWorkForDepartments
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string Employeename { get; set; }
        public string DepartmentName { get; set; }
    }
}