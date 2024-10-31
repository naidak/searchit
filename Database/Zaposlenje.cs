using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class Zaposlenje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NazivKompanije { get; set; }

        [Required]
        public string NazivPozicije { get; set; }

        [Required]
        public DateOnly DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Opis { get; set; }

        public ICollection<CVZaposlenje> CVs { get; set; }
    }
}
