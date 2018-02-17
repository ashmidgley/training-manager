namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRepsTypeExerciseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "Reps", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Reps", c => c.Int(nullable: false));
        }
    }
}
