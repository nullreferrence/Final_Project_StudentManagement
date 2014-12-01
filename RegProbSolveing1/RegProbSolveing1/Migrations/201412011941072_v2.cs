namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Course", newName: "Courses");
            RenameTable(name: "dbo.Department", newName: "Departments");
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.Semester", newName: "Semesters");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Semesters", newName: "Semester");
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Departments", newName: "Department");
            RenameTable(name: "dbo.Courses", newName: "Course");
        }
    }
}
