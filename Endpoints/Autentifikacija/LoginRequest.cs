using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Autentifikacija
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
