namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedRatingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        PlanId = c.Int(nullable: false),
                        RaterId = c.String(nullable: false, maxLength: 128),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlanId, t.RaterId })
                .ForeignKey("dbo.Plans", t => t.PlanId)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId, cascadeDelete: true)
                .Index(t => t.PlanId)
                .Index(t => t.RaterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "PlanId", "dbo.Plans");
            DropIndex("dbo.Ratings", new[] { "RaterId" });
            DropIndex("dbo.Ratings", new[] { "PlanId" });
            DropTable("dbo.Ratings");
        }
    }
}
