namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanModelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plans", "Rating", c => c.Double(nullable: false));
            AlterColumn("dbo.Plans", "RatingCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plans", "RatingCount", c => c.Int());
            AlterColumn("dbo.Plans", "Rating", c => c.Double());
        }
    }
}
