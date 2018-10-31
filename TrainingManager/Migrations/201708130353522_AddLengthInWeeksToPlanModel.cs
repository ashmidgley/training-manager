namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLengthInWeeksToPlanModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "LengthInWeeks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "LengthInWeeks");
        }
    }
}
