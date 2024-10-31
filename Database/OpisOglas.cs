using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("OpisOglas")]
    public class OpisOglas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Oglas))]
        public int OglasId { get; set; }

        public Oglas Oglas { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Job Description must be at least 10 characters!")]
        [MaxLength(255, ErrorMessage = "Job Description must be less than 255 characters!")]
        public string OpisPozicije { get; set; }

        [Range(1, 40)]
        public int? MinimumGodinaIskustva { get; set; }

        [Range(1, 40)]
        public int? PrefiraneGodineIskstva { get; set; }

        public string? Kvalifikacija { get; set; }

        public string? Vjestine { get; set; }

        public string? Benefiti { get; set; }
    }
}
