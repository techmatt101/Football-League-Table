using System.Data.Entity;
using FootballLeagueTable.Models.LeagueTable;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FootballLeagueTable.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class TeamTrackerDb : IdentityDbContext<ApplicationUser>
    {
        public TeamTrackerDb() : base("TeamTrackerDemoDb") {
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<MatchHistory> MatchHistories { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserFollowings> UsersFollowings { get; set; }
    }
}