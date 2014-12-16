using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.Account
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}