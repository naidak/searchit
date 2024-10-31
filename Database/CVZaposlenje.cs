using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class CVZaposlenje
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CV))]
        public int CVId { get; set; }

        public CV CV { get; set; }

        [ForeignKey(nameof(Zaposlenje))]
        public int ZaposlenjeId { get; set; }

        public Zaposlenje Zaposlenje { get; set; }
    }
}
