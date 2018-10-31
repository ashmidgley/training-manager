namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "TrainingTypeId");
            DropColumn("dbo.AspNetUsers", "TrainingTypeName");
            AddColumn("dbo.AspNetUsers", "TrainingTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "TrainingTypeName", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LifterTypeName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LifterTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "TrainingTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "TrainingTypeName", c => c.String());
        }
    }
}
