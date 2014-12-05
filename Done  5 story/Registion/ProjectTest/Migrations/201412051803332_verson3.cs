namespace ProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verson3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allocate_Class_Room", "TimeTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Allocate_Class_Room", "TimeTo");
        }
    }
}
