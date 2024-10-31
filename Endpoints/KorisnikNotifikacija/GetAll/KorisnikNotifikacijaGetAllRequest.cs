using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.GetAll
{
    public class KorisnikNotifikacijaGetAllRequest
    {
        public string? korisnik_id { get; set; }

        public int? notifikacija_id { get; set; }

        public DateTime? datum_primanja { get; set; }

        public bool? pogledano { get; set; }
    }
}
