using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RegProbSolveing1.Models;

namespace RegProbSolveing1.Models
{
    public class RegDbContext:DbContext
    {
        public DbSet<Department> DepartmentDbSet { set; get; }
        public DbSet<Semester> SemesterDbSet { set; get; }
        public DbSet<Course> CourseDbSet { set; get; }
        public DbSet<Student> StudentDbSet { set; get; }


    }
}