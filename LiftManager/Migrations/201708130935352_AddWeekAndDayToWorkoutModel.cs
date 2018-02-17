namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekAndDayToWorkoutModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Week", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "Day");
            DropColumn("dbo.Workouts", "Week");
        }
    }
}
