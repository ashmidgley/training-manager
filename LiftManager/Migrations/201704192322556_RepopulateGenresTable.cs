namespace LiftManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RepopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2,3,4,5,6,7)");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Legs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Shoulders/Abs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Back/Abs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Chest/Calves')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Traps, Arms & Abs')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Cardio')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'HIIT')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Rest')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Custom')");
        }

        public override void Down()
        {
            Sql("DELETE FROM  Genres WHERE Id IN (1,2,3,4,5,6,7,8,9)");
        }
    }
}
