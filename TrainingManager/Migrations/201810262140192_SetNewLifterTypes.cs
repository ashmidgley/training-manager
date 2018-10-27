namespace TrainingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNewLifterTypes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (0, 1, 2, 3, 4, 5 ,6)");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (1, 'Unspecified', 'unspecified.png')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (2, 'Lifter', 'lifter.png')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (3, 'Cardio', 'cardio.png')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (4, 'Balance/flexibility', 'balance-flexibility.png')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM LifterTypes WHERE Id IN (1, 2, 3, 4)");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (0, 'Bodybuilding', 'arnold_grey.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (1, 'Crossfit', 'rich_froning.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (2, 'Weightlifting', 'dmitry_klokov.jpeg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (3, 'Powerlifting', 'brett_gibbs.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (4, 'Cardio', 'usain_bolt.jpg')");
            Sql("INSERT INTO LifterTypes (Id, Name, FileName) VALUES (5, 'Sports/Athletic', 'honey_badger.jpg')");
        }
    }
}
