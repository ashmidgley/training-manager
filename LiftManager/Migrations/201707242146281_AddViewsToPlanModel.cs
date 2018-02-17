namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewsToPlanModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Views");
        }
    }
}
