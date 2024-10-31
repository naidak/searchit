using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    public class CV
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kandidat))]
        public string KandidatId { get; set; }

        public virtual Kandidat Kandidat { get; set; }

        [Required]
        public bool Objavljen { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Drzava { get; set; }

        public string? Grad { get; set; }

        public string? ProfesionalniSazetak { get; set; }

        public List<string>? Vjestine { get; set; }

        public List<string>? TehnickeVjestine { get; set; }

        public List<string>? Kursevi { get; set; }

        public DateTime DatumModificiranja { get; set; }

        public ICollection<CVEdukacija> Edukacije { get; set; }

        public ICollection<CVZaposlenje> Zaposlenja { get; set; }

        public ICollection<CVURL> URLovi { get; set; }
    }
}
