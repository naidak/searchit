using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Update
{
    public class KandidatOglasUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string KandidatId { get; set; }

        [Required]
        public string KompanijaId { get; set; }

        public string? Status { get; set; }

        public bool? Spasen { get; set; }
    }
}
