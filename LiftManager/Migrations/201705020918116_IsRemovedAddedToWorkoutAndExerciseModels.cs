namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsRemovedAddedToWorkoutAndExerciseModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Workouts", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "IsRemoved");
            DropColumn("dbo.Exercises", "IsRemoved");
        }
    }
}
