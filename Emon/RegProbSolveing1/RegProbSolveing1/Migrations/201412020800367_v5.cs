namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeLatters",
                c => new
                    {
                        GradeLatterId = c.Int(nullable: false, identity: true),
                        GradeLatterName = c.String(),
                    })
                .PrimaryKey(t => t.GradeLatterId);
            
            CreateTable(
                "dbo.ResultEntries",
                c => new
                    {
                        ResultEntryId = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        GradeLatterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultEntryId)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.GradeLatters", t => t.GradeLatterId, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.GradeLatterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultEntries", "GradeLatterId", "dbo.GradeLatters");
            DropForeignKey("dbo.ResultEntries", "CourseID", "dbo.Courses");
            DropIndex("dbo.ResultEntries", new[] { "GradeLatterId" });
            DropIndex("dbo.ResultEntries", new[] { "CourseID" });
            DropTable("dbo.ResultEntries");
            DropTable("dbo.GradeLatters");
        }
    }
}
