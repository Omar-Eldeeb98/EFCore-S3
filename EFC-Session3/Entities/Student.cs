using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_S3.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Course> StudentCourses { get; set; } = new HashSet<Course>();
        // navigtional property

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        // navigtional property
    }
}