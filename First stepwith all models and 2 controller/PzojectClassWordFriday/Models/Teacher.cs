using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string ContactNo { get; set; }
        public virtual Designation Designations { get; set; }
        public int DesignationId { get; set; }
        public double TeacherCredit { get; set; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }


    }
}