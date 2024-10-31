using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseneKomapnije.Dodaj
{
    public class KandidatSpaseneKompanijeDodajRequest
    {
        [Required]
        public string kandidat_id { get; set; }

        [Required]  
        public string kompanija_id { get; set; }
    }
}
