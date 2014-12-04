namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollCourses",
                c => new
                    {
                        EnrollCourseId = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.EnrollCourses", new[] { "CourseID" });
            DropTable("dbo.EnrollCourses");
        }
    }
}
