using System.ComponentModel.DataAnnotations;

namespace MyMoviesAPI
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Tytuł filmu nie może być dłuższy niż 200 znaków.")]
        public string Title { get; set; } = string.Empty;

        [Range(1900,2100)]
        public int Year { get; set; }
    }
}
