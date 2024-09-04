using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_S3.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Grade { get; set; }

        public virtual Student Student { get; set; }  // N.P
        public virtual Course Course { get; set; }  // N.P.
    }
}