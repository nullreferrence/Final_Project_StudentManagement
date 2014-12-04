namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        AllocateClassRoomId = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        RoomsId = c.Int(nullable: false),
                        DaysId = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.AllocateClassRoomId)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.DaysId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .ForeignKey("dbo.Rooms", t => t.RoomsId, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.DaysId)
                .Index(t => t.Department_DepartmentID)
                .Index(t => t.RoomsId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DaysId = c.Int(nullable: false, identity: true),
                        DaysName = c.String(),
                    })
                .PrimaryKey(t => t.DaysId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomsId = c.Int(nullable: false, identity: true),
                        RoomsName = c.String(),
                    })
                .PrimaryKey(t => t.RoomsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateClassRooms", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.AllocateClassRooms", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "DaysId", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "CourseID", "dbo.Courses");
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomsId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "Department_DepartmentID" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DaysId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseID" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Days");
            DropTable("dbo.AllocateClassRooms");
        }
    }
}
