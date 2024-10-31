using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    public class URL
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        [Url]
        public string Putanja { get; set; }

        public ICollection<CVURL> CVs { get; set; }
    }
}
