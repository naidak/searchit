using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    [Table("OglasIskustvo")]
    public class OglasIskustvo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Oglas))]
        public int OglasId { get; set; }

        public Oglas Oglas { get; set; }

        [ForeignKey(nameof(Iskustvo))]
        public int IskustvoId { get; set; }

        public Iskustvo Iskustvo { get; set; }
    }
}
