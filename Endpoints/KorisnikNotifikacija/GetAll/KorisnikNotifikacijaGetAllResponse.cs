using JobSearchingWebApp.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KorisnikNotifikacija.GetAll
{
    public class KorisnikNotifikacijaGetAllResponse
    {
        public List<KorisniciNotifikacijeGetAllResponse> KorisniciNotifikacije { get; set; }
    }

    public class KorisniciNotifikacijeGetAllResponse
    {
        public string KorisnikId { get; set; }

        public int NotifikacijaId { get; set; }

        public DateTime DatumPrimanja { get; set; }

        public bool Pogledano { get; set; }
    }
}
