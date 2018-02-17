namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RepopulateGenresTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2,3,4,5,6,7,8,9)");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Legs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Shoulders')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Back')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Chest')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Arms')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Full Body')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Cardio')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'HIIT')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Rest')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Custom')");
        }

        public override void Down()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2,3,4,5,6,7,8,9)");
        }
    }
}
