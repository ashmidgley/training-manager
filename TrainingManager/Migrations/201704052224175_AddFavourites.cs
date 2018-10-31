namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        PlanId = c.Int(nullable: false),
                        FavouriteId = c.String(nullable: false, maxLength: 128),
                        SelectedUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PlanId, t.FavouriteId })
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SelectedUser_Id)
                .Index(t => t.PlanId)
                .Index(t => t.SelectedUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "SelectedUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favourites", "PlanId", "dbo.Plans");
            DropIndex("dbo.Favourites", new[] { "SelectedUser_Id" });
            DropIndex("dbo.Favourites", new[] { "PlanId" });
            DropTable("dbo.Favourites");
        }
    }
}
