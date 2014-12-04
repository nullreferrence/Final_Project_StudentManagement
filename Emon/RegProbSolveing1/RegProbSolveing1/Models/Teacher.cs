using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegProbSolveing1.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { set; get; }
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }


    }
}