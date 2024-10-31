using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Iskustvo")]
    public class Iskustvo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public virtual ICollection<OglasIskustvo> OglasIskustvo { get; set; } = new List<OglasIskustvo>();
    }
}
