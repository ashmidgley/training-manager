namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRatingInPlanModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plans", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plans", "Rating", c => c.Int(nullable: false));
        }
    }
}
