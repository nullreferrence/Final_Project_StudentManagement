using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTest.Models
{
    public class Course
    {
        public int CourseId { set; get; }
          [Remote("Check_CourseCode", "CourseEntry", ErrorMessage = "Course Code already exists!")]
        public string CourseCode { set; get; }
        public string CourseCredit { set; get; }
          [Remote("Check_Coursname", "CourseEntry", ErrorMessage = "Course  Name already exists!")]
        public string CourseName { set; get; }

        public string Description { set; get; }

        public virtual Department Departments { set; get; }
        public int DepartmentId { get; set; }
        public virtual Semester Semesters { set; get; }
        public int SemesterId { set; get; }




    }
}