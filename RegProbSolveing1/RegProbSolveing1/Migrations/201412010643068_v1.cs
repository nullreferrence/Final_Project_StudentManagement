namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false),
                        CourseName = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        AssignedTo = c.String(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Semester", t => t.SemesterID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.SemesterID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DeptCode = c.String(nullable: false),
                        DeptName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        StudentName = c.String(nullable: false),
                        Email = c.String(),
                        ContactNo = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.SemesterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "SemesterID", "dbo.Semester");
            DropForeignKey("dbo.Student", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Course", new[] { "SemesterID" });
            DropIndex("dbo.Student", new[] { "DepartmentID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropTable("dbo.Semester");
            DropTable("dbo.Student");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
        }
    }
}
