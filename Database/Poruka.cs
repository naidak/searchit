using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchingWebApp.Database
{
    [Table("Poruke")]
    public class Poruka
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeSlanja { get; set; }
        public bool IsSeen { get; set; }
    }
}
