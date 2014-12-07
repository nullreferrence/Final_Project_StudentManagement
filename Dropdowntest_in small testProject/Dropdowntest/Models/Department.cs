using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropdowntest.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public List<Course> CoursesList { get; set; }

    }
}