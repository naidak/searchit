using System.ComponentModel.DataAnnotations;

namespace JobSearchingWebApp.Endpoints.Autentifikacija
{
    public class RegistracijaRequest : IUserRegistrationRequest
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UlogaRequest { get; set; }
    }
}
