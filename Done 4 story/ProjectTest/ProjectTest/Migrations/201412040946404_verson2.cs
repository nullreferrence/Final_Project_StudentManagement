namespace ProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verson2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Contract_Number = c.String(),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Registrations", new[] { "DepartmentId" });
            DropTable("dbo.Registrations");
        }
    }
}
