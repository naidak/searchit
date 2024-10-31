using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Dodaj
{
    public class KandidatSpaseniOglasiDodajRequest
    {
        [Required]
        public string kandidat_id { get; set; }

        [Required]
        public int oglas_id { get; set; }
    }
}
