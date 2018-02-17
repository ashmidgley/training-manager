namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAllModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "WorkoutId", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "PlanId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "PlanId");
            DropColumn("dbo.Plans", "Ranking");
            DropColumn("dbo.Plans", "DateCreated");
            DropColumn("dbo.Exercises", "WorkoutId");
        }
    }
}
