using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballLeagueTable.Models.LeagueTable;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FootballLeagueTable.Models.Account
{
    public class UserAccount : IdentityUser
    {
        [Required]
        public int UserFollowingsId { get; set; }

        [ForeignKey("UserFollowingsId")]
        public virtual UserFollowings UserFollowings { get; set; }
    }
}