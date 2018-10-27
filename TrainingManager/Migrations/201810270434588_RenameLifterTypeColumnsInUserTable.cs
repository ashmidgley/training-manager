namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLifterTypeColumnsInUserTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("AspNetUsers", "LifterTypeId", "TrainingTypeId");
            RenameColumn("AspNetUsers", "LifterTypeName", "TrainingTypeName");
        }
        
        public override void Down()
        {
            RenameColumn("AspNetUsers", "TrainingTypeId", "LifterTypeId");
            RenameColumn("AspNetUsers", "TrainingTypeName", "LifterTypeName");
        }
    }
}
