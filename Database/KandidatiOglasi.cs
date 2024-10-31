using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("KandidatiOglasi")]
    public class KandidatiOglasi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kandidat))]
        public string KandidatId { get; set; }

        public Kandidat Kandidat { get; set; }

        [ForeignKey(nameof(Oglas))]
        public int OglasId { get; set; }

        public Oglas Oglas { get; set; }

        [ForeignKey(nameof(CV))]
        public int CVId { get; set; }

        public CV CV { get; set; }

        [Required]
        public DateTime DatumPrijave { get; set; }

        [Required]
        public string Status { get; set; }

        public bool Spasen { get; set; } = false;
    }
}
