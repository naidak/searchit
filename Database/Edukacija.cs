using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class Edukacija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NazivSkole { get; set; }

        public DateOnly? DatumPocetka { get; set; }

        public DateOnly? DatumZavrsetka { get; set; }

        public string? Grad { get; set; }

        public string? Opis { get; set; }

        public ICollection<CVEdukacija> CVs { get; set; }
    }
}
