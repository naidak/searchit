using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Database
{
    public class CVURL
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CV))]
        public int CVId { get; set; }

        public CV CV { get; set; }

        [ForeignKey(nameof(URL))]
        public int URLId { get; set; }

        public URL URL { get; set; }
    }
}
