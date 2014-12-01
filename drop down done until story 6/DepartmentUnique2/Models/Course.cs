using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentUnique2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [Remote("Check_CourseCode", "Course", ErrorMessage = "Course code already exists!")]
        public string CourseCode { get; set; }
        public double CourseCredit { get; set; }
        [Required]
        [Remote("Check_CourseName", "Course", ErrorMessage = "Course Name already exists!")]
        public string CourseName { get; set; }
        public string Description { get; set; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }
        public virtual Semister Semisters { get; set; }
        public int SemisterId { get; set; }
    }
}