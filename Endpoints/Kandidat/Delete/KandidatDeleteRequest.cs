using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kandidat.Delete
{
    public class KandidatDeleteRequest
    {
        [Required]
        public string Id { get; set; } 
    }
}
