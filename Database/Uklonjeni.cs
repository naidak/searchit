using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    public class Uklonjeni
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Oznaka))]
        public int OznakaId { get; set; }

        public Oznaka Oznaka { get; set; }

        [Required]
        public DateTime DatumUklanjanja { get; set; }

        [Required]
        public string Razlog { get; set; }
    }
}
