namespace Dropdowntest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        CourseAssignID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: false)
                .Index(t => t.DepartmentID)
                .Index(t => t.CourseID)
                .Index(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssigns", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssigns", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.CourseAssigns", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseAssigns", new[] { "TeacherID" });
            DropIndex("dbo.CourseAssigns", new[] { "CourseID" });
            DropIndex("dbo.CourseAssigns", new[] { "DepartmentID" });
            DropTable("dbo.CourseAssigns");
        }
    }
}
