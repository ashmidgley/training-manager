namespace TrainingManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatePlanModel2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plans", "DateCreated");
            DropColumn("dbo.Plans", "Ranking");
        }

        public override void Down()
        {
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
