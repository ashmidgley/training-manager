namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExerciseAndWorkoutModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "WorkoutId", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "PlanId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "PlanId");
            DropColumn("dbo.Exercises", "WorkoutId");
        }
    }
}
