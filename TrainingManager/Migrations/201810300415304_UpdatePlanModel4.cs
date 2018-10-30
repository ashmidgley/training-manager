namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlanModel4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Plans", name: "LifterId", newName: "UserId");
            RenameIndex(table: "dbo.Plans", name: "IX_LifterId", newName: "IX_UserId");
            AddColumn("dbo.Plans", "RatingCount", c => c.Int());
            AlterColumn("dbo.Plans", "Rating", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plans", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Plans", "RatingCount");
            RenameIndex(table: "dbo.Plans", name: "IX_UserId", newName: "IX_LifterId");
            RenameColumn(table: "dbo.Plans", name: "UserId", newName: "LifterId");
        }
    }
}
