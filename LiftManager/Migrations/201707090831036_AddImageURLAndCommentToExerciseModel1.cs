namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageURLAndCommentToExerciseModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Image", c => c.Binary());
            DropColumn("dbo.Exercises", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "ImageURL", c => c.String());
            DropColumn("dbo.Exercises", "Image");
        }
    }
}
