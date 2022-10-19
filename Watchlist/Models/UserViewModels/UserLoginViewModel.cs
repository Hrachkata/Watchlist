using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.UserConstants;

namespace Watchlist.Models.UserViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
