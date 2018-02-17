namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageURLAndCommentToExerciseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "ImageURL", c => c.String());
            AddColumn("dbo.Exercises", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Comment");
            DropColumn("dbo.Exercises", "ImageURL");
        }
    }
}
