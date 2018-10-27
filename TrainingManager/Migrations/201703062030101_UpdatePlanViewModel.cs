namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlanViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Ranking");
        }
    }
}
