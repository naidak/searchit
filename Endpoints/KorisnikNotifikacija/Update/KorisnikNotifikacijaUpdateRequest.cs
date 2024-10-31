using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Update
{
    public class KorisnikNotifikacijaUpdateRequest
    {
        [Required]
        public int korisnik_notifikacija_id { get; set; }

        [Required]
        public bool pogledano { get; set; }
    }
}
