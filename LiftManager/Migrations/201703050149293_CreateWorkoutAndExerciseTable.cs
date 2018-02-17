namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateWorkoutAndExerciseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Reps = c.Int(nullable: false),
                        Sets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LifterId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LifterId, cascadeDelete: true)
                .Index(t => t.LifterId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "LifterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Workouts", "GenreId", "dbo.Genres");
            DropIndex("dbo.Workouts", new[] { "GenreId" });
            DropIndex("dbo.Workouts", new[] { "LifterId" });
            DropTable("dbo.Workouts");
            DropTable("dbo.Genres");
            DropTable("dbo.Exercises");
        }
    }
}
