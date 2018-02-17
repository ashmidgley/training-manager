namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateLifterTypes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2)");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (0, 'Bodybuilding Bob', 'arnold_grey.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (1, 'Crossfit Carl', 'rich_froning.jpg')");
        }

        public override void Down()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0,1)");
        }
    }
}
