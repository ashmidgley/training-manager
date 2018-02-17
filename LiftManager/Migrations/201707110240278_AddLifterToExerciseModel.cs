namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLifterToExerciseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "LifterId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Exercises", "LifterId");
            AddForeignKey("dbo.Exercises", "LifterId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "LifterId", "dbo.AspNetUsers");
            DropIndex("dbo.Exercises", new[] { "LifterId" });
            DropColumn("dbo.Exercises", "LifterId");
        }
    }
}
