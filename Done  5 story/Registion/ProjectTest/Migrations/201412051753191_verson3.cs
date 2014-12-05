namespace ProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verson3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allocate_Class_Room",
                c => new
                    {
                        Allocate_Class_RoomID = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        ADepartment_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Allocate_Class_RoomID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.ADepartment_DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.ADepartment_DepartmentId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allocate_Class_Room", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Allocate_Class_Room", "ADepartment_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Allocate_Class_Room", "CourseId", "dbo.Courses");
            DropIndex("dbo.Allocate_Class_Room", new[] { "RoomId" });
            DropIndex("dbo.Allocate_Class_Room", new[] { "ADepartment_DepartmentId" });
            DropIndex("dbo.Allocate_Class_Room", new[] { "CourseId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Allocate_Class_Room");
        }
    }
}
