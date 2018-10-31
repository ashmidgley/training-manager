namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageTypeInExerciseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Image", c => c.Binary());
        }
    }
}
