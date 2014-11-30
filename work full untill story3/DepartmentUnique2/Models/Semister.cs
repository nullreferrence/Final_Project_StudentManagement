using System.Collections.Generic;

namespace DepartmentUnique2.Models
{
    public class Semister
    {
        public int SemisterId { get; set; }
        public string SemisterName { get; set; }
        public virtual List<Course> CourseList { get; set; }
    }
}