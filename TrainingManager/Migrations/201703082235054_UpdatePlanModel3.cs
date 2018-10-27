namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlanModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Ranking");
            DropColumn("dbo.Plans", "DateCreated");
        }
    }
}
