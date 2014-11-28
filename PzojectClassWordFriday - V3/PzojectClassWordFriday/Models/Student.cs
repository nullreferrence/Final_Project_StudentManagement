using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class Student
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
       
        [Required]
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string StudentAddress { get; set; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }
        public string StudentRegNo { get; set; }


    }
}