namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLifterTypeNameToApplicationUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LifterTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "LifterTypeName", c => c.String());
            DropColumn("dbo.AspNetUsers", "LifterType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LifterType", c => c.Byte(nullable: false));
            DropColumn("dbo.AspNetUsers", "LifterTypeName");
            DropColumn("dbo.AspNetUsers", "LifterTypeId");
        }
    }
}
