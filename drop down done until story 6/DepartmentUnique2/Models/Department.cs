using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentUnique2.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [Remote("Check_DeptName", "Department", ErrorMessage = "Department name already exists!")]
        public string Name { get; set; }
        [Required]
        [Remote("Check_DeptCode", "Department", ErrorMessage = "Department code already exists!")]
        public string  Code { get; set; }

        public virtual List<Course> CourseList { get; set; }
    }
}