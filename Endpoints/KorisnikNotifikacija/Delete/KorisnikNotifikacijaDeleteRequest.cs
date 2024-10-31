using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.Delete
{
    public class KorisnikNotifikacijaDeleteRequest
    {
        [Required]
        public int korisnik_notifikacija_id { get; set; }
    }
}
