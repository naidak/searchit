using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseneKomapnije.Update
{
    public class KandidatSpaseneKompanijeUpdateRequest
    {
        [Required]
        public string kandidat_id { get; set; }

        [Required]
        public string kompanija_id { get; set; }

        [Required]
        public bool Spasen { get; set; }
    }
}
