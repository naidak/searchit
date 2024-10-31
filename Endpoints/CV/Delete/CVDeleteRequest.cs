using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.CV.Delete
{
    public class CVDeleteRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
