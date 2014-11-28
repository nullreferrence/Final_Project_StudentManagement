using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }


        public List<Course> CourseList { get; set; }
        public List<Teacher> TeacherList { get; set; }
        public List<Student> StudentList { get; set; }

        //public List<RoomAllocation> RoomAllocations { get; set; }


    }
}