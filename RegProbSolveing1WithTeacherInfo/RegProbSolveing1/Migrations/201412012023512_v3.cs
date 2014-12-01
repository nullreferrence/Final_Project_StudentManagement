namespace RegProbSolveing1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentID" });
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
        }
    }
}
