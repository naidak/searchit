using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    [Table("KandidatSpaseniOglasi")]
    public class KandidatSpaseniOglasi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kandidat))]
        public string KandidatId { get; set; }

        public virtual Kandidat Kandidat { get; set; }

        [ForeignKey(nameof(Oglas))]
        public int OglasId { get; set; }

        public virtual Oglas Oglas { get; set; }

        [Required]
        public bool Spasen { get; set; }
    }
}
