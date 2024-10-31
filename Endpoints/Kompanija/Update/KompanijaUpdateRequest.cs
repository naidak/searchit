using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Kompanija.Update
{
    public class KompanijaUpdateRequest
    {
        [Required]
        public string Id {  get; set; }  

        public string? Naziv { get; set; }

        public string? Lokacija { get; set; }

        public string? BrojZaposlenih { get; set; }

        public string? Logo{ get; set; }

        public string? Website { get; set; }

        public string? LinkedIn { get; set; }

        public string? Twitter { get; set; }

        public string? KratkiOpis { get; set; }

        public string? Opis { get; set; }
    }
}
