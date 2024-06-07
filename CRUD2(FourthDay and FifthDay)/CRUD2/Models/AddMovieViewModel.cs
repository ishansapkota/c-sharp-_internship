using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CRUD2.Models
{
    public class AddMovieViewModel
    {
        [Required]
        public string movieName { get; set; }

        [Required]
        public string genre { get; set; }

        public DateTime releaseDate { get; set; }

        [AllowNull]
        public string actors { get; set; }
    }
}
