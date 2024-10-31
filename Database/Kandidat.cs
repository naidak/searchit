using JobSearchingWebApp.Endpoints.Kandidat.Dodaj;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Kandidati")]
    public class Kandidat : Korisnik
    {
        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters!")]
        [MaxLength(30, ErrorMessage = "First Name must be less than 30 characters!")]
        public string Ime { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters!")]
        [MaxLength(30, ErrorMessage = "Last Name must be less than 30 characters!")]
        public string Prezime { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public string MjestoPrebivalista { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters!")]
        [MaxLength(50, ErrorMessage = "Title must be less than 50 characters!")]
        public string Zvanje { get; set; }
    }
}
