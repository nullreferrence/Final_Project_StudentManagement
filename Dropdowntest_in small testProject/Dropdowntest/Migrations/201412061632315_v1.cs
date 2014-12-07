namespace Dropdowntest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseCredit = c.String(),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        DepartmnetID = c.Int(nullable: false),
                        Departments_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.Departments_DepartmentID)
                .Index(t => t.Departments_DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        TeacherCredit = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Departments_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Departments_DepartmentID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
