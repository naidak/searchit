using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kompanija.Delete
{
    public class KompanijaDeleteRequest
    {
        [Required]
        public string Id { get; set; } 
    }
}
