namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateLifterTypes2 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0,1,2,3,4,5)");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (0, 'Bodybuilding Bob', 'arnold_grey.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (1, 'Crossfit Colin', 'rich_froning.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (2, 'Weightlifting Will', 'dmitry_klokov.jpeg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (3, 'Powerlifting Paul', 'brett_gibbs.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (4, 'Cardio Carl', 'usain_bolt.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (5, 'Sporty Sam', 'honey_badger.jpg')");
        }

        public override void Down()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0,1,2,3,4,5)");
        }
    }
}
