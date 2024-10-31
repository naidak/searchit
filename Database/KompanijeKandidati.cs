using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("KompanijeKandidati")]
    public class KompanijeKandidati
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kompanija))]
        public string KompanijaId { get; set; }

        public Kompanija Kompanija { get; set; }

        [ForeignKey(nameof(Kandidat))]
        public string KandidatId { get; set; }

        public Kandidat Kandidat { get; set; }

        [Required]
        public DateTime DatumRazgovora { get; set; }
    }
}
