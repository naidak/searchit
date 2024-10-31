using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KompanijaKandidat.Delete
{
    public class KompanijaKandidatDeleteRequest
    {
        [Required]
        public int kompanija_kandidat_id { get; set; }
    }
}
