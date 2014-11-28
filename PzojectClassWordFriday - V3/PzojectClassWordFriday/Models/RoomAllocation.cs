using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class RoomAllocation
    {
        public int RoomAllocationId { set; get; }
        public virtual Department Departments { get; set; }
        public int DepartmentId { get; set; }


        public virtual Course Courses { get; set; }
        public int CourseId { get; set; }


        public virtual Room Rooms { get; set; }
        public int RoomId { get; set; }


        public virtual WeekDay WeekDays { get; set; }
        public int DayId { get; set; }
        
      

    }
}