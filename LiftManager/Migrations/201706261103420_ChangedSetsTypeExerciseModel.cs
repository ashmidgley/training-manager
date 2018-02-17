namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSetsTypeExerciseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "Sets", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Sets", c => c.Int(nullable: false));
        }
    }
}
