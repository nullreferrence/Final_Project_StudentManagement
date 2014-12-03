using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace ProjectTest.Models
{
    public class Department
    {
        public int DepartmentId { set; get; }


        [Required(ErrorMessage = "Palese Enter Department Name")]
        [Remote("Check_Depname", "Department", ErrorMessage = "Department Name already exists!")]
        public string Name { set; get; }

       [Required (ErrorMessage = "Palese Enter Department Code ")]
       [Remote("Check_DeptCode", "Department", ErrorMessage = "Department Code already exists!")]
        public string Code { set; get; }
        


  }
}