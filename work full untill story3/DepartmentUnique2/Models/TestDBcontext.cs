using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DepartmentUnique2.Models
{
    public class TestDBcontext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> CourseDbSet { get; set; }
        public DbSet<Semister> SemisterDbSet { get; set; }
        public DbSet<Teacher> TeacherDbSet { get; set; }
        public DbSet<Designation> DesignationDbSet { get; set; }
        //public DbSet<Student> StudentDbSet { get; set; }
    }
}