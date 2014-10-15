using System.Data.Entity;
using FootballLeagueTable.Models.LeagueTable;

namespace FootballLeagueTable.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<MatchHistory> MatchHistories { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}