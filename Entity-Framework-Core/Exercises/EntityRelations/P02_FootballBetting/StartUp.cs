using P02_FootballBetting.Data;

namespace P02_FootballBetting
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}