using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Delete
{
    public class NotifikacijaDeleteRequest
    {
        [Required]
        public int notifikacija_id { get; set; }
    }
}
