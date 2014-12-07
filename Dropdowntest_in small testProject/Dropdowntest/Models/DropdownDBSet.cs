using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dropdowntest.Models
{
    public class DropdownDBSet:DbContext
    {
        public DbSet<Course> CoursesDbset { get; set; }
        public DbSet<Department> DepartmentsDbset { get; set; }
        public DbSet<Teacher> TeachersDcset { get; set; }

        public System.Data.Entity.DbSet<Dropdowntest.Models.CourseAssign> CourseAssigns { get; set; }
    }
}