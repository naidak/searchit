using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Delete
{
    public class KandidatOglasDeleteRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
