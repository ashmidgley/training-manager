namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWorkoutModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Workouts", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
