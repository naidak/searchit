using JobSearchingWebApp.Endpoints.Autentifikacija;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kandidat.Dodaj
{
    public class KandidatDodajRequest : IUserRegistrationRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public string MjestoPrebivalista { get; set; }

        [Required]
        public string Zvanje { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }


    public class KandidatWrapper
    {
        public KandidatDodajRequest Kandidat { get; set; }
    }
}
