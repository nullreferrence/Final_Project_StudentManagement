using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTest.Models
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Department> aDepartments { set; get; }
        public DbSet<Semester> aSemesters { set; get; }
        public DbSet<Course> aCourses { set; get; }
        public DbSet<Designation> aDesignations { set; get; }
        public DbSet<Teacher> ATeachers { set; get; }
 
    }
}