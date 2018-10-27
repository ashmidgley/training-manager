namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        LifterId = c.String(nullable: false, maxLength: 128),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LifterId, cascadeDelete: true)
                .Index(t => t.LifterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "LifterId", "dbo.AspNetUsers");
            DropIndex("dbo.Plans", new[] { "LifterId" });
            DropTable("dbo.Plans");
        }
    }
}
