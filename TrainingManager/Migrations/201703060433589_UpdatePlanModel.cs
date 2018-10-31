namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlanModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "DateCreated");
        }
    }
}
