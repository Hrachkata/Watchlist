using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static Watchlist.Constants.UserConstants;


namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();

    }
}
