using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Projekt.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 60 znaków.")]
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Gatunek jest wymagany.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Gatunek musi zaczynać się od wielkiej litery i zawierać tylko litery i spacje.")]
        [StringLength(30, ErrorMessage = "Gatunek może mieć maksymalnie 30 znaków.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reżyser jest wymagany.")]
        [StringLength(60, ErrorMessage = "Nazwa reżysera może mieć maksymalnie 60 znaków.")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Język jest wymagany.")]
        [StringLength(30, ErrorMessage = "Język może mieć maksymalnie 30 znaków.")]
        public string Language { get; set; } = string.Empty;

        [Required(ErrorMessage = "Czas trwania jest wymagany.")]
        [Range(0, 300, ErrorMessage = "Czas trwania musi być mniejszy lub równy 300 minut.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Ocena jest wymagana.")]
        [Range(0, 10, ErrorMessage = "Ocena musi być w zakresie od 0 do 10.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }

        public ICollection<MyRating>? MyRatings { get; set; }
    }
}
