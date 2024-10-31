using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.CV.UpdateStatus
{
    public class CVUpdateStatusRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string KandidatId { get; set; }

        public bool Objavljen { get; set; }
    }
}
