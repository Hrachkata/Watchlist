using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.UserConstants;

namespace Watchlist.Models.UserViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords don't match.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
