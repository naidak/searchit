using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KandidatSpaseniOglasi.Update
{
    public class KandidatSpaseniOglasiUpdateRequest
    {
        [Required]
        public string kandidat_id { get; set; }

        [Required]
        public int oglas_id { get; set; }
    }
}
