using System.Data.Entity;

namespace FootballLeagueTable.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FootballLeagueTable.Models.League> Leagues { get; set; }
        public System.Data.Entity.DbSet<FootballLeagueTable.Models.MatchHistory> MatchHistories { get; set; }
        public System.Data.Entity.DbSet<FootballLeagueTable.Models.Team> Teams { get; set; }
    }
}