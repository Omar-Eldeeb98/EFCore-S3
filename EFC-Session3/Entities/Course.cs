using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_S3.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public ICollection<Student> CourseStudents { get; set; } = new HashSet<Student>();
        // navigational property

        public virtual ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();
        // navigational property
    }
}