using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentUnique2.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        [Required]
        [Remote("Check_EmailAddress", "Teacher", ErrorMessage = "This Email Address already exists!")]
        public string TeacherEmail { get; set; }
        public string ContactNo { get; set; }
        public virtual Designation Designations { get; set; }
        public int DesignationId { get; set; }
        public double TeacherCredit { get; set; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }


    }
}