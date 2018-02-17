namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Chest')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Back')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Legs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Shoulders')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Arms')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Custom')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Cardio')");
        }

        public override void Down()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2,3,4,5,6,7)");
        }
    }
}
