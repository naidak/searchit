using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("PorukeKorisnici")]
    public class PorukaKorisnik
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public string KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        [ForeignKey(nameof(Poruka))]
        public int PorukaId { get; set; }
        public virtual Poruka Poruka { get; set; }
        public bool isPrimljena { get; set; }
        public string PosiljalacId { get; set; }
        public virtual Korisnik Posiljalac { get; set; }

    }
}
