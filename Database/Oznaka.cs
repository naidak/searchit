using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class Oznaka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}
