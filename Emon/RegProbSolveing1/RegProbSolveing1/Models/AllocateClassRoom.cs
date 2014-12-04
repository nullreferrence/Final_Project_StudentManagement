using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegProbSolveing1.Models
{
    public class AllocateClassRoom
    {
        public int AllocateClassRoomId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Course Course { get; set; }
        public int CourseID { set; get; }
        public virtual Rooms Rooms { get; set; }
        public int RoomsId { get; set; }
        public virtual Days Days { get; set; }
        public int DaysId { get; set; }

    }
}