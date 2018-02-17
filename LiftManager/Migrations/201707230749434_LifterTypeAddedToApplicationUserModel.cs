namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LifterTypeAddedToApplicationUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LifterType", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LifterType");
        }
    }
}
