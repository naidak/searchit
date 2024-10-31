using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class CVEdukacija
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CV))]
        public int CVId { get; set; }

        public CV CV { get; set; }

        [ForeignKey(nameof(Edukacija))]
        public int EdukacijaId { get; set; }

        public Edukacija Edukacija { get; set; }
    }
}
