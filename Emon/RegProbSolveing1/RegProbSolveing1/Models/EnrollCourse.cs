using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegProbSolveing1.Models
{
    public class EnrollCourse
    {
        public int EnrollCourseId { get; set; }

        public virtual Course Course { get; set; }
        public int CourseID { set; get; }
        public DateTime Date { get; set; }


    }
}