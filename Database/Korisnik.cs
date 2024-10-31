using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobSearchingWebApp.Database
{
    [Table("Korisnici")]
    public class Korisnik : IdentityUser
    {
        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public int UlogaId { get; set; }

        public virtual Uloga Uloga { get; set; }

        public bool IsObrisan { get; set; } = false;
    }
}
