namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRankingFromPlanModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plans", "Ranking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
        }
    }
}
