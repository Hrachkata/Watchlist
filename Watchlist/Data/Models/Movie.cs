
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Constants.MovieConstants;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), MinRatingValue, MaxRatingValue)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [Required]
        public Genre Genre { get; set; }

        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
