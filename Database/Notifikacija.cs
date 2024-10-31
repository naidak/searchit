using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Notifikacije")]
    public class Notifikacija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Vrsta { get; set; }
    }
}
