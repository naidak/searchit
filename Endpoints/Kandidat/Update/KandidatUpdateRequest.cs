using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kandidat.Update
{
    public class KandidatUpdateRequest
    {
        [Required]
        public string Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Username { get; set; }
        public string? MjestoPrebivalista { get; set; }
        public string? Zvanje { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
