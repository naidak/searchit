using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Endpoints.KandidatOglas.Dodaj
{
    public class KandidatOglasDodajRequest
    {
        [Required]
        public string KandidatId { get; set; }

        [Required]
        public int OglasId { get; set; }

        [Required]
        public int CVId { get; set; }

        [Required]
        public DateTime DatumPrijave { get; set; }
    }
}
