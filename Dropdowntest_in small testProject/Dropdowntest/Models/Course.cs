using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Dropdowntest.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCredit { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public int DepartmnetID { set; get; }
        public Department Departments { set; get; }
        
    }
}