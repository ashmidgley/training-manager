namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkoutModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Workouts", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Description", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Workouts", "Name");
        }
    }
}
