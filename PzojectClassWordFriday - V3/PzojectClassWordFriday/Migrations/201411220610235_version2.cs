namespace PzojectClassWordFriday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomAllocations",
                c => new
                    {
                        RoomAllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        WeekDays_WeekDayId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomAllocationId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.WeekDays", t => t.WeekDays_WeekDayId)
                .Index(t => t.CourseId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoomId)
                .Index(t => t.WeekDays_WeekDayId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        WeekDayId = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.WeekDayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomAllocations", "WeekDays_WeekDayId", "dbo.WeekDays");
            DropForeignKey("dbo.RoomAllocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAllocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.RoomAllocations", "CourseId", "dbo.Courses");
            DropIndex("dbo.RoomAllocations", new[] { "WeekDays_WeekDayId" });
            DropIndex("dbo.RoomAllocations", new[] { "RoomId" });
            DropIndex("dbo.RoomAllocations", new[] { "DepartmentId" });
            DropIndex("dbo.RoomAllocations", new[] { "CourseId" });
            DropTable("dbo.WeekDays");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomAllocations");
        }
    }
}
