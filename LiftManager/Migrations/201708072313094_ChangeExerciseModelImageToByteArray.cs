namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeExerciseModelImageToByteArray : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exercises", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Image", c => c.String());
        }
    }
}
