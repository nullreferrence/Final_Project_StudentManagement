using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegProbSolveing1.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public virtual List<Teacher> Teacher { get; set; }

    }
}