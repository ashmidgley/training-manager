namespace LiftManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LiftTypesDBSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LifterTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LifterTypes");
        }
    }
}
