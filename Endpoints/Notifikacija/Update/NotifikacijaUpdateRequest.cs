using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Update
{
    public class NotifikacijaUpdateRequest
    {
        [Required]
        public int notifikacija_id { get; set; }

        [Required]
        public string naziv { get; set; }

        [Required]
        public string vrsta { get; set; }
    }
}
