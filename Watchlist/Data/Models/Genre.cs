using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.GenreConstants;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
