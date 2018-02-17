namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAllModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exercises", "WorkoutId");
            DropColumn("dbo.Plans", "DateCreated");
            DropColumn("dbo.Plans", "Ranking");
            DropColumn("dbo.Workouts", "PlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "PlanId", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "Ranking", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Exercises", "WorkoutId", c => c.Int(nullable: false));
        }
    }
}
