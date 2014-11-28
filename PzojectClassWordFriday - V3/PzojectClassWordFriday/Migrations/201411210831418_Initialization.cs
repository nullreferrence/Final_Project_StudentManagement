namespace PzojectClassWordFriday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentEmail", c => c.String());
        }
    }
}
