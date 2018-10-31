namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeExerciseModelImageToByteArray1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Image");
        }
    }
}
