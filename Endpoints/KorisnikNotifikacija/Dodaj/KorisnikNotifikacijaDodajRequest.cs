using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Dodaj
{
    public class KorisnikNotifikacijaDodajRequest
    {
        [Required]
        public string korisnik_id { get; set; }

        [Required]
        public int notifikacija_id { get; set; }

        [Required]
        public DateTime datum_primanja { get; set; }

        [Required]
        public bool pogledano { get; set; }
    }
}
