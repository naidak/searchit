using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    public class Uloga
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}
