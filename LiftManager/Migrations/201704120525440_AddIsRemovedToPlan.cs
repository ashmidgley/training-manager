namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRemovedToPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "IsRemoved");
        }
    }
}
