using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PzojectClassWordFriday.Models
{
    public class Semister
    {
        public int SemisterId { get; set; }
        public string SemisterName { get; set; }
        public List<Course> CourseList { get; set; }

    }
}