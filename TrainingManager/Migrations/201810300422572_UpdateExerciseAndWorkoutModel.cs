namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExerciseAndWorkoutModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Exercises", name: "LifterId", newName: "UserId");
            RenameColumn(table: "dbo.Workouts", name: "LifterId", newName: "UserId");
            RenameIndex(table: "dbo.Exercises", name: "IX_LifterId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Workouts", name: "IX_LifterId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Workouts", name: "IX_UserId", newName: "IX_LifterId");
            RenameIndex(table: "dbo.Exercises", name: "IX_UserId", newName: "IX_LifterId");
            RenameColumn(table: "dbo.Workouts", name: "UserId", newName: "LifterId");
            RenameColumn(table: "dbo.Exercises", name: "UserId", newName: "LifterId");
        }
    }
}
