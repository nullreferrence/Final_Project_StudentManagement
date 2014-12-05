using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTest.Models
{
    public class Teacher
    {
        public int TeacherId { set; get; }

        public string TeacherName { set; get; }
        public string TeacherAddress { set; get; }
         [Remote("Check_TeacherEmail", "Teacher", ErrorMessage = "Emal already exists!")]
        public string TeacherEmail { set; get; }
        public virtual Designation ADesignation { set; get; }
        public int DesignationId { set; get; }

        public virtual Department ADepartment { set; get; }
        public int DepartmentId { set; get; }
        public string TeacherCredit { set; get; }
    }
}