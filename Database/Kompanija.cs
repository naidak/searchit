using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Kompanije")]
    public class Kompanija : Korisnik
    {
        [Required]
        [MinLength(3, ErrorMessage = "Company Name must be at least 3 characters!")]
        [MaxLength(30, ErrorMessage = "Company Name must be less than 30 characters!")]
        public string Naziv { get; set; }

        [Required]
        public int GodinaOsnivanja { get; set; }

        [ForeignKey(nameof(Lokacija))]
        public int LokacijaId { get; set; }

        public Lokacija Lokacija { get; set; }

        public byte[]? Logo { get; set; }

        [Required]
        public string BrojZaposlenih { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Short Description must be at least 10 characters!")]
        [MaxLength(150, ErrorMessage = "Short Description must be less than 150 characters!")]
        public string KratkiOpis { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters!")]
        public string Opis { get; set; }

        [Url]
        public string? Website { get; set; }

        [Url]
        public string? LinkedIn { get; set; }

        [Url]
        public string? Twitter { get; set; }

        public virtual ICollection<Oglas> Oglasi { get; set; } = new List<Oglas>();

        public virtual ICollection<KandidatSpaseneKompanije> KandidatSpaseneKompanije { get; set; } = new List<KandidatSpaseneKompanije>();
    }
}
