using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Oglasi")]
    public class Oglas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kompanija))]
        public string KompanijaId { get; set; }

        public Kompanija Kompanija { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Job Title must be at least 3 characters!")]
        [MaxLength(30, ErrorMessage = "Job Title must be less than 30 characters!")]
        public string NazivPozicije { get; set; }

        [Required]
        public DateTime DatumObjave { get; set; }

        [Required]
        public string Plata { get; set; }

        [Required]
        public string TipPosla { get; set; }

        [Required]
        public DateTime RokPrijave { get; set; }

        public DateTime? DatumModificiranja { get; set; }

        public bool Otvoren => RokPrijave > DateTime.Now;

        public bool? Objavljen { get; set; }

        public bool IsObrisan { get; set; } = false;

        public virtual OpisOglas OpisOglas { get; set; }    

        public virtual ICollection<OglasLokacija> OglasLokacija { get; set; } = new List<OglasLokacija>();

        public virtual ICollection<OglasIskustvo> OglasIskustvo { get; set; } = new List<OglasIskustvo>();

        public virtual ICollection<KandidatSpaseniOglasi> KandidatSpaseniOglasi { get; set; } = new List<KandidatSpaseniOglasi>();
    }
}
