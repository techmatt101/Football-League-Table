using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.Account
{
    public class RegisterView
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]{3,18}$", ErrorMessage = "{0} contains invalid symbols")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}