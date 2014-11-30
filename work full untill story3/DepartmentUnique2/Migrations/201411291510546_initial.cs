namespace DepartmentUnique2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false),
                        CourseCredit = c.Double(nullable: false),
                        CourseName = c.String(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemisterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semisters", t => t.SemisterId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemisterId);
            
            CreateTable(
                "dbo.Semisters",
                c => new
                    {
                        SemisterId = c.Int(nullable: false, identity: true),
                        SemisterName = c.String(),
                    })
                .PrimaryKey(t => t.SemisterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "SemisterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Semisters");
            DropTable("dbo.Courses");
        }
    }
}
