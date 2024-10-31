using JobSearchingWebApp.Endpoints.Autentifikacija;
using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kompanija.Dodaj
{
    public class KompanijaDodajRequest : IUserRegistrationRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public int GodinaOsnivanja { get; set; }

        [Required]
        public string Lokacija { get; set; }

        public string? Logo { get; set; }

        [Required]
        public string BrojZaposlenih { get; set; }

        [Required]
        public string KratkiOpis { get; set; }

        [Required]
        public string Opis { get; set; }

        public string? Website { get; set; }

        public string? LinkedIn { get; set; }

        public string? Twitter { get; set; }
    }
}
