using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Notifikacija.Dodaj
{
    public class NotifikacijaDodajRequest
    {
        [Required]
        public string naziv { get; set; }

        [Required]
        public string vrsta { get; set; }
    }
}
