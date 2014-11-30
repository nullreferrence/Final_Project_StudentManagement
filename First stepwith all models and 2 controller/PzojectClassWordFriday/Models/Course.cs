using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public double CourseCredit { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }
        public virtual Semister Semisters { get; set; }
        public int SemisterId { get; set; }



    }
}