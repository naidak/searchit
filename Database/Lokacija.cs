using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Lokacija")]
    public class Lokacija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public virtual ICollection<OglasLokacija> OglasLokacija { get; set; } = new List<OglasLokacija>();
    }
}
