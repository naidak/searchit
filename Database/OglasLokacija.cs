using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("OglasLokacija")]
    public class OglasLokacija
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Oglas))]
        public int OglasId { get; set; }

        public Oglas Oglas { get; set; }

        [ForeignKey(nameof(Lokacija))]
        public int LokacijaId { get; set; }

        public Lokacija Lokacija { get; set; }
    }
}
