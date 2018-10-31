namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavourites2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourites", "SelectedUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Favourites", new[] { "SelectedUser_Id" });
            RenameColumn(table: "dbo.Favourites", name: "SelectedUser_Id", newName: "FavouriterId");
            DropPrimaryKey("dbo.Favourites");
            AlterColumn("dbo.Favourites", "FavouriterId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Favourites", new[] { "PlanId", "FavouriterId" });
            CreateIndex("dbo.Favourites", "FavouriterId");
            AddForeignKey("dbo.Favourites", "FavouriterId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Favourites", "FavouriteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favourites", "FavouriteId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Favourites", "FavouriterId", "dbo.AspNetUsers");
            DropIndex("dbo.Favourites", new[] { "FavouriterId" });
            DropPrimaryKey("dbo.Favourites");
            AlterColumn("dbo.Favourites", "FavouriterId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Favourites", new[] { "PlanId", "FavouriteId" });
            RenameColumn(table: "dbo.Favourites", name: "FavouriterId", newName: "SelectedUser_Id");
            CreateIndex("dbo.Favourites", "SelectedUser_Id");
            AddForeignKey("dbo.Favourites", "SelectedUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
