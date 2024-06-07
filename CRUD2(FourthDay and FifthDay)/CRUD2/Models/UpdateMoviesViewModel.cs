using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CRUD2.Models
{
    public class UpdateMoviesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        [AllowNull]
        public string Actors { get; set; }

    }
}
