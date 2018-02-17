namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavourites1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourites", "PlanId", "dbo.Plans");
            AddForeignKey("dbo.Favourites", "PlanId", "dbo.Plans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "PlanId", "dbo.Plans");
            AddForeignKey("dbo.Favourites", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
    }
}
