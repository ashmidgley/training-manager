namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateLifterTypes31 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0,1,2,3,4,5)");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (0, 'Unspecified', 'the_rock.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (1, 'Bodybuilding', 'arnold_grey.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (2, 'Crossfit', 'rich_froning.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (3, 'Weightlifting', 'dmitry_klokov.jpeg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (4, 'Powerlifting', 'brett_gibbs.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (5, 'Cardio', 'usain_bolt.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (6, 'Sports/Athletic', 'honey_badger.jpg')");
        }

        public override void Down()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0,1,2,3,4,5,6)");
        }
    }
}
