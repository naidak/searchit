using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.Dodaj
{
    public class KompanijaKandidatDodajRequest
    {
        [Required]
        public string kompanija_id { get; set; }

        [Required]
        public string kandidat_id { get; set; }

        [Required]
        public DateTime datum_razgovora { get; set; }
    }
}
