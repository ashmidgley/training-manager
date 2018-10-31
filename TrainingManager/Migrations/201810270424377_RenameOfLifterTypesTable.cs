namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOfLifterTypesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable("LifterTypes", "TrainingTypes");
        }
        
        public override void Down()
        {
            RenameTable("TrainingTypes", "LifterTypes");
        }
    }
}
