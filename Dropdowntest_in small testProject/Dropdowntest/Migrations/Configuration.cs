using Dropdowntest.Models;

namespace Dropdowntest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dropdowntest.Models.DropdownDBSet>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dropdowntest.Models.DropdownDBSet context)
        {
            //context.CoursesDbset.AddOrUpdate(x => x.CourseID,
            //    new Course() { CourseID = 1, CourseCode = "CSE101", CourseName = "Algorthm", CourseCredit = "20", DepartmnetID = 1 },
            //    new Course() { CourseID = 2, CourseCode = "CSE201", CourseName = "database", CourseCredit = "40", DepartmnetID = 1 },
            //    new Course() { CourseID = 3, CourseCode = "CSE301", CourseName = "java", CourseCredit = "30", DepartmnetID = 2 }
            //    );

            //context.DepartmentsDbset.AddOrUpdate(x=>x.DepartmentID,
            //    new Department(){DepartmentID =1,DepartmentCode = "CSE",DepartmentName = "Computer"},
            //    new Department() { DepartmentID = 2, DepartmentCode = "BBA", DepartmentName = "Business"},
            //    new Department() { DepartmentID = 3, DepartmentCode = "PHY", DepartmentName = "Physics" }
            //    );

            //context.TeachersDcset.AddOrUpdate(x => x.TeacherID,
            //    new Teacher() { TeacherID = 1, TeacherName = "alom", TeacherCredit = "10" },
            //    new Teacher() { TeacherID = 2, TeacherName = "korim", TeacherCredit = "50" }
            //    );
        }
    }
}
